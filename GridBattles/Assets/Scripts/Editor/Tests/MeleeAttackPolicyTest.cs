using GridBattles;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests
{
    public class MeleeAttackPolicyTest
    {
        private Creature _target;
        private Creature _source;

        [SetUp]
        public void CreateActors()
        {
            _source = new Creature();
            _target = new Creature();
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
            var random = new ControlledRandomSource {NextResult = 11};

            MeleeHittingPolicy sut = new MeleeHittingPolicy(random);

            Assert.IsTrue(sut.DetermineHit(_source, _target));
        }

        [Test]
        public void AttackHitsIfItsTotalIsEqualToArmorClass()
        {
            var random = new ControlledRandomSource {NextResult = 9};

            MeleeHittingPolicy sut = new MeleeHittingPolicy(random);
            _source.SetAttribute(Attributes.Strength, 12);

            Assert.IsTrue(sut.DetermineHit(_source, _target));
        }

        [Test]
        public void AttackMissesIfItsTotalIsLowerThanAc()
        {
            var random = new ControlledRandomSource {NextResult = 9};

            MeleeHittingPolicy sut = new MeleeHittingPolicy(random);

            Assert.IsFalse(sut.DetermineHit(_source, _target));
        }

        [Test]
        public void AttackMissesIfTotalIsGreaterThanAcButRollIsCriticalFail()
        {
            var random = new ControlledRandomSource {NextResult = 1};

            MeleeHittingPolicy sut = new MeleeHittingPolicy(random);
            _source.SetAttribute(Attributes.Strength, 30);

            Assert.IsFalse(sut.DetermineHit(_source, _target));
        }

        [Test]
        public void MeleeAttackUsesModifierFromStrength()
        {
            MeleeHittingPolicy sut = new MeleeHittingPolicy(new CriticalSuccessSource());

            _source.SetAttribute(Attributes.Strength, 14);

            Assert.AreEqual(2, sut.GetAttackBonus(_source));
        }
    }
}