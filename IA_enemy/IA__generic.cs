using System;
using System.Collections.Generic;
using System.Text;
using _Enter_name__backend.Isekaied;
/// <summary>
/// 
/// BASE PARA CRIAR A IA DOS INIMIGOS 
/// CASO SEJA UM JOGO Q N TENHA TURNOS
/// 
/// 
/// </summary>
namespace _Enter_name__backend.IA_enemy
{
    class IA__generic : Ibase,p_methods
    {
        public bool player_detected { get; set; }
        public bool is_player_reachable { get; set; } // hitbox 

        public IA__generic(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money)
            : base(HP, CP, MP, Str_, Tough, intelli, lvl, money) { }

        
    }
}
