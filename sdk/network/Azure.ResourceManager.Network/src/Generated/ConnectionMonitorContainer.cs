// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> A class representing collection of ConnectionMonitor and their operations over a NetworkWatcher. </summary>
    public partial class ConnectionMonitorContainer : ArmContainer
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ConnectionMonitorsRestOperations _restClient;

        /// <summary> Initializes a new instance of the <see cref="ConnectionMonitorContainer"/> class for mocking. </summary>
        protected ConnectionMonitorContainer()
        {
        }

        /// <summary> Initializes a new instance of ConnectionMonitorContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ConnectionMonitorContainer(ArmResource parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _restClient = new ConnectionMonitorsRestOperations(_clientDiagnostics, Pipeline, ClientOptions, Id.SubscriptionId, BaseUri);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => NetworkWatcher.ResourceType;

        // Container level operations.

        /// <summary> Create or update a connection monitor. </summary>
        /// <param name="connectionMonitorName"> The name of the connection monitor. </param>
        /// <param name="parameters"> Parameters that define the operation to create a connection monitor. </param>
        /// <param name="migrate"> Value indicating whether connection monitor V1 should be migrated to V2 format. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionMonitorName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ConnectionMonitorCreateOrUpdateOperation CreateOrUpdate(string connectionMonitorName, ConnectionMonitorInput parameters, string migrate = null, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (connectionMonitorName == null)
            {
                throw new ArgumentNullException(nameof(connectionMonitorName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ConnectionMonitorContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _restClient.CreateOrUpdate(Id.ResourceGroupName, Id.Name, connectionMonitorName, parameters, migrate, cancellationToken);
                var operation = new ConnectionMonitorCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, Id.Name, connectionMonitorName, parameters, migrate).Request, response);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Create or update a connection monitor. </summary>
        /// <param name="connectionMonitorName"> The name of the connection monitor. </param>
        /// <param name="parameters"> Parameters that define the operation to create a connection monitor. </param>
        /// <param name="migrate"> Value indicating whether connection monitor V1 should be migrated to V2 format. </param>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionMonitorName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ConnectionMonitorCreateOrUpdateOperation> CreateOrUpdateAsync(string connectionMonitorName, ConnectionMonitorInput parameters, string migrate = null, bool waitForCompletion = true, CancellationToken cancellationToken = default)
        {
            if (connectionMonitorName == null)
            {
                throw new ArgumentNullException(nameof(connectionMonitorName));
            }
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            using var scope = _clientDiagnostics.CreateScope("ConnectionMonitorContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, Id.Name, connectionMonitorName, parameters, migrate, cancellationToken).ConfigureAwait(false);
                var operation = new ConnectionMonitorCreateOrUpdateOperation(Parent, _clientDiagnostics, Pipeline, _restClient.CreateCreateOrUpdateRequest(Id.ResourceGroupName, Id.Name, connectionMonitorName, parameters, migrate).Request, response);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="connectionMonitorName"> The name of the connection monitor. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ConnectionMonitor> Get(string connectionMonitorName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ConnectionMonitorContainer.Get");
            scope.Start();
            try
            {
                if (connectionMonitorName == null)
                {
                    throw new ArgumentNullException(nameof(connectionMonitorName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, Id.Name, connectionMonitorName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    throw _clientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ConnectionMonitor(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets details for this resource from the service. </summary>
        /// <param name="connectionMonitorName"> The name of the connection monitor. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ConnectionMonitor>> GetAsync(string connectionMonitorName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ConnectionMonitorContainer.Get");
            scope.Start();
            try
            {
                if (connectionMonitorName == null)
                {
                    throw new ArgumentNullException(nameof(connectionMonitorName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Name, connectionMonitorName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ConnectionMonitor(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="connectionMonitorName"> The name of the connection monitor. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<ConnectionMonitor> GetIfExists(string connectionMonitorName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ConnectionMonitorContainer.GetIfExists");
            scope.Start();
            try
            {
                if (connectionMonitorName == null)
                {
                    throw new ArgumentNullException(nameof(connectionMonitorName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, Id.Name, connectionMonitorName, cancellationToken: cancellationToken);
                return response.Value == null
                    ? Response.FromValue<ConnectionMonitor>(null, response.GetRawResponse())
                    : Response.FromValue(new ConnectionMonitor(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="connectionMonitorName"> The name of the connection monitor. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<ConnectionMonitor>> GetIfExistsAsync(string connectionMonitorName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ConnectionMonitorContainer.GetIfExists");
            scope.Start();
            try
            {
                if (connectionMonitorName == null)
                {
                    throw new ArgumentNullException(nameof(connectionMonitorName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Name, connectionMonitorName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value == null
                    ? Response.FromValue<ConnectionMonitor>(null, response.GetRawResponse())
                    : Response.FromValue(new ConnectionMonitor(this, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="connectionMonitorName"> The name of the connection monitor. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public virtual Response<bool> CheckIfExists(string connectionMonitorName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ConnectionMonitorContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (connectionMonitorName == null)
                {
                    throw new ArgumentNullException(nameof(connectionMonitorName));
                }

                var response = GetIfExists(connectionMonitorName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="connectionMonitorName"> The name of the connection monitor. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async virtual Task<Response<bool>> CheckIfExistsAsync(string connectionMonitorName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ConnectionMonitorContainer.CheckIfExists");
            scope.Start();
            try
            {
                if (connectionMonitorName == null)
                {
                    throw new ArgumentNullException(nameof(connectionMonitorName));
                }

                var response = await GetIfExistsAsync(connectionMonitorName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all connection monitors for the specified Network Watcher. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ConnectionMonitor" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ConnectionMonitor> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ConnectionMonitor> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ConnectionMonitorContainer.GetAll");
                scope.Start();
                try
                {
                    var response = _restClient.GetAll(Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ConnectionMonitor(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary> Lists all connection monitors for the specified Network Watcher. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ConnectionMonitor" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ConnectionMonitor> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ConnectionMonitor>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ConnectionMonitorContainer.GetAll");
                scope.Start();
                try
                {
                    var response = await _restClient.GetAllAsync(Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ConnectionMonitor(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        // Builders.
        // public ArmBuilder<ResourceIdentifier, ConnectionMonitor, ConnectionMonitorData> Construct() { }
    }
}
