using Logic.Enum;
using Logic.Shifts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOfWeek = Logic.Enum.DayOfWeek;

namespace Logic.Companys.Request
{
    [Serializable]
    public class NeededStaff
    {
        private Occaption occaption;
        private Shift neededShift;

        public Occaption Occaption { get { return occaption; } }
        public Shift NeededShift { get { return NeededShift; } }

       

        public NeededStaff(Occaption occaption, Shift neededShift)
        {
            this.occaption = occaption;
            this.neededShift = neededShift;
        }
    }
}
