using GridBattles;

namespace Tests.Helpers
{
    public class CriticalFailSource : IRandomSource
    {
        public int GetRandom()
        {
            return 1;
        }
    }
}