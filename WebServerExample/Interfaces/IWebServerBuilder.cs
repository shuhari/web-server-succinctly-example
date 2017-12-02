namespace WebServerExample.Interfaces
{
    /// <summary>
    /// Describe how to setup web server
    /// </summary>
    public interface IWebServerBuilder
    {
        /// <summary>
        /// Register middleware to pipeline
        /// </summary>
        /// <param name="middleware"></param>
        /// <returns></returns>
        IWebServerBuilder Use(IMiddleware middleware);

        /// <summary>
        /// Specify handler to process unhandled exception
        /// </summary>
        /// <param name="handler"></param>
        /// <returns></returns>
        IWebServerBuilder UnhandledException(IExceptionHandler handler);
    }
}