using Logic;
using Logic.Employee.Degrees;
using Logic.Employee;
using Logic.Enum;
using Logic.Schedules.Company;
using Logic.WorkRules;
using Logic.Schedules.Staff;
using Logic.Companys;
using DayOfWeek = Logic.Enum.DayOfWeek;

namespace UnitTest_Pl
{
    internal class FiftyRuleTest
    {
        private StaffMember staff;
        private Company company;

        [SetUp]
        public void Setup()
        {
            staff = new StaffMember(
               "abdi114@live.nl",
               "Abdi",
               Gender.Male,
               CompanyRole.StaffMember,
               Occupation.Picker,
               new DateTime(05 / 29 / 1960),
               new Degree("Software Developer", 5)
           );

            company = new Company("Tesla");

        }

        [Test]
        public void FiftyRuleTest_WithInvalidRule_ShouldReturnFalse()
        {
            int week = 1;

            staff = new StaffMember(
           "abdi114@live.nl",
           "Abdi",
           Gender.Male,
           CompanyRole.StaffMember,
           Occupation.Picker,
           new DateTime(05 / 29 / 1960),
           new Degree("Software Developer", 5)
            );

            StaffSchedule staffSchedule = new StaffSchedule(week, company);

            //arrange
            IList<CompanyScheduleInfo> companyScheduleInfos = new List<CompanyScheduleInfo>
            {
                new CompanyScheduleInfo(
                    staff,
                    new Logic.Shifts.Shift(DayOfWeek.Monday, ShiftHour.MorningShift)
                ),
                new CompanyScheduleInfo(
                    staff,
                    new Logic.Shifts.Shift(DayOfWeek.Tuesday, ShiftHour.MorningShift)
                )
            };


            staffSchedule.AddNewShift(new Logic.Shifts.Shift(DayOfWeek.Tuesday, ShiftHour.AfternoonShift));
            staffSchedule.AddNewShift(new Logic.Shifts.Shift(DayOfWeek.Wednesday, ShiftHour.MorningShift));

            staff.AddSchedule(staffSchedule);
            IWorkRuleSchedule workRuleSchedule = new FiftyRule(
                companyScheduleInfos,
                staff,
                week
            );

            //act
            bool ruleAdhered = workRuleSchedule.IsRuleAdhered();

            //assert
            Assert.IsFalse(ruleAdhered);
        }

        [Test]
        public void FiftyRuleTest_WithValidRule_ShouldReturnTrue()
        {
            // Arrange
            int week = 1;

            staff = new StaffMember(
             "abdi114@live.nl",
             "Abdi",
             Gender.Male,
             CompanyRole.StaffMember,
             Occupation.Picker,
             new DateTime(21 / 01 / 2001),
             new Degree("Software Engineer", 5)
             );

            StaffSchedule staffSchedule = new StaffSchedule(week, company);
            IList<CompanyScheduleInfo> companyScheduleInfos = new List<CompanyScheduleInfo>
            {
                new CompanyScheduleInfo(
                    staff,
                    new Logic.Shifts.Shift(DayOfWeek.Monday, ShiftHour.MorningShift)
                )
            };

            IWorkRuleSchedule workRuleSchedule = new FiftyRule(
                companyScheduleInfos,
                staff,
                week
            );


            // Act
            bool ruleAdhered = workRuleSchedule.IsRuleAdhered();

            // Assert
            Assert.IsTrue(ruleAdhered);
        }
    }

}
