using Logic.Employee;

namespace Logic.WorkRules
{
    public abstract class WorkRule : IWorkRuleSchedule
    {
        protected StaffMember staffMember;

        public WorkRule(StaffMember staffMember)
        {
            this.staffMember = staffMember;
        }

        public abstract bool IsRuleAdhered();
    }
}
