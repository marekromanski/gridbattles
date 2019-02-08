namespace GridBattles
{
    public class StrengthHittingPolicy : IHittingPolicy
    {
        private readonly IRandomSource _randomSource;

        public StrengthHittingPolicy(IRandomSource randomSource)
        {
            _randomSource = randomSource;
        }

        public bool DetermineHit(Character source, Character target)
        {
            var roll = _randomSource.GetRandom();
            if (roll == 20)
            {
                return true;
            }

            int ac = target.GetAc();
            int bonus = source.GetAttackBonus();
            int total = roll + bonus;
            if (total >= ac)
            {
                return true;
            } 
            return false;
        }
    }

    public interface IRandomSource
    {
        int GetRandom();
    }
}