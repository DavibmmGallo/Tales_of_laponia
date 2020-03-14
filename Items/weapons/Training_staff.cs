using System;
using System.Collections.Generic;
using System.Text;

namespace _Enter_name__backend.Items.weapons
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
