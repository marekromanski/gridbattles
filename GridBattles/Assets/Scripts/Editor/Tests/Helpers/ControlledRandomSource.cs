using GridBattles;

namespace Tests.Helpers
{
    public class ControlledRandomSource : IRandomSource
    {
        public int nextResult = 10;
        public int GetRandom()
        {
            return nextResult;
        }
    }
}