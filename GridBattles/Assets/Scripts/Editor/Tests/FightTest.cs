using System.Collections.Generic;
using GridBattles;
using NUnit.Framework;
using Tests.Helpers;

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
            _fight.AddParticipants(new List<IFightParticipant>());

            Assert.IsTrue(_fight.IsFinished());
        }

        [Test]
        public void FightWithOneParticipantsEndsImmediately()
        {
            var participants = new List<IFightParticipant> {StubFightParticipant.AlliedFightParticipant()};
            _fight.AddParticipants(participants);

            Assert.IsTrue(_fight.IsFinished());
        }

        [Test]
        public void FightWithOneHostileParticipantsEndsImmediately()
        {
            var participants = new List<IFightParticipant> {StubFightParticipant.HostileFightParticipant()};
            _fight.AddParticipants(participants);

            Assert.IsTrue(_fight.IsFinished());
        }

        [Test]
        public void FightWithOnlyHostileParticipantsEndsImmediately()
        {
            _fight.AddParticipants(StubFightParticipant.HostileFightParticipants());
            Assert.IsTrue(_fight.IsFinished());
        }

        [Test]
        public void FightWithTwoMixedParticipantsIsStarted()
        {
            _fight.AddParticipants(new List<IFightParticipant>
                {StubFightParticipant.AlliedFightParticipant(), StubFightParticipant.HostileFightParticipant()});

            Assert.IsFalse(_fight.IsFinished());
        }

        [Test]
        public void FightWithMixedParticipantsWhereHostilesAreUnconsciousEnds()
        {
            var participants = new List<IFightParticipant>
            {
                StubFightParticipant.AlliedFightParticipant(), StubFightParticipant.HostileUnconsciousFightParticipant()
            };
            _fight.AddParticipants(participants);

            Assert.IsTrue(_fight.IsFinished());
        }

        [Test]
        public void FightWithMixedParticipantsWhereAlliesAreUnconsciousEnds()
        {
            var participants = new List<IFightParticipant>
            {
                StubFightParticipant.AlliedUnconsciousFightParticipant(), StubFightParticipant.HostileFightParticipant()
            };
            _fight.AddParticipants(participants);

            Assert.IsTrue(_fight.IsFinished());
        }
    }
}