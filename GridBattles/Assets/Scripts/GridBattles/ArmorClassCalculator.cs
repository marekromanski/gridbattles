namespace GridBattles
{
    public class ArmorClassCalculator
    {
        public int CalculateAC(Creature character)
        {
            return 10 + character.GetAttributeModifier(Attributes.Dexterity);
        }
    }
}
