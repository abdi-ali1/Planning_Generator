using Logic.Companys;
using Logic.Companys.Request;
using Logic.Interface;

namespace Logic.System.Generator
{
    internal class WeeklyNeedLooper : IGetLoopInfoWeeklyNeed
    {
        /// <summary>
        /// Gets the weekly need for a given company on a given date.
        /// </summary>
        /// <param name="company">The company to get the weekly need for.</param>
        /// <param name="dateTime">The date to get the weekly need for.</param>
        /// <returns>A result object containing either the weekly need for the given company on the given date, or an exception if there was an error.</returns>
        public Result<IWeeklyNeed> GetInfo(Company company, DateTime dateTime)
        {
            try
            {
                IWeeklyNeed weeklyNeed = company.WeeklyNeed.FirstOrDefault(x => x.WeekNeeded == dateTime);
                if (weeklyNeed == null)
                {
                    return Result<IWeeklyNeed>.Fail(new Exception("there doesnt exist a weeklyneed with the given date"));
                }

                return Result<IWeeklyNeed>.Ok(weeklyNeed);
            }
            catch (Exception e)
            {
                return Result<IWeeklyNeed>.Fail(e);
            }
        }
    }
}
