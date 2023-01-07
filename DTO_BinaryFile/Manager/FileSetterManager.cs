using Logic.Companys;
using Logic.Employee;
using Logic.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    return "C:\\Users\\abdi1\\source\\repos\\PlanningGenerator\\DTO_BinaryFile\\Files\\StaffMember.bin";

                case RepositoryType.Company:
                    return "C:\\Users\\abdi1\\source\\repos\\PlanningGenerator\\DTO_BinaryFile\\Files\\Company.bin";

                default:
                    return "";
            }
        }
    }
}
