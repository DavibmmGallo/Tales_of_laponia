using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales_of_laponian_front.Characters;

namespace Tales_of_laponian_front.IA_enemy
{
    public class Slime : IA__generic
    {
        public Slime(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money, string fp)
         : base(HP, CP, MP, Str_, Tough, intelli, lvl, money, fp)
        {
            dmg_b = 10;
            filepath = fp;
            atk1 += Slime_atk1;
            atk2 += Slime_atk2;
        }

        private void Slime_atk2(object sender, EventArgs e)
        {
            poison_bounce(current_enemy);
        }

        private void Slime_atk1(object sender, EventArgs e)
        {
            gruss(current_enemy);
        }

        public void gruss(Cbase enemy)
        {
            enemy.take_dmg(dmg_b + Strength + 100);
        }
        public void poison_bounce(Cbase enemy)
        {
            enemy.take_dmg(dmg_b + Strength + 120);
        }

        public static Slime Convert_to_Slime(IA__generic ia)
        {
            var t = new Slime(ia.HP, ia.CP, ia.MP, ia.Strength, ia.Toughness, ia.Intelligence, ia.Lvl, ia.Money, "ms-appx:///Assets/slime.gif");
            return t;
        }
    }
}
