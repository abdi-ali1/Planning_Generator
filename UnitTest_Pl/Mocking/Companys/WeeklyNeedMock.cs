using Logic.Companys.Request;
using Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Pl.Mocking.Companys
{
    public class WeeklyNeedMock : IWeeklyNeed
    {
        public DateTime WeekNeeded => throw new NotImplementedException();

        public IList<NeededStaff> NeededStaff => throw new NotImplementedException();

        public void AddNeededStaff(NeededStaff needed)
        {
            throw new NotImplementedException();
        }
    }
}
