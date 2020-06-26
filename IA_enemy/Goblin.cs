using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales_of_laponian_front.Characters;

namespace Tales_of_laponian_front.IA_enemy
{
    public class Goblin : IA__generic
    {
        public Goblin(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money, string fp)
         : base(HP, CP, MP, Str_, Tough, intelli, lvl, money, fp)
        {
            dmg_b = 10;
            filepath = fp;
            atk1 += Goblin_atk1;
            atk2 += Goblin_atk2;
        }

        private void Goblin_atk2(object sender, EventArgs e)
        {
            Nazimbo(current_enemy);
        }

        private void Goblin_atk1(object sender, EventArgs e)
        {
            Machadada(current_enemy);
        }

        public void Machadada(Cbase enemy)
        {
            enemy.take_dmg(dmg_b + Strength + 25);
        }
        public void Nazimbo(Cbase enemy)
        {
            enemy.take_dmg(dmg_b + Strength + 40);
            untouchable = true;
        }

        public static Goblin Convert_to_goblin(IA__generic ia)
        {
            var t = new Goblin(ia.HP, ia.CP, ia.MP, ia.Strength, ia.Toughness, ia.Intelligence, ia.Lvl, ia.Money, "ms-appx:///Assets/goblin.gif");
            return t;
        }
    }
}
