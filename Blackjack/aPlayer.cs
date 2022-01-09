using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    //class defining a player
    public class aPlayer : aShoe
    {
        //class variables for player cards, value, money, etc.
        public List<aCard> playerCards;
        public int numCards;
        public int valHand;
        public int totalMoney;
        public int betMoney;
        public bool containsAce;
        public bool busted;

        //constructor for a player that accepts 2 cards, player money, and player bet
        public aPlayer(aCard one, aCard two, int total, int bet)
        {
            //add cards to hand and increment number of cards
            playerCards = new List<aCard>();
            playerCards.Add(one);
            numCards++;
            playerCards.Add(two);
            numCards++;
            busted = false;
            //calculates val of hand
            getValHand();
            totalMoney = total;
            betMoney = bet;
        }

        //function for when player hits that accepts a card
        public void Hit(aCard c)
        {
            //add card to player hand, increment number of cards, and set hand value
            playerCards.Add(c);
            numCards++;
            getValHand();
        }

        //function that checks weather the player has busted
        public bool Bust(){ return valHand > 21 ? true : false;}        

        //function that determines the value of the player hand
        private int getValue(string val)
        {
            //face cards are worth 10, ace is initially counted as 1, and number cards return their number
            //if the card is an ace, set contains ace to true
            if (val == "J" || val == "Q" || val == "K")
                return 10;
            else if (val == "A")
            {
                containsAce = true;
                return 1;
            }
            else
                return Int16.Parse(val);
        }

        //function that gets the value of the player hand
        public int getValHand()
        {
            //return the sum of each card in the players hand value
            valHand = 0;
            for (int i = 0; i < playerCards.Count(); i++)
            {
                valHand += getValue(playerCards[i].cardVal);
            }
            return valHand;
        }

        //when player stands, if they have an ace, check best value of their hand
        //this function is called after the player stands only if they have an ace
        public void setBestHand()
        {
            if (valHand < 12)
                valHand += 10;
        }

        //function that clears player data
        public void clearPlayerData()
        {
            //reset all player data
            valHand = 0;
            numCards = 0;
            containsAce = false;
            busted = false;
            playerCards.Clear();
        }

        //function that updates players money when they win
        public void win()
        {
            totalMoney += (3 * betMoney) / 2;
        }

        //function that updates players money when they lose
        public void lose()
        {
            totalMoney -= betMoney;
        }
    }
}
