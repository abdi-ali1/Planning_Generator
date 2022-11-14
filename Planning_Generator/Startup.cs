using DTO.DataMangement;
using Logic.System;
using Microsoft.AspNetCore.Builder;

namespace Planning_Generator
{
    public class Startup
    {
       


      


        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
            DataManagement = new DataManagement(configuration.GetConnectionString("myDb"));
        }
    }
}
