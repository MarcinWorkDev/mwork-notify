using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using MWork.Common.Sdk.Extensions;
using MWork.Common.Sdk.Repositories;

namespace MWork.Common.Aws.DynamoDb
{
    public abstract class BaseRepository<TEntity>
    {
        private readonly IDynamoDBContext _dbContext;
        private readonly Action<DynamoDBOperationConfig> _defaultOperationConfig;
        
        protected BaseRepository(string tableNamePrefix)
        {
            var dynamoDbClient = new AmazonDynamoDBClient();
            var config = new DynamoDBContextConfig()
            {
                TableNamePrefix = tableNamePrefix,
                IgnoreNullValues = true
            };
            
            _dbContext = new DynamoDBContext(dynamoDbClient, config);
            var tableName = typeof(TEntity).Name;
            _defaultOperationConfig = o => { o.OverrideTableName = tableName; };
        }
        
        protected async Task<TEntity> Get(string hashKey, string rangeKey = null, string index = null)
        {
            var options = new DynamoDBOperationConfig();
            _defaultOperationConfig.Invoke(options);

            if (index.IsPresent())
            {
                options.IndexName = index;
            }
            
            TEntity entity;

            if (rangeKey.IsPresent())
            {
                entity = await _dbContext.LoadAsync<TEntity>(hashKey, rangeKey, options);
            }
            else
            {
                entity = await _dbContext.LoadAsync<TEntity>(hashKey, options);
            }
            
            return entity;
        }
        
        protected async Task<IEnumerable<TEntity>> Find(params ScanCondition[] conditions)
        {
            var options = new DynamoDBOperationConfig();
            _defaultOperationConfig.Invoke(options);
            
            var searchResult = _dbContext.ScanAsync<TEntity>(conditions, options);
            var entities = await searchResult.GetRemainingAsync();
            
            return entities;
        }
        
        protected async Task<IEnumerable<TEntity>> Find(string hashKey, IEnumerable<object> values, string index = null, QueryOperator queryOperator = QueryOperator.Equal)
        {
            var options = new DynamoDBOperationConfig();
            _defaultOperationConfig.Invoke(options);

            if (index.IsPresent())
            {
                options.IndexName = index;
            }
            
            var searchResult = _dbContext.QueryAsync<TEntity>(hashKey, queryOperator, values, options);
            var entities = await searchResult.GetRemainingAsync();
            
            return entities;
        }

        protected async Task Put(TEntity entity)
        {
            var options = new DynamoDBOperationConfig();
            _defaultOperationConfig.Invoke(options);

            if (HasModifiedColumn())
            {
                ((IModifiedColumn) entity).ModifiedAtUtc = DateTime.UtcNow;
            }
            
            await _dbContext.SaveAsync(entity, options);
        }

        protected async Task Delete(string id, bool softDelete)
        {
            var options = new DynamoDBOperationConfig();
            _defaultOperationConfig.Invoke(options);
            
            if (softDelete)
            {
                if (HasDeleteColumn())
                {
                    var entity = await this.Get(id);
                    ((IDeleteColumn) entity).Deleted = true;

                    if (HasModifiedColumn())
                    {
                        ((IModifiedColumn) entity).ModifiedAtUtc = DateTime.UtcNow;
                    }
                }
                else
                {
                    throw new InvalidOperationException($"Soft delete is not available for type: '{typeof(TEntity)}'");
                }
            }
            else
            {
                await _dbContext.DeleteAsync<TEntity>(id, options);
            }
        }

        private static bool HasDeleteColumn()
        {
            return typeof(TEntity).GetInterfaces().Any(x => x == typeof(IDeleteColumn));
        }
        
        private static bool HasModifiedColumn()
        {
            return typeof(TEntity).GetInterfaces().Any(x => x == typeof(IModifiedColumn));
        }
    }
}