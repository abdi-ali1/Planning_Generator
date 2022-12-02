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
        private DateTime neededWeek;
        private Company company;
        private List<Shift> shifts = new();

        // properties
        public DateTime NeededWeek { get { return neededWeek; } }
        public Company Company { get { return company; } }
        public IList<Shift> Shifts { get { return shifts.AsReadOnly(); }  }

        public AvailibiltyStaff(DateTime neededWeek, Company company)
        {
            this.neededWeek = neededWeek;
            this.company = company;
        }


        //constructors
        public AvailibiltyStaff(DateTime neededWeek, Company company, List<Shift> shifts): this(neededWeek, company)
        {
            this.shifts = shifts;
        }


        public bool AddNewShift(Shift shift)
        {
            bool doesntExist = true;
            foreach (Shift s in Shifts)
            {
                if (s.Equals(shift))
                {
                    doesntExist = false;
                    break;
                }
            }
            if (doesntExist) Shifts.Add(shift);

            return doesntExist;
        }

    }
}
