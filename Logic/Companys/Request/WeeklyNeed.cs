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
            
        
        public void AddNeededStaff(NeededStaff needed)
        {
            neededStaff.Add(needed);
        }
    }
}
