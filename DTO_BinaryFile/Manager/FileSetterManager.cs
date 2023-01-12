using Logic.Enum;

namespace DTO_BinaryFile.Manager
{
    internal static class FileSetterManager
    {
        /// <summary>
        /// Returns the file path for the specified repository type.
        /// </summary>
        /// <param name="type">The type of repository.</param>
        /// <returns>The file path for the repository.</returns>
        public static string SetFileLocation(RepositoryType type)
        {
            switch (type)
            {
                case RepositoryType.Staff:
                    return "D:\\temp\\Planning_Generator\\DTO_BinaryFile\\Files\\StaffMember.bin";

                case RepositoryType.Company:
                    return "D:\\temp\\Planning_Generator\\DTO_BinaryFile\\Files\\Company.bin";

                default:
                    return "";
            }
        }
    }
}
