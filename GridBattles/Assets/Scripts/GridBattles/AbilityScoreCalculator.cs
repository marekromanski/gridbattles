using System;

namespace GridBattles
{
    public static class AbilityScoreCalculator
    {
        public static int CalculateModifier(int score)
        {
            return (int) Math.Floor((score - 10) / 2.0);
        }
    }
}