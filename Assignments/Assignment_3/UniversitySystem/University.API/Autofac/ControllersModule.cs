using Autofac;

namespace University.API.Autofac
{
    public class ControllersModule :  Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
            .Where(t => t.Name.EndsWith("Controller"))
            .PropertiesAutowired();
        }
    }
}
