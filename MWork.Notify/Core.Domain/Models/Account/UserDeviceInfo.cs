using MWork.Notify.Core.Domain.Models.Enums;

namespace MWork.Notify.Core.Domain.Models.Account
{
    public class UserDeviceInfo
    {
        public DeviceType Type { get; set; }
        
        public string Name { get; set; }
        
        public string Platform { get; set; }
        
        public string AppName { get; set; }
        
        public string AppVersion { get; set; }
    }
}