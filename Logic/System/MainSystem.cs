using DTO_BinaryFile.Manager;
using Logic.Interface;
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
        


        public MainSystem(IBinaryFileManager model)
        {
            models = model.ReadFromBinaryFile();
        }









    }
}
