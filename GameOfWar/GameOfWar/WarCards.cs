using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfWar
{
    class WarCards
    {
        public List<Card> warDeck;
        //initialize the warcard list
        public WarCards()
        {
            this.warDeck = new List<Card>();
        }
        //when war cards are played we push them onto the list so we keep track of all the cards that are played
        public void putCardInDeck(Card card)
        {
            warDeck.Add(card);
        }
    }
}
