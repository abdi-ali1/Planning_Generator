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

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object, otherwise false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Degree degree = (Degree)obj;
            return (degree.nameOfDegree == nameOfDegree && degree.degreeLevel == degreeLevel);
        }
    }
}
