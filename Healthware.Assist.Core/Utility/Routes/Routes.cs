namespace Healthware.Assist.Core.Utility.Routes
{
    public static class Routes
    {
        public const string DownloadFile = "{id:long}/DownloadFile/{fileId:long}";
        public const string InspectionPdf = "{id:long}/pdf";
        public const string ActionItemAttachmentDownloadFile = "{id:long}/attachment/{attachmentId:long}";
    }
}