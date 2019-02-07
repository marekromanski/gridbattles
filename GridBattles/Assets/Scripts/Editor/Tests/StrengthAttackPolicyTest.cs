using GridBattles;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests
{
    public class StrengthAttackPolicyTest
    {
        [Test]
        public void CriticalFailAlwaysMisses()
        {
            var random = new CriticalFailSource();
            
            StrengthAttackPolicy sut = new StrengthAttackPolicy(random);
            Character source = new Character();
            Character target = new Character();
            
            bool result = sut.DetermineHit(source, target);
            Assert.IsFalse(result);
        }

        [Test]
        public void CriticalSuccessAlwaysHits()
        {
            var random = new CriticalSuccessSource();
            
            StrengthAttackPolicy sut = new StrengthAttackPolicy(random);
            Character source = new Character();
            Character target = new Character();
            
            bool result = sut.DetermineHit(source, target);
            Assert.IsTrue(result);
        }
    }
}
