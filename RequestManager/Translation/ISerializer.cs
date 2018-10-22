using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SWriter.RequestManager.Translation
{
    public interface ISerializer<T, U>
    {
        U SerializeFrom(T content);
    }

    public interface ISerializer<T> : ISerializer<T, string>
    {
    }
}
