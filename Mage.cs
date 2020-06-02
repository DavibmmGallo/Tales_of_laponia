using System;
using System.Collections.Generic;
using System.Text;

namespace Tales_of_laponian_front.Characters.Classes
{
    class Mage : Cbase
    {
        public Mage(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money)
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money) { dmg_b = 5; }

        public void Fireball(Cbase enemy)
        {
            enemy.take_dmg(Intelligence * (MP));
            if (enemy.isDead) Lvl += (1.21 + enemy.Lvl * 0.618);
            //lança abola de fogo em linha reta, se chegar ao fim do rnge ou pegar em alguem explode e da dano em area
        }
        public void Eruption(Cbase enemy)
        {
            enemy.take_dmg(Intelligence * (MP));
            take_dmg(100);
            if (enemy.isDead) Lvl += (1.21 + enemy.Lvl * 0.618);
            //circulo ao redor do player dando dano em tudo ao redor e um pco de dano no player
        }

        public void Fire_shot(Cbase enemy)
        {
            enemy.take_dmg(Intelligence * Lvl);
            if (enemy.isDead) Lvl += (1.21 + enemy.Lvl * 0.618);
            // Atira gelinho pra frente causando dano no primeiro inimigo acertado

        }
    }
}