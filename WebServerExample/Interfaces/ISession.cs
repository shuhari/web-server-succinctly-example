namespace WebServerExample.Interfaces
{
    /// <summary>
    /// Session interface
    /// </summary>
    public interface ISession
    {
        /// <summary>
        /// Get/set session imtes
        /// </summary>
        /// <param name="name"></param>
        object this[string name] { get; set; }        
    }
}