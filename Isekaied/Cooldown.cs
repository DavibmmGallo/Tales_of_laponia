using System;
using System.Collections.Generic;
using System.Text;
using Timer = System.Timers.Timer;

namespace _Enter_name__backend.Isekaied
{
    public class Cooldown
    {
        private Timer[] Skill_cooldown= new Timer[3];

        protected int[] cooldown_sec = new int[3];
        public int cool_1 { get; set; }
        public int cool_2 { get; set; }
        public int cool_3 { get; set; }

        public bool[] cannot_use = new bool[3];

        public Cooldown(int Cool_1, int Cool_2, int Cool_3)
        {
            cool_1 = Cool_1;
            cool_2 = Cool_2;
            cool_3 = Cool_3;
            
            for (int i = 0; i < 3; i++)
            {
                Skill_cooldown[i] = new Timer(1000);
            }
            Skill_cooldown[0].Elapsed += new System.Timers.ElapsedEventHandler(pass_1);
            Skill_cooldown[1].Elapsed += new System.Timers.ElapsedEventHandler(pass_2);
            Skill_cooldown[2].Elapsed += new System.Timers.ElapsedEventHandler(pass_3);
        }
        public void press(int t_ind)
        {
            switch (t_ind)
            {
                case 1:
                    Skill_cooldown[0].Start();
                    cannot_use[0] = true;
                    break;
                case 2:
                    Skill_cooldown[1].Start();
                    cannot_use[1] = true;
                    break;
                case 3:
                    Skill_cooldown[2].Start();
                    cannot_use[2] = true;
                    break;
                default:
                    break;
            }
        }
        public void pass_1(object sender, System.Timers.ElapsedEventArgs e)
        {
            cooldown_sec[0] += 1000;
            Console.WriteLine("Cooldown actived : "+cooldown_sec[0]+" seconds.");
            if(tokio_tomare(cool_1, Skill_cooldown[0], cooldown_sec[0]))
            {
                cooldown_sec[0] = 0;
                cannot_use[0] = false;
            }
        }
        public void pass_2(object sender, System.Timers.ElapsedEventArgs e)
        {
            cooldown_sec[1] += 1000;
            Console.WriteLine("Cooldown actived : " + cooldown_sec[1] + " seconds.");
            if (tokio_tomare(cool_2, Skill_cooldown[1], cooldown_sec[1]))
            {
                cooldown_sec[1] = 0;
                cannot_use[1] = false;
            }
        }
        public void pass_3(object sender, System.Timers.ElapsedEventArgs e)
        {
            cooldown_sec[2] += 1000;
            Console.WriteLine("Cooldown actived : " + cooldown_sec[2] + " seconds.");
            if (tokio_tomare(cool_3, Skill_cooldown[2], cooldown_sec[2]))
            {
                cooldown_sec[2] = 0;
                cannot_use[2] = false;
            }
        }
        bool tokio_tomare(int final_sec,Timer t,int cool_s)
        {
            if (cool_s == final_sec)
            {
                t.Stop();
                cool_s = 0;
                Console.WriteLine("Cooldown ended.\n count : "+cool_s+"\n");
                return true;
            }
            else
            {
                return false;
            }
        }
       
    }
}
