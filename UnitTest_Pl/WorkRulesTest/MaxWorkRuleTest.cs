using Logic;
using Logic.Companys;
using Logic.Employee;
using Logic.Employee.Degrees;
using Logic.Enum;
using Logic.Schedules.Company;
using Logic.Schedules.Staff;
using Logic.Shifts;
using Logic.WorkRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOfWeek = Logic.Enum.DayOfWeek;

namespace UnitTest_Pl
{
    internal class MaxWorkRuleTest
    {
        private StaffMember staff;
        private IList<CompanyScheduleInfo> scheduleInfo;
        private int week;
        private Shift newShift;

        [SetUp]
        public void Setup()
        {
            staff = new StaffMember
          (
               "abdi114@live.nl",
               "Abdi",
               Gender.Male,
               CompanyRole.StaffMember,
               Occupation.Picker,
               new DateTime(05 / 29 / 1960),
               new Degree("Software Developer", 5)
           );

            scheduleInfo = new List<CompanyScheduleInfo>
        {
            new CompanyScheduleInfo(
                staff,
                new Shift(DayOfWeek.Monday, ShiftHour.MorningShift)
            ),
            new CompanyScheduleInfo(
                staff,
                new Shift(DayOfWeek.Tuesday, ShiftHour.MorningShift)
            )
        };

            week = 1;
            newShift = new Shift(DayOfWeek.Wednesday, ShiftHour.MorningShift);
        }

        [Test]
        public void MaxWorkHours_CanAddShift_ReturnTrue()
        {
            IWorkRuleSchedule maxWorkHours = new MaxWorkHours(scheduleInfo, staff, week, newShift);

            bool result = maxWorkHours.IsRuleAdhered();

            Assert.IsTrue(result);
        }

        [Test]
        public void MaxWorkHours_CanAddShift_ReturnFalse()
        {
            scheduleInfo.Add(new CompanyScheduleInfo(
                staff,
                new Shift(DayOfWeek.Wednesday, ShiftHour.MorningShift)
            ));
            MaxWorkHours maxWorkHours = new MaxWorkHours(scheduleInfo, staff, week, newShift);

            bool result = maxWorkHours.IsRuleAdhered();

            Assert.IsFalse(result);
        }


        [Test]
        public void MaxWorkHours_CanAddShift_ReturnTrueSheduleStaffMember()
        {
            Company company = new Company("Tesla");

            StaffSchedule staffSchedule = new StaffSchedule(week, company);

            staffSchedule.AddNewShift(new Shift(DayOfWeek.Thursday, ShiftHour.MorningShift));
            staff.AddSchedule(staffSchedule);

            IWorkRuleSchedule maxWorkHours = new MaxWorkHours(scheduleInfo, staff, week, newShift);

            bool result = maxWorkHours.IsRuleAdhered();

            Assert.IsTrue(result);

        }



        [Test]
        public void MaxWorkHours_CanAddShift_ReturnFalseSheduleStaffMember()
        {
            Company company = new Company("Tesla");

            StaffSchedule staffSchedule = new StaffSchedule(week, company);

            staffSchedule.AddNewShift(new Shift(DayOfWeek.Wednesday, ShiftHour.AfternoonShift));
            staff.AddSchedule(staffSchedule);

            IWorkRuleSchedule maxWorkHours = new MaxWorkHours(scheduleInfo, staff, week, newShift);

            bool result = maxWorkHours.IsRuleAdhered();

            Assert.IsFalse(result);

        }



    }
}
