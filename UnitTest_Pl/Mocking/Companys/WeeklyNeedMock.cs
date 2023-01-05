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
        private DateTime weekNeeded;
        private List<NeededStaff> neededStaff = new List<NeededStaff>();
        public DateTime WeekNeeded => weekNeeded;

        IList<NeededStaff> IWeeklyNeed.NeededStaff => neededStaff;

        public WeeklyNeedMock(DateTime weekNeeded)
        {
            this.weekNeeded = weekNeeded;
        }

        public IList<NeededStaff> NeededStaff = new List<NeededStaff>();

        public Result<string> AddNeededStaff(NeededStaff needed)
        {
            return Result<string>.Ok("Mock class");
        }
    }
}
