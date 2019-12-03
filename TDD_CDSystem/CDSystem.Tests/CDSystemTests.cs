using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CDSystem;
using FluentAssertions;

namespace CDSystem.Tests
{
    public class CDSystemTests
    {
        [Theory]
        [InlineData("Abbey Road", 1, 5, true)]
        [InlineData("Abbey Road", 1, 5, false)]
        [InlineData("Abbey Road", 1, 0, true)]
        [InlineData("Abbey Road", 2, 1, true)]
        public void AdjustStockIfPaymentIsOkAndStockAboveZero(string name, int amountToBuy, int startingStock, bool paymentIsOk)
        {
            int expectedRemainingStock;
            IPaymentSystem paymentSystem;

            if (paymentIsOk)
            {
                paymentSystem = new SuccessfulPayment();
                expectedRemainingStock = startingStock - amountToBuy >= 0 ? startingStock - amountToBuy : (startingStock-amountToBuy < 0) ? startingStock: startingStock - amountToBuy;
            }
            else
            {
                paymentSystem = new UnsuccessfulPayment();
                expectedRemainingStock = startingStock;
            }             

            Warehouse warehouse = new Warehouse();
            warehouse.AddStock(name, startingStock);
            warehouse.BuyCd(name, amountToBuy, paymentSystem);

            //Assertion
            warehouse.GetCdFromInventory(name).Stock.Should().Be(expectedRemainingStock);
        }

        [Fact]
        public void TestWarehouseStockGoesDownWhenCdBought()
        {
            string name = "Abbey Road";
            Warehouse warehouse = new Warehouse();            
            warehouse.AddStock(name, 5);
            warehouse.BuyCd(name, 1, new SuccessfulPayment());           

            //Assertion
            warehouse.GetCdFromInventory(name).Stock.Should().Be(4);
        }


        [Theory]
        [InlineData("Abbey Road", 100, 1)]
        [InlineData("Abbey Road", 100, null)]
        public void AdjustWarehouseInventoryBasedOnRecordCompanyShipment(string cdName, int amountInShipment, int? startingStock)
        {
            Warehouse warehouse = new Warehouse();

            if (startingStock != null)
            {
                warehouse.Inventory.Add(new CD() { Name = cdName, Stock = (int)startingStock });
            }

            warehouse.AddStock(cdName, amountInShipment);

            //Assertion
            warehouse.GetCdFromInventory(cdName).Stock.Should().Be((startingStock ?? 0) + amountInShipment);
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

            warehouse.Inventory.Add(new CD() { Name = "Abbey Road", Stock = 10 });

            foreach (var record in recordsInShipment)
            {
                warehouse.AddStock(record.Key, record.Value);
            }

            //Assertion            
            Assert.True(warehouse.GetCdFromInventory("Abbey Road").Stock == 60 && warehouse.GetCdFromInventory("What's the story morning glory").Stock == 70);
        }

        [Fact]
        public void LeavingReviewForCdIsSuccessful()
        {
            int rating = 9;
            string review = "Great";
            string name = "Abbey Road";

            Warehouse warehouse = new Warehouse();
            warehouse.AddStock(name, 10);

            CD cd = new CD() { Name = name };
            cd.LeaveReview(rating, review, warehouse);

            //Assertion
            Assert.True(cd.Rating == rating && cd.Review == review);
        }

        [Fact]
        public void LeavingReviewForCdIsUnsuccessfulIfCdDoesNotExist()
        {
            int rating = 9;
            string review = "Great";
            string name = "Abbey Road";

            Warehouse warehouse = new Warehouse();            

            CD cd = new CD() { Name = name };
            cd.LeaveReview(rating, review, warehouse);

            //Assertion
            Assert.True(cd.Rating == 0 && string.IsNullOrEmpty(cd.Review));
        }
    }
}
