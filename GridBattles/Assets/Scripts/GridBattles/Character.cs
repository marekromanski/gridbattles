namespace GridBattles
{
    public class Character
    {
        private int level; 
        private int hitPoints;
        public Character()
        {
            level = 1;
            hitPoints = 0;
        }

        public void Attack(Character target)
        {
            var hittingPolicy = GameRules.Get().GetHittingPolicy();
            if (hittingPolicy.DetermineHit(this, target))
            {
                target.ApplyDamage(1);
            }
        }

        private void ApplyDamage(int damage)
        {
            hitPoints -= damage;
        }

        public int GetLevel()
        {
            return level;
        }

        public int GetHitPoints()
        {
            return hitPoints;
        }
    }

}