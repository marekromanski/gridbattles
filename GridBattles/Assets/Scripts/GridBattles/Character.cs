namespace GridBattles
{
    public class Character
    {
        private int _level; 
        private int _hitPoints;
        private IHittingPolicy _hittingPolicy;
        
        public Character()
        {
            _level = 1;
            _hitPoints = 0;
        }

        public void SetHittingPolicy(IHittingPolicy policy)
        {
            _hittingPolicy = policy;
        }

        public void Attack(Character target)
        {
            if (_hittingPolicy.DetermineHit(this, target))
            {
                target.ApplyDamage(1);
            }
        }

        private void ApplyDamage(int damage)
        {
            _hitPoints -= damage;
        }

        public int GetLevel()
        {
            return _level;
        }

        public int GetHitPoints()
        {
            return _hitPoints;
        }
    }

}