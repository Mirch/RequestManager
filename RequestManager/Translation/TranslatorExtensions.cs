using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SWriter.RequestManager.Translation
{
    public static class TranslatorExtensions
    {
        public static StringContent ToStringContent(this string str, ContentType contentType)
        {
            string content = "";
            switch(contentType)
            {
                case ContentType.JSON:
                    content = "application/json";
                    break;
                case ContentType.XML:
                    content = "application/xml";
                    break;
            }
            return new StringContent(str, Encoding.UTF8, content);
        }
    }
}
