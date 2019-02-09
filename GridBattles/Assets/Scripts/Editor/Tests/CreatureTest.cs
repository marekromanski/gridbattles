using GridBattles;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests
{
    public class CreatureTest
    {
        private Creature _sut;

        [SetUp]
        public void CreateCreature()
        {
            _sut = new Creature();
        }

        [Test]
        public void NewCharacterHasLevelOne()
        {
            Assert.AreEqual(1, _sut.GetLevel());
        }

        [Test]
        public void NewCharacterHas10Ac()
        {
            Assert.AreEqual(10, _sut.GetAc());
        }

        [Test]
        public void NewCharacterHas10Strength()
        {
            Assert.AreEqual(10, _sut.GetStrength());
        }

        [Test]
        public void MissedAttackDoesntCauseDamage()
        {
            IHittingPolicy policy = new AlwaysMissingPolicy();

            _sut.SetHittingPolicy(policy);
            var target = new Creature();
            var hitPoints = target.GetHitPoints();

            _sut.Attack(target);
            Assert.AreEqual(hitPoints, target.GetHitPoints());
        }

        [Test]
        public void SuccessfulAttackCausesDamage()
        {
            IHittingPolicy policy = new AlwaysHittingPolicy();

            _sut.SetHittingPolicy(policy);
            var target = new Creature();
            var hitPoints = target.GetHitPoints();

            _sut.Attack(target);
            Assert.Less(target.GetHitPoints(), hitPoints);
        }

        [TestCase(1, 2)]
        [TestCase(4, 2)]
        [TestCase(5, 3)]
        [TestCase(8, 3)]
        [TestCase(9, 4)]
        [TestCase(12, 4)]
        [TestCase(13, 5)]
        [TestCase(16, 5)]
        [TestCase(17, 6)]
        [TestCase(20, 6)]
        public void ProficiencyBonusIsDeterminedByLevel(int level, int expectedProficiencyBonus)
        {
            _sut.SetLevel(level);
            Assert.AreEqual(expectedProficiencyBonus, _sut.GetProficiencyBonus());
        }
    }
}