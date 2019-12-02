using System;

namespace RockPaperScissorsGame
{
    public class RockPaperScissors
    {
        private int playerOneScore = 0;
        private int playerTwoScore = 0;
        private int gameStatus = 0;

        public void IncrementScore(int playerNumber)
        {
            if (playerNumber == 1)
            {
                playerOneScore++;
            }
            else
            {
                playerTwoScore++;
            }
        }

        public int GetPlayerScore(int playerNumber)
        {
            if (playerNumber == 1)
            {
                return playerOneScore;
            }
            else
            {
                return playerTwoScore;
            }
        }

        public int GetGameStatus()
        {
            return gameStatus;
        }

        public void SetGameStatus(int status)
        {
            gameStatus = status;
        }
    }
}
