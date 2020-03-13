using System;
using System.Collections.Generic;
using System.Text;
using Timer = System.Timers.Timer;


namespace _Enter_name__backend.Isekaied.Class
{
    //Classe [Berserker]
    /// <summary>
    /// 1 - Great punch
    /// 2 - Tremor
    /// 3 - Rage
    /// P - if doesn't wear armor dmg * 2
    /// </summary>
    class Berserker : Ibase
    {
        public Berserker(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money)
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money) { dmg_b = 20; }
        int sec = 0;
        Timer timer;
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
        //cannot take damage for 3 seconds e damage aumenta baseado na vida perdida
        public void Rage()
        {
            imorrivel = true;
            timer = new Timer(1000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(GRRR);
            timer.Start();
            
        }
        void GRRR(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Berserker HP: "+HP+"Imorrivel = "+imorrivel);
            sec += 1000;
            if (tomare(3000))
            {
                gain_HP(MAXHP / 2);
                imorrivel = false;
                Console.WriteLine(HP);
            }
        }
        public void to_putp(Ibase enemy)
        {

        }

        public void da_dano(Ibase enemy)
        {

        }

    }
}