using System;
using System.Collections.Generic;
using System.Text;
using Tales_of_laponian_front.Items;
namespace Tales_of_laponian_front.Characters
{
    public class Inventory
    {
        /// <summary>
        /// <A ARMOR> [1 SLOT]
        /// <A PRIMARY HAND> [1 SLOT]
        /// <A SECUNDARY HAND> [1 SLOT]
        /// <A BAG HOLDER> [27 SLOT]
        /// </summary>
        protected static int size = 30;// TAMANHO -> items infinitos nao tem graça
        public Item[] inventory = new Item[size];  
        bool isInventoryfull = false;
        public Item Main_weapon { get; set; }
        /// <summary>
        /// Merge sort UwU
        /// Organiza com base no ID do item
        /// </summary>
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
        /// <summary>
        /// Mostra os items no console
        /// </summary>
        public void show_inventory_console()
        {
            Console.WriteLine("Items :\n");
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine("\t " + i + " " + inventory[i]);
            }
        }
        /// <summary>
        /// Append item 
        /// </summary>
        /// <param name="item">o item que deseja colocar na sacola</param>
        /// <param name="slot"> em qual slot</param>
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
        /// <summary>
        /// Destroy item 
        /// Ame-o ou deixe-o
        /// </summary>
        /// <param name="slot">qual slot</param>
        public void destroy_item(int slot)
        {
            inventory[slot] = null;
            isInventoryfull = false;
        }
    }
}
