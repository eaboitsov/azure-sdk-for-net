// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.Scanning
{
    /// <summary> The PurviewClassificationRule service client. </summary>
    public partial class PurviewClassificationRuleClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline { get => _pipeline; }
        private HttpPipeline _pipeline;
        private readonly string[] AuthorizationScopes = { "https://purview.azure.net/.default" };
        private readonly TokenCredential _tokenCredential;
        private Uri endpoint;
        private string classificationRuleName;
        private readonly string apiVersion;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Initializes a new instance of PurviewClassificationRuleClient for mocking. </summary>
        protected PurviewClassificationRuleClient()
        {
        }

        /// <summary> Initializes a new instance of PurviewClassificationRuleClient. </summary>
        /// <param name="endpoint"> The scanning endpoint of your purview account. Example: https://{accountName}.scan.purview.azure.com. </param>
        /// <param name="classificationRuleName"> The String to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public PurviewClassificationRuleClient(Uri endpoint, string classificationRuleName, TokenCredential credential, PurviewScanningServiceClientOptions options = null)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (classificationRuleName == null)
            {
                throw new ArgumentNullException(nameof(classificationRuleName));
            }
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            options ??= new PurviewScanningServiceClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _tokenCredential = credential;
            var authPolicy = new BearerTokenAuthenticationPolicy(_tokenCredential, AuthorizationScopes);
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new LowLevelCallbackPolicy() }, new HttpPipelinePolicy[] { authPolicy }, new ResponseClassifier());
            this.endpoint = endpoint;
            this.classificationRuleName = classificationRuleName;
            apiVersion = options.Version;
        }

        /// <summary> Get a classification rule. </summary>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   id: string,
        ///   name: string,
        ///   kind: &quot;System&quot; | &quot;Custom&quot;
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [
        ///       {
        ///         code: string,
        ///         message: string,
        ///         target: string,
        ///         details: [ErrorModel]
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> GetPropertiesAsync(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateGetPropertiesRequest();
            RequestOptions.Apply(options, message);
            using var scope = _clientDiagnostics.CreateScope("PurviewClassificationRuleClient.GetProperties");
            scope.Start();
            try
            {
                await Pipeline.SendAsync(message, options.CancellationToken).ConfigureAwait(false);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                            return message.Response;
                        default:
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a classification rule. </summary>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   id: string,
        ///   name: string,
        ///   kind: &quot;System&quot; | &quot;Custom&quot;
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [
        ///       {
        ///         code: string,
        ///         message: string,
        ///         target: string,
        ///         details: [ErrorModel]
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual Response GetProperties(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateGetPropertiesRequest();
            RequestOptions.Apply(options, message);
            using var scope = _clientDiagnostics.CreateScope("PurviewClassificationRuleClient.GetProperties");
            scope.Start();
            try
            {
                Pipeline.Send(message, options.CancellationToken);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                            return message.Response;
                        default:
                            throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private HttpMessage CreateGetPropertiesRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/classificationrules/", false);
            uri.AppendPath(classificationRuleName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Creates or Updates a classification rule. </summary>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   id: string,
        ///   name: string,
        ///   kind: &quot;System&quot; | &quot;Custom&quot; (required)
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   id: string,
        ///   name: string,
        ///   kind: &quot;System&quot; | &quot;Custom&quot;
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [
        ///       {
        ///         code: string,
        ///         message: string,
        ///         target: string,
        ///         details: [ErrorModel]
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> CreateOrUpdateAsync(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateCreateOrUpdateRequest(content);
            RequestOptions.Apply(options, message);
            using var scope = _clientDiagnostics.CreateScope("PurviewClassificationRuleClient.CreateOrUpdate");
            scope.Start();
            try
            {
                await Pipeline.SendAsync(message, options.CancellationToken).ConfigureAwait(false);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                        case 201:
                            return message.Response;
                        default:
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or Updates a classification rule. </summary>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   id: string,
        ///   name: string,
        ///   kind: &quot;System&quot; | &quot;Custom&quot; (required)
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   id: string,
        ///   name: string,
        ///   kind: &quot;System&quot; | &quot;Custom&quot;
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [
        ///       {
        ///         code: string,
        ///         message: string,
        ///         target: string,
        ///         details: [ErrorModel]
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual Response CreateOrUpdate(RequestContent content, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateCreateOrUpdateRequest(content);
            RequestOptions.Apply(options, message);
            using var scope = _clientDiagnostics.CreateScope("PurviewClassificationRuleClient.CreateOrUpdate");
            scope.Start();
            try
            {
                Pipeline.Send(message, options.CancellationToken);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                        case 201:
                            return message.Response;
                        default:
                            throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private HttpMessage CreateCreateOrUpdateRequest(RequestContent content)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/classificationrules/", false);
            uri.AppendPath(classificationRuleName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        /// <summary> Deletes a classification rule. </summary>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   id: string,
        ///   name: string,
        ///   kind: &quot;System&quot; | &quot;Custom&quot;
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [
        ///       {
        ///         code: string,
        ///         message: string,
        ///         target: string,
        ///         details: [ErrorModel]
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> DeleteAsync(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateDeleteRequest();
            RequestOptions.Apply(options, message);
            using var scope = _clientDiagnostics.CreateScope("PurviewClassificationRuleClient.Delete");
            scope.Start();
            try
            {
                await Pipeline.SendAsync(message, options.CancellationToken).ConfigureAwait(false);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                            return message.Response;
                        case 204:
                            return message.Response;
                        default:
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a classification rule. </summary>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   id: string,
        ///   name: string,
        ///   kind: &quot;System&quot; | &quot;Custom&quot;
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [
        ///       {
        ///         code: string,
        ///         message: string,
        ///         target: string,
        ///         details: [ErrorModel]
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual Response Delete(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateDeleteRequest();
            RequestOptions.Apply(options, message);
            using var scope = _clientDiagnostics.CreateScope("PurviewClassificationRuleClient.Delete");
            scope.Start();
            try
            {
                Pipeline.Send(message, options.CancellationToken);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                            return message.Response;
                        case 204:
                            return message.Response;
                        default:
                            throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private HttpMessage CreateDeleteRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/classificationrules/", false);
            uri.AppendPath(classificationRuleName, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Lists the rule versions of a classification rule. </summary>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   value: [
        ///     {
        ///       id: string,
        ///       name: string,
        ///       kind: &quot;System&quot; | &quot;Custom&quot;
        ///     }
        ///   ],
        ///   nextLink: string,
        ///   count: number
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [
        ///       {
        ///         code: string,
        ///         message: string,
        ///         target: string,
        ///         details: [ErrorModel]
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> GetVersionsAsync(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateGetVersionsRequest();
            RequestOptions.Apply(options, message);
            using var scope = _clientDiagnostics.CreateScope("PurviewClassificationRuleClient.GetVersions");
            scope.Start();
            try
            {
                await Pipeline.SendAsync(message, options.CancellationToken).ConfigureAwait(false);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                            return message.Response;
                        default:
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists the rule versions of a classification rule. </summary>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   value: [
        ///     {
        ///       id: string,
        ///       name: string,
        ///       kind: &quot;System&quot; | &quot;Custom&quot;
        ///     }
        ///   ],
        ///   nextLink: string,
        ///   count: number
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [
        ///       {
        ///         code: string,
        ///         message: string,
        ///         target: string,
        ///         details: [ErrorModel]
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual Response GetVersions(RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateGetVersionsRequest();
            RequestOptions.Apply(options, message);
            using var scope = _clientDiagnostics.CreateScope("PurviewClassificationRuleClient.GetVersions");
            scope.Start();
            try
            {
                Pipeline.Send(message, options.CancellationToken);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 200:
                            return message.Response;
                        default:
                            throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private HttpMessage CreateGetVersionsRequest()
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/classificationrules/", false);
            uri.AppendPath(classificationRuleName, true);
            uri.AppendPath("/versions", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Sets Classification Action on a specific classification rule version. </summary>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   scanResultId: OperationResponseScanResultId,
        ///   startTime: string (ISO 8601 Format),
        ///   endTime: string (ISO 8601 Format),
        ///   status: &quot;Accepted&quot; | &quot;InProgress&quot; | &quot;TransientFailure&quot; | &quot;Succeeded&quot; | &quot;Failed&quot; | &quot;Canceled&quot;,
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [
        ///       {
        ///         code: string,
        ///         message: string,
        ///         target: string,
        ///         details: [ErrorInfo]
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [
        ///       {
        ///         code: string,
        ///         message: string,
        ///         target: string,
        ///         details: [ErrorModel]
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="classificationRuleVersion"> The Integer to use. </param>
        /// <param name="action"> The ClassificationAction to use. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual async Task<Response> TagVersionAsync(int classificationRuleVersion, string action, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateTagVersionRequest(classificationRuleVersion, action);
            RequestOptions.Apply(options, message);
            using var scope = _clientDiagnostics.CreateScope("PurviewClassificationRuleClient.TagVersion");
            scope.Start();
            try
            {
                await Pipeline.SendAsync(message, options.CancellationToken).ConfigureAwait(false);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 202:
                            return message.Response;
                        default:
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Sets Classification Action on a specific classification rule version. </summary>
        /// <remarks>
        /// Schema for <c>Response Body</c>:
        /// <code>{
        ///   scanResultId: OperationResponseScanResultId,
        ///   startTime: string (ISO 8601 Format),
        ///   endTime: string (ISO 8601 Format),
        ///   status: &quot;Accepted&quot; | &quot;InProgress&quot; | &quot;TransientFailure&quot; | &quot;Succeeded&quot; | &quot;Failed&quot; | &quot;Canceled&quot;,
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [
        ///       {
        ///         code: string,
        ///         message: string,
        ///         target: string,
        ///         details: [ErrorInfo]
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   error: {
        ///     code: string,
        ///     message: string,
        ///     target: string,
        ///     details: [
        ///       {
        ///         code: string,
        ///         message: string,
        ///         target: string,
        ///         details: [ErrorModel]
        ///       }
        ///     ]
        ///   }
        /// }
        /// </code>
        /// 
        /// </remarks>
        /// <param name="classificationRuleVersion"> The Integer to use. </param>
        /// <param name="action"> The ClassificationAction to use. </param>
        /// <param name="options"> The request options. </param>
#pragma warning disable AZC0002
        public virtual Response TagVersion(int classificationRuleVersion, string action, RequestOptions options = null)
#pragma warning restore AZC0002
        {
            options ??= new RequestOptions();
            using HttpMessage message = CreateTagVersionRequest(classificationRuleVersion, action);
            RequestOptions.Apply(options, message);
            using var scope = _clientDiagnostics.CreateScope("PurviewClassificationRuleClient.TagVersion");
            scope.Start();
            try
            {
                Pipeline.Send(message, options.CancellationToken);
                if (options.StatusOption == ResponseStatusOption.Default)
                {
                    switch (message.Response.Status)
                    {
                        case 202:
                            return message.Response;
                        default:
                            throw _clientDiagnostics.CreateRequestFailedException(message.Response);
                    }
                }
                else
                {
                    return message.Response;
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private HttpMessage CreateTagVersionRequest(int classificationRuleVersion, string action)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/classificationrules/", false);
            uri.AppendPath(classificationRuleName, true);
            uri.AppendPath("/versions/", false);
            uri.AppendPath(classificationRuleVersion, true);
            uri.AppendPath("/:tag", false);
            uri.AppendQuery("action", action, true);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }
    }
}
