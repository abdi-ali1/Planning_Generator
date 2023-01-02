using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Employee.Degrees
{
    [Serializable]
    public class Degree
    {
        // fields
        private string nameOfDegree;
        private int degreeLevel;

    
        //properties (getters and setters)
        public string NameOfDegree { get { return nameOfDegree; } }
        public int DegreeLevel { get { return degreeLevel; } }

   
        public Degree(string nameOfDegree, int degreeLevel)
        {
            this.nameOfDegree = nameOfDegree;
            this.degreeLevel = degreeLevel;
        }


        public override bool Equals(object? obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Degree degree =  (Degree)obj;
            return (degree.nameOfDegree == nameOfDegree && degree.degreeLevel == degreeLevel);
        }


    }
}
