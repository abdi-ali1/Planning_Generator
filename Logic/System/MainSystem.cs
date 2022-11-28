using DTO_BinaryFile.Manager;

using Logic.System.Authentication;
using Logic.System.Generator;
using Logic.System.Management;
using ModelManager = Logic.System.Management.ModelManager;

namespace Logic.System
{
    public class MainSystem
    {
        private IModelManager models;
        private ScheduleGenerator scheduleGenerator;
        private AuthenticationManagement authentication;

        public IModelManager ModelManager { get => models; }
        public ScheduleGenerator Generator { get => scheduleGenerator; }
        public AuthenticationManagement Authentication { get => authentication; }

        public IModelManager Models { get => models; }
        
        public MainSystem()
        {
            // probably this wil be a static class, but downt now for sure
            // going to ask for feedback tommorow
            models = BinaryFileManager.ReadFromBinaryFile<IModelManager>();

        }









    }
}
