using System.Text.Json;
using System.Text.Json.Serialization;

namespace RandomUser.Infrastructure.Persistence.Seed;

public class StringConverter : JsonConverter<string>
{
    // https://stackoverflow.com/questions/71183483/how-to-force-a-particular-property-to-be-deserialized-as-string-instead-of-numbe
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            var stringValue = reader.GetInt32();
            return stringValue.ToString();
        }
        else if (reader.TokenType == JsonTokenType.String)
        {
            return reader.GetString();
        }
        
        throw new System.Text.Json.JsonException();
    }
    
    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}