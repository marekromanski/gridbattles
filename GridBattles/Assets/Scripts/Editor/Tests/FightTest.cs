using System.Collections.Generic;
using GridBattles;
using NUnit.Framework;

namespace Tests
{
    public class FightTest
    {
        private Fight _fight;

        [SetUp]
        public void GivenFight()
        {
            _fight = new Fight();
        }

        [Test]
        public void FightWithNoParticipantsAddedEndsImmediately()
        {
            Assert.IsTrue(_fight.IsFinished());
        }

        [Test]
        public void FightWithNullParticipantsEndsImmediately()
        {
            _fight.AddParticipants(null);

            Assert.IsTrue(_fight.IsFinished());
            Assert.IsTrue(_fight.IsFinished());
        }

        [Test]
        public void FightWithNoParticipantsEndsImmediately()
        {
            _fight.AddParticipants(new List<FightParticipant>());

            Assert.IsTrue(_fight.IsFinished());
        }

        [Test]
        public void FightWithOneParticipantsEndsImmediately()
        {
            var participants = new List<FightParticipant> {AlliedFightParticipant()};
            _fight.AddParticipants(participants);

            Assert.IsTrue(_fight.IsFinished());
        }
        
        [Test]
        public void FightWithOneHostileParticipantsEndsImmediately()
        {
            var participants = new List<FightParticipant> {HostileFightParticipant()};
            _fight.AddParticipants(participants);

            Assert.IsTrue(_fight.IsFinished());
        }

        private static FightParticipant HostileFightParticipant()
        {
            return new FightParticipant {isHostile = true};
        }

        [Test]
        public void FightWithTwoHostileParticipantsIsStarted()
        {
            var participants = HostileFightParticipants();
            _fight.AddParticipants(participants);

            Assert.IsFalse(_fight.IsFinished());
        }

        private static List<FightParticipant> HostileFightParticipants()
        {
            return new List<FightParticipant> {AlliedFightParticipant(), HostileFightParticipant()};
        }

        private static FightParticipant AlliedFightParticipant()
        {
            return new FightParticipant();
        }
    }
}