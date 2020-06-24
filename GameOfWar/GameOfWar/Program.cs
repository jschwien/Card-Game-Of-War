using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfWar
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("WELCOME TO THE GAME OF WAR!");
            Console.WriteLine("Press Enter to begin the game");
            //seperate deck piles for computer and player
            Deck player = new Deck();
            Deck computer = new Deck();
            //generate the main deck fill it and shuffle it
            Deck mainDeck = new Deck();
            mainDeck.fillDeck();
            mainDeck.shuffle();

                // splitting the deck between the computer and player giving one card each at a time  
                bool toggle = false;
                
                foreach (Card card in mainDeck.cardDeck)
                {
                    if (toggle)
                    {
                        player.cardDeck.Add(card);
                    }
                    else
                    {
                        computer.cardDeck.Add(card);
                    }
                    toggle = !toggle;
                }

            //Call Game of war Function, 
            //Main part of the game
            gameOfWar(player, computer);
         
            Console.ReadKey();
        }


        public static void gameOfWar(Deck player, Deck computer)
        {
            //while the player or computer still has cards left keep playing until one of them runs out
            while (!player.isEmpty() && !computer.isEmpty())
            {
                Console.ReadLine();

                // Each player draws a card

                Card playerDraw = player.drawCard();
                Card computerDraw = computer.drawCard();

                Console.Write("Player has drawn: ");
                playerDraw.printCard();
                Console.Write("Computer has drawn: ");
                computerDraw.printCard();
                Console.WriteLine("");
                Console.WriteLine("Player Cards " + player.deckCount());
                Console.WriteLine("Computer Cards " + computer.deckCount());

                //check to see if the payer or computer have higher rank than the other
                if (playerDraw.getRank() > computerDraw.getRank())
                {
                    Console.WriteLine("The Player has won the cards.The cards have been placed in your deck.\n\n");
                    player.putCardInDeck(playerDraw, computerDraw);
                }
                else if (playerDraw.getRank() < computerDraw.getRank())
                {
                    Console.WriteLine("The Computer has won the cards.\nThe cards have been placed in the computer's deck.\n\n");
                    computer.putCardInDeck(playerDraw, computerDraw);
                }
                // if there is a draw on the last card on either the player or computer they lose
                else if(player.isEmpty())
                {                    
                    Console.WriteLine("Player has No Cards left");
                }
                else if(computer.isEmpty())
                {
                    Console.WriteLine("Computer has No Cards left");
                }
                else {
                    bool war = true;

                    //create new warDecks to place warCards in 
                    WarCards playerWarCards = new WarCards();
                    WarCards computerWarCards = new WarCards();
                    
                    //put the cards that are equal in the deck
                    playerWarCards.putCardInDeck(playerDraw);
                    computerWarCards.putCardInDeck(computerDraw);
                    //WAR phase 
                    //while the players/computer cards are not empty and while the opponents dont draw equal cards we loop
                    while (war && !player.isEmpty() && !computer.isEmpty())
                    {

                        Console.WriteLine("DRAW! It's time for WAR!\n\n");
                        Console.ReadLine();
                        Console.WriteLine("-----------------------------------------------------------------------------------\n");

                        Console.WriteLine("Computer and Player face one card down\n");

                        playerDraw = player.drawCard();
                        computerDraw = computer.drawCard();

                        //check to see if the computer or player has any cards left after there face down
                        //if no cards left we stop the war 
                        if (player.isEmpty())
                        {
                            Console.WriteLine("Player has No Cards left");
                            war = false;
                        }
                        else if (computer.isEmpty())
                        {
                            Console.WriteLine("Computer has No Cards left");
                            war = false;
                        }
                        else
                        {                      
                            playerWarCards.putCardInDeck(playerDraw);
                            computerWarCards.putCardInDeck(computerDraw);

                            Console.WriteLine("WAR DRAW!");
                            playerDraw = player.drawCard();
                            computerDraw = computer.drawCard();

                            Console.Write("Player has drawn: ");
                            playerDraw.printCard();
                            Console.Write("Computer has drawn:");
                            computerDraw.printCard();
                            Console.WriteLine("");
                            Console.WriteLine("Player Cards " + player.deckCount());
                            Console.WriteLine("Computer Cards " + computer.deckCount());

                            playerWarCards.putCardInDeck(playerDraw);
                            computerWarCards.putCardInDeck(computerDraw);

                            if (playerDraw.getRank() > computerDraw.getRank())
                            {
                                Console.WriteLine("The Player has won the WAR. The cards have been placed in your deck.\n\n");
                                player.warCards(playerWarCards, computerWarCards);
                                war = false;
                            }
                            else if (playerDraw.getRank() < computerDraw.getRank())
                            {
                                Console.WriteLine("The Computer has won the WAR. The cards have been placed in the computer's deck.\n\n");
                                computer.warCards(playerWarCards, computerWarCards);
                                war = false;
                            }
                            else
                            {
                                war = true;
                            }
                        }
                    }
                }
                Console.WriteLine("================================================================================");
            }
            //check to see who deck is empty and declare winner
            if (player.isEmpty())
            {
                Console.WriteLine("the Computer has won!");
                Console.WriteLine("Computer Cards " + computer.deckCount());
            }

            else
            {
                Console.WriteLine("the Player has won!");
                Console.WriteLine("Player Cards " + player.deckCount());
            }
        }

    }




}
