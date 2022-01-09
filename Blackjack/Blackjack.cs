using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//This project was created by
//Michael Bodzenski and Chantal Espinosa


namespace Blackjack
{
    public partial class Blackjack : Form
    {
        //define player, dealer, and shoe object for table
        private aPlayer p1;
        private aDealer dealer;
        private aShoe shoe;

        //define soft17 and numDecks members of class
        private bool soft17;
        private int numDecks;

        public Blackjack() { }

        //function to initialize the table
        public Blackjack(bool soft, string decks, string s)
        {
            InitializeComponent();

            //if there is a seed, use the set seed constructor
            if (s != "")
            {
                shoe = new aShoe(Int32.Parse(decks), Int32.Parse(s));
                Text += " Seed:" + s + "/NumDecks:" + decks + "/Soft17:" + soft;
            }
            //else use the random seed constructor
            else
            {
                shoe = new aShoe(Int32.Parse(decks));
                Text += " Seed:RANDOM/NumDecks:" + decks + "/Soft17:" + soft;
            }

            //set class variables that track number of decks and soft17
            numDecks = Int32.Parse(decks);
            soft17 = soft;

            //disable hit/stand button before game starts
            disableGameButtons();
        }

        private void Blackjack_Load(object sender, EventArgs e)
        {

        }

        private void button_play_Click(object sender, EventArgs e)
        {
            //if the deck contains less than 30 cards don't start a new game
            if ((shoe.numDecks * 52) - shoe.cardsDrawn < 30)
                return;

            //if player bet is invalid, don't start game
            if (int.Parse(textBox_bet.Text) < 0 || int.Parse(textBox_bet.Text) > int.Parse(textBox_total.Text))
                return;

            //clear previous game data if a previous game has been played
            if (p1 != null)
                clearGame();

            //initialize number of players with cards
            p1 = new aPlayer(shoe.Draw(), shoe.Draw(), int.Parse(textBox_total.Text), int.Parse(textBox_bet.Text));

            //set player money & bet money
            p1.totalMoney = int.Parse(textBox_total.Text);
            p1.betMoney = int.Parse(textBox_bet.Text);

            //initialize dealer with 1 card
            //define soft17
            dealer = new aDealer(shoe.Draw(), soft17);

            //display the cards that the player/dealer have
            updatePlayerCards();
            updateDealerCards();

            //set the value of the player/daealers hands
            p1.getValHand();
            dealer.getValHand();

            //display the value of the player/dealers hand
            label_playerValueNumber.Text = p1.valHand.ToString();
            label_dealerValueNumber.Text = dealer.dealerHand.ToString();

            //if the player has an ace, display the other possible value of their hand
            if (p1.containsAce && p1.valHand < 12)
                label_playerValueNumber.Text += " or " + (p1.valHand + 10).ToString();

            //if the dealer has an ace, display the other possible value of their hand
            if (dealer.containsAce && dealer.dealerHand < 12)
                label_dealerValueNumber.Text += " or " + (dealer.dealerHand + 10).ToString();

            //enable hit/stand buttons and disable play/reset buttons
            enableGameButtons();
        }

        //function to reshuffle the deck and clear previous game data
        private void button_reset_Click(object sender, EventArgs e)
        {
            //reshuffle deck and clear previous game data
            shoe.Shuffle();
            clearGame();
        }

        //function for when player hits
        private void button_hit_Click(object sender, EventArgs e)
        {
            //deal 1 card to player and display it
            p1.Hit(shoe.Draw());
            updatePlayerCards();

            //set player hand value and display it
            p1.getValHand();
            label_playerValueNumber.Text = p1.valHand.ToString();

            //if player has an ace, display the other possible hand value
            if (p1.containsAce && p1.valHand < 12)
                label_playerValueNumber.Text += " or " + (p1.valHand + 10).ToString();

            //check value of players hand
            //if > 21, call lose function
            if (p1.Bust())
            {
                label_playerValueNumber.Text = "BUST";
                playerLoses();
            }
        }

        //function for when player stands
        private void button_stand_Click(object sender, EventArgs e)
        {
            //if player has an ace, set the value of their hand to the better value of ace
            if(p1.containsAce)
                p1.setBestHand();

            //update the player hand value label
            label_playerValueNumber.Text = p1.valHand.ToString();

            //call function that plays game for dealer
            playDealer();
        }

        //function for when player wins game
        public void playerWins()
        {
            //update the w/l/t label and update the player money
            label_winLossTieValue.Text = "Win";
            p1.win();

            //display player's new total money
            textBox_total.Text = p1.totalMoney.ToString();

            //disable hit/play buttons and enable play/reset buttons
            disableGameButtons();
        }

        //function for when player loses game
        public void playerLoses()
        {
            //set w/l/t label to lose and update te player money
            label_winLossTieValue.Text = "Lose";
            p1.lose();

            //display player's new total money
            textBox_total.Text = p1.totalMoney.ToString();

            //disable hit/play buttons and enable play/reset buttons
            disableGameButtons();
        }

        //function for when player ties game
        public void playerTies()
        {
            //update w/l/t label
            label_winLossTieValue.Text = "Tie";

            //disable hit/play buttons and enable play/reset buttons
            disableGameButtons();
        }

        //function that displays the player's cards
        public void updatePlayerCards()
        {
            //display the initial two cards that the player is dealt
            label_playerCard1.Text = p1.playerCards[0].cardVal.ToString() + p1.playerCards[0].cardShape.ToString();
            label_playerCard2.Text = p1.playerCards[1].cardVal.ToString() + p1.playerCards[1].cardShape.ToString();

            //display the card that the player most recently drew
            switch (p1.numCards)
            {
                case 11:
                    label_playerCard11.Text = p1.playerCards[10].cardVal.ToString() + p1.playerCards[10].cardShape.ToString();
                    break;
                case 10:
                    label_playerCard10.Text = p1.playerCards[9].cardVal.ToString() + p1.playerCards[9].cardShape.ToString();
                    break;
                case 9:
                    label_playerCard9.Text = p1.playerCards[8].cardVal.ToString() + p1.playerCards[8].cardShape.ToString();
                    break;
                case 8:
                    label_playerCard8.Text = p1.playerCards[7].cardVal.ToString() + p1.playerCards[7].cardShape.ToString();
                    break;
                case 7:
                    label_playerCard7.Text = p1.playerCards[6].cardVal.ToString() + p1.playerCards[6].cardShape.ToString();
                    break;
                case 6:
                    label_playerCard6.Text = p1.playerCards[5].cardVal.ToString() + p1.playerCards[5].cardShape.ToString();
                    break;
                case 5:
                    label_playerCard5.Text = p1.playerCards[4].cardVal.ToString() + p1.playerCards[4].cardShape.ToString();
                    break;
                case 4:
                    label_playerCard4.Text = p1.playerCards[3].cardVal.ToString() + p1.playerCards[3].cardShape.ToString();
                    break;
                case 3:
                    label_playerCard3.Text = p1.playerCards[2].cardVal.ToString() + p1.playerCards[2].cardShape.ToString();
                    break;
            }
        }

        //function that displays the dealer's cards
        public void updateDealerCards()
        {
            //display the dealer's initial card
            label_dealerCard1.Text = dealer.dealerCards[0].cardVal.ToString() + dealer.dealerCards[0].cardShape.ToString();

            //display the card that the dealer most recently drew
            switch (dealer.numCards)
            {
                case 11:
                    label_dealerCard11.Text = dealer.dealerCards[10].cardVal.ToString() + dealer.dealerCards[10].cardShape.ToString();
                    goto case 10;
                case 10:
                    label_dealerCard10.Text = dealer.dealerCards[9].cardVal.ToString() + dealer.dealerCards[9].cardShape.ToString();
                    goto case 9;
                case 9:
                    label_dealerCard9.Text = dealer.dealerCards[8].cardVal.ToString() + dealer.dealerCards[8].cardShape.ToString();
                    goto case 8;
                case 8:
                    label_dealerCard8.Text = dealer.dealerCards[7].cardVal.ToString() + dealer.dealerCards[7].cardShape.ToString();
                    goto case 7;
                case 7:
                    label_dealerCard7.Text = dealer.dealerCards[6].cardVal.ToString() + dealer.dealerCards[6].cardShape.ToString();
                    goto case 6;
                case 6:
                    label_dealerCard6.Text = dealer.dealerCards[5].cardVal.ToString() + dealer.dealerCards[5].cardShape.ToString();
                    goto case 5;
                case 5:
                    label_dealerCard5.Text = dealer.dealerCards[4].cardVal.ToString() + dealer.dealerCards[4].cardShape.ToString();
                    goto case 4;
                case 4:
                    label_dealerCard4.Text = dealer.dealerCards[3].cardVal.ToString() + dealer.dealerCards[3].cardShape.ToString();
                    goto case 3;
                case 3:
                    label_dealerCard3.Text = dealer.dealerCards[2].cardVal.ToString() + dealer.dealerCards[2].cardShape.ToString();
                    goto case 2;
                case 2:
                    label_dealerCard2.Text = dealer.dealerCards[1].cardVal.ToString() + dealer.dealerCards[1].cardShape.ToString();
                    break;
            }
        }

        //function to reset the labels of the player cards to blank
        public void resetPlayerCards()
        {
            label_playerCard1.Text = "";
            label_playerCard2.Text = "";
            label_playerCard3.Text = "";
            label_playerCard4.Text = "";
            label_playerCard5.Text = "";
            label_playerCard6.Text = "";
            label_playerCard7.Text = "";
            label_playerCard8.Text = "";
            label_playerCard9.Text = "";
            label_playerCard10.Text = "";
            label_playerCard11.Text = "";
        }

        //function to reset the label of the dealers cards to blank
        public void resetDealerCards()
        {
            label_dealerCard1.Text = "";
            label_dealerCard2.Text = "";
            label_dealerCard3.Text = "";
            label_dealerCard4.Text = "";
            label_dealerCard5.Text = "";
            label_dealerCard6.Text = "";
            label_dealerCard7.Text = "";
            label_dealerCard8.Text = "";
            label_dealerCard9.Text = "";
            label_dealerCard10.Text = "";
            label_dealerCard11.Text = "";
        }

        //function to clear the previous game data from the table
        public void clearGame()
        {
            //clear player/dealer data
            if (p1 != null)
                p1.clearPlayerData();
            if (dealer != null)
                dealer.clearDealerData();

            //reset labels
            resetPlayerCards();
            resetDealerCards();

            //reset dealer/player value labels and w/l/t label
            label_dealerValueNumber.Text = "-";
            label_playerValueNumber.Text = "-";
            label_winLossTieValue.Text = "-";
        }

        //function that plays for the dealer
        public void playDealer()
        {
            //loop runs until dealer is done drawing cards
            while (dealer.dealerHand < 18)
            {
                //if we are playing soft17 and dealer has 17, stop drawing cards
                if (soft17 && dealer.dealerHand == 17)
                    break;

                //dealer draws a card and displays it
                dealer.Hit(shoe.Draw());
                updateDealerCards();

                //set dealer hand value and display it
                dealer.getValHand();
                label_dealerValueNumber.Text = dealer.dealerHand.ToString();

                //if dealer has an ace, display the other possible hand value
                if (dealer.containsAce && dealer.dealerHand < 12)
                    label_dealerValueNumber.Text += " or " + (dealer.dealerHand + 10).ToString();

                //set dealer hand value if hand contains an ace
                if (dealer.containsAce)
                    dealer.setBestHand();
            }

            //display the dealers hand value
            label_dealerValueNumber.Text = dealer.dealerHand.ToString();

            //if dealer busted, update dealer value label and player wins
            //else if the player's hand is more valuable than the dealer's the player wins
            //else if the players hand has the same value as the dealer the player ties
            //else the player has lost to the dealer
            if (dealer.Bust())
            {
                label_dealerValueNumber.Text = "BUST";
                playerWins();
                return;
            }
            else if (p1.valHand > dealer.dealerHand)
            {
                playerWins();
                return;
            }
            else if (p1.valHand == dealer.dealerHand)
            {
                playerTies();
                return;
            }
            else
                playerLoses();
        }

        //function to enable hit/stand buttons and disable play/reset buttons
        private void enableGameButtons()
        {
            //disable play and reset buttons
            button_play.Enabled = false;
            button_reset.Enabled = false;

            //enable hit and stand buttons
            button_hit.Enabled = true;
            button_stand.Enabled = true;
        }

        //function to disable hit/stand buttons and disable play/reset buttons
        private void disableGameButtons()
        {
            //enable play and reset buttons
            button_play.Enabled = true;
            button_reset.Enabled = true;

            //disable hit and stand buttons
            button_hit.Enabled = false;
            button_stand.Enabled = false;
        }
    }
}