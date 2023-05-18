using System;
using System.Collections.Generic;

[Serializable]
public class Config
{
    public Tips tips;
    
    [Serializable]
    public class Tips
    {
        public string closeReading;
        public List<ItemTips> itemTips;
    }

    [Serializable]
    public class ItemTips
    {
        public string itemName;
        public List<TipForPhase> tipsForPhases;
    }
    
    [Serializable]
    public class TipForPhase
    {
        public string phase;
        public string tip;
    }
}