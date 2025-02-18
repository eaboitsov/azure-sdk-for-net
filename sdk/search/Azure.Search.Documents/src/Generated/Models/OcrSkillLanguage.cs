// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Search.Documents.Indexes.Models
{
    /// <summary> The language codes supported for input by OcrSkill. </summary>
    public readonly partial struct OcrSkillLanguage : IEquatable<OcrSkillLanguage>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="OcrSkillLanguage"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public OcrSkillLanguage(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ZhHansValue = "zh-Hans";
        private const string ZhHantValue = "zh-Hant";
        private const string CsValue = "cs";
        private const string DaValue = "da";
        private const string NlValue = "nl";
        private const string EnValue = "en";
        private const string FiValue = "fi";
        private const string FrValue = "fr";
        private const string DeValue = "de";
        private const string ElValue = "el";
        private const string HuValue = "hu";
        private const string ItValue = "it";
        private const string JaValue = "ja";
        private const string KoValue = "ko";
        private const string NbValue = "nb";
        private const string PlValue = "pl";
        private const string PtValue = "pt";
        private const string RuValue = "ru";
        private const string EsValue = "es";
        private const string SvValue = "sv";
        private const string TrValue = "tr";
        private const string ArValue = "ar";
        private const string RoValue = "ro";
        private const string SrCyrlValue = "sr-Cyrl";
        private const string SrLatnValue = "sr-Latn";
        private const string SkValue = "sk";

        /// <summary> Chinese-Simplified. </summary>
        public static OcrSkillLanguage ZhHans { get; } = new OcrSkillLanguage(ZhHansValue);
        /// <summary> Chinese-Traditional. </summary>
        public static OcrSkillLanguage ZhHant { get; } = new OcrSkillLanguage(ZhHantValue);
        /// <summary> Czech. </summary>
        public static OcrSkillLanguage Cs { get; } = new OcrSkillLanguage(CsValue);
        /// <summary> Danish. </summary>
        public static OcrSkillLanguage Da { get; } = new OcrSkillLanguage(DaValue);
        /// <summary> Dutch. </summary>
        public static OcrSkillLanguage Nl { get; } = new OcrSkillLanguage(NlValue);
        /// <summary> English. </summary>
        public static OcrSkillLanguage En { get; } = new OcrSkillLanguage(EnValue);
        /// <summary> Finnish. </summary>
        public static OcrSkillLanguage Fi { get; } = new OcrSkillLanguage(FiValue);
        /// <summary> French. </summary>
        public static OcrSkillLanguage Fr { get; } = new OcrSkillLanguage(FrValue);
        /// <summary> German. </summary>
        public static OcrSkillLanguage De { get; } = new OcrSkillLanguage(DeValue);
        /// <summary> Greek. </summary>
        public static OcrSkillLanguage El { get; } = new OcrSkillLanguage(ElValue);
        /// <summary> Hungarian. </summary>
        public static OcrSkillLanguage Hu { get; } = new OcrSkillLanguage(HuValue);
        /// <summary> Italian. </summary>
        public static OcrSkillLanguage It { get; } = new OcrSkillLanguage(ItValue);
        /// <summary> Japanese. </summary>
        public static OcrSkillLanguage Ja { get; } = new OcrSkillLanguage(JaValue);
        /// <summary> Korean. </summary>
        public static OcrSkillLanguage Ko { get; } = new OcrSkillLanguage(KoValue);
        /// <summary> Norwegian (Bokmaal). </summary>
        public static OcrSkillLanguage Nb { get; } = new OcrSkillLanguage(NbValue);
        /// <summary> Polish. </summary>
        public static OcrSkillLanguage Pl { get; } = new OcrSkillLanguage(PlValue);
        /// <summary> Portuguese. </summary>
        public static OcrSkillLanguage Pt { get; } = new OcrSkillLanguage(PtValue);
        /// <summary> Russian. </summary>
        public static OcrSkillLanguage Ru { get; } = new OcrSkillLanguage(RuValue);
        /// <summary> Spanish. </summary>
        public static OcrSkillLanguage Es { get; } = new OcrSkillLanguage(EsValue);
        /// <summary> Swedish. </summary>
        public static OcrSkillLanguage Sv { get; } = new OcrSkillLanguage(SvValue);
        /// <summary> Turkish. </summary>
        public static OcrSkillLanguage Tr { get; } = new OcrSkillLanguage(TrValue);
        /// <summary> Arabic. </summary>
        public static OcrSkillLanguage Ar { get; } = new OcrSkillLanguage(ArValue);
        /// <summary> Romanian. </summary>
        public static OcrSkillLanguage Ro { get; } = new OcrSkillLanguage(RoValue);
        /// <summary> Serbian (Cyrillic, Serbia). </summary>
        public static OcrSkillLanguage SrCyrl { get; } = new OcrSkillLanguage(SrCyrlValue);
        /// <summary> Serbian (Latin, Serbia). </summary>
        public static OcrSkillLanguage SrLatn { get; } = new OcrSkillLanguage(SrLatnValue);
        /// <summary> Slovak. </summary>
        public static OcrSkillLanguage Sk { get; } = new OcrSkillLanguage(SkValue);
        /// <summary> Determines if two <see cref="OcrSkillLanguage"/> values are the same. </summary>
        public static bool operator ==(OcrSkillLanguage left, OcrSkillLanguage right) => left.Equals(right);
        /// <summary> Determines if two <see cref="OcrSkillLanguage"/> values are not the same. </summary>
        public static bool operator !=(OcrSkillLanguage left, OcrSkillLanguage right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="OcrSkillLanguage"/>. </summary>
        public static implicit operator OcrSkillLanguage(string value) => new OcrSkillLanguage(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is OcrSkillLanguage other && Equals(other);
        /// <inheritdoc />
        public bool Equals(OcrSkillLanguage other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
