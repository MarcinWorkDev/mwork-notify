let admin = require('firebase-admin');
let AWS = require("aws-sdk");

let dbClient = new AWS.DynamoDB.DocumentClient();
let dbTable = process.env.STORAGE_DB_TABLE;

admin.initializeApp({
    credential: admin.credential.applicationDefault()
});

exports.handler = async function(event) {
    let records = event.Records;

    for (let i = 0; i < records.length; i++){
        await execute(records[i])
    }
}

function prepareRequest(record){
    let notificationId;
    try {
        notificationId = record.messageAttributes.notificationId.stringValue.toString();
        if (notificationId.length === 0) throw new Error();
    } catch {
        throw new Error("Missing attribute: notificationId");
    }

    let msg = {}
    try {
        msg = JSON.parse(record.body);
    } catch {
        throw new Error("Body is not valid JSON!");
    }

    if (msg.tokens === undefined || msg.tokens.length === 0){
        throw new Error("Missing body property: tokens");
    }

    let tokens = Array.isArray(msg.tokens) ? msg.tokens : [ msg.tokens ];
    let data = msg.data === undefined ? { } : msg.data;
    data.notificationId = notificationId;
    let title = msg.title;
    let body = msg.body;

    return {
        tokens,
        data,
        title,
        body
    }
}

async function execute(record) {
    let req = prepareRequest(record);

    let message = {
        data: req.data,
        notification: {
            title: req.title,
            body: req.body
        },
        tokens: req.tokens
    };

    const failedTokens = [];
    let error;
    await admin.messaging().sendMulticast(message)
        .then((response) => {
            if (response.failureCount > 0) {
                response.responses.forEach((resp, idx) => {
                    if (!resp.success) {
                        failedTokens.push(req.tokens[idx]);
                    }
                });
                console.log('List of tokens that caused failures: ' + failedTokens);
            }
        })
        .catch((error) => {
            console.log('Error sending message:', error);
        });

    let dbItem = {
        TableName: dbTable,
        Item:{
            "Id": record.messageId,
            "NotificationId": req.notificationId,
            "Message": message,
            "EventSource": record.eventSourceARN,
            "CreatedAtUtc": new Date().toJSON(),
            "FailedTokens": failedTokens,
            "Error": error
        }
    };

    await dbPutItem(dbItem)
        .catch(err => {
            console.log('Error putting message into storage:', err, dbItem);
        });
}

function dbPutItem(dbItem){
    return new Promise((resolve, reject) => {
        dbClient.put(dbItem, function(err, data) {
            if (err) {
                reject(err);
            } else {
                resolve();
            }
        });
    });
}