using Logic.Companys;
using Logic.Companys.Request;

namespace Logic.Interface
{
    public interface IGetLoopInfoWeeklyNeed
    {
        public Result<IWeeklyNeed> GetInfo(Company company, DateTime dateTime);
    }
}
