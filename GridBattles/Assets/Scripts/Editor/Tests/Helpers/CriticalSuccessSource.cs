using GridBattles;

namespace Tests.Helpers
{
    public class CriticalSuccessSource : IRandomSource
    {
        public int GetRandom()
        {
            return 20;
        }
    }
}