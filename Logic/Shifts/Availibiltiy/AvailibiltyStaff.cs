using Logic.Companys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Shifts.Availibiltiy
{
    [Serializable]
    public class AvailibiltyStaff
    {
        // fields
        private DateTime weekAvailbilty;
        private Company company;
        private List<Shift> shifts = new List<Shift>();

        // properties
        public DateTime WeekAvailbilty { get { return weekAvailbilty; } }
        public Company Company { get { return company; } }
        public IList<Shift> Shifts { get { return shifts.AsReadOnly(); }  }

        public AvailibiltyStaff(DateTime neededWeek, Company company)
        {
            this.weekAvailbilty = neededWeek;
            this.company = company;
        }


        public AvailibiltyStaff(DateTime neededWeek, Company company, List<Shift> shifts) : this(neededWeek, company)
        {
            this.shifts = shifts;
        }

        /// <summary>
        /// Adds a shift object to the list of shifts for the AvailibiltyStaff.
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
                if (!shifts.Any(x => x.Equals(shift)))
                {
                    shifts.Add(shift);
                    return Result<string>.Ok("Added to list");
                }

                return Result<string>.Fail(new Exception("shift already exist"));
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

            AvailibiltyStaff availibiltyStaff = (AvailibiltyStaff)obj;

            return (availibiltyStaff.company.Name == company.Name && availibiltyStaff.WeekAvailbilty == weekAvailbilty);
        }

    }
}
