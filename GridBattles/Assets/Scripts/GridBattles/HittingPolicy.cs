namespace GridBattles
{
    public interface IHittingPolicy
    {
        bool DetermineHit(Creature source, Creature target);
    }
}
