namespace ReverseTicTacToeLogic
{
    public class ScoreBoard
    {
        private readonly Scores r_Scores;

        public ScoreBoard(Player i_Player1, Player i_Player2)
        {
            r_Scores = new Scores(i_Player1, i_Player2);
        }

        public void AddWinToPlayer1()
        {
            r_Scores.Player1.AddWinToScore();
        }

        public void AddWinToPlayer2()
        {
            r_Scores.Player2.AddWinToScore();
        }

        public Scores GetScores()
        {
            return r_Scores;
        }

        public class Scores
        {
            public Scores(Player i_Player1, Player i_Player2)
            {
                Player1 = i_Player1;
                Player2 = i_Player2;
            }

            public Player Player1 { get; private set; }

            public Player Player2 { get; private set; }
        }
    }
}