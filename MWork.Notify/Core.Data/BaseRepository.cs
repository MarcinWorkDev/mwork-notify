using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using MWork.Notify.Core.Domain.Models;

namespace MWork.Notify.Core.Data
{
    public abstract class BaseRepository<TDomain, TEntity>
    {
        protected readonly IDynamoDBContext DbContext;

        protected readonly string TableName;
        protected readonly DynamoDBOperationConfig DefaultOperationConfig;
        
        protected BaseRepository()
        {
            var dynamoDbClient = new AmazonDynamoDBClient();
            var config = new DynamoDBContextConfig()
            {
                TableNamePrefix = GetType().Namespace + '.'
            };
            
            DbContext = new DynamoDBContext(dynamoDbClient, config);
            TableName = typeof(TEntity).Name;
            DefaultOperationConfig = new DynamoDBOperationConfig()
            {
                OverrideTableName = TableName
            };
        }
        
        public async Task<TDomain> Get(Guid id)
        {
            var entity = await DbContext.LoadAsync<TEntity>(id);
            return entity.Map<TDomain>();
        }

        public async Task Save(TDomain domain)
        {
            var entity = domain.Map<TEntity>();
            await DbContext.SaveAsync(entity, DefaultOperationConfig);
        }

        public async Task Remove(Guid id)
        {
            await DbContext.DeleteAsync<TEntity>(id, DefaultOperationConfig);
        }
    }
}