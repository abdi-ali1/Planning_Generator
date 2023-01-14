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
using Logic.Companys.Request;
using Logic.Shifts;
using DayOfWeek = Logic.Enum.DayOfWeek;
using System.Collections;
using Logic.Companys;
using Logic.Employee.Degrees;

namespace UnitTest_Pl.MatcherTest
{
    internal class AvailibilityMatcherTest
    {

        private GeneratorAvailibilityMatcher _matcher;
        private StaffMember staff;
        private NeededStaff needed;
        private AvailabilityStaff availability;
        private IList<CompanyScheduleInfo> scheduleInfo = new List<CompanyScheduleInfo>();

        [SetUp]
        public void SetUp()
        {
            _matcher = new GeneratorAvailibilityMatcher();
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
            needed = new NeededStaff(Occupation.Picker, new Shift(DayOfWeek.Thursday, ShiftHour.MorningShift), 5);
            availability.AddNewShift(new Shift(DayOfWeek.Thursday, ShiftHour.MorningShift));
            staff.AddAvailibilty(availability);


            //Act
            bool result = _matcher.MatchesNeed(needed, staff, 1, scheduleInfo);

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
            bool result = _matcher.MatchesNeed(needed, staff, 1, scheduleInfo);

            //Assert
            Assert.IsFalse(result);
        }


        [Test]
        public void MatchesNeed_StaffDoesntHaveTheSameOccupation_ReturnsFalse()
        {
            scheduleInfo.Add(new CompanyScheduleInfo(
                        staff,
                        new Shift(DayOfWeek.Wednesday, ShiftHour.MorningShift)
                    ));
            needed = new NeededStaff(Occupation.Mechinic, new Shift(DayOfWeek.Thursday, ShiftHour.MorningShift), 5);
            availability.AddNewShift(new Shift(DayOfWeek.Thursday, ShiftHour.MorningShift));
            staff.AddAvailibilty(availability);


            //Act
            bool result = _matcher.MatchesNeed(needed, staff, 1, scheduleInfo);

            //Assert
            Assert.IsFalse(result);
        }

    }
}
