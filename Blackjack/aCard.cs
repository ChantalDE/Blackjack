using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    //class defining a card
    public class aCard
    {
        //contains a rank and a suit
        public string cardVal;
        public string cardShape;

        //default constructor
        public aCard() { }

        //constructor with rank ans suit input
        public aCard(string shape, string val)
        {
            //set card rank and suit
            cardVal = val;
            cardShape = shape;
        }
    }
}
