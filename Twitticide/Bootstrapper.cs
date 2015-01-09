namespace Twitticide
{
    internal class Bootstrapper
    {
        public static void Initialise()
        {
            IOC.Initialize();
            IOC.Bind<ITwitterClient>().To<TwitterClient>().ScopeAsSingleton();

            IOC.Bind<TwitticideController>().To<TwitticideController>();
        }
    }
}