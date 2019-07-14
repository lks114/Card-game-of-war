using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfWar
{
    public class Player
    {
        private List<Card> cardsInHand;
        private List<Card> cardsInPlay;

        internal List<Card> CardsInHand { get => cardsInHand; set => cardsInHand = value; }
        internal List<Card> CardsInPlay { get => cardsInPlay; set => cardsInPlay = value; }
    }
    
}
