using SWriter.RequestManager.Translation;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using SWriter.RequestManager.Helpers;

namespace SWriter.RequestManager.Translation
{
    public class FormTranslator<T> : ITranslator<T, FormUrlEncodedContent> where T : new()
    {
        public T DeserializeFrom(FormUrlEncodedContent content)
        {
            string stringRepresentation = content.ReadAsStringAsync().Result;
            string[] tokens = stringRepresentation.Split('&');

            T result = new T();

            foreach (string token in tokens)
            {
                string[] keyValue = token.Split('=');
                string key = keyValue[0];
                string value = keyValue[1];

                var props = result.GetType().GetProperties();
                var prop = props.SingleOrDefault(p => p.Name == key);
                
                if (prop != null) prop.SetValue(result, value.ToObject(result, prop.Name));

            }
            return result;
        }

        public FormUrlEncodedContent SerializeFrom(T content)
        {
            ICollection<KeyValuePair<string, string>> values = new LinkedList<KeyValuePair<string, string>>();
            foreach (var prop in content.GetType().GetProperties())
            {
                var propName = prop.Name;
                var value = prop.GetValue(content).ToString();
                values.Add(new KeyValuePair<string, string>(propName, value));
            }
            return new FormUrlEncodedContent(values);
        }
    }
}
