using System;
using Xunit;
using RockPaperScissorsGame;

namespace RockPaperScissorsTests
{
    public class RockPaperScissorsTests
    {
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
            RockPaperScissors rps = new RockPaperScissors();
            var score = rps.GetPlayerScore(1);
            rps.IncrementScore(1);
            Assert.True(score +1 == rps.GetPlayerScore(1));
        }        

        [Fact]
        public void TestAssignWinIncrementsPlayerTwoScore()
        {
            RockPaperScissors rps = new RockPaperScissors();
            var score = rps.GetPlayerScore(2);
            rps.IncrementScore(1);
            Assert.True(score + 1 == rps.GetPlayerScore(1));
        }

        [Fact]
        public void TestGameWonShouldBeNoWinner()
        {
            RockPaperScissors rps = new RockPaperScissors();
            GameWinner();
            Assert.True(rps.GetGameStatus() == 0);
        }

        [Fact]
        public void TestOutcomeIsDrawIfChoicesSame()
        {
            Assert.True(Outcome.Draw == DoesChoiceWin(ChoiceType.Rock, ChoiceType.Rock));
        }

        private void GameWinner()
        {
            RockPaperScissors rps = new RockPaperScissors();
            if (rps.GetPlayerScore(1) >= 2)
            {
                rps.SetGameStatus(1);
            }
            else if (rps.GetPlayerScore(2) >= 2)
            {
                rps.SetGameStatus(1);
            }
            else
            {
                rps.SetGameStatus(0);
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
