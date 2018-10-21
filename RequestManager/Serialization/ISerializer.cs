using System;
using System.Collections.Generic;
using System.Text;

namespace SWriter.RequestManager.Serialization
{
    public interface ISerializer<T, U>
    {
        U SerializeFrom(T content);
        T DeserializeFrom(U content);
    }

    public interface ISerializer<T> : ISerializer<T, string>
    {
    }
}
