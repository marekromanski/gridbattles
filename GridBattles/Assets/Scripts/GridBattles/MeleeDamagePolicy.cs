namespace GridBattles
{
    public class MeleeDamagePolicy
    {
        public int CalculateDamage(Creature source, IRandomSource randomSource)
        {
            int modifier = AbilityScoreCalculator.CalculateModifier(source.GetStrength());
            Weapon weapon = source.GetWeapon();
            if (weapon != null)
            {
                int roll = randomSource.GetRandom(weapon.DamageDie);
                return roll + modifier;
            }
            return 1 + modifier;
        }
    }
}