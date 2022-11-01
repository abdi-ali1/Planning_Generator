using Logic.Enum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOfWeek = Logic.Enum.DayOfWeek;

namespace Logic.Companys.Request
{
    public class NeededStaff
    {
        private Occaption occaption;
        private DayOfWeek neededDay;
        private Dictionary<ShiftHour, int> staffPerHour = new();

        public Occaption Occaption { get { return occaption; }  }
        public DayOfWeek NeededDay { get { return neededDay; } }


        public ReadOnlyDictionary<ShiftHour, int> StaffPerHour 
        { 
            get 
            {
                return new ReadOnlyDictionary<ShiftHour, int>(staffPerHour); 
            } 
        }


        public NeededStaff(Occaption occaption, DayOfWeek neededDay, 
            Dictionary<ShiftHour, int> staffPerHour)
        {
            this.occaption = occaption;
            this.neededDay = neededDay;
            this.staffPerHour = staffPerHour;
        }


        public NeededStaff(Occaption occaption, DayOfWeek neededDay, 
            ShiftHour kindOfShift, int amountNeededStaff)
        {
            this.occaption = occaption;
            this.neededDay = neededDay;

            staffPerHour.Add(kindOfShift, amountNeededStaff);
            
        }

      
    }
}
