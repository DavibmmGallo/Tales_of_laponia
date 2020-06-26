using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales_of_laponian_front.Items.misc
{
    class HealthPotion:Item
    {
        public HealthPotion()
        {
            dmg = 0;
            rarity = "Common";
            Mana_increase = 100;// vida
            ID = 3;
        }
    }
}
