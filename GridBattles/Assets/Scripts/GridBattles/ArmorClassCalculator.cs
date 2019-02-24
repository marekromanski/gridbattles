namespace GridBattles
{
    public class ArmorClassCalculator
    {
        private const int MaxDexModifierForMediumArmor = 2;

        public int CalculateAc(Creature character)
        {
            Armor armor = character.GetArmor();
            int dexModifier = character.GetAttributeModifier(Attributes.Dexterity);
            int effectiveDexModifier = GetEffectiveDexModifier(dexModifier, armor.kind);

            return armor.ac + effectiveDexModifier;
        }

        private int GetEffectiveDexModifier(int dexModifier, Armor.Kind armorKind)
        {
            if (Armor.Kind.Medium == armorKind)
            {
                if (dexModifier > MaxDexModifierForMediumArmor)
                {
                    return MaxDexModifierForMediumArmor;
                }
                return dexModifier;
            }

            if (Armor.Kind.Heavy == armorKind)
            {
                return 0;
            }

            return dexModifier;
        }
    }
}
