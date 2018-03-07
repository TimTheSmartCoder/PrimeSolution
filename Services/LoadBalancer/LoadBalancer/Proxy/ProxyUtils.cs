using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace LoadBalancer.Proxy
{
    public static class ProxyUtils
    {
        /// <summary>
        /// Creates an HttpRequestMessage from the given context and assign the
        /// returned HttpRequestMessage to the given destination.
        /// </summary>
        /// <param name="context">HttpContext to get HttpRequest from.</param>
        /// <param name="destination">Destination of the HttpRequestMessage.</param>
        /// <returns></returns>
        public static HttpRequestMessage CreateProxyHttpRequest(HttpContext context, Uri destination)
        {
            /*
             * Code copied an modified a little from AspNetCore Proxy middleware.
             * https://github.com/aspnet/Proxy/blob/dev/src/Microsoft.AspNetCore.Proxy/ProxyAdvancedExtensions.cs
             */

            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (destination == null)
                throw new ArgumentNullException(nameof(destination));

            // Get the request from the HttpContext.
            var request = context.Request;

            // Create an HttpRequestMessage.
            var requestMessage = new HttpRequestMessage();

            // Get request method from the HttpContext.
            var requestMethod = request.Method;

            // Copy content of the request body, if neccesary.
            if (!HttpMethods.IsGet(requestMethod) &&
                !HttpMethods.IsHead(requestMethod) &&
                !HttpMethods.IsDelete(requestMethod) &&
                !HttpMethods.IsTrace(requestMethod))
            {
                var streamContent = new StreamContent(request.Body);
                requestMessage.Content = streamContent;
            }

            // Copy the request headers.
            foreach (var header in request.Headers)
            {
                if (!requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray()))
                {
                    requestMessage.Content?.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
                }
            }

            // Copy host, request an so on from HttpContext request.
            requestMessage.Headers.Host = destination.Authority;
            requestMessage.RequestUri = destination;
            requestMessage.Method = new HttpMethod(request.Method);

            return requestMessage;
        }

        /// <summary>
        /// Copies the HttpResponseMessage to the HttpContext Response.
        /// </summary>
        /// <param name="context">HttpContext to copy to from HttpResponseMessage.</param>
        /// <param name="responseMessage">HttpResponseMessage to copy from.</param>
        /// <returns></returns>
        public static async Task CopyProxyHttpResponse(HttpContext context, HttpResponseMessage responseMessage)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (responseMessage == null)
                throw new ArgumentNullException(nameof(responseMessage));
            
            // Get HttpContext Response, so we can respond to the user.
            var response = context.Response;

            // Copy the status code from the HttpResonseMessage.
            response.StatusCode = (int)responseMessage.StatusCode;

            // Copy the normal http headers from the HttpResponseMessage.
            foreach (var header in responseMessage.Headers)
                response.Headers[header.Key] = header.Value.ToArray();

            // Copy the content http headers from the HttpResponseMessage.
            foreach (var contentHeader in responseMessage.Content.Headers)
                response.Headers[contentHeader.Key] = contentHeader.Value.ToArray();

            // Remove the header transfer-encoding, so that the user do not expect
            // chunked response, because we are using SendAsync and SendAsync
            // do not use use chunked response.
            response.Headers.Remove("transfer-encoding");

            // Stream the content from HttpResponseMessage to HttpContext response.
            using (var responseStream = await responseMessage.Content.ReadAsStreamAsync())
            {
                await responseStream.CopyToAsync(response.Body, 81920, context.RequestAborted);
            }
        }

        /// <summary>
        /// Sends the given HttpRequestMessage with the given HttpClient.
        /// </summary>
        /// <param name="context">HttpContext to get cancellation token from.</param>
        /// <param name="requestMessage">HttpRequestMessage to send.</param>
        /// <param name="client">HttpClient to use in sending HttpRequestMessage.</param>
        /// <returns></returns>
        public static Task<HttpResponseMessage> SendProxyHttpRequest(HttpContext context, HttpRequestMessage requestMessage, HttpClient client)
        {
            /*
             * Code copied an modified a little from AspNetCore Proxy middleware.
             * https://github.com/aspnet/Proxy/blob/dev/src/Microsoft.AspNetCore.Proxy/ProxyAdvancedExtensions.cs
             */

            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (requestMessage == null)
                throw new ArgumentNullException(nameof(requestMessage));
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            return client.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, context.RequestAborted);
        }
    }
}
