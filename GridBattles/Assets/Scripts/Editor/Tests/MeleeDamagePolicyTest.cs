using GridBattles;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests
{
    public class MeleeDamagePolicyTest
    {
        [Test]
        public void UnarmedStrikeDeals1DamageWithoutModifiers()
        {
            MeleeDamagePolicy sut = new MeleeDamagePolicy();
            Creature source = new Creature();
            Assert.AreEqual(1, sut.CalculateDamage(source, null));
        }

        [Test]
        public void UnArmedStrikeAddsStrenthModifierToDamage()
        {
            MeleeDamagePolicy sut = new MeleeDamagePolicy();

            Creature source = new Creature();
            source.SetAttribute(Attributes.Strength, 12);

            Assert.AreEqual(2, sut.CalculateDamage(source, null));
        }

        [Test]
        public void WeaponStrikeUsesWeaponDieForDamage()
        {
            MeleeDamagePolicy sut = new MeleeDamagePolicy();
            ControlledRandomSource random = new ControlledRandomSource();
            random.NextResult = 4;

            Creature source = new Creature();
            Weapon weapon = new Weapon(4);
            source.EquipWeapon(weapon);

            Assert.AreEqual(4, sut.CalculateDamage(source, random));
        }
    }
}