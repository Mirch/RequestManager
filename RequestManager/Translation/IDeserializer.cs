using System;
using System.Collections.Generic;
using System.Text;

namespace SWriter.RequestManager.Translation
{
    public interface IDeserializer<T, U> where T: new()
    {
        T DeserializeFrom(U content);
    }

    public interface IDeserializer<T> : IDeserializer<T, string> where T: new()
    {
    }
}
