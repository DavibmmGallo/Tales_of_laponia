using System;
using System.Collections.Generic;
using System.Text;

namespace Tales_of_laponian_front.Items.weapons
{
    class Training_staff:Item
    {
        public Training_staff()
        {
            dmg = 3.5;
            rarity = "Common";
            Mana_increase = 100;
            can_break_obj = false;
            ID = 2;
        }
    }
}
