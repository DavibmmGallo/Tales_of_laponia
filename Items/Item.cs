using System;
using System.Collections.Generic;
using System.Text;
using Tales_of_laponian_front.Characters;
namespace Tales_of_laponian_front.Items
{
    public class Item
    {
        public int ID { get; protected set; } // ID
        public double dmg { get; set; } // weapons and stuff
        public string rarity { get; set; } // just for front
        public double Mana_increase { get; set; } // magical stuff
        
        public delegate void UseEventHandler(object sender, EventArgs e);
        public event UseEventHandler Use_item;

        public Item()
        {
            Use_item += Usar;
        }
        /// <summary>
        /// Para consumiveis serem usados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Usar(object sender, EventArgs e)
        {
            var tt = sender as Cbase;
            use_method(tt);
        }
        public void use_method(Cbase target)
        {
            switch (ID)
            {
                case 3:
                    target.gain_HP(Mana_increase);
                    break;
                case 4:
                    target.gain_MP(Mana_increase);
                    break;
                default:
                    break;
            }
        }
    }    
}
