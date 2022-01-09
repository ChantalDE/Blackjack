using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    //class defining a dealer
    public class aDealer : aShoe
    {
        //members of the dealer class
        public List<aCard> dealerCards;
        public bool soft17;
        public int numCards;
        public int dealerHand;
        public bool containsAce;

        //constructor for a dealer with a card and soft17 for input
        public aDealer(aCard one, bool s)
        {
            //initialize all members of the dealer class
            dealerCards = new List<aCard>();
            dealerCards.Add(one);
            numCards++;
            getValHand();
            soft17 = s;
            containsAce = false;
        }

        //functon for when the dealer hits that accepts a card
        public void Hit(aCard c)
        {
            //add card to the dealers cards, increment the number of cards, and set dealer hand value
            dealerCards.Add(c);
            numCards++;
            getValHand();
        }

        //function that checks if dealer has busted
        public bool Bust() { return dealerHand > 21 ? true : false; }


        //checks the value of the current hand.--------------------------------
        public int getValHand()
        {
            //add up the value of each card in dealer hand and return it
            dealerHand = 0;
            for (int i = 0; i < dealerCards.Count(); i++)
            {
               dealerHand += getValue(dealerCards[i].cardVal);
            }
            return dealerHand;
        }

        //function to get value of any one given card
        private int getValue(string val)
        {
            //face cards are 10, Ace is initially counted as 1, and number cards are equal to that number
            //if the card is an ace, update contains ace variable
            if (val == "J" || val == "Q" || val == "K")
            {
                return 10;
            }
            else if (val == "A")
            {
                containsAce = true;
                return 1;
            }
            else
            {
                return Int16.Parse(val);
            }
        }

        //function that is called when a hand contains an ace
        //this will set the best value of the ace for the hand that does not exceed 21
        public void setBestHand()
        {
            if (dealerHand < 12)
                dealerHand += 10;
        }

        //--------------------------------------------------------------------------------------------

        //function to clear dealer data
        public void clearDealerData()
        {
            //reset all dealer data
            dealerHand = 0;
            numCards = 0;
            containsAce = false;
            dealerCards.Clear();
        }
    }
}
