using Logic;
using Logic.Employee.Degrees;
using Logic.Employee;
using Logic.Enum;
using Logic.Schedules.Company;
using Logic.WorkRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Pl
{
    internal class WorkRuleTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FiftyRuletest()
        {
            StaffMember staffMember1 = new StaffMember("abdi114@live.nl", "Abdi", Gender.Male, CompanyRole.StaffMember, Occupation.Picker, DateTime.Now, new Degree("Software Developer", 5));
            int week = 1;

            //arrange 
            IList<CompanyScheduleInfo> companyScheduleInfos = new List<CompanyScheduleInfo> 
            {
                new CompanyScheduleInfo(staffMember1, new Logic.Shifts.Shift(Logic.Enum.DayOfWeek.Monday, ShiftHour.MorningShift)),
                new CompanyScheduleInfo(staffMember1, new Logic.Shifts.Shift(Logic.Enum.DayOfWeek.Tuesday, ShiftHour.MorningShift))
             };
            IWorkRuleSchedule workRuleSchedule = new FiftyRule(companyScheduleInfos, staffMember1, week);





        } 


    }
}
