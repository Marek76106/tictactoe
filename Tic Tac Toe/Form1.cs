using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Napravite igru križić-kružić (iks-oks) korištenjem znanja stečenih na ovoj
laboratorijskoj vježbi. Omogućiti pokretanje igre, unos imena dvaju igrača, ispis
koji igrač je trenutno na potezu, igranje igre s iscrtavanjem križića i kružića na
odgovarajućim mjestima te ispis dijaloga s porukom o pobjedi, odnosno
neriješenom rezultatu kao i praćenje ukupnog rezultata.*/

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        bool turn = true;// turn=X turn; false = Y turn
        int turn_count = 0;
        int x_count = 0;
        int y_count = 0;
        
       

        public Form1()
        {
            InitializeComponent();
            
        }


        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Brlog Studios®","Križić Kružić");
        }

      
        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            SetTurnDisplay();

            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            
            turn_count++;
            checkForWinner();
            prikaziPobjede();


        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            label.Text = "Turn:" + textBox1.Text;


            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                    

                }
                catch { }
            }
        }


        private void SetTurnDisplay()
        {

            if (turn)
                label.Text = "Turn:" + textBox2.Text;
            else if (!turn)
                label.Text = "Turn:" + textBox1.Text;
            
        }


        private void checkForWinner()
        {
            bool winner = false;
                
                //horizontal check
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text)&&(!A1.Enabled))
                winner = true;
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                winner = true;
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                winner = true;
            //Vertical check
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                winner = true;
            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                winner = true;
            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                winner = true;
            //diagonal check
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                winner = true;
            if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                winner = true;




            if (winner)
            {
                disableButtons();

                String player;

                if (turn)
                {
                    player = textBox2.Text;
                    y_count++;
                }

                else
                {
                    player = textBox1.Text;
                    x_count++;
                }

                MessageBox.Show(player + " Wins!", "Huraaay! " + player);
               

            } //end if

            else
            {
                if (turn_count == 9)
                    MessageBox.Show("Draw, both of you suck equally..", "Booo!");
                y_count = y_count;   //iz nekog razloga bez ovog ne radi ispravo
                x_count = x_count;   //iz nekog razloga bez ovog ne radi ispravno
            }



        }   //end check for winner

        private void disableButtons() {
            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                   
                }
                catch { }
            }

        }
        private void prikaziPobjede()
        {
            label4.Text = x_count.ToString();
            label5.Text = y_count.ToString();
        }

        //Instructions msg
        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Prvo ukucajte imena igrača.\nX igrač po default-u igra prvi.\nIgra vam nakon prvog poteza prikazuje tko je na redu."+"\nIgra prikazuje koliko pobijeda je ostvario pojedini igrač."+
          "\nZa novu igru odaberite File->New Game."+
                "\nSretno" + ", neka bolji igrac pobijedi!"
              , "For Dummies");
        }

        private void restetWinCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vratiCout();
            prikaziPobjede();
        }
        private void vratiCout()
        {
            x_count = 0;
            y_count = 0;
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }


}
