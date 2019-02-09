namespace GridBattles
{
    public class MeleeHittingPolicy : IHittingPolicy
    {
        private readonly IRandomSource _randomSource;

        public MeleeHittingPolicy(IRandomSource randomSource)
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

            if (roll == 1)
            {
                return false;
            }

            if (roll + GetAttackBonus(source) >= target.GetAc())
            {
                return true;
            }

            return false;
        }

        public int GetAttackBonus(Character character)
        {
            return character.GetAttackBonus();
        }
    }

    public interface IRandomSource
    {
        int GetRandom();
    }
}