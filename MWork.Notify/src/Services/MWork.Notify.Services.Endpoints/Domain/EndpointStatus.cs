namespace MWork.Notify.Services.Endpoints.Domain
{
    public enum EndpointStatus
    {
        // Active
        Active,
        
        // Inactive (manually)
        Inactive,
        
        // Disabled do to failed counter
        Disabled,
        
        // Deleted (manually)
        Deleted
    }
}