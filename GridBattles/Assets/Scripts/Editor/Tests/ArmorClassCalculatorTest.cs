using System;
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

        private static void AssertAcIsBasedOnCharacterDexterity(int dexterity, int expectedAc)
        {
            Creature character = new Creature();
            character.SetAttribute(Attributes.Dexterity, dexterity);
            var sut = new ArmorClassCalculator();
            Assert.AreEqual(expectedAc, sut.CalculateAC(character));
        }
    }
}
