using Logic.Schedules.Company;

namespace Logic.Schedules
{
    [Serializable]
    public class CompanySchedule
    {
        private int currentWeek;
        private List<CompanyScheduleInfo> companyScheduleInfos = new List<CompanyScheduleInfo>();

        public int CurrentWeek { get { return currentWeek; } }
        public IList<CompanyScheduleInfo> CompanyScheduleInfos { get { return companyScheduleInfos.AsReadOnly(); } }

        public CompanySchedule(int currentWeek)
        {
            this.currentWeek = currentWeek;
        }

        public CompanySchedule(int currentWeek, List<CompanyScheduleInfo> companyScheduleInfos)
        {
            this.currentWeek = currentWeek;
            this.companyScheduleInfos = companyScheduleInfos;
        }

        /// <summary>
        /// Adds a company schedule info to the list of company schedule infos.
        /// </summary>
        /// <param name="scheduleInfo">The company schedule info to add to the list.</param>
        /// <returns>A Result object indicating the success or failure of the operation, and any error message if applicable.</returns>
        public Result<bool> AddComapanyScheduleInfo(CompanyScheduleInfo scheduleInfo)
        {
            try
            {
                if (!companyScheduleInfos.Any(x => x.StaffMember == scheduleInfo.StaffMember && x.Shift == scheduleInfo.Shift))
                {
                    companyScheduleInfos.Add(scheduleInfo);
                    return Result<bool>.Ok(true);
                }
                return Result<bool>.Fail(new Exception("already exists"));
            }
            catch (Exception e)
            {
                return Result<bool>.Fail(e);
            }
        }
    }
}
