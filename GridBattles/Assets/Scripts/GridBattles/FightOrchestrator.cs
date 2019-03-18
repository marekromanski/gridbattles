using System;
using System.Collections.Generic;

namespace GridBattles
{
    public class FightOrchestrator
    {
        private readonly List<IFightParticipant> _participants;
        private int _next;

        public FightOrchestrator()
        {
            _participants = new List<IFightParticipant>();
        }

        public void AddParticipants(IEnumerable<IFightParticipant> participants)
        {
            if (null != participants)
            {
                _participants.AddRange(participants);
                _participants.Sort(SortParticipantsByInitiative);
            }
        }

        private int SortParticipantsByInitiative(IFightParticipant left, IFightParticipant right)
        {
            return right.GetInitiative() - left.GetInitiative();
        }


        public IFightParticipant GetNextActor()
        {
            if (0 == _participants.Count)
            {
                throw new OrchestratorException("No participants!");
            }

            var result = _participants[_next];
            _next = ++_next % _participants.Count;

            return result;
        }
    }

    public class OrchestratorException : Exception
    {
        public OrchestratorException(string text) : base(text)
        {
        }
    }
}