using System;
using System.Collections.Generic;
using System.Text;
using Tales_of_laponian_front.Characters;
/// <summary>
/// 
/// BASE PARA CRIAR A IA DOS INIMIGOS 
/// CASO SEJA UM JOGO Q N TENHA TURNOS
/// 
/// 
/// </summary>
namespace Tales_of_laponian_front.IA_enemy
{
    public class IA__generic : Cbase,p_methods
    {
        public bool player_detected { get; set; }
        public bool is_player_reachable { get; set; } // hitbox 

        public IA__generic(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money)
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money) { }

        
    }
}
