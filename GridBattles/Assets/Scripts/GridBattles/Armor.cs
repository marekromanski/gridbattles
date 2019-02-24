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

        public Kind kind;
        public int ac;

        public Armor(Kind armorKind, int armorAc)
        {
            kind = armorKind;
            ac = armorAc;
        }
    }
}