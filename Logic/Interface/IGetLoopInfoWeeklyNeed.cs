using Logic.Companys;
using Logic.Companys.Request;

namespace Logic.Interface
{
    internal interface IGetLoopInfoWeeklyNeed
    {
        public WeeklyNeed GetInfo(Company company, DateTime dateTime);
    }
}
