using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
    public interface IBinaryFileManager
    {

        public void WriteToBinaryFile(IModelManager objectToWrite);
        public IModelManager ReadFromBinaryFile();
    }
}
