using System;
using FullSerializer;

namespace Serialization
{
    public static class SerializationHandler
    {
        private static readonly fsSerializer Serializer = new fsSerializer();

        /// <summary>
        /// Serializes an object into a JSON string
        /// It uses the FullSerializer library: https://github.com/jacobdufault/fullserializer
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <param name="prettyJson">Whether the JSON should be human readable or not</param>
        /// <returns>Serialized object</returns>
        public static string FromObjectToJSON(object obj, bool prettyJson)
        {
            fsData data;
            Serializer.TrySerialize(obj.GetType(), obj, out data);

            return prettyJson ? fsJsonPrinter.PrettyJson(data) : fsJsonPrinter.CompressedJson(data);
        }

        /// <summary>
        /// Deserializes a JSON string into an object
        /// It uses the FullSerializer library: https://github.com/jacobdufault/fullserializer
        /// </summary>
        /// <param name="json">The JSON string</param>
        /// <param name="obj">The object in which the JSON string will be deserialized into</param>
        /// <typeparam name="T">Type of the object</typeparam>
        public static void FromJSONToObject<T>(string json, out T obj)
        {
            var data = fsJsonParser.Parse(json);
            object genericObj = null;
            Serializer.TryDeserialize(data, typeof(T), ref genericObj);

            obj = (T) genericObj;
        }
    }
}