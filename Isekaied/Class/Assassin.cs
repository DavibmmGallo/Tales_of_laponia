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
        { dmg_b = 10; cooldown = new Cooldown(5000, 4000, 5000); }
        
        Timer timer,timer_s;
        int sec_p = 0;
        int sec_s = 0;
        bool is_invisible = false;

        bool tomare(int final_sec,Timer t, int seconds)
        {
            if (seconds == final_sec)
            {
                t.Stop();
                seconds = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
        int tes=0;

        /// <see cref = "[Assassin] cover his blades with GH_blood, a strong poison that _is_ based on enemy_HP , 
        /// and deals damage based on his Strength + base_damage +(10/per point)"/>
        public void Poison_slash(Ibase enemy)
        {
            if (!cooldown.cannot_use[0])
            {
                enemy.take_dmg(Strength+dmg_b+20);
                current_poison_enemy = enemy;
                Console.WriteLine("\t\t DANO INICIAL DO PS HP = "+current_poison_enemy.HP+" t = "+tes+"\n\n");
                tes ++;
                timer = new Timer(1000);
                timer.Elapsed += new System.Timers.ElapsedEventHandler(poison);
                timer.Start();
                cooldown.press(1);
            }
            
        } 

        public void poison(object sender, System.Timers.ElapsedEventArgs e)
        {
            sec_p += 1000;
            if(!current_poison_enemy.imorrivel) current_poison_enemy.take_dmg((current_poison_enemy.MAXHP*0.1)*Strength*0.1);
            Console.WriteLine("HP Poisoned : "+current_poison_enemy.HP+" sec "+sec_p);
            if (current_poison_enemy.isDead) Lvl += (1.21 + current_poison_enemy.Lvl * 0.618);
            if (tomare(5000, timer, sec_p)) sec_p = 0;
        }

        /// <see cref = "Makes [Assassin] invisible to enemies,and doubles it's base_damage along 10sec + (1 sec/per point)"/>
        public void Stealth() 
        {
            if (!cooldown.cannot_use[1])
            {
                is_invisible = true;
                timer_s = new Timer(1000);//10 sec lvl 1
                timer_s.Elapsed += new System.Timers.ElapsedEventHandler(Invisibility);
                timer_s.Start();
                cooldown.press(2);
            }
            
        }
        public void Invisibility(object sender, System.Timers.ElapsedEventArgs e)
        {
            sec_s += 1000;
            dmg_b *= 2;
            if (tomare(10000,timer_s,sec_s))

            {
                dmg_b /= 2;
            }
        }
    }
}
