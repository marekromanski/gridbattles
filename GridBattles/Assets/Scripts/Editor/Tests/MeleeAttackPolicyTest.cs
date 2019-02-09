using GridBattles;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests
{
    public class MeleeAttackPolicyTest
    {
        private Character _target;
        private Character _source;

        [SetUp]
        public void CreateActors()
        {
            _source = new Character();
            _target = new Character();
        }

        [Test]
        public void CriticalFailAlwaysMisses()
        {
            var random = new CriticalFailSource();

            MeleeHittingPolicy sut = new MeleeHittingPolicy(random);

            Assert.IsFalse(sut.DetermineHit(_source, _target));
        }

        [Test]
        public void CriticalSuccessAlwaysHits()
        {
            var random = new CriticalSuccessSource();

            MeleeHittingPolicy sut = new MeleeHittingPolicy(random);

            Assert.IsTrue(sut.DetermineHit(_source, _target));
        }

        [Test]
        public void AttackHitsIfItsTotalIsGreaterThanArmorClass()
        {
            var random = new ControlledRandomSource {nextResult = 11};

            MeleeHittingPolicy sut = new MeleeHittingPolicy(random);

            Assert.IsTrue(sut.DetermineHit(_source, _target));
        }

        [Test]
        public void AttackHitsIfItsTotalIsEqualToArmorClass()
        {
            var random = new ControlledRandomSource {nextResult = 9};

            MeleeHittingPolicy sut = new MeleeHittingPolicy(random);
            _source.SetAttackBonus(1);

            Assert.IsTrue(sut.DetermineHit(_source, _target));
        }

        [Test]
        public void AttackMissesIfItsTotalIsLowerThanAc()
        {
            var random = new ControlledRandomSource {nextResult = 9};

            MeleeHittingPolicy sut = new MeleeHittingPolicy(random);

            Assert.IsFalse(sut.DetermineHit(_source, _target));
        }

        [Test]
        public void AttackMissesIfTotalIsGreaterThanAcButRollIsCriticalFail()
        {
            var random = new ControlledRandomSource {nextResult = 1};

            MeleeHittingPolicy sut = new MeleeHittingPolicy(random);
            _source.SetAttackBonus(10);

            Assert.IsFalse(sut.DetermineHit(_source, _target));
        }

        [Test]
        public void MeleeAttackUsesModifierFrmStrengthByDefault()
        {
            MeleeHittingPolicy sut = new MeleeHittingPolicy(new CriticalSuccessSource());

            Assert.AreEqual(0, sut.GetAttackBonus(_source));
        }
    }
}