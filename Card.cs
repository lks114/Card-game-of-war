using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfWar
{
    public class Card
    {
        public int DeckValue { get; set; }      // 0 - 51 - used for shuffling in order to create a random list of 52 numbers
        public string ValueString { get; set; }  // String repesentation or a card's value, i.e. 2-10, Jack, Queen, King, Ace
        public int SuitValue { get; set; }      // 0 - 12, where 0 is equivalent to a "2", and 12 is equivalent to an ace
        public string Suit { get; set; }        // Hears, Spades, Diamonds, Clubs
    }
}
