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

        // Be emplemanted later on
        private int degreeLevel;
        private int reviewScore;

        public Occaption Occaption { get { return occaption; } }
        public Shift NeededShift { get { return NeededShift; } }
        public int DegreeLevel { get { return degreeLevel; } }


       

        public NeededStaff(Occaption occaption, Shift neededShift, int degreelevel)
        {
            this.occaption = occaption;
            this.neededShift = neededShift;
            this.degreeLevel = degreelevel;
        }


    }
}
