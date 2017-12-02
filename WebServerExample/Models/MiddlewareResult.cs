namespace WebServerExample.Models
{
    /// <summary>
    /// Middleware execution result
    /// </summary>
    public enum MiddlewareResult
    {
        /// <summary>
        /// Request has been processed, no more steps should be executed any more
        /// </summary>
        Processed = 1,
        
        /// <summary>
        /// Continue to execute next middleware
        /// </summary>
        Continue = 2,
    }
}