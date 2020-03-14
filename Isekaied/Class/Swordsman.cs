using System;
using System.Collections.Generic;
using System.Text;

namespace _Enter_name__backend.Isekaied.Class
{
    public class Swordsman : Ibase
    {
        public Swordsman(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money)
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money) { }

        public double Fatal_Slash(Ibase enemy)
        {
            enemy.take_dmg(Strength +50+((MAXHP - HP)*Lvl/10)*CP);
            if (enemy.isDead) Lvl += (1.21 + enemy.Lvl * 0.618);

            return enemy.HP;
        }
        public double Bleeding_Strike(Ibase enemy)
        {
            enemy.take_dmg(Strength * 2);
            //a cada segundo por um periodo a determinar dar 1 tick de dano
            //dano a discutir
            return enemy.HP;
        }

        public void Blink_Slash(Ibase enemy)
        {
            // move-se até um alcance de 5 blocos e da dano no inimigo em linha reta
        }
    }
}
