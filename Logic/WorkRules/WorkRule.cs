using System.Runtime.CompilerServices;
using Logic.Employee;

[assembly: InternalsVisibleTo("UnitTest_Pl")]
namespace Logic
{
    internal abstract class WorkRule : IWorkRuleSchedule
    {
        protected StaffMember staffMember;

        public WorkRule(StaffMember staffMember)
        {
            this.staffMember = staffMember;
        }

        public abstract bool IsRuleAdhered();
    }
}
