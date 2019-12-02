using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CDSystem
{
    public class Warehouse
    {
        public Dictionary<string, int> Inventory { get; set; } = new Dictionary<string, int>();

        public void AddStock(string cdName, int amountInShipment)
        {
            if (Inventory.ContainsKey(cdName))
            {
                Inventory[cdName] = Inventory[cdName] + amountInShipment;
                
            }
            else
            {
                Inventory.Add(cdName, amountInShipment);
            }
        }
    }
}
