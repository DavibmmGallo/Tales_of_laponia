using System;
using System.Collections.Generic;
using System.Text;

namespace Tales_of_laponian_front.Characters.Classes
{
    public class Swordsman : Cbase
    {
        public Swordsman(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money)
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money) {
            dmg_b = 15;
            atk1 += Swordsman_atk1;
            atk2 += Swordsman_atk2;
            atk3 += Swordsman_atk3;
            atk4 += Swordsman_atk4;
        }

        private void Swordsman_atk4(object sender, EventArgs e)
        {
            Blood_gilhotine(current_enemy);
        }

        private void Swordsman_atk3(object sender, EventArgs e)
        {
            Blink_Slash(current_enemy);
        }

        private void Swordsman_atk2(object sender, EventArgs e)
        {
            Bleeding_Strike(current_enemy);
        }

        private void Swordsman_atk1(object sender, EventArgs e)
        {
            Fatal_Slash(current_enemy);
        }

        public double Fatal_Slash(Cbase enemy)
        {
            enemy.take_dmg(Strength + 25 + ((MAXHP/HP) * Lvl / 10) * CP);
            return enemy.HP;
        }
        /// <summary>
        /// um golpe tao preciso nas correntes sanguineas do inimigo , causando dano com base em CP e sua forca
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public double Bleeding_Strike(Cbase enemy)
        {
            enemy.take_dmg(Strength * 2 + dmg_b+CP);
            return enemy.HP;
        }
        /// <summary>
        /// da um dash ate o inimigo causando cegueira nele 
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public double Blink_Slash(Cbase enemy)
        {
            enemy.take_dmg(dmg_b* CP + Strength*(Lvl/enemy.Lvl) +50);
            return enemy.HP;
        }
        /// <summary>
        /// ergue a espada como uma guilhotina e corta a resistencia do ar tao rápido quanto uma busca binaria em uma arvore binaria
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public double Blood_gilhotine(Cbase enemy)
        {
            if(enemy.HP <= enemy.MAXHP * 0.7)
            {
                enemy.take_dmg(dmg_b*enemy.HP);
            }
            else
            {
                gain_HP(20*Lvl);
            }
            
            return enemy.HP;
        }
        public override string get_atk_name(int i)
        {
            if (i == 1)
                return "Fatal Slash";
            else if (i == 2)
                return "Bleeding Strike";
            else if (i == 3)
                return "Blink Slash";
            else if (i == 4)
                return "Blood gilhotine";

            return "Atk" + i;
        }
    }
}