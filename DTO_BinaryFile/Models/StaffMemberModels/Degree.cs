using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_BinaryFile
{
    [Serializable]
    public class Degree
    {

        private string nameOfDegree;
        private int degreelevel;


        public string NameOfDegree { get => nameOfDegree; }
        public int Degreelevel { get => degreelevel; }

        public Degree( string nameOfDegree, int degreelevel)
        {

            this.nameOfDegree = nameOfDegree;
            this.degreelevel = degreelevel;
        }

        // for seralization
        private Degree()
        {

        }



    }
}
