using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales_of_laponian_front.Items.misc
{
    class ManaPotion:Item
    {
        public ManaPotion()
        {
            dmg = 0;
            rarity = "Common";
            Mana_increase = 100;
            ID = 4;
        }
    }
}
