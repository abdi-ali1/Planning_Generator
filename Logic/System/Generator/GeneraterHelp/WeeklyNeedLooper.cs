using Logic.Companys;
using Logic.Companys.Request;
using Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.Generator
{
    internal class WeeklyNeedLooper : IGetLoopInfoWeeklyNeed
    {
        public Result<WeeklyNeed> GetInfo(Company company, DateTime dateTime)
        {
            try
            {
                WeeklyNeed weeklyNeed = company.WeeklyNeed.FirstOrDefault(x => x.WeekNeeded == dateTime);
                if (weeklyNeed == null)
                {
                    return Result<WeeklyNeed>.Fail(new Exception("there doesnt exist a weeklyneed with the given date"));
                }

                return Result<WeeklyNeed>.Ok(weeklyNeed);
            }
            catch (Exception e)
            {
                return Result<WeeklyNeed>.Fail(e);
            }
        }
    }
}
