using GridBattles;

namespace Tests.Helpers
{
    public class AlwaysMissingPolicy : IHittingPolicy
    {
        public bool DetermineHit(Character source, Character target)
        {
            return false;
        }
    }
}
