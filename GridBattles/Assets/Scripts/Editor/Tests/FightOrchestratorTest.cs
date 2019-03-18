using System.Collections.Generic;
using GridBattles;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests
{
    public class FightOrchestratorTest
    {
        private FightOrchestrator _orchestrator;

        [SetUp]
        public void GivenFightOrchestrator()
        {
            _orchestrator = new FightOrchestrator();
        }

        [Test]
        public void GivenFightOrchestratorWithNoAddedParticipantsGettingNextParticipantThrowsOrchestratorException()
        {
            Assert.Throws<OrchestratorException>(() => _orchestrator.GetNextActor());
        }

        [Test]
        public void GivenFightOrchestratorWithNullParticipantsGettingNextParticipantThrowsOrchestratorException()
        {
            _orchestrator.AddParticipants(null);

            Assert.Throws<OrchestratorException>(() => _orchestrator.GetNextActor());
        }

        [Test]
        public void GivenFightOrchestratorWithNoParticipantsGettingNextParticipantThrowsOrchestratorException()
        {
            _orchestrator.AddParticipants(new List<IFightParticipant>());

            Assert.Throws<OrchestratorException>(() => _orchestrator.GetNextActor());
        }

        [Test]
        public void FightOrchestratorWithOneParticipantsReturnsThatParticipant()
        {
            var participant = new StubFightParticipant();
            _orchestrator.AddParticipants(new List<IFightParticipant> {participant});

            Assert.AreSame(participant, _orchestrator.GetNextActor());
        }

        [Test]
        public void FightWithManyParticipantsReturnsThemInOrderFastestToSlowest()
        {
            var slower = new StubFightParticipant {initiative = 1};
            var faster = new StubFightParticipant {initiative = 2};

            _orchestrator.AddParticipants(new List<IFightParticipant> {slower, faster});

            Assert.AreSame(faster, _orchestrator.GetNextActor());
            Assert.AreSame(slower, _orchestrator.GetNextActor());
            Assert.AreSame(faster, _orchestrator.GetNextActor());
            Assert.AreSame(slower, _orchestrator.GetNextActor());
        }
    }
}