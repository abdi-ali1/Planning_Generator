using Logic;

namespace DTO_BinaryFile.Manager
{
    public class BinaryFileManager : IBinaryFileManager
    {

        private string fileLocation = "C:\\Users\\abdi1\\source\\repos\\PlanningGenerator\\DTO_BinaryFile\\Files\\data.bin";

        /// <summary>
        /// Writes the given object instance to a binary file.
        /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
        /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the XML file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the XML file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public  void WriteToBinaryFile(IModelManager objectToWrite)
        {
            using (Stream stream = File.Open(fileLocation, false ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        /// <summary>
        /// Reads an object instance from a binary file.
        /// </summary>
        /// <typeparam name="T">The type of object to read from the XML.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the binary file.</returns>
        public  IModelManager ReadFromBinaryFile()
        {
            using (Stream stream = File.Open(fileLocation, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (IModelManager)binaryFormatter.Deserialize(stream);
            }
        }

    }
}