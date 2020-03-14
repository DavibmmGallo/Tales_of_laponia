using System;
using System.Collections.Generic;
using System.Text;
using _Enter_name__backend.Items;

namespace _Enter_name__backend.History.Quests
{
    /// <summary>
    /// Base para fazer as quests 
    /// 
    /// 
    /// </summary>
    class quest_base
    {
        public double gain_xp { get; set; }
        public string Briefing { get; set; }
        
        public bool isQuestdone = false;
        public Item Reward { get; set; }

    }
}
