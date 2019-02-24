namespace GridBattles
{
    public class Armor
    {
        public enum Kind
        {
            Light = 0,
            Medium,
            Heavy
        }

        public readonly Kind kind;
        public readonly int ac;

        public Armor(Kind armorKind, int armorAc)
        {
            kind = armorKind;
            ac = armorAc;
        }
    }
}