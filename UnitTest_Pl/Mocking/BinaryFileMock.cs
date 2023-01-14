using Logic.Enum;
using Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest_Pl.Mocking.Companys;
using UnitTest_Pl.Mocking.StaffMember;

namespace UnitTest_Pl.Mocking
{
    internal class BinaryFileMock : IBinaryFileManager
    {
        public T ReadFromBinaryFile<T>(RepositoryType type)
        {
            if (type == RepositoryType.Staff)
            {
                return (T)MockStaffMembers.GetListStaffMember();
            }
            else
            {
                return (T)CompanyDataMock.GetListCompany();
            }
        }

        public void WriteToBinaryFile<T>(T objectToWrite, RepositoryType type)
        {
            Console.WriteLine("doesnt do anything");
        }
    }
}
