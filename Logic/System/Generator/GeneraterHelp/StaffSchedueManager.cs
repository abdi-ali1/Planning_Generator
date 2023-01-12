using Logic.Companys;
using Logic.Employee;
using Logic.Schedules.Company;
using Logic.Schedules.Staff;

namespace Logic.System.Generator.GeneraterHelp
{
    public class StaffSchedueManager
    {
        private StaffMember staffMember;
        private IList<CompanyScheduleInfo> companyScheduleInfos;
        private int week;

        public StaffSchedueManager(StaffMember staffMember, IList<CompanyScheduleInfo> companyScheduleInfo, int week)
        {
            this.staffMember = staffMember;
            companyScheduleInfos = companyScheduleInfo;
            this.week = week;
        }

        /// <summary>
        /// Sets the staff member's schedule.
        /// </summary>
        /// <param name="company">The company for which the schedule is being set.</param>
        /// <returns>The updated staff member object, or an error if something went wrong.</returns>
        public Result<StaffMember> SetStaffSchedule(Company company)
        {
            try
            {
                IList<CompanyScheduleInfo> staffMemberShift = GetStaffMemberShift();
                if (staffMemberShift == null)
                {
                    return Result<StaffMember>.Fail(
                        new Exception("there are no shift for this user")
                    );
                }

                int staffScheduleIndex = GetStaffScheduleIfExist();
                if (staffScheduleIndex == -1)
                {
                    CreateAndAddStaffSchedule(staffMemberShift, company);
                }
                else
                {
                    AddShiftsToExistingStaffSchedule(staffMemberShift, staffScheduleIndex);
                }

                return Result<StaffMember>.Ok(staffMember);
            }
            catch (Exception e)
            {
                return Result<StaffMember>.Fail(e);
            }
        }

        /// <summary>
        /// Gets the shift information for the staff member.
        /// </summary>
        /// <returns>A list of shift information for the staff member, or null if there is no information.</returns>
        private IList<CompanyScheduleInfo>? GetStaffMemberShift()
        {
            IList<CompanyScheduleInfo> companyScheduleInfos = new List<CompanyScheduleInfo>();

            foreach (CompanyScheduleInfo info in companyScheduleInfos)
            {
                if (info.StaffMember.Equals(staffMember))
                {
                    companyScheduleInfos.Add(info);
                }
            }

            //addvencde
            return companyScheduleInfos.Count > 0 ? companyScheduleInfos : null;
        }

        /// <summary>
        /// Gets the index of the staff member's schedule for the current week, if it exists.
        /// </summary>
        /// <returns>The index of the staff member's schedule, or -1 if it does not exist.</returns>
        private int GetStaffScheduleIfExist()
        {
            for (int i = 0; i < staffMember.StaffSchedule.Count; i++)
            {
                if (staffMember.StaffSchedule[i].CurrentWeek == week)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Creates a new staff schedule and adds it to the staff member's schedule list.
        /// </summary>
        /// <param name="staffMemberShift">The shift information for the staff member.</param>
        /// <param name="company">The company for which the schedule is being set.</param>
        private void CreateAndAddStaffSchedule(
            IList<CompanyScheduleInfo> staffMemberShift,
            Company company
        )
        {
            StaffSchedule schedule = new StaffSchedule(week, company);
            foreach (CompanyScheduleInfo scheduleInfo in staffMemberShift)
            {
                schedule.AddNewShift(scheduleInfo.Shift);
            }

            staffMember.AddSchedule(schedule);
        }

        /// <summary>
        /// Adds shifts to an existing staff schedule.
        /// </summary>
        /// <param name="staffMemberShift">The shift information for the staff member.</param>
        /// <param name="staffScheduleIndex">The index of the staff member's schedule.</param>
        private void AddShiftsToExistingStaffSchedule(
            IList<CompanyScheduleInfo> staffMemberShift,
            int staffScheduleIndex
        )
        {
            foreach (CompanyScheduleInfo scheduleInfo in staffMemberShift)
            {
                staffMember.StaffSchedule[staffScheduleIndex].AddNewShift(scheduleInfo.Shift);
            }
        }
    }
}

