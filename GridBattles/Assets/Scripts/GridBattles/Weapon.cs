namespace GridBattles
{
    public interface IWeapon
    {
        int GetDamage(IRandomSource source);
    }


    public class Weapon : IWeapon
    {
        private readonly int _damageDie;
        private readonly int _diceNumber;

        public Weapon(int diceNumber, int damageDie)
        {
            _damageDie = damageDie;
            _diceNumber = diceNumber;
        }

        public int GetDamage(IRandomSource source)
        {
            int result = 0;
            for (int i = 0; i < _diceNumber; ++i)
            {
                result += 1 + source.GetRandom() % _damageDie;
            }

            return result;
        }
    }

    public class UnarmedStrike : IWeapon
    {
        public int GetDamage(IRandomSource _)
        {
            return 1;
        }
    }
}