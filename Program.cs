using System;
using _Enter_name__backend.Isekaied.Class;
using _Enter_name__backend.Items.weapons;

namespace _Enter_name__backend
{
    class Program
    {
        static void Main(string[] args)
        {
            Assassin a = new Assassin(100, 200, 0, 10, 5, 0, 10, 999);
            Berserker b = new Berserker(200, 100, 0, 9, 8, 0, 10, 999);
            a.Poison_slash(b);
            b.Rage();
            Console.Read();
        }
    }
}
