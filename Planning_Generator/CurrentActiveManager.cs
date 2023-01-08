using Logic;
using Logic.Companys;
using Logic.Employee;
using System.Runtime.CompilerServices;

namespace Planning_Generator
{
    public static class CurrentActive<T>
    {
        private static T _currentActive;

        public static bool IsLoggedIn { get { return (_currentActive is not null); } }

        public static T Current
        {
            get { return _currentActive; }
            set { _currentActive = value; }
        }
    }
}
