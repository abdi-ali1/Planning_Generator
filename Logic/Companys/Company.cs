using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Companys
{
    public class Company
    {
        private string name;
        private DateTime addedTime;
    

       

        public string Name { get { return name; } }

        public Company(string name, DateTime addedTime)
        {
            this.name = name;
            this.addedTime = addedTime;
        }
    }
}
