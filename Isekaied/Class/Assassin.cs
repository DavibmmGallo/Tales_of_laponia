using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using _Enter_name__backend.Items;
using Timer = System.Timers.Timer;

namespace _Enter_name__backend.Isekaied.Class
{
    //Classe [Assassin]
    /// <summary>
    /// 1 - Poison Slash
    /// 2 - Stealth
    /// 3 - Shadow's clone
    /// P - Movement speed 125%
    /// </summary>
    public class Assassin : Ibase
    {
        Ibase current_poison_enemy;
        public Assassin(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money) : base(HP, CP, MP, Str_, Tough, intelli, lvl, money)
        { dmg_b = 10; }
        Timer timer;
        int sec = 0;
        bool is_invisible = false;
        bool tomare(int final_sec)
        {
            if (sec == final_sec)
            {
                timer.Stop();
                sec = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <see cref = "[Assassin] cover his blades with GH_blood, a strong poison that _is_ based on enemy_HP , 
        /// and deals damage based on his Strength + base_damage +(10/per point)"/>
        public void Poison_slash(Ibase enemy)
        {
            enemy.take_dmg(Strength+dmg_b);
            current_poison_enemy = enemy;
            Console.WriteLine(current_poison_enemy.HP);
            timer = new Timer(1000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(poison);
            timer.Start();
        } 
        public void poison(object sender, System.Timers.ElapsedEventArgs e)
        {
            sec += 1000;
            if(!current_poison_enemy.imorrivel) current_poison_enemy.take_dmg((current_poison_enemy.MAXHP*0.1)*Strength*0.1);
            Console.WriteLine(current_poison_enemy.HP);
            if (current_poison_enemy.isDead) Lvl += (1.21 + current_poison_enemy.Lvl * 0.618);
            tomare(5000);
        }
        /// <see cref = "Makes [Assassin] invisible to enemies,and doubles it's base_damage along 10sec + (1 sec/per point)"/>
        public void Stealth() 
        {
            is_invisible = true;
            timer = new Timer(1000);//10 sec lvl 1
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Invisibility);
            timer.Start();
        }
        public void Invisibility(object sender, System.Timers.ElapsedEventArgs e)
        {
            sec += 1000;
            dmg_b *= 2;
            if (tomare(10000))
            {
                dmg_b /= 2;
            }
        }
    }
}
