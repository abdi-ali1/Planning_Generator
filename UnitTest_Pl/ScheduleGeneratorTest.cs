using Logic.Companys.Request;
using Logic.Companys;
using Logic.Employee;
using Logic.Interface;
using Logic.System.Generator;
using Logic.System.Generator.GeneraterHelp.AvailibiltyMatcher;
using UnitTest_Pl.Mocking;
using UnitTest_Pl.Mocking.StaffMember;

namespace UnitTest_Pl
{
    internal class ScheduleGeneratorTest
    {
        private ScheduleGenerator ScheduleGenerator;

        [SetUp]
        public void Setup() { }

        [Test]
        public void TestCreateCompanySchedulesForWeek()
        {
            // Arrange
            IGetLoopInfoWeeklyNeed mockGetLoopInfoWeeklyNeed = new MockGetLoopInfoWeeklyNeed();
            IAvailibiltyMatcher mockAvailabilityMatcher = new MockAvailabilityMatcher();
            IAvailibiltyMatcher mockSecondaryAvailabilityMatcher = new MockAvailabilityMatcher();
            IList<StaffMember> mockStaffMembers = MockStaffMembers.GetListStaffMember();

            ScheduleGenerator generator = new ScheduleGenerator(
                mockStaffMembers,
                mockGetLoopInfoWeeklyNeed,
                mockAvailabilityMatcher,
                mockSecondaryAvailabilityMatcher
            );

            Company company = new Company("tesla");
            int week = 1;

            // Set up mock behavior


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
