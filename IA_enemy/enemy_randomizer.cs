using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tales_of_laponian_front.IA_enemy
{   
    /// <summary>
    /// Essa classe tem o propósito de calcular a probabilidade de encontrar inimigos 
    /// e calcula também seus Stats;
    /// </summary>
    public class enemy_randomizer
    {
        public enemy_randomizer()
        {}

        Random rfound = new Random();
        /// <summary>
        /// Calcula qual inimigo irá lutar
        /// </summary>
        public int randon(int qtd_inimigos)
        {
            int pp = rfound.Next(1,qtd_inimigos+1);
            return pp;
        }
        /// <returns>
        ///     90% -> not found , 10% found
        /// </returns>
        public bool Found()
        {
            return rfound.Next(0, 100) > 90 ? true : false;        
        }
        /// <summary>
        /// Seta e calcula os parametros dos inimigos com base no mapa (lvl) 
        /// </summary>
        /// <param name="enemy"> usando polimorfismo a função retorna os stats dos inimigos com valores aleatórios baseados no mapa </param>
        /// <param name="map"> esse é o valor mapa (1-5)</param>
        /// <returns>inimigo feito</returns>
        public IA__generic set_enemies(IA__generic enemy, int map)
        {
            Random rand = new Random();
            int lvlb;
            switch (map)
            {
                case 1:
                    lvlb = rand.Next(1, 10);
                    enemy = new IA__generic(10 * lvlb, 0, rand.Next(10, 25) * lvlb, 0, rand.Next(20), 0, lvlb,rand.Next(1,20),null);
                    break;
                case 2:
                    lvlb = rand.Next(11, 20);
                    enemy = new IA__generic(15 * lvlb, 0, rand.Next(20, 50) * lvlb, 0, rand.Next(40), 0, lvlb, rand.Next(20, 40), null);
                    break;
                case 3:
                    lvlb = rand.Next(21, 40);
                    enemy = new IA__generic(20 * lvlb, 0, rand.Next(40, 100) * lvlb, 0, rand.Next(60), 0, lvlb, rand.Next(40, 80), null);
                    break;
                case 4:
                    lvlb = rand.Next(41, 60);
                    enemy = new IA__generic(25 * lvlb, 0, rand.Next(80, 200) * lvlb, 0, rand.Next(80), 0, lvlb, rand.Next(80, 100), null);
                    break;
                case 5:
                    lvlb = rand.Next(61, 90);
                    enemy = new IA__generic(50 * lvlb, 0, rand.Next(160, 400) * lvlb, 0, rand.Next(160), 0, lvlb, rand.Next(100, 200), null);
                    break;
            }
            return enemy;
        }
    }
}
