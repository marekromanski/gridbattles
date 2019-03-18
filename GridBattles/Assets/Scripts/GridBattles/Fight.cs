using System.Collections.Generic;

namespace GridBattles
{
    public class Fight
    {
        private readonly List<IFightParticipant> _participants;

        public Fight()
        {
            _participants = new List<IFightParticipant>();
        }

        public void AddParticipants(IEnumerable<IFightParticipant> participants)
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
                if (participant.IsConscious())
                {
                    alliedParticipants = alliedParticipants || !participant.IsHostile();
                    hostileParticipants = hostileParticipants || participant.IsHostile();
                }
            }

            return !(alliedParticipants && hostileParticipants);
        }
    }


    public interface IFightParticipant
    {
        bool IsHostile();
        bool IsConscious();

        int GetInitiative();

    }
}