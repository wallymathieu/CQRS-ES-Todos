using Autofac;
using Todo.Infrastructure.Events;
using Todo.Infrastructure.Events.Rebuilding;
using Todo.QueryStack;
using Todo.QueryStack.Logic.EventHandlers;
using Todo.QueryStack.Logic.Services;

namespace Web.UI.Injection.Installers
{
    public class QueryStackInstaller : Module 
    {
        //public void Install(IWindsorContainer container, IConfigurationStore store)
        protected override void Load(ContainerBuilder builder)
        {
            // QueryStack Event Handlers Registration
            builder.RegisterAssemblyTypes(typeof(ToDoEventHandlers).Assembly)
                .AsClosedTypesOf(typeof(IEventHandler<>)) // That implement IEventHandler Interface
                .SingleInstance();
            /*container.Register(
                Classes
                .FromAssemblyContaining<ToDoEventHandlers>()
                .BasedOn(typeof(IEventHandler<>)) // That implement ICommandHandler Interface
                .WithService.Base()    // and its name contain "CommandHandler"
                .LifestyleSingleton()
                );*/

            // DI Registration for IDatabase (QueryStack)
            builder.RegisterType<Database>().As<IDatabase>();
            //container.Register(Component.For<IDatabase>().ImplementedBy<Database>().LifestyleTransient());
            builder.RegisterType<IdentityMapper>().As<IIdentityMapper>();
            //container.Register(Component.For<IIdentityMapper>().ImplementedBy<IdentityMapper>().LifestyleTransient());
            // DI for SignalR Notifier service
            
            /*container.Register(Component.For<IEventNotifier>().ImplementedBy<EventNotifier>().LifestyleSingleton()
                .DependsOn(Dependency.OnValue<IHubConnectionContext<dynamic>>(GlobalHost.ConnectionManager.GetHubContext<NotifierHub>().Clients)));*/

            // DI Registration for Events Rebuilding
            builder.RegisterType<EventsRebuilder>().As<IEventsRebuilder>();
            //container.Register(Component.For<IEventsRebuilder>().ImplementedBy<EventsRebuilder>().LifestyleTransient());
        }
    }
}