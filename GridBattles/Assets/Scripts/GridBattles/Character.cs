namespace GridBattles
{
    public class Character
    {
        private int _level; 
        private int _hitPoints;
        private int _ac;
        private IHittingPolicy _hittingPolicy;
        private int _attackBonus;

        public Character()
        {
            _level = 1;
            _hitPoints = 0;
            _ac = 10;
            _attackBonus = 0;
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

        public int GetAc()
        {
            return _ac;
        }

        public void SetAttackBonus(int attackBonus)
        {
            _attackBonus = attackBonus;
        }

        public int GetAttackBonus()
        {
            return _attackBonus;
        }
    }

}