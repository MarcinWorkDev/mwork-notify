using AutoMapper;
using MWork.Notify.Core.Data.Models;
using MWork.Notify.Core.Domain.Models;
using MWork.Notify.Core.Domain.Models.Account;

namespace MWork.Notify.Core.Data
{
    internal static class DataMapper
    {
        private static readonly AutoMapper.Mapper MapperInternal;
        
        static DataMapper()
        {
            var configuration = new MapperConfiguration(c =>
            {
                c.CreateMap<Notification, NotificationEntity>()
                    .ReverseMap();

                c.CreateMap<QueueMessage, QueueMessageEntity>()
                    .ReverseMap();

                c.CreateMap<User, UserEntity>()
                    .ReverseMap();

                c.CreateMap<UserEndpoint, UserEntityEndpoint>()
                    .ReverseMap();

                c.CreateMap<UserPreferences, UserEntityPreferences>()
                    .ReverseMap();

                c.CreateMap<UserDeviceInfo, UserEntityEndpointDeviceInfo>()
                    .ReverseMap();
            });
            
            MapperInternal = new AutoMapper.Mapper(configuration);
        }

        public static Notification ToDomain(this NotificationEntity entity)
        {
            return MapperInternal.Map<Notification>(entity);
        }
        
        public static NotificationEntity ToEntity(this Notification domain)
        {
            return MapperInternal.Map<NotificationEntity>(domain);
        }
        
        public static QueueMessage ToDomain(this QueueMessageEntity entity)
        {
            return MapperInternal.Map<QueueMessage>(entity);
        }
        
        public static QueueMessageEntity ToEntity(this QueueMessage domain)
        {
            return MapperInternal.Map<QueueMessageEntity>(domain);
        }
        
        public static User ToDomain(this UserEntity entity)
        {
            return MapperInternal.Map<User>(entity);
        }
        
        public static UserEntity ToEntity(this User domain)
        {
            return MapperInternal.Map<UserEntity>(domain);
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