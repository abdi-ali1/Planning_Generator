using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Employee.Formules
{
    public class Age
    {
        private DateTime birthDate;


        public Age(DateTime birthDate)
        {
            this.birthDate = birthDate;
        }


        /// <summary>
        /// calculates and returns the current age
        /// </summary>
        /// <returns> the current age in round nummers</returns>
        public int GetCurrentAge()
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
