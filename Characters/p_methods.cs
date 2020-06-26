using System;
using System.Collections.Generic;
using System.Text;
//using Tales_of_laponian_front.Items;

namespace Tales_of_laponian_front.Characters
{
    interface p_methods
    {
        /// <summary>
        /// a INTERFACE p_methods só serve para linkar os metodos que todas as entidades devem possuir em batalha
        /// </summary>
        /// <param name="dmg"></param>
        void take_dmg(double dmg);
        void gain_HP(double heal);
        void gain_MP(double heal);
        void lose_money(int dola);
    }
}
