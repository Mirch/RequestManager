using Newtonsoft.Json;
using SWriter.RequestManager.Translation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWriter.RequestManager
{
    public class Response
    {
        public bool Success { get; set; }
        public string Content { get; set; }

        public T ResultAs<T>(ContentType type = ContentType.JSON) where T : new()
        {
            IDeserializer<T> serializer = TranslatorFactory.GetTranslator<T>(type);

            return serializer.DeserializeFrom(Content);
        }
    }
}
