using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CDSystem;

namespace CDSystem.Tests
{
    public class CDSystemTests
    {

        [Theory]
        [InlineData(1, 5, 4, true)]
        [InlineData(1, 5, 5, false)]
        [InlineData(1, 0, 0, true)]
        [InlineData(2, 1, 1, true)]
        public void AdjustStockIfPaymentIsOkAndStockAboveZero(int amountToBuy,
            int startingStock, int amountExpected, bool paymentIsOk)
        {

            IPaymentSystem paymentSystem = paymentIsOk ?
                (IPaymentSystem)new SuccessfulPayment() : new UnsuccessfulPayment();

            CD cd = new CD
            {
                Stock = startingStock
            };

            cd.Buy(amountToBuy, paymentSystem);

            Assert.True(cd.Stock == amountExpected);
        }

        [Theory]
        [InlineData("Abbey Road", 100, 1)]
        [InlineData("Abbey Road", 100, null)]
        public void AdjustWarehouseInventoryBasedOnRecordCompanyShipment(string cdName, int amountInShipment, int? startingStock)
        {
            Warehouse warehouse = new Warehouse();

            if (startingStock != null)
            {
                warehouse.Inventory.Add(cdName, (int)startingStock);
            }

            warehouse.AddStock(cdName, amountInShipment);

            Assert.Equal(warehouse.Inventory[cdName], (startingStock ?? 0) + amountInShipment);

        }

        [Fact]
        public void AdjustWarehouseInventoryBasedOnMixedRecordCompanyShipment()
        {
            Warehouse warehouse = new Warehouse();
            Dictionary<string, int> recordsInShipment = new Dictionary<string, int>()
            {
                {"Abbey Road", 50 },
                { "What's the story morning glory", 70 }
            };

            warehouse.Inventory.Add("Abbey Road", 10);

            foreach (var record in recordsInShipment)
            {
                warehouse.AddStock(record.Key, record.Value);               
            }

            Assert.Equal(60, warehouse.Inventory["Abbey Road"]);
            Assert.Equal(70, warehouse.Inventory["What's the story morning glory"]);
        }
    }
}
