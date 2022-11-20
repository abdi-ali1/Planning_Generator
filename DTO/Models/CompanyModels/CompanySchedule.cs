using DTO.Models.StaffMemberModels;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models.CompanyModels
{
    public class CompanySchedule
    {
        private int id;
        private DateTime currentWeek;
        private List<StaffMember> AllStaffMembers = new();

        public int Id { get => id; }
        public DateTime CurrentWeek { get => currentWeek; }
        public List<StaffMember> AllStaffMembers1 { get => AllStaffMembers; }


        public CompanySchedule(int id, DateTime currentWeek, List<StaffMember> allStaffMembers)
        {
            this.id = id;
            this.currentWeek = currentWeek;
            AllStaffMembers = allStaffMembers;
        }

     
    }
}
