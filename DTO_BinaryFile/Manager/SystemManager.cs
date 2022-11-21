using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_BinaryFile.Manager
{
    public class SystemManager
    {
        private ModelManager modelManager;
        private BinaryFileManager fileManager = new BinaryFileManager();

        public ModelManager GetModelManager { get { return modelManager; } }

        public SystemManager()
        {

            modelManager = fileManager.DeSerializeObject<ModelManager>();


        }



        public void Add(StaffMember staffMember)
        {
            modelManager.Add(staffMember);
            fileManager.SerializeObject<ModelManager>(modelManager);
        }

        public void Add(Company company)
        {
            modelManager.Add(company);
            fileManager.SerializeObject<ModelManager>(modelManager);

        }


    }
}
