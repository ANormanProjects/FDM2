using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Deck
    {
        public List<Card> listOfCards { get; set; }

        public Deck()
        {
            listOfCards = new List<Card>();

            SetDeck();
        }

        private void SetDeck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Face face in Enum.GetValues(typeof(Face)))
                {
                    listOfCards.Add(new Card(face, suit));
                }
            }
        }

        public void Shuffle()
        {
            Random _random = new Random();

            for (int i = 0; i < listOfCards.Count; i++)
            {
                int r = i + (int)(_random.NextDouble() * (listOfCards.Count - i));
                Card t = listOfCards[r];
                listOfCards[r] = listOfCards[i];
                listOfCards[i] = t;
            }
        }

    }
}
