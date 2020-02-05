using AutoMapper;
using MWork.Notify.Services.Messages.Domain;
using MWork.Notify.Services.Messages.Repositories.Models;

namespace MWork.Notify.Services.Messages.Repositories
{
    internal static class DataMapper
    {
        private static readonly AutoMapper.Mapper MapperInternal;
        
        static DataMapper()
        {
            var configuration = new MapperConfiguration(c =>
            {
                c.CreateMap<Message, MessageEntity>()
                    .ReverseMap();
            });
            
            MapperInternal = new AutoMapper.Mapper(configuration);
        }

        public static Message ToDomain(this MessageEntity entity)
        {
            return MapperInternal.Map<Message>(entity);
        }
        
        public static MessageEntity ToEntity(this Message domain)
        {
            return MapperInternal.Map<MessageEntity>(domain);
        }
        
        public static TOut Map<TOut>(this object input)
        {
            return MapperInternal.Map<TOut>(input);
        }

        public static void ValidateConfiguration()
        {
            MapperInternal.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}