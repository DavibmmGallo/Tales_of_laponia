using System;
using System.Collections.Generic;
using System.Text;
using _Enter_name__backend.Items;

namespace _Enter_name__backend.Isekaied
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

        public void take_dmg(double dmg);
        public void gain_HP(double heal);
    }
}
