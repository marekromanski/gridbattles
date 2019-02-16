namespace GridBattles
{
    public interface IRandomSource
    {
        int GetRandom();
        int GetRandom(int max);
    }
}