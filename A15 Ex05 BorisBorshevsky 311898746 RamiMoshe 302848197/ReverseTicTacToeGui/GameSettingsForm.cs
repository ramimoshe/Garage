using System;
using System.Windows.Forms;
using ReverseTicTacToeLogic;

namespace ReverseTicTacToeGui
{
    public partial class GameSettingsForm : Form
    {
        private const string k_ComputerName = "[Computer]";
        
        public GameSettingsForm()
        {
            InitializeComponent();
        }

        private void cBPlayer2_CheckedChanged(object i_Sender, EventArgs e)
        {
            CheckBox checkBox = i_Sender as CheckBox;
            if (checkBox != null)
            {
                tbPlayer2.Enabled = checkBox.Checked;
                if (!checkBox.Checked)
                {
                    tbPlayer2.Text = k_ComputerName;
                }
            }
        }

        private void ButtonStart_Click(object i_Sender, EventArgs e)
        {
            Player player1 = new Player(ePlayerType.User, eSymbol.X, tbPlayer1.Text);
            Player player2 = new Player(getPlayer2Type(), eSymbol.O, tbPlayer2.Text);
            int size = (int)nUDRows.Value;

            Hide();
            new ReverseTicTacToeForm(player1, player2, size).ShowDialog();
        }

        private void nUD_ValueChanged(object i_Sender, EventArgs e)
        {
            NumericUpDown numericUpDown = i_Sender as NumericUpDown;
            if (numericUpDown != null)
            {
                nUDCols.Value = numericUpDown.Value;
                nUDRows.Value = numericUpDown.Value;
            }
        }

        private ePlayerType getPlayer2Type()
        {
            var playerType = cBPlayer2.Checked ? ePlayerType.User : ePlayerType.Computer;

            return playerType;
        }
    }
}
