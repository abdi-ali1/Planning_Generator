
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models.CompanyModels
{
    public class NeededStaff
    {
        private int id;
        private int occaption;
        private int neededShift;

        public int Occaption { get { return occaption; } }
        public int NeededShift { get { return NeededShift; } }
        public int Id { get { return id; } }



        public NeededStaff(int id,int occaption, int neededShift)
        {
            this.id = id;
            this.occaption = occaption;
            this.neededShift = neededShift;
        }

    }
}
