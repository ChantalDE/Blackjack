using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    //class that defines a shoe
    public class aShoe : IDrawCard
    {
        //random variable r for shuffling deck
        Random r;

        //list of cards in shoe, number of decks initially in shoe, and cards drawn from shoe
        public List<aCard> shoeBox;
        public int numDecks;
        public int cardsDrawn;

        //default constructor
        public aShoe() { }

        
        //cards with random shuffle
        public aShoe(int num, int seed)
        {
            shoeBox = new List<aCard>();
            r = new Random(seed);
            numDecks = num;
            //puts all the cards in shoe
            FillShoeBox();
            cardsDrawn = 0;
        }

        //constructor for a shoe
        public aShoe(int num)
        {
            //initialize list of cards for shoe box, set random var to new seed, set number of decks
            shoeBox = new List<aCard>();
            r = new Random();
            numDecks = num;

            //fill the shoebox with "num" decks, initialize number of cards drawn
            FillShoeBox();
            cardsDrawn = 0;
        }

        //shuffle cards
        public void Shuffle()
        {
            //make shoebox full again
            shoeBox.Clear();
            cardsDrawn = 0;
            FillShoeBox();
        }
        
        //NOTE: when we pull a random card, the max cards decrement (cardsDrawn)
        public aCard Draw()
        {
            //num of cards
            int num = r.Next(1, (numDecks * 52) - cardsDrawn);
            aCard drew = shoeBox[num];

            //remove card from box
            shoeBox.RemoveAt(num);
            cardsDrawn++;

            return drew;
        }


        //loads all cards in shoeBox
        private List<aCard> FillShoeBox()
        {
            //define a deck of cards
            aDeckOfCards aDeck = new aDeckOfCards();

            //add the deck to to the shoe once per deck that needs to be in the shoe
            for (int i = 0; i < numDecks; i++)
            {
                for (int j = 0; j < aDeck.deck.Count(); j++)
                {
                    shoeBox.Add(aDeck.deck[j]);
                }
            }
            return shoeBox;
        }


        
    }
}
