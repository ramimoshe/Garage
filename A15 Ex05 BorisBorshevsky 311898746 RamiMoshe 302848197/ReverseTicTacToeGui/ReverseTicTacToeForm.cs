using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ReverseTicTacToeLogic;

namespace ReverseTicTacToeGui
{
    public partial class ReverseTicTacToeForm : Form
    {
        private static readonly Size r_DefaultButtonSize = new Size(70,70);
        private const int k_DefaultPadding = 10;
        private const int k_FooterHeight = 25;
        private readonly TicTacToeModel r_TicTacToe;

        private Player m_CurrentPlayer;
        private readonly Player r_Player1;
        private readonly Player r_Player2;

        private readonly List<TicTacToeCellButton> r_CellButtons = new List<TicTacToeCellButton>();

        public ReverseTicTacToeForm(Player i_Player1, Player i_Player2, int i_Size)
        {
            InitializeComponent();
            
            r_TicTacToe = new TicTacToeModel(i_Size, i_Player1, i_Player2);
            r_Player1 = i_Player1;
            r_Player2 = i_Player2;
            
            r_TicTacToe.OnBoardChaned += r_TicTacToe_OnBoardChange;

            setPlayerNames();
            buildBoard(i_Size);
            initializeNewGame();
        }

        private void setPlayerNames()
        {
            lblPlayer1Name.Text = r_Player1.PlayerName + ": ";
            lblPlayer2Name.Text = r_Player2.PlayerName + ": ";
        }

        void r_TicTacToe_OnBoardChange(Point i_Point, eSymbol i_Symbol, eGameState i_GameState)
        {
            TicTacToeCellButton button = getButtonByPoint(i_Point);
            button.SetSymbol(i_Symbol);
            button.Enabled = false;

            switch (i_GameState)
            {
                case eGameState.BoardFull:
                    showNewGameMessage(tieMessage());
                    break;
                case eGameState.HasWinner:
                    showNewGameMessage(winnerMessage());
                    break;
                case eGameState.Active:
                    togglePlayerTurn();
                    if (m_CurrentPlayer.PlayerType == ePlayerType.Computer)
                    {
                        playPcTurn();
                    }
                   
                    break;
            }
        }
        /// <summary>
        /// runs every new game
        /// </summary>
        private void initializeNewGame()
        {
            m_CurrentPlayer = r_Player1;
            r_TicTacToe.Board.InitializeBoard();
            resetTicTacToeButtons();
            updateScores();
        }

        private void resetTicTacToeButtons()
        {
            foreach (TicTacToeCellButton ticTacToeCellButton in r_CellButtons)
            {
                ticTacToeCellButton.SetSymbol(eSymbol.Blank);
                ticTacToeCellButton.Enabled = true;
            }
        }

        private void updateScores()
        {
            ScoreBoard.Scores scores = r_TicTacToe.GetScores();
            lblPlayer1Score.Text = scores.Player1.Score.ToString();
            lblPlayer2Score.Text = scores.Player2.Score.ToString();
        }

        /// <summary>
        /// adds all the required buttons to the form and resizes it
        /// </summary>
        /// <param name="i_BoardSize"> num of rows / cols</param>
        private void buildBoard(int i_BoardSize)
        {
            for (int col = 0; col < i_BoardSize; col++)
            {
                for (int row = 0; row < i_BoardSize; row++)
                {
                    addCellButton(new Point(row, col));
                }
            }

            ClientSize = calculateClientSize(i_BoardSize, r_DefaultButtonSize, k_DefaultPadding);
        }

        private void addCellButton(Point i_LogicCordinates)
        {
            TicTacToeCellButton cellButton = new TicTacToeCellButton(i_LogicCordinates)
            {
                Size = r_DefaultButtonSize,
                Location = calculateVisualPoint(i_LogicCordinates, r_DefaultButtonSize, k_DefaultPadding)
            };

            r_CellButtons.Add(cellButton);
            cellButton.Click += CellButton_Click;
            Controls.Add(cellButton);
        }

        private void CellButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            TicTacToeCellButton ticTacToeCellButton = i_Sender as TicTacToeCellButton;
            if (ticTacToeCellButton != null && m_CurrentPlayer.PlayerType == ePlayerType.User)
            {
                r_TicTacToe.TryPlayTurn(ticTacToeCellButton.CellLocation, m_CurrentPlayer);
            }
        }

        private void playPcTurn()
        {
            r_TicTacToe.TryPlayTurn(m_CurrentPlayer);
        }

        private TicTacToeCellButton getButtonByPoint(Point i_Point)
        {
            return r_CellButtons[convertPointToIndexArray(i_Point)];
        }

        private int convertPointToIndexArray(Point i_Point)
        {
            return i_Point.X + i_Point.Y * (r_TicTacToe.Board.Size);
        }

        private void showNewGameMessage(string i_MessageToUser)
        {
            if (MessageBox.Show(i_MessageToUser, "Game Over", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                initializeNewGame();
            }
            else
            {
                Close();
            }
        }

        private static string tieMessage()
        {
            return String.Format("Tie! {0}Would you like to play another round?", Environment.NewLine);
        }

        private string winnerMessage()
        {
            return String.Format("The winner is {0}!{1}Would you like to play another round?", getNextPlayer().PlayerName, Environment.NewLine);
        }

        private void togglePlayerTurn()
        {
            m_CurrentPlayer = getNextPlayer();
        }

        private Player getNextPlayer()
        {
            return m_CurrentPlayer == r_Player1 ? r_Player2 : r_Player1;
        }

        private static Point calculateVisualPoint(Point i_LogicCordinates, Size i_ButtonSize, int i_Padding)
        {
            return new Point(i_LogicCordinates.X*(i_ButtonSize.Width + i_Padding) + i_Padding,
                i_LogicCordinates.Y * (i_ButtonSize.Height + i_Padding) + i_Padding);
        }

        private static Size calculateClientSize(int i_BoardSize, Size i_ButtonSize, int i_Padding)
        {
            return new Size(i_BoardSize * (i_ButtonSize.Width + i_Padding) + i_Padding, i_BoardSize * (i_ButtonSize.Height + i_Padding) + i_Padding + k_FooterHeight);
        }
    }
}
