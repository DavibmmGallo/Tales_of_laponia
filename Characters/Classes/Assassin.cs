using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Tales_of_laponian_front.Items;

namespace Tales_of_laponian_front.Characters.Classes
{
    //Classe [Assassin]
    /// <summary>
    /// 1 - Poison Slash
    /// 2 - Stealth
    /// 3 - Shadow's clone
    /// P - Movement speed 125%
    /// </summary>

    public class Assassin : Cbase
    {
        public Assassin(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money)
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money) {
            dmg_b = 35;
            atk1 += Assassin_atk1;
            atk2 += Assassin_atk2;
            atk3 += Assassin_atk3;
            atk4 += Assassin_atk4;
        }
        public int turn_agr = 0;
        private void Assassin_atk4(object sender, EventArgs e)
        {
            Stab(turn - (turn_agr + 1), current_enemy);
        }
        
        private void Assassin_atk3(object sender, EventArgs e)
        {
            Studds(current_enemy,turn);
        }

        private void Assassin_atk2(object sender, EventArgs e)
        {
            Stealth(turn-(turn_agr+1));
        }

        private void Assassin_atk1(object sender, EventArgs e)
        {
            Poison_slash(current_enemy);
        }

        /// <see cref = "[Assassin] cover his blades with GH_blood, a strong poison that _is_ based on enemy_HP , 
        /// and deals damage based on his Strength + base_damage +(10/per point)"/>
        public double Poison_slash(Cbase enemy)
        {
            enemy.take_dmg(Strength + dmg_b + 20);
            //Console.WriteLine("\t\t DANO INICIAL DO PS HP = " + current_enemy.HP + " t = " + "\n\n");
            return enemy.HP;
        }

        /// <see cref = "Makes [Assassin] invisible to enemies,and doubles it's base_damage along 10sec + (1 sec/per point)"/>
        public void Stealth(int duration)
        {
            if(duration <= 2)
            {
                untouchable = true;
                turn_agr = turn;
                dmg_b *= 2;
            }else
            {
                untouchable = false;
                dmg_b += 1 / 2;
            }
            
        }
        /// <summary>
        /// joga espinhos no chao e o inimigo toma dano ate 4 turnos
        /// </summary>
        /// <param name="enemy"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public double Studds(Cbase enemy,int duration)
        {
            if(duration != 5)
            {
                 enemy.take_dmg(dmg_b*CP);               
            }
            return enemy.HP;
        }
        /// <summary>
        /// apunhala um inimigo pelas costas
        /// </summary>
        /// <param name="turn"></param>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public double Stab(int turn, Cbase enemy)
        {
            if (turn == 1)
            {
                enemy.take_dmg(CP * Strength + dmg_b);
            }
            else
            {
                enemy.take_dmg(Strength + dmg_b);
            }
            return enemy.HP;
        }

        public override string get_atk_name(int i)
        {
            if (i == 1)
                return "Poison Slash";
            else if (i == 2)
                return "Stealth";
            else if (i == 3)
                return "Studds";
            else if (i == 4)
                return "Stab";

            return "Atk"+ i;
        }
    }
}