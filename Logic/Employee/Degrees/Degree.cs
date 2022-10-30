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
        private DateTime obtainedDate;
        private string instition;
        private int degreeLevel;

        //properties (getters and setters)
        public string NameOfDegree { get { return nameOfDegree; } }
        public int DegreeLevel { get { return degreeLevel; } }


        public Degree(string nameOfDegree, DateTime obtainedDate, string instition, int degreeLevel)
        {
            this.nameOfDegree = nameOfDegree;
            this.obtainedDate = obtainedDate;
            this.instition = instition;
            this.degreeLevel = degreeLevel;
        }

        public Degree(string nameOfDegree, DateTime obtainedDate, int degreeLevel)
        {
            this.nameOfDegree = nameOfDegree;
            this.obtainedDate= obtainedDate;
            this.degreeLevel = degreeLevel;
        }
    }
}
