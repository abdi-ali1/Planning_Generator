using DTO.DataMangement;
using Logic.System;

namespace Planning_Generator.Services
{
    public class ApplicationContext
    {
        private DataManagement dataManagement;

        public DataManagement DataManagement { get { return dataManagement; } }

        public ApplicationContext(IConfiguration configuration)
        {
            dataManagement = new DataManagement(configuration.GetConnectionString("myDb"));
        }

    }
}
