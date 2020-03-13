using System;
using System.Collections.Generic;
using System.Text;
using _Enter_name__backend.Items;
namespace _Enter_name__backend.Isekaied
{
    public class Inventory
    {
        /// <summary>
        /// <A ARMOR> [1 SLOT]
        /// <A PRIMARY HAND> [1 SLOT]
        /// <A SECUNDARY HAND> [1 SLOT]
        /// <A BAG HOLDER> [3+ SLOTS]
        /// </summary>
        protected static int size = 6;
        Item[] inventory = new Item[size];
        bool isInventoryfull = false;

        public void sort_by_ID()
        {
            for (int gap = size / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < size; i += 1)
                {
                    Item temp = inventory[i];
                    int j;
                    for (j = i; j >= gap && inventory[j - gap].ID > temp.ID; j -= gap)
                        inventory[j] = inventory[j - gap];
                    inventory[j] = temp;
                }
            }
        }

        public void show_inventory_console()
        {
            Console.WriteLine("Items :\n");
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine("\t " + i + " " + inventory[i]);
            }
        }
        public void append_item(Item item, int slot)
        {
            if (!isInventoryfull)
            {
                inventory[slot] = item;
            }
            else
            {
                Console.WriteLine("inventory is full!!");
            }
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null) isInventoryfull = false;
                else isInventoryfull = true;
            }
        }
        public void destroy_item(int slot)
        {
            inventory[slot] = null;
            isInventoryfull = false;
        }
    }
}
