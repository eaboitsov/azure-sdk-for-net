// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Channel Archive heartbeat event data. Schema of the data property of an EventGridEvent for a Microsoft.Media.LiveEventChannelArchiveHeartbeatEventData event. </summary>
    public partial class MediaLiveEventChannelArchiveHeartbeatEventData
    {
        /// <summary> Initializes a new instance of MediaLiveEventChannelArchiveHeartbeatEventData. </summary>
        /// <param name="channelLatencyMs"> Gets the channel latency in ms. </param>
        /// <param name="latencyResultCode"> Gets the latency result code. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="channelLatencyMs"/> or <paramref name="latencyResultCode"/> is null. </exception>
        internal MediaLiveEventChannelArchiveHeartbeatEventData(string channelLatencyMs, string latencyResultCode)
        {
            if (channelLatencyMs == null)
            {
                throw new ArgumentNullException(nameof(channelLatencyMs));
            }
            if (latencyResultCode == null)
            {
                throw new ArgumentNullException(nameof(latencyResultCode));
            }

            ChannelLatencyMs = channelLatencyMs;
            LatencyResultCode = latencyResultCode;
        }

        /// <summary> Gets the channel latency in ms. </summary>
        public string ChannelLatencyMs { get; }
        /// <summary> Gets the latency result code. </summary>
        public string LatencyResultCode { get; }
    }
}
