
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_BinaryFile
{
    [Serializable]
    public class NeededStaff
    {
        private int occaption;
        private int neededShift;

        public int Occaption { get { return occaption; } }
        public int NeededShift { get { return NeededShift; } }

        public NeededStaff(int occaption, int neededShift)
        {
            this.occaption = occaption;
            this.neededShift = neededShift;
        }

        private  NeededStaff()
        {

        }

    }
}
