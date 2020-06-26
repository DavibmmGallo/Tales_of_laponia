using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales_of_laponian_front.Characters;

namespace Tales_of_laponian_front.IA_enemy
{
    public class BOSS : IA__generic
    {
        public BOSS(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money, string fp)
        : base(HP, CP, MP, Str_, Tough, intelli, lvl, money, fp)
        {
            dmg_b = 10;
            filepath = fp;
            atk1 += BOSS_atk1;
            atk2 += BOSS_atk2;
            atk3 += BOSS_atk3;
            atk4 += BOSS_atk4;
        }

        private void BOSS_atk4(object sender, EventArgs e)
        {
            NaN_attk(current_enemy);
        }

        private void BOSS_atk3(object sender, EventArgs e)
        {
            Chamuscada(current_enemy);
        }

        private void BOSS_atk2(object sender, EventArgs e)
        {
            Nazimbo(current_enemy);
        }

        private void BOSS_atk1(object sender, EventArgs e)
        {
            single_thread(current_enemy);
        }

        public void single_thread(Cbase enemy)
        {
            enemy.take_dmg(dmg_b + Strength + 1025);
        }
        public void Chamuscada(Cbase enemy)
        {
            enemy.take_dmg(dmg_b + Strength + 1030);
        }
        public void NaN_attk(Cbase enemy)
        {
            enemy.take_dmg(10000);
        }
        public void Nazimbo(Cbase enemy)
        {
            enemy.take_dmg(dmg_b + Strength + 1040);
            untouchable = true;
        }

    }
}
