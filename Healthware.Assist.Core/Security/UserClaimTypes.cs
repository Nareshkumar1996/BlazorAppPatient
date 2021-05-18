namespace Healthware.Assist.Core.Security
{
    /// <summary>Used to get specific claim type names.</summary>
    public static class UserClaimTypes
    {
        /// <summary>
        /// UserId.
        /// Default: <see cref="F:System.Security.Claims.ClaimTypes.Name" />
        /// </summary>
        public static string UserName { get; set; } = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";

        /// <summary>
        /// UserId.
        /// Default: <see cref="F:System.Security.Claims.ClaimTypes.NameIdentifier" />
        /// </summary>
        public static string UserId { get; set; } = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";

        /// <summary>
        /// UserId.
        /// Default: <see cref="F:System.Security.Claims.ClaimTypes.Role" />
        /// </summary>
        public static string Role { get; set; } = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

        /// <summary>
        /// TenantId.
        /// Default: http://www.zucisystems.com/identity/claims/tenantId
        /// </summary>
        public static string TenantId { get; set; } = "http://www.zucisystems.com/identity/claims/tenantId";

        /// <summary>
        /// ImpersonatorUserId.
        /// Default: http://www.zucisystems.com/identity/claims/impersonatorUserId
        /// </summary>
        public static string ImpersonatorUserId { get; set; } = "http://www.zucisystems.com/identity/claims/impersonatorUserId";

        /// <summary>
        /// ImpersonatorTenantId
        /// Default: http://www.zucisystems.com/identity/claims/impersonatorTenantId
        /// </summary>
        public static string ImpersonatorTenantId { get; set; } = "http://www.zucisystems.com/identity/claims/impersonatorTenantId";
        public static string NHSNumber { get; set; } = "http://ccube.zucisystems.com/identity/claims/NHSNumber";
        public static string MailType { get; set; } = "http://ccube.zucisystems.com/identity/claims/MailType";
        public static string Email { get; set; } = "http://ccube.zucisystems.com/identity/claims/Email";
    }
}
