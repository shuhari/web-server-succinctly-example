namespace WebServerExample.Models
{
    /// <summary>
    /// Url parameters
    /// </summary>
    public class UrlParameter
    {
        /// <summary>
        /// Optional parameter
        /// </summary>
        public static readonly UrlParameter Optional = new UrlParameter();

        /// <summary>
        /// Missing parameter
        /// </summary>
        public static readonly UrlParameter Missing = new UrlParameter();
    }
}