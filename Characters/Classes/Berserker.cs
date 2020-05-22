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
    class Berserker : Cbase
    {
        public Berserker(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money)
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money) { dmg_b = 20; }
        double lfst = 0.1;// 0 - 1
        
        public void Rage()
        {
            untouchable = true;           
        }
        public void Tremor(Cbase enemy)
        {
            enemy.take_dmg(Strength * dmg_b);
        }

        public void Great_Punch(Cbase enemy)
        {
            enemy.take_dmg(Strength * dmg_b);
            gain_HP(Strength * dmg_b*lfst);
        }

    }
}