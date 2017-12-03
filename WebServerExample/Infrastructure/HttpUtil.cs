using System.Net;
using System.Text;

namespace WebServerExample.Infrastructure
{
    /// <summary>
    /// Helper methods to process http request/response
    /// </summary>
    public static class HttpUtil
    {
        public static HttpListenerResponse Status(this HttpListenerResponse response,
            int statusCode, string description)
        {
            var messageBytes = Encoding.UTF8.GetBytes(description);

            response.StatusCode = statusCode;
            response.StatusDescription = description;
            response.ContentLength64 = messageBytes.Length;
            response.OutputStream.Write(messageBytes, 0, messageBytes.Length);
            response.OutputStream.Close();

            return response;
        }

        public static HttpListenerResponse Content(this HttpListenerResponse response,
            string content, string mimeType)
        {
            var contentBytes = Encoding.UTF8.GetBytes(content);

            response.ContentType = mimeType;
            response.StatusCode = 200;
            response.ContentLength64 = contentBytes.Length;
            response.OutputStream.Write(contentBytes, 0, contentBytes.Length);
            response.OutputStream.Close();

            return response;
        }
    }
}