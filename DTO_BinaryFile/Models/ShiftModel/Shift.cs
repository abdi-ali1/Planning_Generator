using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_BinaryFile
{
    [Serializable]
    public class Shift
    {
        private int day;
        private int kindOfShift;

        public int Day { get { return day; } }
        public int KindOfShift { get { return kindOfShift; } }


        public Shift(int day, int kindOfShift)
        {
            this.day = day;
            this.kindOfShift = kindOfShift;
        }

        private Shift()
        {

        }

    }
}
