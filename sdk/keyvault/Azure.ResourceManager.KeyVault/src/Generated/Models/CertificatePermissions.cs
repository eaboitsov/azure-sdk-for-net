// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.KeyVault.Models
{
    /// <summary> The CertificatePermissions. </summary>
    public readonly partial struct CertificatePermissions : IEquatable<CertificatePermissions>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="CertificatePermissions"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public CertificatePermissions(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string GetValue = "get";
        private const string ListValue = "list";
        private const string DeleteValue = "delete";
        private const string CreateValue = "create";
        private const string ImportValue = "import";
        private const string UpdateValue = "update";
        private const string ManagecontactsValue = "managecontacts";
        private const string GetissuersValue = "getissuers";
        private const string ListissuersValue = "listissuers";
        private const string SetissuersValue = "setissuers";
        private const string DeleteissuersValue = "deleteissuers";
        private const string ManageissuersValue = "manageissuers";
        private const string RecoverValue = "recover";
        private const string PurgeValue = "purge";
        private const string BackupValue = "backup";
        private const string RestoreValue = "restore";

        /// <summary> get. </summary>
        public static CertificatePermissions Get { get; } = new CertificatePermissions(GetValue);
        /// <summary> list. </summary>
        public static CertificatePermissions List { get; } = new CertificatePermissions(ListValue);
        /// <summary> delete. </summary>
        public static CertificatePermissions Delete { get; } = new CertificatePermissions(DeleteValue);
        /// <summary> create. </summary>
        public static CertificatePermissions Create { get; } = new CertificatePermissions(CreateValue);
        /// <summary> import. </summary>
        public static CertificatePermissions Import { get; } = new CertificatePermissions(ImportValue);
        /// <summary> update. </summary>
        public static CertificatePermissions Update { get; } = new CertificatePermissions(UpdateValue);
        /// <summary> managecontacts. </summary>
        public static CertificatePermissions Managecontacts { get; } = new CertificatePermissions(ManagecontactsValue);
        /// <summary> getissuers. </summary>
        public static CertificatePermissions Getissuers { get; } = new CertificatePermissions(GetissuersValue);
        /// <summary> listissuers. </summary>
        public static CertificatePermissions Listissuers { get; } = new CertificatePermissions(ListissuersValue);
        /// <summary> setissuers. </summary>
        public static CertificatePermissions Setissuers { get; } = new CertificatePermissions(SetissuersValue);
        /// <summary> deleteissuers. </summary>
        public static CertificatePermissions Deleteissuers { get; } = new CertificatePermissions(DeleteissuersValue);
        /// <summary> manageissuers. </summary>
        public static CertificatePermissions Manageissuers { get; } = new CertificatePermissions(ManageissuersValue);
        /// <summary> recover. </summary>
        public static CertificatePermissions Recover { get; } = new CertificatePermissions(RecoverValue);
        /// <summary> purge. </summary>
        public static CertificatePermissions Purge { get; } = new CertificatePermissions(PurgeValue);
        /// <summary> backup. </summary>
        public static CertificatePermissions Backup { get; } = new CertificatePermissions(BackupValue);
        /// <summary> restore. </summary>
        public static CertificatePermissions Restore { get; } = new CertificatePermissions(RestoreValue);
        /// <summary> Determines if two <see cref="CertificatePermissions"/> values are the same. </summary>
        public static bool operator ==(CertificatePermissions left, CertificatePermissions right) => left.Equals(right);
        /// <summary> Determines if two <see cref="CertificatePermissions"/> values are not the same. </summary>
        public static bool operator !=(CertificatePermissions left, CertificatePermissions right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="CertificatePermissions"/>. </summary>
        public static implicit operator CertificatePermissions(string value) => new CertificatePermissions(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CertificatePermissions other && Equals(other);
        /// <inheritdoc />
        public bool Equals(CertificatePermissions other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
