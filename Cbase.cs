using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rtta = Tales_of_laponian_front.Characters.Race.Raca;
using System.Threading.Tasks;
using System.Drawing;

namespace Tales_of_laponian_front.Characters
{
    public class Cbase : p_methods
    {
        public double HP { get; set; }
        public double CP { get; set; } //Combo point is made to increase dmg 
        public double MP { get; set; }
        public double dmg_b { get; set; } // base dmg
        public double MAXHP { get; set; }
        public double MAXCP { get; set; }
        public double MAXMP { get; set; }
        public double Strength { get; set; } // melee Dmg multiplier
        public double Toughness { get; set; } // Dmg reduction
        public double Intelligence { get; set; } // Mana power common AP
        public double Lvl { get; set; }
        public int Money { get; set; }
        public int speed { get; set; }
        public bool stunned{get; set; }
        public bool isDead = false;
        public Inventory inventory = new Inventory();
        public bool untouchable = false;
        public rtta raca { get; set; }
        public Image img { get; set; }

        public Cbase(double HP, double CP, double MP, double Str_, double Tough, double intelli, double lvl, int money)
        {
            MAXHP = HP;
            this.HP = MAXHP;
            MAXMP = MP;
            this.MP = MAXMP;
            MAXCP = CP;
            this.CP = MAXCP;
            Strength = Str_;
            Toughness = Tough;
            Intelligence = intelli;
            Money = money;
            Lvl = lvl;
        }
        public void show_status_console()
        {
            Console.WriteLine("Status : HP = {0}\n\t MP = {1}\n\t CP = {2}\n\t STR = {3}\n\t " +
                "TGH = {4}\n\t INT = {5}\n\t $$$ = {6}\n\t LVL = {7}\n\n\t MOV = {8}\n\n==========================================", HP, MP, CP, Strength, Toughness, Intelligence, Money, Lvl);
        }

       
        public void atkbasic()
        {
            
        }

        public void take_dmg(double dmg)
        {
            if (!untouchable)
            {
                HP -= (dmg - Toughness);
                if (HP <= 0) isDead = true;
            }
        }

        public void gain_HP(double heal)
        {
            if (heal + HP >= MAXHP) HP = MAXHP;
            else HP += heal;
        }
    }
}
