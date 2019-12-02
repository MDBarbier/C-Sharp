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

        public void CheckForGameWinner()
        {
            
            if (GetPlayerScore(1) >= 2)
            {
                SetGameStatus(1);
            }
            else if (GetPlayerScore(2) >= 2)
            {
                SetGameStatus(1);
            }
            else
            {
                SetGameStatus(0);
            }
        }

        public Outcome DoesChoiceWin(ChoiceType choice1, ChoiceType choice2)
        {
            switch (choice1)
            {
                case ChoiceType.Rock:
                    if (choice2 == ChoiceType.Scissors)
                        return Outcome.Win;
                    else if (choice2 == ChoiceType.Paper)
                        return Outcome.Loss;
                    else
                        return Outcome.Draw;

                case ChoiceType.Paper:
                    if (choice2 == ChoiceType.Rock)
                        return Outcome.Win;
                    else if (choice2 == ChoiceType.Scissors)
                        return Outcome.Loss;
                    else
                        return Outcome.Draw;

                case ChoiceType.Scissors:
                    if (choice2 == ChoiceType.Paper)
                        return Outcome.Win;
                    else if (choice2 == ChoiceType.Rock)
                        return Outcome.Loss;
                    else
                        return Outcome.Draw;
            }

            return Outcome.Win;
        }
    }

    public enum Outcome
    {
        Win, Draw, Loss
    }

    public enum ChoiceType
    {
        Rock, Paper, Scissors
    }
}
