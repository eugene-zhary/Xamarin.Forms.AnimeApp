namespace Anime
{
    using SimpleInjector;

    public static class DependencyContainer
    {
        public static Container Instance { get; } = new Container();
    }
}
