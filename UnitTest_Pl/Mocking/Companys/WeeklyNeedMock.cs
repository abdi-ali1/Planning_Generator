using Logic;
using Logic.Companys.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Pl.Mocking.Companys
{
    public class WeeklyNeedMock : IWeeklyNeed
    {
        private int weekNeeded;
        private IList<NeededStaff> neededStaff = new List<NeededStaff>();
        public int WeekNeeded => weekNeeded;
        public IList<NeededStaff> NeededStaff { get { return neededStaff; } };

        int IWeeklyNeed.WeekNeeded => throw new NotImplementedException();

      

        public WeeklyNeedMock(int weekNeeded)
        {
            this.weekNeeded = weekNeeded;
        }



        public Result<string> AddNeededStaff(NeededStaff needed)
        {
            return Result<string>.Ok("Mock class");
        }
    }
}
