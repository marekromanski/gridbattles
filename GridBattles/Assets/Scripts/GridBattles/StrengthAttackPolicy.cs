using UnityEngine;

namespace GridBattles
{
    public class StrengthAttackPolicy : IHittingPolicy
    {
        private IRandomSource _randomSource;

        public StrengthAttackPolicy(IRandomSource randomSource)
        {
            _randomSource = randomSource;
        }

        public bool DetermineHit(Character source, Character target)
        {
            var randomModidfier = _randomSource.GetRandom();
            if (randomModidfier == 20)
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