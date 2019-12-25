namespace MWork.Notify.Plugins.AWS.Data
{
    public static class CoreDataConstants
    {
        public const string TableNamePrefix = "MWork.Notify.Core.Data.";

        public static void ValidateDataMapper()
        {
            DataMapper.ValidateConfiguration();
        }
    }
}