using DTO.DataMangement;
using Logic.System;
using System.Security.Cryptography.X509Certificates;

namespace Planning_Generator.Services
{
    public class LogicServices
    {


        public DataManagement DataManagement { get; set; }
        public MainSystem MainSystem { get; set; }


        public LogicServices(IConfiguration configuration)
        {
            DataManagement = new DataManagement(configuration.GetConnectionString("myDb"));
           
        }

    }
}
