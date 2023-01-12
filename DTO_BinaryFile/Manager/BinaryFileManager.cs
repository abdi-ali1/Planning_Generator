using Logic.Enum;
using Logic.Interface;
using System.Runtime.Serialization.Formatters.Binary;

namespace DTO_BinaryFile.Manager
{
    public class BinaryFileManager : IBinaryFileManager
    {
        /// <summary>
        /// Writes the specified object to a binary file. If the file exists, it will be overwritten.
        /// If the file does not exist, it will be created.
        /// </summary>
        /// <typeparam name="T">The type of object to write to the file.</typeparam>
        /// <param name="objectToWrite">The object to write to the file.</param>
        /// <param name="type">The type of repository to which the file belongs.</param>
        public void WriteToBinaryFile<T>(T objectToWrite, RepositoryType type)
        {
            using (Stream stream = File.Open(FileSetterManager.SetFileLocation(type), false ? FileMode.Append : FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }

        /// <summary>
        /// Reads an object of type T from a binary file.
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file.</typeparam>
        /// <param name="type">The type of repository to which the file belongs.</param>
        /// <returns>An object of type T, read from the binary file.</returns>
        public T ReadFromBinaryFile<T>(RepositoryType type)
        {
            using (Stream stream = File.Open(FileSetterManager.SetFileLocation(type), FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

        /*    public void DummyData()
        {
            List<Company> companies = new List<Company>();
            List<StaffMember> staffMembers = new List<StaffMember>();

            staffMembers.Add(new StaffMember("abdi114@live.nl", "Abdi", Gender.Male, CompanyRole.StaffMember, Occupation.Picker, DateTime.Now, new Degree("Software Developer", 5)));
            staffMembers.Add(new StaffMember("john.doe@gmail.com", "John", Gender.Male, CompanyRole.Manager, Occupation.Driver, DateTime.Now, new Degree("Business Administration", 3)));
            staffMembers.Add(new StaffMember("jane.doe@gmail.com", "Jane", Gender.Female, CompanyRole.StaffMember, Occupation.Driver, DateTime.Now, new Degree("Supply Chain Management", 4)));

            staffMembers.Add(new StaffMember("emily456@gmail.com", "Emily", Gender.Female, CompanyRole.StaffMember, Occupation.Picker, DateTime.Now, new Degree("Computer Engineering", 3)));
            staffMembers.Add(new StaffMember("samuel789@gmail.com", "Samuel", Gender.Male, CompanyRole.StaffMember, Occupation.Picker, DateTime.Now, new Degree("Data Science", 2)));
            staffMembers.Add(new StaffMember("david321@gmail.com", "David", Gender.Male, CompanyRole.Manager, Occupation.Picker, DateTime.Now, new Degree("Marketing", 3)));
            staffMembers.Add(new StaffMember("olivia654@gmail.com", "Olivia", Gender.Female, CompanyRole.StaffMember, Occupation.Picker, DateTime.Now, new Degree("Graphic Design", 2)));

            companies.Add(new Company("Tesla"));
            companies.Add(new Company("Apple"));
            companies.Add(new Company("Google"));

            IList<Company> companies1 = companies;
            IList<StaffMember> staffMembers1 = staffMembers;

            WriteToBinaryFile<IList<Company>>(companies1, RepositoryType.Company);
            WriteToBinaryFile<IList<StaffMember>>(staffMembers1, RepositoryType.Staff);
        }*/
    }
}
