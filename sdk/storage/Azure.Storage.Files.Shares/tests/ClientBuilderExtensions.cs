﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using ShareClientBuilder = Azure.Storage.Test.Shared.ClientBuilder<
    Azure.Storage.Files.Shares.ShareServiceClient,
    Azure.Storage.Files.Shares.ShareClientOptions>;

namespace Azure.Storage.Files.Shares.Tests
{
    public static class ClientBuilderExtensions
    {
        public static string GetNewShareName(this ShareClientBuilder clientBuilder)
            => $"test-share-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewDirectoryName(this ShareClientBuilder clientBuilder)
            => $"test-directory-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewNonAsciiDirectoryName(this ShareClientBuilder clientBuilder)
            => $"test-dire¢t Ø®ϒ%3A-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewFileName(this ShareClientBuilder clientBuilder)
            => $"test-file-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewNonAsciiFileName(this ShareClientBuilder clientBuilder)
            => $"test-ƒ¡£€‽%3A-{clientBuilder.Recording.Random.NewGuid()}";

        public static ShareServiceClient GetServiceClient_SharedKey(this ShareClientBuilder clientBuilder, ShareClientOptions options = default)
            => clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigDefault, options);

        public static ShareServiceClient GetServiceClient_OAuthAccount_SharedKey(this ShareClientBuilder clientBuilder) =>
            clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigOAuth);

        public static ShareServiceClient GetServiceClient_PremiumFile(this ShareClientBuilder clientBuilder) =>
            clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigPremiumFile);

        public static ShareServiceClient GetServiceClient_SoftDelete(this ShareClientBuilder clientBuilder) =>
            clientBuilder.GetServiceClientFromSharedKeyConfig(clientBuilder.Tenants.TestConfigSoftDelete);

        public static async Task<DisposingShare> GetTestShareAsync(
            this ShareClientBuilder clientBuilder,
            ShareServiceClient service = default,
            string shareName = default,
            IDictionary<string, string> metadata = default)
        {
            service ??= clientBuilder.GetServiceClient_SharedKey();
            metadata ??= new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            shareName ??= clientBuilder.GetNewShareName();
            ShareClient share = clientBuilder.AzureCoreRecordedTestBase.InstrumentClient(service.GetShareClient(shareName));
            return await DisposingShare.CreateAsync(share, metadata);
        }

        public static async Task<DisposingDirectory> GetTestDirectoryAsync(
            this ShareClientBuilder clientBuilder,
            ShareServiceClient service = default,
            string shareName = default,
            string directoryName = default)
        {
            DisposingShare test = await clientBuilder.GetTestShareAsync(service, shareName);
            directoryName ??= clientBuilder.GetNewDirectoryName();

            ShareDirectoryClient directory = clientBuilder.AzureCoreRecordedTestBase.InstrumentClient(test.Share.GetDirectoryClient(directoryName));
            return await DisposingDirectory.CreateAsync(test, directory);
        }

        public static async Task<DisposingFile> GetTestFileAsync(
            this ShareClientBuilder clientBuilder,
            ShareServiceClient service = default,
            string shareName = default,
            string directoryName = default,
            string fileName = default)
        {
            DisposingDirectory test = await clientBuilder.GetTestDirectoryAsync(service, shareName, directoryName);
            fileName ??= clientBuilder.GetNewFileName();
            ShareFileClient file = clientBuilder.AzureCoreRecordedTestBase.InstrumentClient(test.Directory.GetFileClient(fileName));
            return await DisposingFile.CreateAsync(test, file);
        }
    }
}
