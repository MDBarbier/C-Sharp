using Moq;
using System;
using Xunit;
using ClientProject;
using Xunit.Abstractions;
using System.Collections.Generic;
using System.Collections;

namespace XUnitTestProject1
{
    public class UnitTest1
    {

        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }


        [Fact]
        public void TestInterfaceCreation()
        {
            // Create the mock
            var mock = new Mock<IMagicCard>();

            // Configure the mock to do something           
            //mock.Setup(x => x.CalculateCmc(0, 0, 1, 0, 0, 0)); //This does not work because the implementation is in MagicCard1
            mock.SetupGet(x => x.BlueMana).Returns(1);
            mock.SetupGet(x => x.Cmc).Returns(1);
            mock.SetupGet(x => x.Name).Returns("Siren Stormtamer");
            mock.SetupGet(x => x.Strength).Returns(1);
            mock.SetupGet(x => x.Toughness).Returns(1);

            // Demonstrate that the configuration works
            Assert.Equal(1, mock.Object.Cmc);

            //Invoke the output method
            Console.WriteLine(mock.Object.Name);

            // Verify that the mock was invoked
            mock.VerifyGet(x => x.Name, Times.AtLeast(1));

            CardParser cp = new CardParser(mock.Object);
            var textToOutput = cp.OutputCard();

            output.WriteLine(textToOutput);
        }

        [Theory]
        [InlineData("Llanowar Elf", 1, 0, 0, 1, 0, 0 , 0, 1, 1, "Tap to add one green mana")]
        [InlineData("Fanatical Firebrand", 1, 0, 1, 0, 0, 0, 0, 1, 1, "Haste, sacrifice to deal one damage to any target")]
        public void TestCardParserOutput1(string name, int cmc, int blue, int red, int green, int black, int white, int colourless, int strength, int toughness, string text)
        {
            // Create the mock
            var mock = new Mock<IMagicCard>();

            // Configure the mock to do something           
            //mock.Setup(x => x.CalculateCmc(0, 0, 1, 0, 0, 0)); //This does not work because the implementation is in MagicCard1
            mock.SetupGet(x => x.BlueMana).Returns(blue);
            mock.SetupGet(x => x.BlackMana).Returns(black);
            mock.SetupGet(x => x.GreenMana).Returns(green);
            mock.SetupGet(x => x.RedMana).Returns(red);
            mock.SetupGet(x => x.WhiteMana).Returns(white);
            mock.SetupGet(x => x.ColourlessMana).Returns(colourless);
            mock.SetupGet(x => x.Cmc).Returns(cmc);
            mock.SetupGet(x => x.Name).Returns(name);
            mock.SetupGet(x => x.Strength).Returns(strength);
            mock.SetupGet(x => x.Toughness).Returns(toughness);
            mock.SetupGet(x => x.Text).Returns(text);

            // Demonstrate that the configuration works
            Assert.Equal(1, mock.Object.Cmc);

            //Invoke the output method
            Console.WriteLine(mock.Object.Name);

            // Verify that the mock was invoked
            mock.VerifyGet(x => x.Name, Times.AtLeast(1));

            CardParser cp = new CardParser(mock.Object);
            var textToOutput = cp.OutputCard();

            output.WriteLine(textToOutput);
        }

        [Theory]
        [ClassData(typeof(MagicCardTestData))]
        public void TestCardParserOutput2(string name, int cmc, int blue, int red, int green, int black, int white, int colourless, int strength, int toughness, string text)
        {
            // Create the mock
            var mock = new Mock<IMagicCard>();

            // Configure the mock to do something           
            //mock.Setup(x => x.CalculateCmc(0, 0, 1, 0, 0, 0)); //This does not work because the implementation is in MagicCard1
            mock.SetupGet(x => x.BlueMana).Returns(blue);
            mock.SetupGet(x => x.BlackMana).Returns(black);
            mock.SetupGet(x => x.GreenMana).Returns(green);
            mock.SetupGet(x => x.RedMana).Returns(red);
            mock.SetupGet(x => x.WhiteMana).Returns(white);
            mock.SetupGet(x => x.ColourlessMana).Returns(colourless);
            mock.SetupGet(x => x.Cmc).Returns(cmc);
            mock.SetupGet(x => x.Name).Returns(name);
            mock.SetupGet(x => x.Strength).Returns(strength);
            mock.SetupGet(x => x.Toughness).Returns(toughness);
            mock.SetupGet(x => x.Text).Returns(text);

            //Invoke mock
            mock.Object.AssignCombatDamage(1);
            Console.WriteLine(mock.Object.Name);

            // Verify that the mock was invoked
            mock.VerifyGet(x => x.Name, Times.AtLeast(1));            
            mock.Verify(x => x.AssignCombatDamage(1));

            CardParser cp = new CardParser(mock.Object);
            var textToOutput = cp.OutputCard();

            output.WriteLine(textToOutput);
        }

        [Fact]
        public void TestStub()
        {
            // Create the mock
            var mock = new Mock<IMagicCard>();

            // start "tracking" sets/gets to this property
            mock.SetupProperty(f => f.Name);

            //This would stub all properties on the mock
            //mock.SetupAllProperties();

            // alternatively, provide a default value for the stubbed property
            mock.SetupProperty(f => f.Name, "foo");
            
            // Now you can do:
            IMagicCard foo = mock.Object;

            // Initial value was stored
            Assert.Equal("foo", foo.Name);

            // New value set which changes the initial value
            foo.Name = "bar";
            Assert.Equal("bar", foo.Name);
        }
    }

    public class MagicCardTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "Growth chamber guardian", 2, 0, 0, 1, 0, 0, 1, 2, 2, "Growth 2. When +1 counter is put on this card you may find another in your library and put it in your hand" };
            yield return new object[] { "Deadhorde Butcher", 2, 0, 1, 0, 1, 0, 0, 1, 1, "When this card deals damage to a player/planeswalker put a +1 counter on it. When it dies it deals its damage to any target" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
