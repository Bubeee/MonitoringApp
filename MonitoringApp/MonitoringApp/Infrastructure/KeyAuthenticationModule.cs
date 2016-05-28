namespace MonitoringApp.Infrastructure
{
    public class KeyAuthenticationModule : IAuthenticationModule
    {
        public bool Authenticate()
        {
            return true;
        }
    }
}