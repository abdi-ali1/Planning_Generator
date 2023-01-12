using Logic.Enum;
using Logic.Shifts;

namespace Logic.Companys.Request
{
    [Serializable]
    public class NeededStaff
    {
        private Occupation occupation;
        private Shift shift;
        private int degreeLevel;

        public Occupation Occaption
        {
            get { return occupation; }
        }
        public Shift NeededShift
        {
            get { return shift; }
        }
        public int DegreeLevel
        {
            get { return degreeLevel; }
        }

        public NeededStaff(Occupation occupation, Shift shift, int degreeLevel)
        {
            this.occupation = occupation;
            this.shift = shift;
            this.degreeLevel = degreeLevel;
        }
    }
}
