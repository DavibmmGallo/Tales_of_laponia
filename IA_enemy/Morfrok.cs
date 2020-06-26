using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales_of_laponian_front.Characters;

namespace Tales_of_laponian_front.IA_enemy
{
    public class Morfrok : IA__generic
    {
        public Morfrok(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money,string fp)
         : base(HP, CP, MP, Str_, Tough, intelli, lvl, money,fp)
        { 
            dmg_b = 10;
            filepath = fp;
            atk1 += Morfrok_atk1;
            atk2 += Morfrok_atk2;
        }

        private void Morfrok_atk2(object sender, EventArgs e)
        {
            perfuracao_aquatica(current_enemy);
        }

        private void Morfrok_atk1(object sender, EventArgs e)
        {
            Mordida_aidetica(current_enemy);
        }

        public void Mordida_aidetica(Cbase enemy)
        {
            enemy.take_dmg(dmg_b+enemy.Lvl + 25);
        }
        public void perfuracao_aquatica(Cbase enemy)
        {
            enemy.take_dmg(dmg_b + enemy.Lvl + Strength + 40);
        }

        public static Morfrok Convert_to_morfrok(IA__generic ia)
        {
            var t = new Morfrok(ia.HP, ia.CP, ia.MP, ia.Strength, ia.Toughness, ia.Intelligence, ia.Lvl, ia.Money, "ms-appx:///Assets/frog.gif");
            return t;
        }
    }
}
