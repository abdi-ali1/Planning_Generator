using Logic.System;
using DTO_BinaryFile.Manager;

namespace Planning_Generator
{
    public static class LogicManager
    {
        private static MainSystem mainSystem;
        public static MainSystem LogicSystem { get { return mainSystem; }}

        static LogicManager()
        {
          BinaryFileManager binaryFileManager = new BinaryFileManager();
            mainSystem = new MainSystem();
        }


    }
}
