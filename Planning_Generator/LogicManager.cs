using Logic.System;

namespace Planning_Generator
{
    public static class LogicManager
    {
        private static MainSystem mainSystem;
        public static MainSystem LogicSystem { get { return mainSystem; }}

        static LogicManager()
        {
            mainSystem = new MainSystem();
        }


    }
}
