﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Storage.Blobs.Tests
{
    public class DisposingContainer : IAsyncDisposable
    {
        public BlobContainerClient Container;

        public DisposingContainer(BlobContainerClient client)
        {
            Container = client;
        }

        public async ValueTask DisposeAsync()
        {
            if (Container != null)
            {
                try
                {
                    await Container.DeleteIfExistsAsync();
                    Container = null;
                }
                catch
                {
                    // swallow the exception to avoid hiding another test failure
                }
            }
        }
    }
}
