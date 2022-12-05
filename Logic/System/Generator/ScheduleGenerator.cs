using Logic.Companys;
using Logic.Companys.Request;
using Logic.Employee;
using Logic.Shifts.Availibiltiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.Generator
{
    public class ScheduleGenerator
    {

        private IList<StaffMember> allStaffMembers;
        private List<IWorkRule> workRule;

        public ScheduleGenerator(IList<StaffMember> allStaffMembers, List<IWorkRule> workRule)
        {
            this.allStaffMembers = allStaffMembers;
            this.workRule = workRule;
        }



        /// <summary>
        /// will generate schedules for the company and the chosen staffmembers
        /// 
        /// </summary>
        /// <param name="weeklyNeed"> will probably be changed to a diffrent data type</param>
        public void GenerateSchedule(Company company, DateTime weekNeeded)
        {
            WeeklyNeed neededWeekData = GetNeededWeek(company.WeeklyNeed, weekNeeded);
            IList<StaffMember> workingStaff = new List<StaffMember>();
           // workingStaff = SetWorkingStaff()

         


               
        }


      
      
        private WeeklyNeed GetNeededWeek(IList<WeeklyNeed> weeklyNeeds, DateTime weekneeded)
        {
            WeeklyNeed weekly = null;

            foreach (WeeklyNeed weeklyNeed in weeklyNeeds)
            {
                if (weeklyNeed.WeekNeeded == weekneeded)
                {
                    weekly = weeklyNeed;
                }
            }
            return weekly;
        }


        private IList<StaffMember> SetWorkingStaff(IList<NeededStaff> neededStaff, IList<StaffMember> staffMembers)
        {
            List<StaffMember> workingStaffList = new List<StaffMember>();
            foreach (NeededStaff needed in neededStaff)
            {
                foreach (StaffMember staff in staffMembers)
                {
                   
                       
                    
                }
            }


            return workingStaffList;
        }


        private IList<StaffMember> GetAvailibelStaffMembers(DateTime dateTime)
        {
            IList<StaffMember> workingStaffList = new List<StaffMember>();

            foreach (StaffMember staff in allStaffMembers)
            {
                foreach (AvailibiltyStaff availibilty in staff.Availibilty)
                {
                    if (availibilty.WeekAvailbilty == dateTime)
                    {
                        workingStaffList.Add(staff);
                    }
                }
            }

            return workingStaffList;

        }


        private AvailibiltyStaff GetAvailibiltyStaffObject(StaffMember staff ,DateTime dateTime)
        {
            AvailibiltyStaff availibiltyStaff = null;

            foreach (AvailibiltyStaff availibilty in staff.Availibilty)
            {
                if (availibilty.WeekAvailbilty == dateTime)
                {
                    availibiltyStaff = availibilty;
                    break;
                }
            }

            return availibiltyStaff;

        }




        #region to do
        private void SetStaffSchedules()
        {
            // to do sets the chosen staff schedules
        }

        private void SetCompanySchedule()
        {
            // todo sets the schedule for company (maybe this isnt the smartes way)
        }
        #endregion

    }
}
