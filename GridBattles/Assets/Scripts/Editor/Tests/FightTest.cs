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
            _fight.AddParticipants(new List<IFightParticipant>());

            Assert.IsTrue(_fight.IsFinished());
        }

        [Test]
        public void FightWithOneParticipantsEndsImmediately()
        {
            var participants = new List<IFightParticipant> {AlliedFightParticipant()};
            _fight.AddParticipants(participants);

            Assert.IsTrue(_fight.IsFinished());
        }

        [Test]
        public void FightWithOneHostileParticipantsEndsImmediately()
        {
            var participants = new List<IFightParticipant> {HostileFightParticipant()};
            _fight.AddParticipants(participants);

            Assert.IsTrue(_fight.IsFinished());
        }

        [Test]
        public void FightWithOnlyHostileParticipantsEndsImmediately()
        {
            _fight.AddParticipants(HostileFightParticipants());
            Assert.IsTrue(_fight.IsFinished());
        }

        [Test]
        public void FightWithTwoMixedParticipantsIsStarted()
        {
            _fight.AddParticipants(MixedFightParticipants());

            Assert.IsFalse(_fight.IsFinished());
        }

        [Test]
        public void FightWithMixedParticipantsWhereHostilesAreUnconsciousEnds()
        {
            var participants = new List<IFightParticipant>
                {AlliedFightParticipant(), HostileUnconsciousFightParticipant()};
            _fight.AddParticipants(participants);

            Assert.IsTrue(_fight.IsFinished());
        }

        [Test]
        public void FightWithMixedParticipantsWhereAlliesAreUnconsciousEnds()
        {
            var participants = new List<IFightParticipant>
                {AlliedUnconsciousFightParticipant(), HostileFightParticipant()};
            _fight.AddParticipants(participants);

            Assert.IsTrue(_fight.IsFinished());
        }

        private IEnumerable<IFightParticipant> HostileFightParticipants()
        {
            return new List<IFightParticipant> {HostileFightParticipant(), HostileFightParticipant()};
        }

        private static List<IFightParticipant> MixedFightParticipants()
        {
            return new List<IFightParticipant> {AlliedFightParticipant(), HostileFightParticipant()};
        }

        private static IFightParticipant HostileFightParticipant()
        {
            return new StubFightParticipant {isHostile = true, isConscious = true};
        }

        private static IFightParticipant AlliedFightParticipant()
        {
            return new StubFightParticipant {isHostile = false, isConscious = true};
        }

        private static IFightParticipant HostileUnconsciousFightParticipant()
        {
            return new StubFightParticipant {isHostile = true, isConscious = false};
        }

        private static IFightParticipant AlliedUnconsciousFightParticipant()
        {
            return new StubFightParticipant {isHostile = false, isConscious = false};
        }
    }

    public class StubFightParticipant : IFightParticipant
    {
        public bool isHostile;
        public bool isConscious;

        public bool IsHostile()
        {
            return isHostile;
        }

        public bool IsConscious()
        {
            return isConscious;
        }
    }
}