using Logic;
using Logic.Companys.Request;

namespace UnitTest_Pl.Mocking.Companys
{
    public class WeeklyNeedMock : IWeeklyNeed
    {
        private int weekNeeded;
        private IList<NeededStaff> neededStaff = new List<NeededStaff>();

        public int WeekNeeded { get { return weekNeeded; } }
        public IList<NeededStaff> NeededStaff { get { return neededStaff; } }

       

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