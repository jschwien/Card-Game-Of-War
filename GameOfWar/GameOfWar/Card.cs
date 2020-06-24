using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfWar
{
    class Card:ICard
    {
        public enum Rank { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };
        public enum Suite { Spades, Hearts, Clubs, Diamonds };
        // enums that contain Rank and suite of cards
        private Suite suite;
        private Rank rank;

        //constructor that take a suite and rank
        public Card(Suite s, Rank r)
        {
            this.suite = s;
            this.rank = r;
        }

        // returns the rank 
        public int getRank()
        {
            return (int)rank;
        }
        //prints card
        public void printCard()
        {
            Console.WriteLine(rank + " of " + suite);
        }     
    }  
}
