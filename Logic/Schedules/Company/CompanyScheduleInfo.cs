using Logic.Employee;
using Logic.Shifts;

namespace Logic.Schedules.Company
{
    public class CompanyScheduleInfo
    {
        private StaffMember staffMember;
        private Shift shift;

        public StaffMember StaffMember { get { return staffMember; } }
        public Shift Shift { get { return shift; } }

        public CompanyScheduleInfo(StaffMember staffMember, Shift shift)
        {
            this.staffMember = staffMember;
            this.shift = shift;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object, otherwise false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            CompanyScheduleInfo info = (CompanyScheduleInfo)obj;
            return (staffMember.Equals(info.staffMember)) && (shift.Equals(info.shift));
        }
    }
}
