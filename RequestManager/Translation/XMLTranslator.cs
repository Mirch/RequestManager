using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SWriter.RequestManager.Translation
{
    public class XMLTranslator<T> : ITranslator<T>
    {
        private System.Xml.Serialization.XmlSerializer _serializer;

        public XMLTranslator()
        {
            _serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
        }

        public T DeserializeFrom(string content)
        {
            T result;

            using (TextReader reader = new StringReader(content))
            {
                result = (T)(_serializer.Deserialize(reader));
            }

            return result;
        }

        public string SerializeFrom(T content)
        {
            var sb = new StringBuilder();

            using (TextWriter writer = new StringWriter(sb))
            {
                _serializer.Serialize(writer, content);
            }

            return sb.ToString();
        }
    }