using System;
using System.Collections.Generic;
using System.Text;

namespace Tales_of_laponian_front.Characters.Classes
{
    public class Necromancer : Cbase
    {
        public Necromancer(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money)
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money) { 
            dmg_b = 12;
            atk1 += Necromancer_atk1;
            atk2 += Necromancer_atk2;
            atk3 += Necromancer_atk3;
            atk4 += Necromancer_atk4;
        }

        private void Necromancer_atk4(object sender, EventArgs e)
        {
            Passive(current_enemy);
        }

        private void Necromancer_atk3(object sender, EventArgs e)
        {
            Enfeeblement(current_enemy);
        }

        private void Necromancer_atk2(object sender, EventArgs e)
        {
            Life_consumption(current_enemy);
        }

        private void Necromancer_atk1(object sender, EventArgs e)
        {
            Execute(current_enemy);
        }
        /// <summary>
        /// de acordo com a diferenca de vida o necromante da um golpe ethereo no inimigo 
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public double Execute(Cbase enemy)
        {
            if (MP >= MAXMP / 4)
            {
                MP -= MAXMP / 4;
                if ((MAXHP - enemy.MAXHP) > 10) enemy.take_dmg(((MAXHP - enemy.MAXHP) + Intelligence) * (Lvl / enemy.Lvl) + enemy.Toughness + dmg_b);
                else enemy.take_dmg(20+enemy.Toughness);
            }
          
            return enemy.HP;
        }
        /// <summary>
        /// da dano no inimigo com base na inteligencia e nivel e ganha vida pelo mesmo dano à metade
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public double Life_consumption(Cbase enemy)
        {
            if (HP >= 0.2 * MAXHP)
            {
                take_dmg(MAXHP / 4);
                enemy.take_dmg(Intelligence * Lvl / enemy.Lvl + dmg_b+enemy.Lvl*4);
                gain_HP(MAXHP / 10 + Intelligence);
            }
            else {
                gain_HP(Lvl + 20);
                enemy.take_dmg(enemy.Toughness + enemy.MAXHP*0.2);
            }
           
            return enemy.HP;
        }
        /// <summary>
        /// reduz armadura
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public double Enfeeblement(Cbase enemy)
        {
            if (MP >= 40)
            {
                MP -= 40;
                enemy.Toughness *= 0.25;
            }
            else gain_MP(10);
            
            return enemy.Toughness;
        }
        /// <summary>
        /// "rouba" o maior stat do inimigo e sua velocidade 
        /// sim eh OP
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public double Passive(Cbase enemy)
        {
            MP = 0;
            enemy.take_dmg(enemy.Toughness + Intelligence + Lvl);
            gain_HP(MAXHP);
            speed = enemy.speed;
            return MAXHP;
        }
        public override string get_atk_name(int i)
        {
            if (i == 1)
                return "Execute";
            else if (i == 2)
                return "Life Consumption";
            else if (i == 3)
                return "Enfeeblement";
            else if (i == 4)
                return "Steal Soul";

            return "Atk" + i;
        }
        public override double atkbasic(Cbase enemy, int weapon_dmg)
        {
            enemy.take_dmg(enemy.Toughness+enemy.HP*0.05);
            gain_MP(enemy.HP / 5);
            return enemy.HP;
        }
    }
}