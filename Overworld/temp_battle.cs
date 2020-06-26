using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales_of_laponian_front.Characters;
using Tales_of_laponian_front.IA_enemy;
using Windows.UI.Xaml.Controls;

namespace Tales_of_laponian_front.Overworld
{
    public class temp_battle
    {
        public temp_battle(Cbase cplayer, IA__generic enemy,string mapa)
        {
            jogador = cplayer;
            inimigo = enemy;
            map = mapa;
        }
        public Cbase jogador { get; set; }
        public IA__generic inimigo { get; set; }
        public string map { get; set; } 
    }
}
