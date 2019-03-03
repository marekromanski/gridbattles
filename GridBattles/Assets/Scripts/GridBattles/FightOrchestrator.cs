using System;

namespace GridBattles
{
    public class FightOrchestrator
    {
        public void AddParticipants(IFightParticipant participant)
        {
            
        }

        public void GetNextActor()
        {
            throw new OrchestratorException("No participants!");
        }
    }

    public class OrchestratorException : Exception
    {
        public OrchestratorException(string text) : base(text)
        {
        }
    }
}