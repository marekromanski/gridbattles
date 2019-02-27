using System.Collections.Generic;

namespace GridBattles
{
    public class Fight
    {
        private List<FightParticipant> _participants;

        public Fight()
        {
            _participants = new List<FightParticipant>();
        }

        public void AddParticipants(IEnumerable<FightParticipant> participants)
        {
            if (participants != null)
            {
                _participants.AddRange(participants);
            }
        }

        public bool IsFinished()
        {
            bool alliedParticipants = false;
            bool hostileParticipants = false;
            foreach (var participant in _participants)
            {
                alliedParticipants = alliedParticipants || !participant.isHostile;
                hostileParticipants = hostileParticipants || participant.isHostile;
            }

            return !(alliedParticipants && hostileParticipants);
        }
    }


    public class FightParticipant
    {
        public bool isHostile;
    }
}