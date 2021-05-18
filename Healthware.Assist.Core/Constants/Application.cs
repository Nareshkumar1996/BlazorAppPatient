namespace Healthware.Assist.Core.Constants
{
    public static class Application
    {
        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public const string DefaultPassPhrase = "gsKxGZ012HLL3MI5";
        public const string PatientConfirmEmailSubject = "CCube Solutions Account Activation";
        public const string ForgotPasswordEmailSubject = "Forgot Password Link for your CCube Account";
        public const string ForgotPasswordEmailBodyThree = "Note that this link is valid for 24 hours. After 24 hours link will expire, then you need to resubmit a request for resetting your password.<br>";
        public const string NavigationLink = "Please Click Here";
        public const string PatientPortalAnnouncementUrl = "api/Announcements?system=PatientPortal";
        public const int AddOneDay = 1;
        public const string TimeFormat = "hh:mm:ss:tt";
        public const string FullDateTimeFormat = "f";
        public const string AppointmentStatusNew = "New";
        public const string ModifiedAppointmentStatus = "Yet to Accept";
        public const string AppointmentsbySpeciality = "Speciality";
        public const string AppointmentsbyStatus = "Status";
        public const string AppointmentsbyMonth = "Month";
        public const string AppointmentsbyPastMonths = "PastMonths";
        public const string AppointmentsbyYear = "Year";
        public const int GetYesterday = -1;
        public const string AppointmentActionUrl = "api/appointment/";        
        public const string ActionSeen = "/Seen";
        public const string ActionAccepted = "/Accepted";        
        public const string ActionRequestCancel = "/RequestCancel";
        public const string ActionRequestCancelPatient = "/RequestCancelPatient";
        public const string ActionRequestReschedule = "/RequestReschedule";
        public const string ActionRequestReschedulePatient = "/RequestReschedulePatient";
        public const string ActionReschedule = "/Reschedule";
        public const string ActionCancel = "/Cancel";
        public const string ActionUndo = "/Undo";
        public const string ClaimsMail = "http://ccube.zucisystems.com/identity/claims/Email";
        public const string MailTypeSetPassword = "SetPassword";
        public const string MailTypeForgotPassword = "ForgotPassword";        
        public const string SetPasswordmessage = "Set Password link has been send to your mail. Please check your email to activate your account.";
        public const string ForgotPasswordmessage = "Mail sent successfully to the User for resetting the password.";
        public const string EmailTemplatePath = "//Templates//EmailTemplate//";
        public const string HtmlExtension = ".html";
        public const string MailNotExistsMessage = "Email Address does not exists";
        public const string InvalidEmailMessage = "Unable to send Email. Invalid email address";
        public const string StatusUpdateMessage = "Status changed successfully";
        public const string NotesUpdateMessage = "Notes updated successfully";
        public const string ObservationUpdateMessage = "Observations updated successfully";
        public const string ArchiveUsersSuccessMessage = "Archive Inactive Users Successfully";
        public const string ArchiveUsersFailureMessage = "Unable to Archive Inactive Users";
        public const string NoInactiveUsersMessage = "No Inactive Users";

    }
}
