using DTO.Models.CompanyModels;
using DTO.Models.ShiftModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models.StaffMemberModels
{
    public class AvailibiltyStaff
    {

        // fields
        private int id;
        private DateTime neededWeek;
        private Company company;
        private List<Shift> shifts = new();

        // properties
        public DateTime NeededWeek { get { return neededWeek; } }
        public Company Company { get { return company; } }
        public IList<Shift> Shifts { get { return shifts.AsReadOnly(); } }
        public int Id { get { return id; } }

        //constructors
        public AvailibiltyStaff(int id,DateTime neededWeek, Company company, List<Shift> shifts)
        {
            this.neededWeek = neededWeek;
            this.company = company;
            this.shifts = shifts;
        }

        public AvailibiltyStaff(int id, DateTime neededWeek, Company company, Shift shift)
        {
            this.neededWeek = neededWeek;
            this.company = company;
            this.shifts.Add(shift);
        }


    }
}
