﻿using Logic.Employee;

namespace Logic.System.ModelManager
{
    public interface IStaffMemberModelManager
    {
        public IList<StaffMember> AllStaffMembers { get; }
        public bool AddNewStaff(StaffMember staffMember);
        public void SaveStaffMembers();
    }
}