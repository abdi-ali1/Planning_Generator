﻿using Logic;
using Logic.Companys;
using Logic.Companys.Request;
using Logic.Interface;

namespace UnitTest_Pl.Mocking
{
    internal class MockGetLoopInfoWeeklyNeed : IGetLoopInfoWeeklyNeed
    {
        public Result<IWeeklyNeed> GetInfo(Company company, int week)
        {
           

           Result<IWeeklyNeed> result =   Result<IWeeklyNeed>.Ok(company.WeeklyNeed.First(x => x.WeekNeeded == week));

            return  result;
        }
    }
}
