using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfWar
{
    class Deck : IDeck
    {
        public List<Card> cardDeck;

        //constructor that initializes the current deck
        public Deck()
        {
            this.cardDeck = new List<Card>();
        }
        //using random number generator we randomize the deck
        public void shuffle()
        {
            Random r = new Random();

            for (int i = cardDeck.Count - 1; i > 0; --i)
            {
                int random = r.Next(i + 1);
                Card temp = cardDeck[i];
                cardDeck[i] = cardDeck[random];
                cardDeck[random] = temp;
            }
        }

        // fills the main deck of cards
        public void fillDeck()
        {
            //Suite of the card
            for (int i = 0; i < Enum.GetValues(typeof(Card.Suite)).Length; i++)
            {
                // Rank of the card
                for (int j = 0; j < Enum.GetValues(typeof(Card.Rank)).Length; j++)
                {
                    // Creates a new card with the suite and rank and adds it to the deck
                    cardDeck.Add(new Card((Card.Suite)i, (Card.Rank)j));
                }
            }
        }

        //removes the first card from the deck
        public Card drawCard()
        {
            Card topDeckCard = cardDeck[0];

            cardDeck.Remove(topDeckCard);

            return (topDeckCard);
        }

        //check to see if the deck is empty
        public bool isEmpty()
        {
            if (cardDeck.Count <= 0)
            {
                return true;
            }
            return false;
        }
        // adds all the warcards that are won onto the the deck
        public void warCards(WarCards playerList, WarCards computerList)
        {
            foreach (Card card in playerList.warDeck)
            {
                cardDeck.Add(card);
            }

            foreach (Card card in computerList.warDeck)
            {
                cardDeck.Add(card);
            }
            shuffle();
        }

        // returns the current deck count
        public int deckCount()
        {
            return cardDeck.Count();
        }

        //if player of computer wins a card place both cards into the deck and shuffle
        public void putCardInDeck(Card card1, Card card2)
        {
            cardDeck.Add(card1);
            cardDeck.Add(card2);         
        }
    }
}
