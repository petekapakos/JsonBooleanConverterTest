using System;
using Newtonsoft.Json;

namespace JsonBooleanConverterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = "{\"name\":\"pete\",\"isAvailable\":\"yes\"}";
            var obj = JsonConvert.DeserializeObject<Unit>(json, new JsonBooleanConverter());
        }
    }
    public class Unit
    {
        public string name { get; set; }
        public bool isAvailable { get; set; }
    }
    public class JsonBooleanConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString().ToLower().Trim();
            switch (value)
            {
                case "true":
                case "yes":
                case "y":
                case "1":
                    return true;
            }
            return false;
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(Boolean))
            {
                return true;
            }
            return false;
        }
    }
}
