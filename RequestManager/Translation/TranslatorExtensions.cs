using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SWriter.RequestManager.Translation
{
    public static class TranslatorExtensions
    {
        public static StringContent ToStringContent(this string str)
        {
            return new StringContent(str);
        }
    }
}
