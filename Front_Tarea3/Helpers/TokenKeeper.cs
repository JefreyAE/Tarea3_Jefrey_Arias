namespace Front_Tarea3.Helpers
{
    public sealed class TokenKeeper
    {
        private static string _token;

        private TokenKeeper()
        {

        }

        public static string Token
        {
            get { return _token; }
            set { _token = value; }
        }
    }
}
