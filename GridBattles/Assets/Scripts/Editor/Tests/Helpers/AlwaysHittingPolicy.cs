using GridBattles;

namespace Tests.Helpers
{
    public class AlwaysHittingPolicy : IHittingPolicy
    {
        public bool DetermineHit(Character source, Character target)
        {
            return true;
        }
    }
}
