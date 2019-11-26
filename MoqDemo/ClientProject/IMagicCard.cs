using System;
using System.Collections.Generic;
using System.Text;

namespace ClientProject
{
    public interface IMagicCard
    {
        public int IdCode { get; set; }
        public string Name { get; set; }
        public int Cmc { get; set; }
        public string Text { get; set; }
        public int Strength { get; set; }
        public int Toughness { get; set; }

        public int GreenMana { get; set; }
        public int RedMana { get; set; }
        public int BlueMana { get; set; }
        public int BlackMana { get; set; }
        public int WhiteMana { get; set; }
        public int ColourlessMana { get; set; }

        public int CalculateCmc(int greenMana, int redMana, int blueMana, int blackMana, int whiteMana, int colourlessMana);

        public bool AssignCombatDamage(int damageAmount);
    }
}
