﻿using GridBattles;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests
{
    public class CharacterTest
    {
        [Test]
        public void NewCharacterHasLevelOne()
        {
            var character = new Character();
            Assert.AreEqual(1, character.GetLevel());
        }

        [Test]
        public void MissedAttackDoesntCauseDamage()
        {
            IHittingPolicy policy = new AlwaysMissingPolicy();
            GameRules.Set(new GameRules(policy));
            
            var character = new Character();
            var target = new Character();
            var hitPoints = target.GetHitPoints();

            character.Attack(target);
            Assert.AreEqual(hitPoints, target.GetHitPoints());

            GameRules.Unset();
        }

        [Test]
        public void SuccessfulAttackCausesDamage()
        {
            IHittingPolicy policy = new AlwaysHittingPolicy();
            GameRules.Set(new GameRules(policy));
            
            var character = new Character();
            var target = new Character();
            var hitPoints = target.GetHitPoints();
            
            character.Attack(target);
            Assert.Less(target.GetHitPoints(), hitPoints);
        }
    }
}
