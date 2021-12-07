using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        List<Button> field;
        int counter = 0;
        string winner;
        void CreateField()
        {
            Controls.Clear();
            winner = null;
            counter = 0;
            field = new List<Button>();
            Width = 330;
            Height = 350;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button tmp = new Button
                    {
                        Width = 100,
                        Height = 100,
                        Font = new Font(FontFamily.GenericSansSerif, 32, FontStyle.Bold),
                        Location = new Point(i * 100 + 5, j * 100 + 5)
                    };
                    tmp.Click += btnClickHandler;
                    field.Add(tmp);
                    Controls.Add(tmp);
                }
            }

        }
        public Form1()
        {
            InitializeComponent();
            Text = "TicTacToe";
            CreateField();
        }
        bool CheckLine(Button a, Button b, Button c)
        {
            if (a.Text == b.Text && a.Text == c.Text && !string.IsNullOrEmpty(a.Text))
            {
                winner = a.Text;
                return true;
            }
            return false;
        }
        void EndGame()
        {
            if (
                CheckLine(field[0], field[1], field[2])
                || CheckLine(field[3], field[4], field[5])
                || CheckLine(field[6], field[7], field[8])
                || CheckLine(field[0], field[3], field[6])
                || CheckLine(field[1], field[4], field[7])
                || CheckLine(field[2], field[5], field[8])
                || CheckLine(field[0], field[4], field[8])
                || CheckLine(field[2], field[4], field[6])
                || counter == 9)
            {
                string msg;
                if (winner != null)
                    msg = $"{winner} win";
                else
                    msg = "Draw";
                var res = MessageBox.Show(msg, "New game?", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    CreateField();
                }
                else
                {
                    Close();
                }
            }




        }
        private void btnClickHandler(object sender, EventArgs e)
        {
            Button tmp = ((Button)sender);
            if (!string.IsNullOrEmpty(tmp.Text))
                return;
            if (counter % 2 == 0)
            {
                tmp.Text = "X";
                tmp.BackColor = Color.Green;
            }
            else
            {
                tmp.Text = "O";
                tmp.BackColor = Color.Red;
            }
            counter++;
            EndGame();
        }
    }
}
