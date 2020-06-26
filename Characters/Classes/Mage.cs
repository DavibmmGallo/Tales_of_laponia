using System;
using System.Collections.Generic;
using System.Text;

namespace Tales_of_laponian_front.Characters.Classes
{
    public class Mage : Cbase
    {
        /// <summary>
        /// Classe de mago tem a passiva de receber mais xp
        /// </summary>
        /// <param name="HP"></param>
        /// <param name="CP"></param>
        /// <param name="MP"></param>
        /// <param name="Str_"></param>
        /// <param name="Tough"></param>
        /// <param name="intelli"></param>
        /// <param name="lvl"></param>
        /// <param name="money"></param>
        public Mage(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money)
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money) { 
            dmg_b = 5;
            atk1 += Mage_atk1;
            atk2 += Mage_atk2;
            atk3 += Mage_atk3;
            atk4 += Mage_atk4;
        }

        private void Mage_atk4(object sender, EventArgs e)
        {
            Cryo_drain(current_enemy);
        }

        private void Mage_atk3(object sender, EventArgs e)
        {
            Eruption(current_enemy);
        }

        private void Mage_atk2(object sender, EventArgs e)
        {
            Fire_shot(current_enemy);
        }

        private void Mage_atk1(object sender, EventArgs e)
        {
            Fireball(current_enemy);
        }

        public double Fireball(Cbase enemy)
        {
            if (MP >= 20)
            {
                MP -= 20;
                enemy.take_dmg(Intelligence  *(Lvl/ enemy.Lvl)+(enemy.MAXHP)*0.1 + enemy.Toughness);
                if (enemy.isDead) XP += (12.1 + enemy.Lvl * 0.618);
                //lança abola de fogo em linha reta, se chegar ao fim do rnge ou pegar em alguem explode e da dano em area
            }
            else gain_MP(4);
            
            return enemy.HP;
        }
        public double Eruption(Cbase enemy)
        {
            if (MP >= 100)
            {
                MP -= 100;
                enemy.take_dmg(Intelligence * (MP/MAXMP)+enemy.HP/10+enemy.Toughness);
                take_dmg(HP- 10);
                if (enemy.isDead) XP += (12.1 + enemy.Lvl * 0.618);
                //circulo ao redor do player dando dano em tudo ao redor e um pco de dano no player
            }
            else gain_MP(10);
            
            return enemy.HP;
        }

        public double Fire_shot(Cbase enemy)
        {
            enemy.take_dmg(Intelligence + (Lvl / enemy.Lvl) * (enemy.HP) / 10 + enemy.Toughness);
            if (enemy.isDead) XP += (12.1 + enemy.Lvl * 0.618);
            // Atira gelinho pra frente causando dano no primeiro inimigo acertado
            gain_MP(2);
            gain_HP(10);
            return enemy.HP;
        }
        public double Cryo_drain(Cbase enemy)
        {
            if (MP == MAXMP)
            {
                MP =0;
                enemy.take_dmg(Intelligence * Lvl/enemy.Lvl * MAXMP);
                if (enemy.isDead) XP += (12.1 + enemy.Lvl * 0.618);
                gain_HP(enemy.Lvl * 2);
                // Atira gelinho pra frente causando dano no primeiro inimigo acertado 
            }
            else gain_MP(20);
            
            return enemy.HP;
        }
        public override string get_atk_name(int i)
        {
            if (i == 1)
                return "Fireball";
            else if (i == 2)
                return "Fire Shot";
            else if (i == 3)
                return "Eruption";
            else if (i == 4)
                return "Cryo Drain";

            return "Atk" + i;
        }
    }
}