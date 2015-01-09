namespace Twitticide
{
    internal class Bootstrapper
    {
        public static void Initialise()
        {
            IOC.Bind<ITwitterClient>().To<TwitterClient>();
            IOC.Initialize();
        }
    }
}