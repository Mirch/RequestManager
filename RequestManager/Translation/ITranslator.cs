using System;
using System.Collections.Generic;
using System.Text;

namespace SWriter.RequestManager.Translation
{
    public interface ITranslator<T, U> : ISerializer<T,U>, IDeserializer<T, U>
    {
    }

    public interface ITranslator<T> : ISerializer<T>, IDeserializer<T>
    {
    }
}
