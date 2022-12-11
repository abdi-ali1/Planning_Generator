using Logic.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
    public interface IBinarayFileManager
    {

        public void WriteToBinaryFile<T>(T objectToWrite, RepositoryType type);
        public T ReadFromBinaryFile<T>(RepositoryType type);
    }
}
