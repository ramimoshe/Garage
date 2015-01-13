using System.Drawing;
using ReverseTicTacToeLogic.Algorithms;

namespace ReverseTicTacToeLogic
{
    public class TicTacToeModel
    {
        private readonly ScoreBoard r_ScoreBoard;

        public delegate void BoardChaned(Point i_Point, eSymbol i_Symbol, eGameState i_GameState);
        public event BoardChaned OnBoardChaned;

        public Board Board { get; private set; }

        public TicTacToeModel(int i_Size, Player i_Player1, Player i_Player2)
        {
            r_ScoreBoard = new ScoreBoard(i_Player1, i_Player2);
            Board = new Board(i_Size);
            Board.InitializeBoard();
        }

        public eCellState TryPlayTurn(Player i_Player)
        {
            eSymbol opponentSymbol = i_Player.Symbol == eSymbol.O ? eSymbol.X : eSymbol.O;
            Point computerMove = ArtificialIntelligenceAlgorithm.GetMove(Board, i_Player.Symbol, opponentSymbol);
            
            return TryPlayTurn(computerMove, i_Player);
        }

        public eCellState TryPlayTurn(Point i_Coordinates, Player i_Player)
        {
            eCellState cellState = Board.GetCellState(i_Coordinates);

            if (cellState == eCellState.Empty)
            {
                Board.SetSymbol(i_Player.Symbol, i_Coordinates);
            }

            if (Board.HasWinner())
            {
                addScoreToOpponent(i_Player);
                if (OnBoardChaned != null)
                {
                    OnBoardChaned(i_Coordinates, i_Player.Symbol, eGameState.HasWinner);
                }
            }
            else
            {
                if (Board.IsBoardFull())
                {
                    if (OnBoardChaned != null)
                    {
                        OnBoardChaned(i_Coordinates, i_Player.Symbol, eGameState.BoardFull);
                    }
                }
                else
                {
                    if (OnBoardChaned != null)
                    {
                        OnBoardChaned(i_Coordinates, i_Player.Symbol, eGameState.Active);
                    }
                }
            }

            return cellState;
        }

        private void addScoreToOpponent(Player i_CurrentPlayer)
        {
            if (r_ScoreBoard.GetScores().Player1 == i_CurrentPlayer)
            {
                r_ScoreBoard.AddWinToPlayer2();
            }
            else
            {
                r_ScoreBoard.AddWinToPlayer1();
            }
        }

        public ScoreBoard.Scores GetScores()
        {
            return r_ScoreBoard.GetScores();
        }

        public void Surrender(Player i_Player)
        {
            addScoreToOpponent(i_Player);
        }
    }
}