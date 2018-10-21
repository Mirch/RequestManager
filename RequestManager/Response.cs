using Newtonsoft.Json;
using SWriter.RequestManager.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWriter.RequestManager
{
    public class Response
    {
        public bool Success { get; set; }
        public string Content { get; set; }

        public T ResultAs<T>(ContentType type = ContentType.JSON)
        {
            ISerializer<T> serializer = SerializerFactory.CreateSerializer<T>(type);

            return serializer.DeserializeFrom(Content);
        }
    }
}
