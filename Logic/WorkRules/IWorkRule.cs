using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTest_Pl")]
namespace Logic
{
    public interface IWorkRuleSchedule
    {
        public bool IsRuleAdhered();
    }
}
