let nodemailer = require('nodemailer');
let AWS = require("aws-sdk");

let dbClient = new AWS.DynamoDB.DocumentClient();
let dbTable = process.env.STORAGE_DB_TABLE;

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

    if (msg.subject === undefined || msg.subject.length === 0){
        throw new Error("Missing property: subject");
    }

    if (msg.to === undefined || msg.to.length === 0){
        throw new Error("Missing property: subject");
    }

    let to = Array.isArray(msg.to) ? msg.to : [ msg.to ];
    let subject = msg.subject;
    let body = msg.body;
    let priority = msg.priority === undefined ? "normal" : msg.priority;

    if (['high', 'normal', 'low'].includes(priority) === false) {
        priority = 'normal'
    }

    return {
        notificationId,
        to,
        subject,
        body,
        priority
    }
}

async function execute(record){
    let req = prepareRequest(record);

    let message = {
        from: process.env.SMTP_USER,
        to: req.to,
        subject: req.subject,
        html: req.body,
        priority: req.priority,
        messageId: req.notificationId
    };

    let info;
    let error;
    await sendEmail(message)
        .then(i => {
            info = i;
        })
        .catch(e => {
            error = e;
            console.log(e);
        });

    let dbItem = {
        TableName: dbTable,
        Item:{
            "Id": record.messageId,
            "NotificationId": req.notificationId,
            "Message": message,
            "EventSource": record.eventSourceARN,
            "CreatedAtUtc": new Date().toJSON(),
            "Info": info,
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

function sendEmail(message){
    return new Promise((resolve, reject) => {
        let transport = nodemailer.createTransport({
            host: process.env.SMTP_HOST,
            port: process.env.SMTP_PORT,
            auth: {
                user: process.env.SMTP_USER,
                pass: process.env.SMTP_PASS
            }
        });

        transport.sendMail(message, function(err, info) {
            if (err) {
                reject(err);
            } else {
                resolve(info);
            }
        });
    });
}