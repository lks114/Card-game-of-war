using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameOfWar
{
    public class Deck
    {
                
        public void shuffle(ref Player Player1, ref Player Player2)
        {
            Player1.CardsInHand = new List<Card>();
            Player2.CardsInHand = new List<Card>();
            createRandomList(ref Player1, ref Player2);
        }
        private void createRandomList(ref Player P1, ref Player P2)
        {
            // used this as a starting point: https://stackoverflow.com/questions/7981766/c-sharp-creating-a-list-of-random-unique-integers
            Random rand = new Random();
            var set = new HashSet<int>();
            var nums = new List<int>();
            var list = new List<int>();
            int count = 0;
            int num;
            // create list of length 52 where each index is random and unique            
            while (count < 52)
            {
                num = rand.Next(0, 52);
                if (!set.Contains(num))
                {
                    set.Add(num);
                    list.Add(num);
                    count++;
                }
            }

            // War testing
            //count = 0;
            //while (count < 52)
            //{
            //    list.Add(count % 13);
            //    count++;
            //}

            //list[0] = 0;
            //list[1] = 1;
            //list[2] = 2;
            //list[26] = 13;
            //list[27] = 14;
            //list[28] = 17;

            for (count = 0; count < 26; count++)
            //for (count = 0; count < 3; count++)       for testing small quantities of cards - end scenarios
                {
                Card card = new Card();
                card.DeckValue = list[count];
                setCardValueAndSuit(card.DeckValue, ref card);
                P1.CardsInHand.Add(card);
            }

            for (count = 26; count < 52; count++)
            //for (count = 3; count < 5; count++)       for testing small quantities of cards - end scenarios
            {
                Card card = new Card();
                card.DeckValue = list[count];
                setCardValueAndSuit(card.DeckValue, ref card);

                P2.CardsInHand.Add(card);
            }
         }
        private void setCardValueAndSuit(int deckValue, ref Card card)
        {
            if (deckValue > 38)
            {
                card.Suit = "Diamonds";
            }
            else if (deckValue > 25)
            {
                card.Suit = "Clubs";
            }
            else if (deckValue > 12)
            {
                card.Suit = "Spades";
            }
            else
            {
                card.Suit = "Hearts";
            }

            // 2 3 4 5 6 7 8 9 10 J  Q  K  A  - suit string
            // 0 1 2 3 4 5 6 7 8  9  10 11 12 - suit value (relative value within suit)
            card.SuitValue = deckValue % 13;

            if ((deckValue % 13) == 9)
            {
                card.ValueString = "Jack";
            }
            else if ((deckValue % 13) == 10)
            {
                card.ValueString = "Queen";
            }
            else if ((deckValue % 13) == 11)
            {
                card.ValueString = "King";
            }
            else if ((deckValue % 13) == 12)
            {
                card.ValueString = "Ace";
            }
            else
            {
                card.ValueString = (deckValue % 13 + 2).ToString();
            }

        }
    }
}
