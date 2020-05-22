using System;
using System.Collections.Generic;
using System.Text;
//using Tales_of_laponian_front.Items;

namespace Tales_of_laponian_front.Characters
{
    interface p_methods
    {
        //Keyboard listener


        //Movements
        /*
         * <UP> = W
         * <DOWN> = S 
         * <RIGHT> = D
         * <LEFT> = A
         * 
         */

        //Interact
        //<E>

        //Attack
        //<SPACE>

        void take_dmg(double dmg);
        void gain_HP(double heal);
    }
}
