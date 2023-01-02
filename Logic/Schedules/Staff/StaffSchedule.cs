using Logic.Employee;
using Logic.Schedules.Staff.formules;
using Logic.Shifts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Companys;


namespace Logic.Schedules.Staff
{
    [Serializable]
    public class StaffSchedule
    {
        // fields
        private DateTime currentWeek;
        private List<Shift> allShifts = new List<Shift>();
        private Companys.Company company;


        // properties
        public DateTime CurrentWeek { get { return currentWeek; } }
        public IList<Shift> AllShifts { get { return allShifts.AsReadOnly(); } }
        public float TotalWorkingHours { get { return  WorkHour.GetTotalWeekWorkingHour(allShifts); } }
        private Companys.Company Company { get { return company; } }

        public StaffSchedule(DateTime currentWeek, Companys.Company company)
        {
            this.currentWeek = currentWeek;
            this.company = company;
        }

        /// <summary>
        /// Adds a Shift object to the list of shifts for the StaffSchedule.
        /// </summary>
        /// <param name="shift">The shift object to be added to the list.</param>
        /// <returns>
        /// A Result<string> object indicating the success or failure of the operation. If the operation is successful,
        /// the Ok variant will contain a string message indicating that the StaffSchedule object was added to the list. 
        /// If the operation fails, the Fail variant will contain an Exception object with more information about the 
        /// error.
        /// </returns>
        public Result<string> AddNewShift(Shift shift)
        {
            try
            {
                Shift shift1 = allShifts.FirstOrDefault(x => x.Equals(shift));

                if (!allShifts.Any(x => x.Equals(shift)))
                {
                   allShifts.Add(shift);
                  return Result<string>.Ok("added to list");
                }

                return Result<string>.Fail(new Exception("already exist"));
            }
            catch (Exception e)
            {

                return Result<string>.Fail(e); 
            }
        }


        public override bool Equals(object? obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            StaffSchedule staffSchedule = (StaffSchedule)obj;

            return (staffSchedule.company == company && staffSchedule.CurrentWeek == currentWeek);
        }





    }
}
