namespace Healthware.Shared
{
    public class ServiceAuditTrail : BaseEntity
    {       
        public string Action { get; set; }
        public string Method { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }      
    }
}
