using GridBattles;

namespace Tests.Helpers
{
    public class AlwaysHittingPolicy : IHittingPolicy
    {
        public bool DetermineHit(Creature source, Creature target)
        {
            return true;
        }
    }
}
