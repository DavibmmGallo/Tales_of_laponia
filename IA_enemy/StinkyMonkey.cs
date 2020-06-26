using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales_of_laponian_front.Characters;

namespace Tales_of_laponian_front.IA_enemy
{
    public class StinkyMonkey : IA__generic
    {
        public StinkyMonkey(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money, string fp)
         : base(HP, CP, MP, Str_, Tough, intelli, lvl, money, fp)
        {
            dmg_b = 15;
            filepath = fp;
            atk1 += StinkyMonkey_atk1;
            atk2 += StinkyMonkey_atk2;
        }

        private void StinkyMonkey_atk2(object sender, EventArgs e)
        {
            Rasteira(current_enemy);
        }

        private void StinkyMonkey_atk1(object sender, EventArgs e)
        {
            Punch(current_enemy);
        }

        public void Punch(Cbase enemy)
        {
            enemy.take_dmg(dmg_b + Strength + 55);
        }
        public void Rasteira(Cbase enemy)
        {
            enemy.take_dmg(dmg_b * Strength + 40);
            untouchable = true;
        }

        public static StinkyMonkey Convert_to_monkey(IA__generic ia)
        {
            var t = new StinkyMonkey(ia.HP, ia.CP, ia.MP, ia.Strength, ia.Toughness, ia.Intelligence, ia.Lvl, ia.Money, "ms-appx:///Assets/macaco.gif");
            return t;
        }
    }
}
