using System;
using System.Collections.Generic;
using System.Linq;

namespace event_demo_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var posm = new PizzaOrderingSystemMethod();

            var pos = new PizzaOrderingSystem(
                DiscountPolicyDelegates.DiscountAllThePizzas());

            PizzaOrder po = new PizzaOrder();
            po.Pizzas = new List<Pizza>();
            po.Pizzas.Add(new Pizza() {Price = 15.99m, CrustType = CrustType.Thin});
            po.Pizzas.Add(new Pizza() { Price = 16.98m, CrustType = CrustType.Stuffed });
            po.Pizzas.Add(new Pizza() { Price = 15.99m, CrustType = CrustType.Thin });


            Console.WriteLine(pos.ComputePrice(po));

           

        }
    }

    public delegate decimal DiscountPolicy(PizzaOrder order);

    class PizzaOrderingSystemMethod
    {
        private readonly DiscountPoliciesMethods _discountPoliciesMethods;
        public PizzaOrderingSystemMethod()
        {
            _discountPoliciesMethods = new DiscountPoliciesMethods();
        }
        public decimal ComputePrice(PizzaOrder order)
        {
            decimal total = order.Pizzas.Sum(p => p.Price);

            decimal[] discounts = new[] {
                _discountPoliciesMethods.BuyOneGetOneFree(order),
                _discountPoliciesMethods.FivePercentOffMoreThanFiftyDollars(order),
                _discountPoliciesMethods.FiveDollarsOffStuffedCrust(order),
            };

            decimal bestDiscount = discounts.Max(discount => discount);
            total = total - bestDiscount;
            return total;
        }
    }
    public class PizzaOrderingSystem
    {
        readonly DiscountPolicy _discountPolicy;

        public PizzaOrderingSystem(DiscountPolicy discountPolicy)
        {
            _discountPolicy = discountPolicy;
        }

        public decimal ComputePrice(PizzaOrder order)
        {
            decimal nonDiscounted = order.Pizzas.Sum(p => p.Price);
            decimal discountedValue = _discountPolicy(order);
            return nonDiscounted - discountedValue;
        }
    }

    public static class DiscountPolicyDelegates
    {
        public static decimal BuyOneGetOneFree(PizzaOrder order)
        {
            var pizzas = order.Pizzas;
            if (pizzas.Count < 2)
            {
                return 0m;
            }
            return pizzas.Min(p => p.Price);
        }
        public static decimal FivePercentOffMoreThanFiftyDollars(PizzaOrder order)
        {
            decimal nonDiscounted = order.Pizzas.Sum(p => p.Price);
            return nonDiscounted >= 50 ? nonDiscounted * 0.05m : 0M;
        }
        public static decimal FiveDollarsOffStuffedCrust(PizzaOrder order)
        {
            return order.Pizzas.Sum(p => p.CrustType == CrustType.Stuffed ? 5m : 0m);
        }
        public static DiscountPolicy CreateBest(params DiscountPolicy[] policies)
        {
            return order => policies.Max(policy => policy.Invoke(order));
        }

        public static DiscountPolicy DiscountAllThePizzas()
        {
            DiscountPolicy best = CreateBest(
                BuyOneGetOneFree,
                FivePercentOffMoreThanFiftyDollars,
                FiveDollarsOffStuffedCrust);
            return best;
        }
    }

    public class PizzaOrder
    {
        public List<Pizza> Pizzas { get; internal set; }
    }

    public class Pizza
    {
        public decimal Price { get; set; }
        public CrustType CrustType { get; set; }
    }

    public enum CrustType
    {
        Stuffed, Thin
    }

    public class DiscountPoliciesMethods
    {
        public decimal BuyOneGetOneFree(PizzaOrder order)
        {
            var pizzas = order.Pizzas;
            if (pizzas.Count < 2)
            {
                return 0m;
            }
            return pizzas.Min(p => p.Price);
        }
        public decimal FivePercentOffMoreThanFiftyDollars(PizzaOrder order)
        {
            decimal nonDiscounted = order.Pizzas.Sum(p => p.Price);
            return nonDiscounted >= 50 ? nonDiscounted * 0.05m : 0M;

        }
        public decimal FiveDollarsOffStuffedCrust(PizzaOrder order)
        {
            return order.Pizzas.Sum(p => p.CrustType == CrustType.Stuffed ? 5m : 0m);
        }
    }
}
