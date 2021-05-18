namespace Healthware.Assist.Core.Dtos
{
    /// <summary>
    /// Validation results
    /// </summary>
    public class ValidationResultDto
    {
        /// <summary>
        /// Validation message, if validation fails.
        /// </summary>
        public string Message { get; set; }
        
        /// <summary>
        /// true if the validation succeeds
        /// </summary>
        public bool IsValid { get; set; }
    }
}