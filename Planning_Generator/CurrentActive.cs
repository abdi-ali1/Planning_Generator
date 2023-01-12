namespace Planning_Generator
{
    public static class CurrentActive<T>
    {
        private static T? _currentActive;

        /// <summary>
        /// Gets a value indicating whether the current active value is not null.
        /// </summary>
        /// <returns>true if the current active value is not null; otherwise, false.</returns>
        public static bool IsLoggedIn
        {
            get { return (_currentActive is not null); }
        }

        /// <summary>
        /// Gets or sets the current active value.
        /// </summary>
        /// <returns>The current active value.</returns>
        public static T? Current
        {
            get { return _currentActive; }
            set { _currentActive = value; }
        }
    }
}
