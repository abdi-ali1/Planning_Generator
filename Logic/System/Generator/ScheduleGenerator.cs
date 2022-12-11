using Logic.Companys;
using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules;
using Logic.Schedules.Staff;


namespace Logic.System.Generator
{
    public class ScheduleGenerator
    {

        private IList<StaffMember> allStaffMembers;
        private IList<IWorkRule> workRules;


        public ScheduleGenerator(IList<StaffMember> allStaffMembers, List<IWorkRule> workRule)
        {
            this.allStaffMembers = allStaffMembers;
            this.workRules = workRule;
        }



        /// <summary>
        /// will generate schedules for the company and the chosen staffmembers
        /// </summary>
        /// <param name="weeklyNeed"> will probably be changed to a diffrent data type</param>
        public IList<StaffMember> GenerateSchedule(Company company, DateTime weekNeeded)
        {
            WeeklyNeed neededWeekData = GeneraterloopContext.GetNeededWeek(company.WeeklyNeed, weekNeeded);
            IList<StaffMember> availibilStaff = new List<StaffMember>();
            int neededAmountEmployees = GeneraterloopContext.AmountOfNeededStaff(neededWeekData);

            foreach (NeededStaff needed in neededWeekData.NeededStaff)
            {
                foreach (StaffMember staff in allStaffMembers)
                {
                    if (GeneraterloopContext.IsChosen(needed, staff, weekNeeded))
                    {
                        availibilStaff.Add(staff);
                    }
                }
            }

            if (neededAmountEmployees != availibilStaff.Count)
            {
                foreach (NeededStaff needed in neededWeekData.NeededStaff)
                {
                    foreach (StaffMember staff in allStaffMembers)
                    {
                        if (GeneraterloopContext.IsAbelToWork(needed, staff, weekNeeded))
                        {
                            if (!availibilStaff.Contains(staff))
                            {
                                availibilStaff.Add(staff);
                            }
                        }
                    }
                }
            }

   /*         company.AddSchedules(new CompanySchedule(weekNeeded, (List<StaffMember>)availibilStaff));*/

     

            return availibilStaff;
        }


        /// <summary>
        /// Adds a new workrule
        /// weet niet als dit handig kan zijn
        /// </summary>
        /// <param name="workRule"></param>
        /// <returns></returns>
        public bool AddRule(IWorkRule workRule)
        {
            if (!workRules.Contains(workRule))
            {
                workRules.Add(workRule);
                return true;
            }

            return false;
        }


      

      
  

    }
}
