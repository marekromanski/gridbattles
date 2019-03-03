using GridBattles;
using NUnit.Framework;

namespace Tests
{
    public class FightOrchestratorTest
    {
        [Test]
        public void GivenFightOrchestratorWithNoParticipants ()
        {
            FightOrchestrator orchestrator = new FightOrchestrator();
            orchestrator.AddParticipants(null);

            Assert.Throws<OrchestratorException>(() => orchestrator.GetNextActor());
        }
    }
}