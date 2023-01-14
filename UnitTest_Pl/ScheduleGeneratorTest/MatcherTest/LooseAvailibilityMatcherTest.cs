using Logic.Enum;
using Logic.Schedules.Company;
using Logic.Shifts.Availibiltiy;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Employee;
using Logic.Shifts;
using Logic.Companys.Request;
using DayOfWeek = Logic.Enum.DayOfWeek;
using Logic.Employee.Degrees;
using Logic.Companys;

namespace UnitTest_Pl.ScheduleGeneratorTest.MatcherTest
{
    internal class LooseAvailibilityMatcherTest
    {

        private IAvailibiltyMatcher matcher;
        private StaffMember staff;
        private NeededStaff needed;
        private AvailabilityStaff availability;
        private IList<CompanyScheduleInfo> scheduleInfo = new List<CompanyScheduleInfo>();

        [SetUp]
        public void SetUp()
        {
            matcher = new GeneratorBackerMatcher();
            availability = new AvailabilityStaff(1, new Company("Tesla"), new List<Shift>()
            {
                new Shift(DayOfWeek.Monday, ShiftHour.MorningShift)
            });

            staff = new StaffMember(
                 "abdi114@live.nl",
                 "Abdi",
                 Gender.Male,
                 CompanyRole.StaffMember,
                 Occupation.Picker,
                 new DateTime(05 / 29 / 1960),
                 new Degree("Software Developer", 5)
             );
        }

        [Test]
        public void MatchesNeed_StaffAvailableAndEligibleAndAdheresToWorkRules_ReturnsTrue()
        {

            scheduleInfo.Add(new CompanyScheduleInfo(
                 staff,
                 new Shift(DayOfWeek.Wednesday, ShiftHour.MorningShift)
             ));
            // the occupation is diffrent
            needed = new NeededStaff(Occupation.Mechinic, new Shift(DayOfWeek.Thursday, ShiftHour.MorningShift), 5);
            availability.AddNewShift(new Shift(DayOfWeek.Thursday, ShiftHour.MorningShift));
            staff.AddAvailibilty(availability);


            //Act
            bool result = matcher.MatchesNeed(needed, staff, 1, scheduleInfo);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void MatchesNeed_StaffNotAvailable_ReturnsFalse()
        {
            scheduleInfo.Add(new CompanyScheduleInfo(
                 staff,
                 new Shift(DayOfWeek.Wednesday, ShiftHour.MorningShift)
             ));
          
            needed = new NeededStaff(Occupation.Driver, new Shift(DayOfWeek.Thursday, ShiftHour.MorningShift), 5);
            availability.AddNewShift(new Shift(DayOfWeek.Friday, ShiftHour.MorningShift));

            staff.AddAvailibilty(availability);


            //Act
            bool result = matcher.MatchesNeed(needed, staff, 1, scheduleInfo);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
