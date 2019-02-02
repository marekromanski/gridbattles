using UnityEngine.Assertions;

namespace GridBattles
{
    public class GameRules
    {
        private static GameRules _instance;

        public static void Set(GameRules rules)
        {
            _instance = rules;
        }

        public static GameRules Get()
        {
            Assert.IsNotNull(_instance);
            return _instance;
        }

        public GameRules(IHittingPolicy policy)
        {
            _policy = policy;
        }
        private IHittingPolicy _policy;

        public IHittingPolicy GetHittingPolicy()
        {
            return _policy;
        }

        public static void Unset()
        {
            _instance = null;
        }
    }
}
