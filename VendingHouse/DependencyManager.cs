using Autofac;
namespace VendingHouse
{
    public static class DependencyManager
    {
        private static IContainer container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // Register your dependencies here
            builder.RegisterType<IMediator>().As<PurchaseMediator>();

            container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
