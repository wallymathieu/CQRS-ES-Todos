using Autofac;
using Autofac.Core;
using Todo.Legacy.Migration.Infrastructure;
using Todo.Legacy.Migration.Logic;
using Todo.Legacy.Migration.Worker;
using Todo.QueryStack;

namespace Web.UI.Injection.Installers
{
    public class LegacyMigrationInstaller : Module 
    {
        //public void Install(IWindsorContainer container, IConfigurationStore store)
        protected override void Load(ContainerBuilder builder)
        {
            // DI Registration for IDatabase (Migration)
            builder.RegisterType<LegacyDatabase>().As<IDatabase>();
            //container.Register(Component.For<IDatabase>().ImplementedBy<LegacyDatabase>().LifestyleTransient());
            // DI Registration for Migration Manager, with dependy on specific IDatabase implementation for migration
            builder.RegisterType<LegacySnapshotCreator>().As<ILegacyMigrationManager>()
                .WithParameter(
                new ResolvedParameter(
                    (pi, ctx) => pi.ParameterType == typeof(IDatabase),
                    (pi, ctx) => ctx.Resolve<LegacyDatabase>()));
            /*container.Register(Component.For<ILegacyMigrationManager>().ImplementedBy<LegacySnapshotCreator>().LifestyleTransient()
                .DependsOn(Dependency.OnComponent<IDatabase, LegacyDatabase>())); */
            // Register Worker Services
            builder.RegisterType<LegacyMigrationWorker>();
            //container.Register(Component.For<LegacyMigrationWorker>().LifeStyle.Transient);

        }
    }
}