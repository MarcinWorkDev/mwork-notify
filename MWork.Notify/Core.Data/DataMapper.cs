using AutoMapper;
using MWork.Notify.Core.Data.Models;
using MWork.Notify.Core.Domain.Models;

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
            });
            
            configuration.AssertConfigurationIsValid();

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

        public static TOut Map<TOut>(this object input)
        {
            return MapperInternal.Map<TOut>(input);
        }
    }
}