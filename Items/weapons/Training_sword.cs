using System;
using System.Collections.Generic;
using System.Text;

namespace Tales_of_laponian_front.Items.weapons
{
    class Training_sword:Item
    {
        public Training_sword()
        {
            dmg = 4.5;
            rarity = "Common";
            Mana_increase = 0;
            can_break_obj = false;
            ID = 1;
        }
    }
}
