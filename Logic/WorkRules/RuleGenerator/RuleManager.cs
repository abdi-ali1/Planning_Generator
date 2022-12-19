using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.Generator
{
    internal static class RuleManager
    {

        public static IEnumerable<IWorkRule> GetLoadableTypes()
        {
            Type ti = typeof(IWorkRule);
            List<IWorkRule> workRules = new List<IWorkRule>();

            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type t in asm.GetTypes())
                {
                    if (ti.IsAssignableFrom(t))
                    {
                        workRules.Add((IWorkRule)t);
                    }
                }
            }

            return workRules;
        }
    }
}
