using System;

namespace ClientProject
{
    class Program
    {
        static void Main(string[] args)
        {
            MagicCard1 mc1 = new MagicCard1() {
                Name = "Siren Stormtamer",
                Toughness = 1,
                Strength = 1,
                Text = "May sacrifice to prevent a targeted ability on another permanent you own"
            };
            mc1.CalculateCmc(0, 0, 1, 0, 0, 0);

            CardParser cp = new CardParser(mc1);

            cp.OutputCard();


        }
    }
}
