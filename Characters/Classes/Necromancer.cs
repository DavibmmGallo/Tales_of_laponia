using System;
using System.Collections.Generic;
using System.Text;

namespace Tales_of_laponian_front.Characters.Classes
{
    class Necromancer:Cbase
    {
        public Necromancer(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money)
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money) { dmg_b = 5; }
        List<Cbase> minions;
        Cbase tenemy;
        public void Rise(Cbase enemy)
        {
            if (enemy.isDead)
            {
                tenemy = enemy;
                tenemy.MAXHP *= 2;
                tenemy.MAXMP *= 2;
                tenemy.MAXCP *= 2;
                tenemy.gain_HP(99999); // heal keks
                minions.Add(tenemy);
            }
        }

        public Cbase I_choose_u(int index) 
        {
            Cbase[] i = minions.ToArray();
            return i[index];
        }

        public void Life_consumption(Cbase enemy) 
        {
            if (dmg_b * Intelligence * MP >= enemy.MAXHP) enemy.take_dmg(enemy.MAXHP * 2);
            else enemy.take_dmg(dmg_b * Intelligence * MP);
        }
    }
}
