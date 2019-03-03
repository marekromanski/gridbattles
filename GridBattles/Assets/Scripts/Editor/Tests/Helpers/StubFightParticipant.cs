using System.Collections.Generic;
using GridBattles;

namespace Tests.Helpers
{
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

        public static IEnumerable<IFightParticipant> HostileFightParticipants()
        {
            return new List<IFightParticipant> {HostileFightParticipant(), HostileFightParticipant()};
        }

        public static IFightParticipant HostileFightParticipant()
        {
            return new StubFightParticipant {isHostile = true, isConscious = true};
        }

        public static IFightParticipant AlliedFightParticipant()
        {
            return new StubFightParticipant {isHostile = false, isConscious = true};
        }

        public static IFightParticipant HostileUnconsciousFightParticipant()
        {
            return new StubFightParticipant {isHostile = true, isConscious = false};
        }

        public static IFightParticipant AlliedUnconsciousFightParticipant()
        {
            return new StubFightParticipant {isHostile = false, isConscious = false};
        }
    }
}