using SWriter.RequestManager.Translation;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using SWriter.RequestManager.Helpers;

namespace SWriter.RequestManager.Translation
{
    public class FormTranslator<T> : ITranslator<T> where T : new()
    {
        public T DeserializeFrom(string content)
        {
            return content.FromFormToObject<T>();
        }

        public string SerializeFrom(T content)
        {
            return content.FromObjectToFormContent<T>().ReadAsStringAsync().Result;
        }
    }
}
