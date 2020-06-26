using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales_of_laponian_front.Characters;

namespace Tales_of_laponian_front.IA_enemy
{
    class Rat : IA__generic
    {
        public Rat(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money, string fp)
       : base(HP, CP, MP, Str_, Tough, intelli, lvl, money, fp)
        {
            dmg_b = 20;
            filepath = fp;
            atk1 += Rat_atk1;
            atk2 += Rat_atk2;
        }

        private void Rat_atk2(object sender, EventArgs e)
        {
            Flesh_cutter(current_enemy);
        }

        private void Rat_atk1(object sender, EventArgs e)
        {
            bite(current_enemy);
        }

        public void bite(Cbase enemy)
        {
            enemy.take_dmg(dmg_b + Strength + 90);
        }
        public void Flesh_cutter(Cbase enemy)
        {
            enemy.take_dmg(enemy.HP/5);
        }

        public static Rat Convert_to_Rat(IA__generic ia)
        {
            var t = new Rat(ia.HP, ia.CP, ia.MP, ia.Strength, ia.Toughness, ia.Intelligence, ia.Lvl, ia.Money, "ms-appx:///Assets/rato.gif");
            return t;
        }
    }
}
