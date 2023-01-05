using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logic.System.Generator
{
    internal class RuleManager
    {
      /*  public static IEnumerable<IWorkRuleSchedule> GetLoadableTypes()
        {
            Type ti = typeof(IWorkRuleSchedule);
            List<IWorkRuleSchedule> workRules = new List<IWorkRuleSchedule>();

            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type t in asm.GetTypes())
                {
                    if (ti.IsAssignableFrom(t))
                    {
                        workRules.Add((IWorkRuleSchedule)t);
                    }
                }
            }
            return workRules;
        }*/

        public IList<IWorkRuleSchedule> CreateWorkRules(List<Type> workRulesTypes, List<object[]> constructorParams)
        {
            // Create a list of shapes
            List<IWorkRuleSchedule> workRules = new List<IWorkRuleSchedule>();
            for (int i = 0; i < workRulesTypes.Count; i++)
            {
                Type workruleType = workRulesTypes[i];
                object[] parameters = constructorParams[i];

                // Find the correct constructor using reflection
                ConstructorInfo constructor = workruleType.GetConstructor(GetTypes(parameters));
                IWorkRuleSchedule workRule = (IWorkRuleSchedule)constructor.Invoke(parameters);
                workRules.Add(workRule);
            }

            return workRules;
        }

        private Type[] GetTypes(object[] objects)
        {
            Type[] types = new Type[objects.Length];
            for (int i = 0; i < objects.Length; i++)
            {
                types[i] = objects[i].GetType();
            }
            return types;
        }


    }
}
