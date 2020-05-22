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
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money) { dmg_b = 10; }
        Cbase current_poison_enemy;

        /// <see cref = "[Assassin] cover his blades with GH_blood, a strong poison that _is_ based on enemy_HP , 
        /// and deals damage based on his Strength + base_damage +(10/per point)"/>
        public void Poison_slash(Cbase enemy)
        {
            enemy.take_dmg(Strength+dmg_b+20);
            current_poison_enemy = enemy;
            //Console.WriteLine("\t\t DANO INICIAL DO PS HP = "+current_poison_enemy.HP+" t = "+"\n\n");            
        }

        /// <see cref = "Makes [Assassin] invisible to enemies,and doubles it's base_damage along 10sec + (1 sec/per point)"/>
        public void Stealth() 
        {
            untouchable = true;
            dmg_b *= 2;
        }
        public void Shadows_clone(Cbase enemy)
        {
            // turno tem 20% chance de evade
            enemy.take_dmg(dmg_b + Strength + 30);
        }
    }
}
