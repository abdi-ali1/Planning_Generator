﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Companys.Request
{
    public class WeeklyNeed
    {
        // fields
        private DateTime weekNeeded;
        private List<NeededStaff> neededStaff = new();

        // properties
        public DateTime WeekNeeded { get { return weekNeeded; } }
        public List<NeededStaff> NeededStaff { get { return neededStaff; } }
        
        // constructors
        public WeeklyNeed(DateTime weekNeeded, List<NeededStaff> neededStaff)
        {
            this.weekNeeded = weekNeeded;
            this.neededStaff = neededStaff;
        }
        public WeeklyNeed(DateTime weekNeeded, NeededStaff neededStaff)
        {
            this.weekNeeded = weekNeeded;
            this.neededStaff.Add(neededStaff);
        }
    }
}