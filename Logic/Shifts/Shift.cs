﻿using Logic.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOfWeek = Logic.Enum.DayOfWeek;

namespace Logic.Shifts
{
    [Serializable]
    public class Shift
    {
        private DayOfWeek day;
        private ShiftHour kindOfShift;

        public DayOfWeek Day { get { return day; } }
        public ShiftHour KindOfShift { get { return kindOfShift; } }


        public Shift(DayOfWeek day, ShiftHour kindOfShift)
        {
            this.day = day;
            this.kindOfShift = kindOfShift;
        }
    }
}
