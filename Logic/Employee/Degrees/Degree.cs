using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Employee.Degrees
{
    public class Degree
    {
        // fields
        private string nameOfDegree;
        private int degreeLevel;

    
        //properties (getters and setters)
        public string NameOfDegree { get { return nameOfDegree; } }
        public int DegreeLevel { get { return degreeLevel; } }

        /// <summary>
        /// constructor sets the private fields
        /// </summary>
        /// <param name="nameOfDegree"></param>
        /// <param name="degreeLevel"></param>
        public Degree(string nameOfDegree, int degreeLevel)
        {
            this.nameOfDegree = nameOfDegree;
            this.degreeLevel = degreeLevel;
        }


    }
}
