namespace MWork.Notify.Plugins.AWS.Data.Models
{
    public class UserDeviceInfoEntity
    {
        public int Type { get; set; }
        
        public string Name { get; set; }
        
        public string Platform { get; set; }
        
        public string AppName { get; set; }
        
        public string AppVersion { get; set; }
    }
}