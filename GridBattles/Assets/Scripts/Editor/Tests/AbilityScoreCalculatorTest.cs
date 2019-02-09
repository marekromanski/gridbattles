using GridBattles;
using NUnit.Framework;

namespace Tests
{
    public class AbilityScoreCalculatorTest
    {
        [TestCase(20, 5)]
        [TestCase(19, 4)]
        [TestCase(18, 4)]
        [TestCase(17, 3)]
        [TestCase(16, 3)]
        [TestCase(15, 2)]
        [TestCase(14, 2)]
        [TestCase(13, 1)]
        [TestCase(12, 1)]
        [TestCase(11, 0)]
        [TestCase(10, 0)]
        [TestCase(9, -1)]
        [TestCase(8, -1)]
        [TestCase(7, -2)]
        [TestCase(6, -2)]
        [TestCase(5, -3)]
        [TestCase(4, -3)]
        [TestCase(3, -4)]
        public void ModifierValuesTest(int score, int modifier)
        {
            Assert.AreEqual(modifier, AbilityScoreCalculator.CalculateModifier(score));
        }
    }
}