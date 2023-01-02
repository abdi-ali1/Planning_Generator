using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Employee.Formules
{

    public class AgeCalculater
    {

        /// <summary>
        /// Calculates and returns the current age of a person based on their birth date.
        /// </summary>
        /// <param name="birthDate">The person's birth date.</param>
        /// <returns>An int value representing the person's current age, rounded to the nearest whole number.</returns>
        public static int GetCurrentAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;

            if (DateTime.Now.Month < birthDate.Month && DateTime.Now.Day < birthDate.Day)
            {
                age -= 1;
            }
            return age;
        }

    }
}
