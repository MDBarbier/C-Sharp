using System.Collections.Generic;
using System.Linq;

namespace CDSystem
{
    public class Warehouse
    {
        public List<CD> Inventory { get; set; } = new List<CD>();

        public void AddStock(string cdName, int amountInShipment)
        {
            var match = Inventory.Where(a => a.Name == cdName).FirstOrDefault();            

            if (match != null)
            {
                Inventory.ForEach(a => a.Stock = (a.Name == cdName) ? a.Stock + amountInShipment : 0);
            }
            else
            {
                Inventory.Add(new CD() { 
                    Name = cdName,
                    Stock = amountInShipment
                });
            }
        }

        public void BuyCd(string cdName, int amount, IPaymentSystem paymentSystem)
        {
            var cd = GetCdFromInventory(cdName);

            if (cd != null && cd.Stock > 0 && (cd.Stock - amount > 0) && paymentSystem.ProcessPayment())
            {
                AddStock(cdName, -1);
            }
        }

        public CD GetCdFromInventory(string name)
        {
            var match = Inventory.Where(a => a.Name == name).FirstOrDefault();
            return match;
        }
    }
}
