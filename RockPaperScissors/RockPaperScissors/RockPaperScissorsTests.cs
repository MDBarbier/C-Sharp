using System;
using Xunit;

namespace RockPaperScissors
{
    public class RockPaperScissorsTests
    {
        [Fact]
        public void TestRockBeatsScissors()
        {
            Assert.True(DoesChoiceWin(ChoiceType.Rock, ChoiceType.Scissors);
        }
    }
}
