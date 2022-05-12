namespace NoMoreYoyo.Helpers
{
    public class SessionVariables
    {
        private static string session_UserName = "username";
        private static string session_Email = "email";
        private static string session_IsAuthenticated = "authenticated";

        public static string Session_UserName { get => session_UserName; set => session_UserName = value; }
        public static string Session_Email { get => session_Email; set => session_Email = value; }
        public static string Session_IsAuthenticated { get => session_IsAuthenticated; set => session_IsAuthenticated = value; }
    }
}
