using System;
using System.Collections.Generic;
using System.Text;

namespace _Enter_name__backend.Items
{
    public class Item
    {
        public int ID { get; protected set; }
        public double dmg { get; set; } // weapons and stuff
        public string rarity { get; set; } // just for front
        public double Mana_increase { get; set; } // magical stuff
        public bool can_break_obj { get; set; }// mine aaaaaaaaaa [tools only]
    }
}
