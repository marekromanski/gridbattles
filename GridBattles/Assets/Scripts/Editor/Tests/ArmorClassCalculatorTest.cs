using System;
using System.Runtime.InteropServices;
using GridBattles;
using NUnit.Framework;

namespace Tests
{
    public class ArmorClassCalculatorTest
    {
        [Test]
        public void CharacterHasAcEqualTo10PlusDexModifier()
        {
            AssertAcIsBasedOnCharacterDexterity(6, 8);
            AssertAcIsBasedOnCharacterDexterity(8, 9);
            AssertAcIsBasedOnCharacterDexterity(10, 10);
            AssertAcIsBasedOnCharacterDexterity(12, 11);
            AssertAcIsBasedOnCharacterDexterity(14, 12);
            AssertAcIsBasedOnCharacterDexterity(16, 13);
            AssertAcIsBasedOnCharacterDexterity(18, 14);
            AssertAcIsBasedOnCharacterDexterity(20, 15);
        }

        [Test]
        public void CharacterWearingLightArmorHasAcEqualToArmorPlusDexModifier()
        {
            AssertCharacterWearingLightArmorHasAcEqualToArmorAcPlusDexterityModifier(11, 10, 11);
            AssertCharacterWearingLightArmorHasAcEqualToArmorAcPlusDexterityModifier(12, 10, 12);
            AssertCharacterWearingLightArmorHasAcEqualToArmorAcPlusDexterityModifier(11, 12, 12);
            AssertCharacterWearingLightArmorHasAcEqualToArmorAcPlusDexterityModifier(12, 14, 14);
            AssertCharacterWearingLightArmorHasAcEqualToArmorAcPlusDexterityModifier(13, 20, 18);
        }

        private static void AssertCharacterWearingLightArmorHasAcEqualToArmorAcPlusDexterityModifier(int armorAc, int dexterity,
            int expectedAc)
        {
            Armor lightArmor = new Armor(Armor.Kind.Light, armorAc);
            Creature character = new Creature();
            character.SetAttribute(Attributes.Dexterity, dexterity);
            character.PutOnArmor(lightArmor);
            var sut = new ArmorClassCalculator();
            Assert.AreEqual(expectedAc, sut.CalculateAC(character));
        }

        private static void AssertAcIsBasedOnCharacterDexterity(int dexterity, int expectedAc)
        {
            Creature character = new Creature();
            character.SetAttribute(Attributes.Dexterity, dexterity);
            var sut = new ArmorClassCalculator();
            Assert.AreEqual(expectedAc, sut.CalculateAC(character));
        }
    }
}
