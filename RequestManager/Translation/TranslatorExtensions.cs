using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Linq;
using SWriter.RequestManager.Helpers;

namespace SWriter.RequestManager.Translation
{
    public static class TranslatorExtensions
    {
        public static StringContent ToStringContent(this string str, ContentType contentType)
        {
            string content = "";
            switch(contentType)
            {
                case ContentType.JSON:
                    content = "application/json";
                    break;
                case ContentType.XML:
                    content = "application/xml";
                    break;
            }
            return new StringContent(str, Encoding.UTF8, content);
        }

        public static T FromFormToObject<T>(this string content) where T : new()
        {
            string[] tokens = content.Split('&');

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

        public static T FromFormToObject<T>(this FormUrlEncodedContent content) where T : new()
        {
            string representation = content.ReadAsStringAsync().Result;
            return FromFormToObject<T>(representation);
        }

        public static FormUrlEncodedContent FromObjectToFormContent<T>(this T content)
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
