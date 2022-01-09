using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    //class defining a deck of cards
    public class aDeckOfCards : aCard
    {
        //lists conatining all possible ranks and suits
        private List<string> suits = new List<string>() {"S", "C", "H", "D"};
        private List <string> values = new List<string>{"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        
        //list of cards in the deck
        public List<aCard> deck;


        //constructor with all cards
        public aDeckOfCards()
        {
            //initialize a deck
           deck = new List<aCard>();

           //add every combonation of rank and suit into the deck
           for(int i = 0; i < suits.Count(); i++)
            {
                for(int j = 0; j < values.Count(); j++)
                {
                    aCard card = new aCard(suits[i], values[j]);
                    deck.Add(card);
                }
            }            
        }
    }
};
