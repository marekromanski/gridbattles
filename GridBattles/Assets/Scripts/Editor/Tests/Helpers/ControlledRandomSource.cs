using GridBattles;

namespace Tests.Helpers
{
    public class ControlledRandomSource : IRandomSource
    {
        public int NextResult = 10;
        public int GetRandom()
        {
            return NextResult;
        }

        public int GetRandom(int max)
        {
            return NextResult;
        }
    }
}