using Logic.Companys.Request;
using Logic.Companys;
using Logic.Employee;
using Logic.Interface;
using Logic;
using Logic.System.Generator;
using Logic.System.Generator.GeneraterHelp.AvailibiltyMatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Pl
{
    internal class ScheduleGeneratorTest
    {
        private ScheduleGenerator ScheduleGenerator;

        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void TestCreateCompanySchedulesForWeek()
        {
            // Arrange
            IGetLoopInfoWeeklyNeed mockGetLoopInfoWeeklyNeed = new MockGetLoopInfoWeeklyNeed();
            IAvailibiltyMatcher mockAvailabilityMatcher = new MockAvailabilityMatcher();
            IAvailibiltyMatcher mockSecondaryAvailabilityMatcher = new MockAvailabilityMatcher();
            IList<StaffMember> mockStaffMembers = new MockStaffMembers();

            var generator = new ScheduleGenerator(
                mockStaffMembers,
                mockGetLoopInfoWeeklyNeed,
                mockAvailabilityMatcher,
                mockSecondaryAvailabilityMatcher
            );

            Company company = new Company("tesla");
            int week = 1;

            // Set up mock data
            IWeeklyNeed neededWeekData = new WeeklyNeed(week);
            neededWeekData.AddNeededStaff = new List<NeededStaff>
            {
                new NeededStaff(),
                new NeededStaff()
            };
            mockGetLoopInfoWeeklyNeed.Setup(company, week, neededWeekData);

            var staffMembersAvailibleOnDate = new List<StaffMember>
            {
                new StaffMember(),
                new StaffMember()
            };
            mockStaffMembers.Setup(week, staffMembersAvailibleOnDate);

            // Set up mock behavior
            mockAvailabilityMatcher.Setup(true);
            mockSecondaryAvailabilityMatcher.Setup(true);

            // Act
            var result = generator.CreateCompanySchedulesForWeek(company, week);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(2, result.Value.Count);
            Assert.AreEqual(2, result.Value[0].CompanyScheduleInfos.Count);
            Assert.AreEqual(0, result.Value[1].CompanyScheduleInfos.Count);
        }


    }
}
