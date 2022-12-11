using Logic.Companys.Request;


namespace Logic.System.Generator
{
    /// <summary>
    /// a heling static class calulets stuff for the generator
    /// </summary>
    internal static class GeneratorCalculator
    {

        public static int AmountOfNeededStaff(WeeklyNeed weeklyNeed)
        {
            int amount = weeklyNeed.NeededStaff.Count;

            return amount;
        }
    }
}
