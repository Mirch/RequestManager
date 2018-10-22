using System;
using System.Collections.Generic;
using System.Text;

namespace SWriter.RequestManager.Translation
{
    public interface IDeserializer<T, U>
    {
        T DeserializeFrom(U content);
    }

    public interface IDeserializer<T> : IDeserializer<T, string>
    {
    }
}
