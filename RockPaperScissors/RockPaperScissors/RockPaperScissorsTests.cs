using System;
using Xunit;

namespace RockPaperScissors
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
