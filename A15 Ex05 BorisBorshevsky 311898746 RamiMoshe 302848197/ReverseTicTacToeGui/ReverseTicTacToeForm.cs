using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ReverseTicTacToeLogic;
using ReverseTicTacToeLogic.Algorithms;

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

            lblPlayer1Name.Text = i_Player1.PlayerName + ": ";
            lblPlayer2Name.Text = i_Player2.PlayerName + ": ";
            
            buildBoard(i_Size);
            initializeNewGame();
        }

        private void initializeNewGame()
        {
            m_CurrentPlayer = r_Player1;
            r_TicTacToe.Board.InitializeBoard();
            foreach (TicTacToeCellButton ticTacToeCellButton in r_CellButtons)
            {
                ticTacToeCellButton.SetSymbol(eSymbol.Blank);
                ticTacToeCellButton.Enabled = true;
            }

            lblPlayer1Score.Text = r_Player1.Score.ToString();
            lblPlayer2Score.Text = r_Player2.Score.ToString();
        }

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
                Location = calcullateVisualPoint(i_LogicCordinates, r_DefaultButtonSize, k_DefaultPadding)
            };
            r_CellButtons.Add(cellButton);
            cellButton.Click += CellButton_Click;

            Controls.Add(cellButton);
        }

        private void CellButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            TicTacToeCellButton ticTacToeCellButton = i_Sender as TicTacToeCellButton;
            playTurn(ticTacToeCellButton);
        }

        private void playTurn(TicTacToeCellButton i_TicTacToeCellButton)
        {
            if (m_CurrentPlayer.PlayerType == ePlayerType.User)
            {
                TicTacToeCellButton button = getButtonByPoint(i_TicTacToeCellButton.CellLocation);
                button.SetSymbol(m_CurrentPlayer.Symbol);
                button.Enabled = false;
                r_TicTacToe.TryPlayTurn(i_TicTacToeCellButton.CellLocation, m_CurrentPlayer);
                if (!r_TicTacToe.Board.IsBoardEmpty())
                    togglePlayerTurn();
            }

            if (r_TicTacToe.Board.HasWinner())
            {
                showNewGameMessage(winnerMessage());
            }
            else if (r_TicTacToe.Board.IsBoardFull())
            {
                showNewGameMessage(tieMessage());
            }
            else
            {

                if (m_CurrentPlayer.PlayerType == ePlayerType.Computer && !r_TicTacToe.Board.IsBoardEmpty())
                {
                    playPcTurn();   
                    togglePlayerTurn();
                }
            }
        }


        private void playPcTurn()
        {
            Point pcMove = ArtificialIntelligenceAlgorithm.GetMove(r_TicTacToe.Board, m_CurrentPlayer.Symbol, getNextPlayer().Symbol);
            getButtonByPoint(pcMove).Enabled = false;
            getButtonByPoint(pcMove).SetSymbol(m_CurrentPlayer.Symbol);
            r_TicTacToe.TryPlayTurn(pcMove, m_CurrentPlayer);
        }

        private TicTacToeCellButton getButtonByPoint(Point pcMove)
        {
            return r_CellButtons[convertPointToIndexArray(pcMove)];
        }

        private int convertPointToIndexArray(Point i_Point)
        {
            return i_Point.X + i_Point.Y*(r_TicTacToe.Board.Size);
        }

        private void checkGameState()
        {
            if (r_TicTacToe.Board.HasWinner())
            {
                showNewGameMessage(winnerMessage());
            }
            else if (r_TicTacToe.Board.IsBoardFull())
            {
                showNewGameMessage(tieMessage());
            }
        }

        private void showNewGameMessage(string i_MessageToUser)
        {
            if (MessageBox.Show(
                i_MessageToUser,
                "Game Over",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
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

        private static Point calcullateVisualPoint(Point i_LogicCordinates, Size i_ButtonSize, int i_Padding)
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
