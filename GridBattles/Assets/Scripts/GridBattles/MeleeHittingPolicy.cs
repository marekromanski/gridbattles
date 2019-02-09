namespace GridBattles
{
    public class MeleeHittingPolicy : IHittingPolicy
    {
        private readonly IRandomSource _randomSource;

        public MeleeHittingPolicy(IRandomSource randomSource)
        {
            _randomSource = randomSource;
        }

        public bool DetermineHit(Creature source, Creature target)
        {
            var roll = _randomSource.GetRandom();
            if (roll == 20)
            {
                return true;
            }

            if (roll == 1)
            {
                return false;
            }

            return roll + GetAttackBonus(source) >= target.GetAc();
        }

        public int GetAttackBonus(Creature creature)
        {
            var strengthScore = creature.GetStrength();
            return AbilityScoreCalculator.CalculateModifier(strengthScore);
        }
    }

    public interface IRandomSource
    {
        int GetRandom();
    }
}