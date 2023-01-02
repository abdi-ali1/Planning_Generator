using Logic.Companys;
using Logic.Companys.Request;

namespace Logic.Interface
{
    public interface IGetLoopInfoWeeklyNeed
    {
        public Result<WeeklyNeed> GetInfo(Company company, DateTime dateTime);
    }
}
