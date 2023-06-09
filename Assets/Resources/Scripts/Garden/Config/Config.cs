using System;
using System.Collections.Generic;

namespace Garden
{
    [Serializable]
    public class Config
    {
        public Tips tips;
        public List<ItemText> texts;

        [Serializable]
        public class ItemText
        {
            public string itemName;
            public string text;
        }
    
        [Serializable]
        public class Tips
        {
            public string closeReading;
            public List<ItemActionTips> itemActionTips;
        }

        [Serializable]
        public class ItemActionTips
        {
            public string itemName;
            public List<TipForItemPresent> tipsForItemsPresent;
        }
    
        [Serializable]
        public class TipForItemPresent
        {
            public string itemPresent;
            public string tip;
            public int priority;
        }
    }
}