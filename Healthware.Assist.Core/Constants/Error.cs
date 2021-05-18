namespace Healthware.Assist.Core.Constants
{
    public static class Error
    {
        public const string HasActiveSession = "User already has an active session.";
        public const string DoesNotHaveActiveSession = "User does not an active session.";
        public const string LastLoggedInDateError = "Could not able to read last logged in date.";
        public const string LogoutSuccess = "User logged out successfully.";
        public const string LogoutFailure = "Could not find the active user.";
        public const string NotFound = "Not Found";
        public const string UnableUpdate = "Unable to Update";
    }
}
