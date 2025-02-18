// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    [JsonConverter(typeof(SubResourceConverter))]
    public partial class SubResource : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        internal static SubResource DeserializeSubResource(JsonElement element)
        {
            string id = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
            }
            return new SubResource(id);
        }

        internal partial class SubResourceConverter : JsonConverter<SubResource>
        {
            public override void Write(Utf8JsonWriter writer, SubResource model, JsonSerializerOptions options)
            {
                writer.WriteObjectValue(model);
            }
            public override SubResource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeSubResource(document.RootElement);
            }
        }
    }
}
