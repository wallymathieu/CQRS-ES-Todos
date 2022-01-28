using Autofac;
using AutoMapper;

namespace Web.UI.Injection.Installers
{
    public class MappersInstaller : Module 
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(di => Mapper.Engine).As<IMappingEngine>();
            base.Load(builder);
        }
    }
}