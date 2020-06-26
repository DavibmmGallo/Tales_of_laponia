using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rtta = Tales_of_laponian_front.Characters.Race.Raca;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Tales_of_laponian_front.Characters
{
    /// <summary>
    /// A base para o player e entidades no jogo
    /// </summary>
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
        public double XP { get; set; }
        public double MAXXP { get; set; }
        public int Money { get; set; }
        public int speed { get; set; }
        public int turn { get; set; }
        public bool repel = false;
        public bool isDead = false;
        public Inventory inventory = new Inventory();
        public bool untouchable = false;
        public rtta raca { get; set; }
        public Image img { get; set; }
        public int[] position { get; set; }
        public Cbase current_enemy { get; set; }
        public delegate void LevelUPEventHandler(object sender, EventArgs e);
        public event LevelUPEventHandler LevelUP;

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
            XP = 0;
            MAXXP = 10;
            this.LevelUP += Cbase_LevelUP;
        }
        /// <summary>
        /// LEVEL UP method and new atributes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Cbase_LevelUP(object sender, EventArgs e)
        {
            if(is_upable())
            {
                while (is_upable())
                {
                    Lvl++;
                    MAXXP += 100+XP/20;
                }               
                Strength += 1;
                Toughness += 1;
                Intelligence += 1;
                MAXHP += 100;
                if(MAXMP !=0) MAXMP += 100;
                if(MAXCP !=0)MAXCP += 100;
                gain_HP(999);
                gain_MP(999);
            }
        }
        /// <summary>
        /// task p checar level up 
        /// </summary>
        public async void task_xp()
        {
            await Task.Run(() =>
            {
                while(is_upable())
                {
                    LevelUP(this, new EventArgs());
                }
            });
        }

        public async void Pos_attp(int[] newpos)
        {
            await Task.Run(() =>
            {
                position = newpos;
                Task.WaitAll();
            });
        }

        public void show_status_console()
        {
            Console.WriteLine("Status : HP = {0}\n\t MP = {1}\n\t CP = {2}\n\t STR = {3}\n\t " +
                "TGH = {4}\n\t INT = {5}\n\t $$$ = {6}\n\t LVL = {7}\n\n\t MOV = {8}\n\n==========================================", HP, MP, CP, Strength, Toughness, Intelligence, Money, Lvl);
        }


        //can be 0 weapon_dmg
        public virtual double atkbasic(Cbase enemy, int weapon_dmg)
        {
            enemy.take_dmg((dmg_b+ weapon_dmg)+Strength+ enemy.Toughness);
            return enemy.HP;
        }
        /// <summary>
        /// take dmg 
        /// </summary>
        /// <param name="dmg"> amount of damage ;; That's a lot of DAMAGE!!!</param>
        public void take_dmg(double dmg)
        {
            if (!untouchable)
            {
                if(dmg>=Toughness) HP -= (dmg - Toughness);
                if (HP <= 0) {
                    isDead = true;
                    HP = 0;
                }
            }
        }
        /// <summary>
        /// Gain health points
        /// </summary>
        /// <param name="heal">amount of heal ;; NEED HEALING!!!</param>
        public void gain_HP(double heal)
        {
            isDead = false;
            if (heal + HP >= MAXHP) HP = MAXHP;
            else HP += heal;
        }
        /// <summary>
        /// Gain mana points
        /// </summary>
        /// <param name="heal"></param>
        public void gain_MP(double heal)
        {
            if (heal + MP >= MAXMP) MP = MAXMP;
            else MP += heal;
        }
        public void use_MP(double amount)
        {
            if (MP >= amount) MP -= amount;
        }
        /// <summary>
        /// se pode upar
        /// </summary>
        /// <returns></returns>
        bool is_upable()
        {
            return XP >= MAXXP? true : false;
        }
        /// <summary>
        /// usando item em combate
        /// </summary>
        /// <param name="slot"></param>
        public void item_on_use(int slot)
        {
            inventory.inventory[slot].Usar(this, new EventArgs());
            inventory.destroy_item(slot);
        }
        /// <summary>
        /// evento de ataque
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void atkEventHandler(object sender, EventArgs e);
        public event atkEventHandler atk1;
        /// <summary>
        /// n° de ataque para cada 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="ea"></param>
        public void atkk1(object e, EventArgs ea)
        {
            atk1(e, ea);
        }
        public event atkEventHandler atk2;
        public void atkk2(object e, EventArgs ea)
        {
            atk2(e, ea);
        }
        public event atkEventHandler atk3;
        public void atkk3(object e, EventArgs ea)
        {
            atk3(e, ea);
        }
        public event atkEventHandler atk4;
        public void atkk4(object e, EventArgs ea)
        {
            atk4(e, ea);
        }
        public void lose_money(int dola)
        {
            if (Money - dola >= 0) Money -= dola;
            else Money = 0;
        }
        public virtual string get_atk_name(int i)
        {
            return "Atk" + i;
        }
    }
}