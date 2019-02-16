using GridBattles;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests
{
    public class MeleeDamagePolicyTest
    {
        private Creature _source;
        private MeleeDamagePolicy _sut;

        [SetUp]
        public void CreateActors()
        {
            _source = new Creature();
            _sut = new MeleeDamagePolicy();
        }

        [Test]
        public void UnarmedStrikeDeals1DamageWithoutModifiers()
        {
            Assert.AreEqual(1, _sut.CalculateDamage(_source, null));
        }

        [Test]
        public void UnarmedStrikeAddsStrengthModifierToDamage()
        {
            _source.SetAttribute(Attributes.Strength, 12);
            Assert.AreEqual(2, _sut.CalculateDamage(_source, null));
        }

        [Test]
        public void WeaponStrikeUsesWeaponDieForDamage()
        {
            ControlledRandomSource random = new ControlledRandomSource
            {
                NextResult = 0
            };

            Weapon weapon = new Weapon(1, 4);
            _source.EquipWeapon(weapon);

            Assert.AreEqual(1, _sut.CalculateDamage(_source, random));
        }
    }
}