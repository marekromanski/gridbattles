using GridBattles;

namespace Tests.Helpers
{
    public class AlwaysMissingPolicy : IHittingPolicy
    {
        public bool DetermineHit(Creature source, Creature target)
        {
            return false;
        }
    }
}
