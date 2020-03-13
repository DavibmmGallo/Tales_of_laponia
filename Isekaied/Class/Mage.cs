using System;
using System.Collections.Generic;
using System.Text;

namespace _Enter_name__backend.Isekaied.Class
{
    class Mage : Ibase
    {
        public Mage(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money)
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money) { }

        public void Fireball(Ibase enemy)
        {
            enemy.take_dmg(Intelligence * (this.MP));
            if (enemy.isDead) Lvl += (1.21 + enemy.Lvl * 0.618);
            //lança abola de fogo em linha reta, se chegar ao fim do rnge ou pegar em alguem explode e da dano em area
        }
        public void Eruption(Ibase enemy)
        {
            enemy.take_dmg(Intelligence * (this.MP));
            this.take_dmg(100);
            if (enemy.isDead) Lvl += (1.21 + enemy.Lvl * 0.618);
            //circulo ao redor do player dando dano em tudo ao redor e um pco de dano no player
        }

        public void Fire_shot(Ibase enemy)
        {
            enemy.take_dmg(Intelligence * this.Lvl);
            if (enemy.isDead) this.Lvl += (1.21 + enemy.Lvl * 0.618);
            // Atira gelinho pra frente causando dano no primeiro inimigo acertado

        }
    }
}