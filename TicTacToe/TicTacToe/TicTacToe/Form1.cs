using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool turn = true; //true = X turn ; false = O turn
        int turn_count = 0;
        Players p1 = new Players("Player 1", 0);
        Players p2 = new Players("Player 2", 0);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Daniel", "Tic Tac Toe Mother Fucker");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;
            turn_count++;

            checkForWinner();
        }
        private void checkForWinner()
        {
            bool there_is_a_winner = false;
            //hor
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;
            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;
            //vert
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;
            //diag
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                there_is_a_winner = true;


            if (there_is_a_winner)
            {
                disableButtons();

                String winner = "";
                if (turn)
                {
                    winner = Player2Label.Text;
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                    p2.Score++;
                    NewGame();
                }
                else
                {
                    winner = Player1Label.Text;
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                    p1.Score++;
                    NewGame();
                }
                MessageBox.Show(winner + " Wins!", "Yay!");
            }
            else
            {
                if (turn_count == 9)
                {
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show("It was a Draw!", "Damn!");
                    NewGame();
                }
            }
        }
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;


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
            Scores.Text = "Show Scores";

        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }
        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void resetScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            draw_count.Text = "0";
            p1.Score = 0;
            p2.Score = 0;

        }
        private void NewGame()
        {
            turn = true;
            turn_count = 0;


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
            Scores.Text = "Show Scores";
        }

        private void player1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("Enter Name:", "Player 1");
            p1.Name = promptValue;
            Player1Label.Text = promptValue;

        }
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }

        private void player2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("Enter Name:", "Player 2");
            p2.Name = promptValue;
            Player2Label.Text = promptValue;
        }

        private void resetNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player1Label.Text = "Player 1";
            p1.Name = "Player 1";
            Player2Label.Text = "Player 2";
            p2.Name = "Player 2";
        }

        private void show_obj_score(object sender, EventArgs e)
        {
            string message = p1.Name + "'s score is " + p1.Score + " and " + p2.Name + "'s score is " + p2.Score + "!";
            string title = "Scores BB!";
            MessageBox.Show(message, title);
        }
    }
    
}
