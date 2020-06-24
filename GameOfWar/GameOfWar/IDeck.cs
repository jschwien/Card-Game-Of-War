using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfWar
{
    interface IDeck
    {
        void shuffle();

        void fillDeck();

        Card drawCard();
    
        bool isEmpty();

        void warCards(WarCards playerList, WarCards computerList);

        void putCardInDeck(Card card1, Card card2);
      
        int deckCount();   
    }
}
