using System;
using System.Collections.Generic;
using System.Text;
//TODO : substituir thread battle por turno , n gostaria de fazer isso ;-;

namespace Tales_of_laponian_front.Characters.Classes
{
    //Classe [Berserker]
    /// <summary>
    /// 1 - Great punch
    /// 2 - Tremor
    /// 3 - Rage
    /// P - if doesn't wear armor dmg * 2
    /// </summary>
    public class Berserker : Cbase
    {
        public Berserker(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money)
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money) {
            dmg_b = 20;
            atk1 += Berserker_atk1;
            atk2 += Berserker_atk2;
            atk3 += Berserker_atk3;
            atk4 += Berserker_atk4;
        }

        private void Berserker_atk4(object sender, EventArgs e)
        {
            Undying_Rage(current_enemy);
        }

        private void Berserker_atk3(object sender, EventArgs e)
        {
            Rage();
        }

        private void Berserker_atk2(object sender, EventArgs e)
        {
            Tremor(current_enemy);
        }

        private void Berserker_atk1(object sender, EventArgs e)
        {
            Great_Punch(current_enemy);
        }

        double lfst = 0.1;// 0 - 1

        public void Rage()
        {
            //fica untouchable por 3 turnos  
            untouchable = true;
        }
        public double Tremor(Cbase enemy)
        {
            enemy.take_dmg(Strength * dmg_b+50);
            //fazer uma chance de 25% de stunar o inimigo
            return enemy.HP;
        }

        public double Great_Punch(Cbase enemy)
        {
            enemy.take_dmg(Strength * dmg_b+CP*dmg_b);
            gain_HP(Strength * dmg_b * lfst);
            return enemy.HP;
        }

        public double Undying_Rage(Cbase enemy)
        {
            enemy.take_dmg(this.Strength * this.MAXHP - this.HP);
            return enemy.HP;
        }
        public override string get_atk_name(int i)
        {
            if (i == 1)
                return "Great Punch";
            else if (i == 2)
                return "Tremor";
            else if (i == 3)
                return "Rage";
            else if (i == 4)
                return "Undying Rage";

            return "Atk" + i;
        }
    }
}