namespace GridBattles
{
    public class ArmorClassCalculator
    {
        public int CalculateAC(Creature character)
        {
            Armor armor = character.GetArmor();
            return armor.ac + character.GetAttributeModifier(Attributes.Dexterity);
        }
    }
}
