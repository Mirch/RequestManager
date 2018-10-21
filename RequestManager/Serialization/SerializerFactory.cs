using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace SWriter.RequestManager.Serialization
{
    public class SerializerFactory
    {
        private static ConcurrentDictionary<ContentType, ISerializer<object>> _SERIALIZERS = new ConcurrentDictionary<ContentType, ISerializer<object>>(); 

        private SerializerFactory() { }

        public static ISerializer<T> CreateSerializer<T>(ContentType type)
        {
            ISerializer<T> serializer = _SERIALIZERS.GetValueOrDefault(type) as ISerializer<T>;

            if (serializer != null) return serializer; 

            switch(type)
            {
                case ContentType.JSON:
                    serializer = new JSONSerializer<T>();
                    break;
                default:
                    serializer = new JSONSerializer<T>();
                    break;
            }

            _SERIALIZERS.TryAdd(type, serializer as ISerializer<object>);
            return serializer;
        }
    }
}
