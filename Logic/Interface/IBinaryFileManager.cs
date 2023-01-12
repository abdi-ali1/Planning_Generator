using Logic.Enum;

namespace Logic.Interface
{
    public interface IBinaryFileManager
    {
        public void WriteToBinaryFile<T>(T objectToWrite, RepositoryType type);
        public T ReadFromBinaryFile<T>(RepositoryType type);
    }
}
