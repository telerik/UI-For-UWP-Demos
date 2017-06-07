namespace QSF.Model
{
    /// <summary>
    /// Holds various enums for the model.
    /// </summary>
	public static class Enums
	{
        /// <summary>
        /// Status of the example/control
        /// </summary>
		public enum StatusMode
		{
			Normal,
			New,
			Beta,
			Ctp,
			Updated,
            Universal,
			Obsolete
		}

        /// <summary>
        /// Type of the example - normal, theming, or something else.
        /// </summary>
		public enum ExampleType
		{
			Normal,
			Theming
		}

        /// <summary>
        /// Platform type of the example/control - UWP or WindowsUniversal.
        /// </summary>
        public enum PlatformType
        {
            UWP,
            WindowsUniversal
        }
    }
}
