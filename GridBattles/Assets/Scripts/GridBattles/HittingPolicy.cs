namespace GridBattles
{
    public interface IHittingPolicy
    {
        bool DetermineHit(Character source, Character target);
    }
}
