using System.Collections.Generic;

namespace GridBattles
{
    public class Creature
    {
        private int _level;
        private int _hitPoints;
        private int _ac;
        private IHittingPolicy _hittingPolicy;
        private readonly Dictionary<Attributes, int> _attributes;
        private IWeapon _weapon;

        public Creature()
        {
            _level = 1;
            _hitPoints = 0;
            _ac = 10;
            _weapon = new UnarmedStrike();

            _attributes = new Dictionary<Attributes, int>
            {
                {Attributes.Strength, 10},
                {Attributes.Dexterity, 10},
                {Attributes.Constitution, 10},
                {Attributes.Intelligence, 10},
                {Attributes.Wisdom, 10},
                {Attributes.Charisma, 10},
            };
        }

        public void SetHittingPolicy(IHittingPolicy policy)
        {
            _hittingPolicy = policy;
        }

        public void Attack(Creature target)
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

        public int GetStrength()
        {
            return _attributes[Attributes.Strength];
        }

        public void SetAttribute(Attributes attributes, int score)
        {
            _attributes[attributes] = score;
        }

        public int GetProficiencyBonus()
        {
            return 2 + (_level - 1) / 4;
        }

        public void SetLevel(int level)
        {
            _level = level;
        }

        public void EquipWeapon(IWeapon weapon)
        {
            _weapon = weapon;
        }

        public IWeapon GetWeapon()
        {
            return _weapon;
        }
    }
}