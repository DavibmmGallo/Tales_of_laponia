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
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money) { dmg_b = 5; }
        Cbase current_poison_enemy;

        /// <see cref = "[Assassin] cover his blades with GH_blood, a strong poison that _is_ based on enemy_HP , 
        /// and deals damage based on his Strength + base_damage +(10/per point)"/>
        public void Poison_slash(Cbase enemy)
        {
            enemy.take_dmg(Strength+dmg_b+20);
            current_poison_enemy = enemy;
            Console.WriteLine("\t\t DANO INICIAL DO PS HP = "+current_poison_enemy.HP+" t = "+"\n\n");            
        }

        /// <see cref = "Makes [Assassin] invisible to enemies,and doubles it's base_damage along 10sec + (1 sec/per point)"/>
        public void Stealth() 
        {
            untouchable = true;
            dmg_b *= 2;
        }

        public void Studds(Cbase enemy) 
        {
            //joga espinhos no chao e o inimigo toma dano ate acabar a batalha
            enemy.take_dmg(Intelligence);
        }

        public void Stab(int turn, Cbase enemy) 
        {
            if(turn = 1){
                enemy.take_dmg(this.Intelligence * this.Strength + dmg_b);
            }
            else{
                enemy.take_dmg(this.Strength + dmg_b);
            }
        }
        

    }
}
