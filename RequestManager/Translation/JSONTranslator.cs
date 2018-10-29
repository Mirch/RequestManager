using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWriter.RequestManager.Translation
{
    public class JSONTranslator<T> : ITranslator<T> where T : new()
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
