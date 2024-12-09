using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // arg1 - > string, text, kterýje obsahem okna
            // arg2 - > nadpis okna
            // arg3 - > ano/ne
            MessageBox.Show(
            "Vývojáø: Maksíkxd\nPravidla:umíš snad piškvorky ne? ",
            "About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // tah - kdo je na øadì
        bool turn = true; // true = X, false = O
        int pocitadlo_tahu = 0; //pøidat do btn_click a do remízy

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            turn = !turn;
            b.Enabled = false;
            pocitadlo_tahu++;
            checkWinner();
        }

        private void checkWinner()
        {
            bool winner = false;

            // [0,0] [0,1] [0,2] [0,3] [0,4]
            // [1,0] [1,1] [1,2] [1,3] [1,4]
            // [2,0] [2,1] [2,2] [2,3] [2,4]
            // [3,0] [3,1] [3,2] [3,3] [3,4]
            // [4,0] [4,1] [4,2] [4,3] [4,4]

            string[,] btn = {
{button1.Text, button2.Text, button3.Text, button4.Text, button5.Text },
{button6.Text, button7.Text, button8.Text, button9.Text, button10.Text },
{button11.Text, button12.Text, button13.Text, button14.Text, button15.Text },
{button16.Text, button17.Text, button18.Text, button19.Text, button20.Text },
{button21.Text, button22.Text, button23.Text, button24.Text, button25.Text }
};

            // øádky
            for (int i = 0; i < 5; i++)
            {
                string row = btn[i, 0];
                bool match = true;
                for (int j = 0; j < 5; j++)
                {
                    if ((btn[i, j] != row) || (btn[i, j] == ""))
                    {
                        match = false;
                    }
                }
                if (match == true)
                {
                    winner = true;
                    break;
                }
            }
            // sloupce
            for (int i = 0; i < 5; i++)
            {
                string col = btn[0, i];
                bool match = true;
                for (int j = 0; j < 5; j++)
                {
                    if ((btn[j, i] != col) || (btn[j, i] == ""))
                    {
                        match = false;
                    }
                }
                if (match == true)
                {
                    winner = true;
                    break;
                }
            }

            // diag1 a 2
            bool dig1 = true;
            bool dig2 = true;
            string digSt = btn[0, 0];
            string digNd = btn[0, 4];
            for (int i = 0; i < 5; i++)
            {
                if (btn[i, i] != digSt || btn[i, i] == "")
                    dig1 = false;
                if (btn[i, 4 - i] != digNd || btn[i, 4 - i] == "")
                    dig2 = false;
            }
            if (dig1 == true || dig2 == true)
            {
                winner = true;
            }

            if (winner)
            {
                // vítìz by mìl být pøedposlední hráè na tahu
                // ihned po kliknutí se hodnota pøehodí, proto je to naopak
                string turn_winner = "";
                if (turn)
                    turn_winner = "O";
                else
                    turn_winner = "X";
                MessageBox.Show(turn_winner + " je vítìz");
                disableButtons();// disableButtons();

            }
            else
            {
                // remíza - využily se všechny tahy a nikdo nevyhrál
                if (pocitadlo_tahu == 25)
                {
                    // timer1.Stop();
                    // disableButtons();
                    MessageBox.Show("Remíza");
                    // MessageBox.Show("Remíza. Hra dohrána za: " + label_vteriny.Text + "s", "Konec hry");
                }
            }
        }
        private void disableButtons()
        {
            //tato metoda bude vypínat všecha tlaèítka
            //všchna talèítka naèist
            //pak vzít každé a a vypnout  ho 

            Button[] tlacitka ={ button1,button2,button3,button4,button5,button5,button6,button7,button8,
                button9,button10,button11,button12,button13,button14,button15,button16,button17,button18,
                button19,button20,button21,button22,button23,button24,button25

            };
            for(int i = 0; i < tlacitka.Length; i++) 
            {
                tlacitka[i].Enabled = false;
            }

        }
        private void enableButtons()
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}