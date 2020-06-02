using System;
using System.Collections.Generic;
using System.Text;

namespace Tales_of_laponian_front.Characters.Classes
{
    class Necromancer:Cbase
    {
        public Necromancer(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money)
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money) { dmg_b = 5; }
        Cbase tenemy;
        

        public Cbase Execute(Cbase enemy) 
        {
            enemy.take_dmg((100 - enemy.HP)*this.Intelligence);
        }

        public void Life_consumption(Cbase enemy) 
        {
            enemy.take_dmg(this.Intelligence * this.Lvl);
            gain_HP((this.Intelligence * this.Lvl)/2);

        }

        public void Enfeeblement(Cbase enemy) 
        {
            enemy.Toughness.set(enemy.Toughness.get()*0.25);
        }

        public void Passive(Cbase enemy) 
        {
            //rouba o maior atributo do inimigo morto so n tenho ideia de como fzr ainda
        }
    }
}
