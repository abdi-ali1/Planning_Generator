using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_BinaryFile
{
    [Serializable]
    public class StaffMemeberSchedule
    {
        // fields

        private DateTime currentWeek;
        private List<Shift> allShifts = new();

        // properties
        public DateTime CurrentWeek { get { return currentWeek; } }
        public IList<Shift> AllShifts { get { return allShifts.AsReadOnly(); } }



        public StaffMemeberSchedule(DateTime currentWeek, List<Shift> shifts)
        {
            this.currentWeek = currentWeek;
            this.allShifts = shifts;
        }

        public StaffMemeberSchedule(DateTime currentWeek, Shift shift)
        {
            this.currentWeek = currentWeek;
            allShifts.Add(shift);
        }

        private StaffMemeberSchedule()
        {

        }

    }
}
