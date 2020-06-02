using System;
using System.Collections.Generic;
using System.Text;

namespace Tales_of_laponian_front.Characters.Classes
{
    public class Swordsman : Cbase
    {
        public Swordsman(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money)
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money) { dmg_b = 15; }

        public double Fatal_Slash(Cbase enemy)
        {
            enemy.take_dmg(Strength +50+((MAXHP - HP)*Lvl/10)*CP);
            if (enemy.isDead) Lvl += (1.21 + enemy.Lvl * 0.618);

            return enemy.HP;
        }
        public double Bleeding_Strike(Cbase enemy)
        {
            enemy.take_dmg(Strength * 2+dmg_b);
            return enemy.HP;
        }

        public void Blink_Slash(Cbase enemy)
        {
            enemy.take_dmg(dmg_b);
        }
    }
}
