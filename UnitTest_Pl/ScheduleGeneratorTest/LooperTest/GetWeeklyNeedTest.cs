using Logic.Companys.Request;
using Logic.System.Generator;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Companys;

namespace UnitTest_Pl.ScheduleGeneratorTest.LooperTest
{
    internal class GetWeeklyNeedTest
    {
        private WeeklyNeedLooper looper;
        private Company company;

        [SetUp]
        public void SetUp()
        {
            looper = new WeeklyNeedLooper();
            company = new Company("Tesla");
        }

        [Test]
        public void GetInfo_WhenWeeklyNeedExists_ShouldReturnWeeklyNeed()
        {
            // Arrange
            int week = 1;
            IWeeklyNeed expected = new WeeklyNeed(week, new List<NeededStaff>());
            company.WeeklyNeed.Add(expected);

            // Act
            Result<IWeeklyNeed> result = looper.GetInfo(company, week);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(expected, result.Value);
        }

        [Test]
        public void GetInfo_WhenWeeklyNeedDoesNotExist_ShouldReturnMessage()
        {
            // Arrange
            int week = 1;

            // Act
            Result<IWeeklyNeed> result = looper.GetInfo(company, week);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("there doesnt exist a weeklyneed with the given date", result.Exception.Message);
        }

    }
}
