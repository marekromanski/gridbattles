namespace GridBattles
{
    public class MeleeDamagePolicy
    {
        public int CalculateDamage(Creature source, IRandomSource randomSource)
        {
            int modifier = AbilityScoreCalculator.CalculateModifier(source.GetStrength());
            IWeapon weapon = source.GetWeapon();
            int damage = weapon.GetDamage(randomSource);
            return damage + modifier;
        }
    }
}