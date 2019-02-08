using GridBattles;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests
{
    public class StrengthAttackPolicyTest
    {
        [Test]
        public void CriticalFailAlwaysMisses()
        {
            var random = new CriticalFailSource();

            StrengthHittingPolicy sut = new StrengthHittingPolicy(random);
            Character source = new Character();
            Character target = new Character();

            bool result = sut.DetermineHit(source, target);
            Assert.IsFalse(result);
        }

        [Test]
        public void CriticalSuccessAlwaysHits()
        {
            var random = new CriticalSuccessSource();

            StrengthHittingPolicy sut = new StrengthHittingPolicy(random);
            Character source = new Character();
            Character target = new Character();

            bool result = sut.DetermineHit(source, target);
            Assert.IsTrue(result);
        }

        [Test]
        public void AttackHitsIfItsTotalIsGreaterThanArmorClass()
        {
            var random = new ControlledRandomSource {nextResult = 11};

            StrengthHittingPolicy sut = new StrengthHittingPolicy(random);
            Character source = new Character();
            Character target = new Character();

            bool result = sut.DetermineHit(source, target);
            Assert.IsTrue(result);
        }

        [Test]
        public void AttackHitsIfItsRollWithoutBonusesIsEqualToArmorClass()
        {
            var random = new ControlledRandomSource {nextResult = 10};

            StrengthHittingPolicy sut = new StrengthHittingPolicy(random);
            Character source = new Character();
            Character target = new Character();

            bool result = sut.DetermineHit(source, target);
            Assert.IsTrue(result);
        }

        [Test]
        public void AttackHitsIfItsTotalIsEqualToArmorClass()
        {
            var random = new ControlledRandomSource {nextResult = 9};

            StrengthHittingPolicy sut = new StrengthHittingPolicy(random);
            Character source = new Character();
            source.SetAttackBonus(1);
            Character target = new Character();

            bool result = sut.DetermineHit(source, target);
            Assert.IsTrue(result);
        }

        [Test]
        public void AttackMissesIfItsTotalIsLowerThanAc()
        {
            var random = new ControlledRandomSource {nextResult = 9};

            StrengthHittingPolicy sut = new StrengthHittingPolicy(random);
            Character source = new Character();
            Character target = new Character();

            bool result = sut.DetermineHit(source, target);
            Assert.IsFalse(result);
        }

        [Test]
        public void AttackMissesIfTotalIsGreaterThanAcButRollIsCriticalFail()
        {
            var random = new ControlledRandomSource {nextResult = 1};

            StrengthHittingPolicy sut = new StrengthHittingPolicy(random);
            Character source = new Character();
            source.SetAttackBonus(10);

            Character target = new Character();

            bool result = sut.DetermineHit(source, target);
            Assert.IsFalse(result);
        }
    }
}