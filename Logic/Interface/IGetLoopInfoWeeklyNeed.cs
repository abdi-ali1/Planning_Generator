using Logic.Companys;
using Logic.Companys.Request;

namespace Logic.Interface
{
    internal interface IGetLoopInfoWeeklyNeed
    {
        public Result<T> GetInfo<T>(Company company, DateTime dateTime);
    }
}
