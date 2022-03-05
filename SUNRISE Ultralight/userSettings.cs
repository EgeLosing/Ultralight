namespace SUNRISE_Launcher_UltraLite
{
    public static class userSettings
    {
        private static string username;

        public static string setUsername
        {
            get { return username; }
            set { username = value; }
        }

        public static string getUsername
        {
            get { return username; }
        }
    }
}
