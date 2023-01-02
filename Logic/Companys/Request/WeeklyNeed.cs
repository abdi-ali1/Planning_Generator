using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interface;

namespace Logic.Companys.Request
{
    [Serializable]
    public class WeeklyNeed: IWeeklyNeed
    {
        // fields
        private DateTime weekNeeded;
        private List<NeededStaff> neededStaff = new List<NeededStaff>();

        // properties
        public DateTime WeekNeeded { get { return weekNeeded; } }
        public IList<NeededStaff> NeededStaff { get { return neededStaff.AsReadOnly(); } }
        
        // constructors
        public WeeklyNeed(DateTime weekNeeded, List<NeededStaff> neededStaff)
        {
            this.weekNeeded = weekNeeded;
            this.neededStaff = neededStaff;
        }


        /// <summary>
        /// Adds a NeededStaff object to the list of needed staff for the given week.
        /// </summary>
        /// <param name="needed">The NeededStaff object to be added to the list.</param>
        /// <returns>
        /// A Result<string> object indicating the success or failure of the operation. If the operation is successful,
        /// the Ok variant will contain a string message indicating that the NeededStaff object was added to the list. If 
        /// the operation fails, the Fail variant will contain an Exception object with more information about the error.
        /// </returns>
        public Result<string> AddNeededStaff(NeededStaff needed)
        {
            try
            {
                if (needed == null)
                {
                    return Result<string>.Fail(new Exception("given object was null"));
                }

                neededStaff.Add(needed);
                return Result<string>.Ok("is added to list");

            }
            catch (Exception e)
            {

                return Result<string>.Fail(e);
            }
          
        }




    }
}
