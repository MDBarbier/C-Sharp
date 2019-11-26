using System;
using System.Collections.Generic;
using System.Text;

namespace ClientProject
{
    public class CardParser
    {
        public IMagicCard MagicCard { get; set; }
        public CardParser(IMagicCard magicCard)
        {
            MagicCard = magicCard;
        }

        public string OutputCard()
        {
            string message = $"The card {MagicCard.Name} has a CMC of {MagicCard.Cmc} and stats {MagicCard.Strength}/{MagicCard.Toughness}";
            Console.WriteLine(message);
            return message;
        }
    }
}
