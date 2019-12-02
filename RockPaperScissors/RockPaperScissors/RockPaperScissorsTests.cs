using System;
using Xunit;

namespace RockPaperScissors
{
    public class RockPaperScissorsTests
    {
        private int playerOneScore = 0;
        private int playerTwoScore = 0;

        //public bool GameState { get; private set; }

        [Fact]
        public void TestRockBeatsScissors()
        {
            Assert.True(Outcome.Win == DoesChoiceWin(ChoiceType.Rock, ChoiceType.Scissors));
        }

        [Fact]
        public void TestScissorsBeatsPaper()
        {
            Assert.True(Outcome.Win == DoesChoiceWin(ChoiceType.Scissors, ChoiceType.Paper));
        }

        [Fact]
        public void TestPaperBeatsRock()
        {
            Assert.True(Outcome.Win == DoesChoiceWin(ChoiceType.Paper, ChoiceType.Rock));
        }

        [Fact]
        public void TestRockLosesToPaper()
        {
            Assert.True(Outcome.Loss == DoesChoiceWin(ChoiceType.Rock, ChoiceType.Paper));
        }     
        
        [Fact]
        public void TestPaperLosesToScissors()
        {
            Assert.True(Outcome.Loss == DoesChoiceWin(ChoiceType.Paper, ChoiceType.Scissors));
        }

        [Fact]
        public void TestScissorsLosesToRock()
        {
            Assert.True(Outcome.Loss == DoesChoiceWin(ChoiceType.Scissors, ChoiceType.Rock));
        }

        [Fact]
        public void TestOutcomeIsDrawWhenSameChoices()
        {
            Assert.True(Outcome.Draw == DoesChoiceWin(ChoiceType.Rock, ChoiceType.Rock));
        }

        [Fact]
        public void TestAssignWinIncrementsPlayerOneScore()
        {
            var score = playerOneScore;
            IncrementScore(1);
            Assert.True(score +1 == playerOneScore);
        }

        private void IncrementScore(int playerNumber)
        {
            if(playerNumber ==1)
            {
                playerOneScore++;
            }
            else
            {
                playerTwoScore++;
            }
        }

        [Fact]
        public void TestAssignWinIncrementsPlayerTwoScore()
        {
            int score = playerTwoScore;
            IncrementScore(playerTwoScore);
            Assert.True(playerTwoScore == score+1);
        }

        [Fact]
        public void TestGameWonShouldBeNoWinner()
        {
            Assert.True(GameWinner() == 0);
        }

        private int GameWinner()
        {
            if (playerOneScore >= 2)
            {
                return 1;
            }
            else if (playerTwoScore >= 2)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        private Outcome DoesChoiceWin(ChoiceType choice1, ChoiceType choice2)
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

        [Fact]
        public void TestOutcomeIsDrawIfChoicesSame()
        {
            Assert.True(Outcome.Draw == DoesChoiceWin(ChoiceType.Rock, ChoiceType.Rock));
        }

    }

    enum Outcome
    {
        Win,Draw, Loss
    }

    enum ChoiceType
    {
        Rock,Paper,Scissors
    }
}
