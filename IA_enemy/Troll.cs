using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales_of_laponian_front.Characters;

namespace Tales_of_laponian_front.IA_enemy
{
    public class Troll : IA__generic
    {
        public Troll(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money, string fp)
         : base(HP, CP, MP, Str_, Tough, intelli, lvl, money, fp)
        {
            dmg_b = 30;
            filepath = fp;
            atk1 += Troll_atk1;
            atk2 += Troll_atk2;
        }

        private void Troll_atk2(object sender, EventArgs e)
        {
            Earthquake(current_enemy);
        }

        private void Troll_atk1(object sender, EventArgs e)
        {
            superior_punch(current_enemy);
        }

        public void superior_punch(Cbase enemy)
        {
            enemy.take_dmg(dmg_b + Strength + 150);
        }
        public void Earthquake(Cbase enemy)
        {
            enemy.take_dmg(dmg_b + enemy.HP/3);
        }

        public static Troll Convert_to_Troll(IA__generic ia)
        {
            var t = new Troll(ia.HP, ia.CP, ia.MP, ia.Strength, ia.Toughness, ia.Intelligence, ia.Lvl, ia.Money, "ms-appx:///Assets/troll.png");
            return t;
        }
    }
}
