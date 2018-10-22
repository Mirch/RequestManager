using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace SWriter.RequestManager.Translation
{
    public class TranslatorFactory
    {
        private static ConcurrentDictionary<ContentType, ITranslator<object>> _TRANSLATORS = new ConcurrentDictionary<ContentType, ITranslator<object>>(); 

        private TranslatorFactory() { }

        public static ITranslator<T> GetTranslator<T>(ContentType type)
        {
            ITranslator<T> translator = _TRANSLATORS.GetValueOrDefault(type) as ITranslator<T>;

            if (translator != null) return translator; 

            switch(type)
            {
                case ContentType.JSON:
                    translator = new JSONTranslator<T>();
                    break;
                default:
                    translator = new JSONTranslator<T>();
                    break;
            }

            _TRANSLATORS.TryAdd(type, translator as ITranslator<object>);
            return translator;
        }
    }
}
