using Logic.Companys.Request;
using Logic.Employee;
using Logic.Schedules.Company;
using Logic.Shifts;
using Logic.Shifts.Availibiltiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.Generator
{
    /// <summary>
    /// is class that helps with filtering for the generator
    /// </summary>
    internal static class GeneraterloopContext
    {
        public static WeeklyNeed GetNeededWeek(IList<WeeklyNeed> weeklyNeeds, DateTime weekneeded)
        {
            WeeklyNeed weekly = null;

            foreach (WeeklyNeed weeklyNeed in weeklyNeeds)
            {
                if (weeklyNeed.WeekNeeded == weekneeded)
                {
                    weekly = weeklyNeed;
                    break;
                }
            }
            return weekly;
        }


        public static IList<StaffMember> GetAvailibilStaff(IList<StaffMember> staffMembers, DateTime dateTime)
        {
           IList<StaffMember> availibilStaff = new List<StaffMember>();
            
            foreach (StaffMember staffMember in staffMembers)
            {
                foreach (AvailibiltyStaff availibilty in staffMember.Availibilty)
                {
                    if (availibilty.WeekAvailbilty == dateTime)
                    {
                        availibilStaff.Add(staffMember);
                    }
                }
            }
      
            return availibilStaff;
        }

            

        public static bool IsChosen(NeededStaff needed, StaffMember staff, DateTime date)
        {
            bool isChosen = false;
            foreach (AvailibiltyStaff availibilty in staff.Availibilty)
            {
                if (availibilty.WeekAvailbilty == date )
                {
                    foreach (Shift shift in availibilty.Shifts)
                    {
                        if (needed.NeededShift.Equals(shift))
                        {
                            if (needed.Occaption.Equals(staff.Occaption) && needed.DegreeLevel.Equals(staff.Degree.DegreeLevel))
                            {
                                new CompanyScheduleInfo(staff, shift);
                                isChosen = true;
                                break;
                            }
                          
                        }
                    }
                }
            }

            return isChosen;
        }

        public static bool IsAbelToWork(NeededStaff needed, StaffMember staff, DateTime date)
        {
            bool isChosen = false;
            foreach (AvailibiltyStaff availibilty in staff.Availibilty)
            {
                if (availibilty.WeekAvailbilty == date)
                {
                    foreach (Shift shift in availibilty.Shifts)
                    {
                        if (needed.NeededShift.Equals(shift) && needed.Occaption.Equals(staff.Occaption))
                        {
                            if (needed.Occaption.Equals(staff.Occaption) && needed.DegreeLevel.Equals(staff.Degree.DegreeLevel))
                            {
                                isChosen = true;
                                break;
                            }
                        }
                    }
                }
            }
            return isChosen;
        }


        public static int AmountOfNeededStaff(WeeklyNeed weeklyNeed)
        {
            int amount = weeklyNeed.NeededStaff.Count;

            return amount;
        }
    }
}
