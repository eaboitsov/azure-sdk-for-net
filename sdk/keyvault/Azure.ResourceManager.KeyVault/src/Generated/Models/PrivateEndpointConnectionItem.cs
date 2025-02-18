// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.KeyVault.Models
{
    /// <summary> Private endpoint connection item. </summary>
    public partial class PrivateEndpointConnectionItem : SubResource
    {
        /// <summary> Initializes a new instance of PrivateEndpointConnectionItem. </summary>
        internal PrivateEndpointConnectionItem()
        {
        }

        /// <summary> Initializes a new instance of PrivateEndpointConnectionItem. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="etag"> Modified whenever there is a change in the state of private endpoint connection. </param>
        /// <param name="privateEndpoint"> Properties of the private endpoint object. </param>
        /// <param name="privateLinkServiceConnectionState"> Approval state of the private link connection. </param>
        /// <param name="provisioningState"> Provisioning state of the private endpoint connection. </param>
        internal PrivateEndpointConnectionItem(string id, string etag, PrivateEndpoint privateEndpoint, PrivateLinkServiceConnectionState privateLinkServiceConnectionState, PrivateEndpointConnectionProvisioningState? provisioningState) : base(id)
        {
            Etag = etag;
            PrivateEndpoint = privateEndpoint;
            PrivateLinkServiceConnectionState = privateLinkServiceConnectionState;
            ProvisioningState = provisioningState;
        }

        /// <summary> Modified whenever there is a change in the state of private endpoint connection. </summary>
        public string Etag { get; }
        /// <summary> Properties of the private endpoint object. </summary>
        public PrivateEndpoint PrivateEndpoint { get; }
        /// <summary> Approval state of the private link connection. </summary>
        public PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; }
        /// <summary> Provisioning state of the private endpoint connection. </summary>
        public PrivateEndpointConnectionProvisioningState? ProvisioningState { get; }
    }
}
