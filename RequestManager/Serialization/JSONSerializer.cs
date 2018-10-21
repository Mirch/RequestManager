using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWriter.RequestManager.Serialization
{
    public class JSONSerializer<T> : ISerializer<T>
    {
        public T DeserializeFrom(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        public string SerializeFrom(T content)
        {
            return JsonConvert.SerializeObject(content);
        }
    }
}
