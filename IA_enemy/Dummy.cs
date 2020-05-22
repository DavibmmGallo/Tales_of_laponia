using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales_of_laponian_front.IA_enemy
{
    public class Dummy : IA__generic
    {
        public bool can_reflect = false;
        public Dummy(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money)
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money) { }

        public void set_reflect(bool signal)
        {
            can_reflect = signal;
        }
    }
}
