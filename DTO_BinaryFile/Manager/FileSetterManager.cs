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

        public static string SetFileLocation(RepositoryType type)
        {
            switch (type)
            {
                case RepositoryType.Staff:
                  return "C:\\Users\\abdi1\\source\\repos\\PlanningGenerator\\DTO_BinaryFile\\Files\\StaffMember.bin";

                case RepositoryType.Company:
                    return "C:\\Users\\abdi1\\source\\repos\\PlanningGenerator\\DTO_BinaryFile\\Files\\Company.bin";
                break;
            }

            return null;
        }


    }
}
