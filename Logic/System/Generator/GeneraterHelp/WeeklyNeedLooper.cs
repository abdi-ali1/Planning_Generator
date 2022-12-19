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
        public WeeklyNeed GetInfo(Company company, DateTime dateTime)
        {
            WeeklyNeed weeklyNeed = null;
            foreach(WeeklyNeed weekly in company.WeeklyNeed)
            {
                if(weekly.WeekNeeded == dateTime)
                {
                   weeklyNeed = weekly;
                }
            }

            return weeklyNeed;
        }
    }
}
