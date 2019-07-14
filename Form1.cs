using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfWar
{
    public partial class Form1 : Form
    {
        Player Player1 = new Player();
        Player Player2 = new Player();
        public Form1()
        {
            InitializeComponent();
            Lbl_Player1CardsInHand.Text = "";
            Lbl_Player2CardsInHand.Text = "";
            label4.Hide();
            label5.Hide();
            Lbl_Player1CardsInHand.Hide();
            Lbl_Player2CardsInHand.Hide();
            Lbl_Player1CardsInPlay.Text = "";
            Lbl_Player2CardsInPlay.Text = "";
            // Cannot flip unless shuffled first.
            btnFlip.Enabled = false;

        }
        private void btnShuffle_Click(object sender, EventArgs e)
        {
            Lbl_Player1CardsInPlay.Text = "";
            Lbl_Player2CardsInPlay.Text = "";
            btnFlip.Enabled = true;

            Deck deck = new Deck();
            deck.shuffle(ref Player1, ref Player2);
            showPlayerCardsInHand();
        }

        private void btnFlip_Click(object sender, EventArgs e)
        {
            // Move top card from hand to table            
            if (Player1.CardsInHand.Count > 0)
            {
                Player1.CardsInPlay = Player1.CardsInHand.GetRange(0, 1);
                Player1.CardsInHand.RemoveAt(0);
                Lbl_Player1CardsInPlay.Text = Player1.CardsInPlay[0].ValueString + " of " + Player1.CardsInPlay[0].Suit;
            }
            DoWeHaveAWinner();

            if (Player2.CardsInHand.Count > 0)
            { 
                Player2.CardsInPlay = Player2.CardsInHand.GetRange(0, 1);
                Player2.CardsInHand.RemoveAt(0);
                Lbl_Player2CardsInPlay.Text = Player2.CardsInPlay[0].ValueString + " of " + Player2.CardsInPlay[0].Suit;
            }

            DoWeHaveAWinner();
          
            showPlayerCardsInHand();
            postFlip();
        }

        private void showPlayerCardsInHand()
        {
            Lbl_Player1CardsInHand.Text = "";
            foreach (Card c in Player1.CardsInHand)
            {
                Lbl_Player1CardsInHand.Text += c.ValueString + " of " + c.Suit + "\n";
            }

            Lbl_Player2CardsInHand.Text = "";
            foreach (Card c in Player2.CardsInHand)
            {
                Lbl_Player2CardsInHand.Text += c.ValueString + " of " + c.Suit + "\n";
            }
        }

        private void postFlip()
        {
            // decide winner/loser/war
            if (Player1.CardsInPlay[0].SuitValue > Player2.CardsInPlay[0].SuitValue)
            {
                foreach (Card c in Player1.CardsInPlay)
                { 
                    Player1.CardsInHand.Add(c);
                }
                foreach (Card c in Player2.CardsInPlay)
                {
                    Player1.CardsInHand.Add(c);
                }

                MessageBox.Show("Player 1 Wins");
            }
            else if (Player1.CardsInPlay[0].SuitValue < Player2.CardsInPlay[0].SuitValue)
            {
                foreach (Card c in Player1.CardsInPlay)
                {
                    Player2.CardsInHand.Add(c);
                }
                foreach (Card c in Player2.CardsInPlay)
                {
                    Player2.CardsInHand.Add(c);
                }

                MessageBox.Show("Player 2 Wins");
            }
            else
            {
                MessageBox.Show("War");
                // pull down card from each player's deck and place it faced down
                if (Player1.CardsInHand.Count > 0)
                {
                    Player1.CardsInPlay.Insert(0, Player1.CardsInHand[0]);
                    Player1.CardsInHand.RemoveAt(0);
                    Lbl_Player1CardsInPlay.Text = Player1.CardsInPlay[0].ValueString + " of " + Player1.CardsInPlay[0].Suit + " (Face Down)\n" + Lbl_Player1CardsInPlay.Text;
                }
                DoWeHaveAWinner();

                if (Player2.CardsInHand.Count > 0)
                {
                    Player2.CardsInPlay.Insert(0, Player2.CardsInHand[0]);
                    Player2.CardsInHand.RemoveAt(0);
                    Lbl_Player2CardsInPlay.Text = Player2.CardsInPlay[0].ValueString + " of " + Player2.CardsInPlay[0].Suit + " (Face Down)\n" + Lbl_Player2CardsInPlay.Text;
                }
                DoWeHaveAWinner();

                // pull down second card from each player's deck and place it facing up
                if (Player1.CardsInHand.Count > 0)
                { 
                    Player1.CardsInPlay.Insert(0, Player1.CardsInHand[0]);
                    Player1.CardsInHand.RemoveAt(0);
                    Lbl_Player1CardsInPlay.Text = Player1.CardsInPlay[0].ValueString + " of " + Player1.CardsInPlay[0].Suit + "\n" + Lbl_Player1CardsInPlay.Text;
                }
                DoWeHaveAWinner();

                if (Player2.CardsInHand.Count > 0)
                { 
                    Player2.CardsInPlay.Insert(0, Player2.CardsInHand[0]);
                    Player2.CardsInHand.RemoveAt(0);
                    Lbl_Player2CardsInPlay.Text = Player2.CardsInPlay[0].ValueString + " of " + Player2.CardsInPlay[0].Suit + "\n" + Lbl_Player2CardsInPlay.Text;
                }
                DoWeHaveAWinner();
                showPlayerCardsInHand();

                // recursively call this function until we get a winner
                postFlip();
            }
            showPlayerCardsInHand();
            Lbl_Player1CardsInPlay.Text = "";
            Lbl_Player2CardsInPlay.Text = "";
        }
        private void DoWeHaveAWinner()
        {
            if (Player2.CardsInHand.Count == 0)
            {
                showPlayerCardsInHand();
                MessageBox.Show("Game Over - Player 1 Wins !!!");
                Application.Exit();
            }
            else if (Player1.CardsInHand.Count == 0)
            {
                showPlayerCardsInHand();
                MessageBox.Show("Game Over - Player 2 Wins !!!");
                Application.Exit();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // See each player's cards or not.
            if (checkBox1.Checked)
            {
                label4.Show();
                label5.Show();
                Lbl_Player1CardsInHand.Show();
                Lbl_Player2CardsInHand.Show();
            }
            else
            {
                label4.Hide();
                label5.Hide();
                Lbl_Player1CardsInHand.Hide();
                Lbl_Player2CardsInHand.Hide();
            }
        }
    }
}
