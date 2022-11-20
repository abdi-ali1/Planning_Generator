using DTO.Models.ShiftModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models.StaffMemberModels
{
    public class StaffMemeberSchedule
    {
        // fields
        private int id;
        private DateTime currentWeek;
        private List<Shift> allShifts = new();

        // properties
        public DateTime CurrentWeek { get { return currentWeek; } }
        public IList<Shift> AllShifts { get { return allShifts.AsReadOnly(); } }
        public int Id { get { return id; } }


        public StaffMemeberSchedule(int id, DateTime currentWeek, List<Shift> shifts)
        {
            this.currentWeek = currentWeek;
            this.allShifts = shifts;
        }

        public StaffMemeberSchedule(int id ,DateTime currentWeek, Shift shift)
        {
            this.currentWeek = currentWeek;
            allShifts.Add(shift);
        }


    }
}
