using System;
using System.Collections.Generic;

namespace Common
{
    [Serializable]
    public class LanguagesConfig
    {
        public List<string> languages;
        public int defaultLanguageIndex;
    }
}