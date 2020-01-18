using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace shitbomber.jogo.domain.Extensions
{
    public static class SerializerDeserializerExtensions
    {
        public static byte[] Serializer(this object _object)
        {

            string objJson = JsonConvert.SerializeObject(_object);
            return Encoding.UTF8.GetBytes(objJson);
        }

        public static T Deserializer<T>(this byte[] _byteArray)
        {

            string jsonObject = Encoding.UTF8.GetString(_byteArray);
            return JsonConvert.DeserializeObject<T>(jsonObject);
        }
    }
}
