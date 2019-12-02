using System;
using Xunit;
using RockPaperScissorsGame;

namespace RockPaperScissorsTests
{
    public class RockPaperScissorsTests
    {
        [Theory]
        [InlineData(ChoiceType.Rock, ChoiceType.Scissors, Outcome.Win)]
        public void TestOutcomeIsAsExpected(ChoiceType choice1, ChoiceType choice2, Outcome outcome)
        {
            Assert.True(Outcome.Win == new RockPaperScissors().DoesChoiceWin(choice1, choice2));
        }

        [Fact]
        public void TestRockBeatsScissors()
        {
            Assert.True(Outcome.Win == new RockPaperScissors().DoesChoiceWin(ChoiceType.Rock, ChoiceType.Scissors));
        }

        [Fact]
        public void TestScissorsBeatsPaper()
        {
            Assert.True(Outcome.Win == new RockPaperScissors().DoesChoiceWin(ChoiceType.Scissors, ChoiceType.Paper));
        }

        [Fact]
        public void TestPaperBeatsRock()
        {
            Assert.True(Outcome.Win == new RockPaperScissors().DoesChoiceWin(ChoiceType.Paper, ChoiceType.Rock));
        }

        [Fact]
        public void TestRockLosesToPaper()
        {
            Assert.True(Outcome.Loss == new RockPaperScissors().DoesChoiceWin(ChoiceType.Rock, ChoiceType.Paper));
        }     
        
        [Fact]
        public void TestPaperLosesToScissors()
        {
            Assert.True(Outcome.Loss == new RockPaperScissors().DoesChoiceWin(ChoiceType.Paper, ChoiceType.Scissors));
        }

        [Fact]
        public void TestScissorsLosesToRock()
        {
            Assert.True(Outcome.Loss == new RockPaperScissors().DoesChoiceWin(ChoiceType.Scissors, ChoiceType.Rock));
        }

        [Fact]
        public void TestOutcomeIsDrawWhenSameChoices()
        {
            Assert.True(Outcome.Draw == new RockPaperScissors().DoesChoiceWin(ChoiceType.Rock, ChoiceType.Rock));
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
            rps.CheckForGameWinner();
            Assert.True(rps.GetGameStatus() == 0);
        }

        [Fact]
        public void TestOutcomeIsDrawIfChoicesSame()
        {
            Assert.True(Outcome.Draw == new RockPaperScissors().DoesChoiceWin(ChoiceType.Rock, ChoiceType.Rock));
        }
    }

    
}
