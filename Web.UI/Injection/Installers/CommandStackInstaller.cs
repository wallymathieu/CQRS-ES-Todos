using Autofac;
using FluentValidation;
using Todo.CommandStack.Logic.CommandHandlers;
using Todo.CommandStack.Logic.Validators;
using Todo.Infrastructure.Commands;

namespace Web.UI.Injection.Installers
{
    public class CommandStackInstaller : Module 
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ToDoListCommandHandlers).Assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>)) // That implement ICommandHandler Interface
                .SingleInstance();
            /*container.Register(
                Classes
                .FromAssemblyContaining<ToDoListCommandHandlers>()
                .BasedOn(typeof(ICommandHandler<>)) // That implement ICommandHandler Interface
                .WithService.Base() // and its name contain "CommandHandler" 
                .LifestyleSingleton()
                );*/
            builder.RegisterAssemblyTypes(typeof(CreateToDoListCommandValidator).Assembly)
                .AsClosedTypesOf(typeof(IValidator<>)) // That implement IValidator Interface
                .SingleInstance(); 
            /*container.Register(
                Classes
                .FromAssemblyContaining<CreateToDoListCommandValidator>()
                .BasedOn(typeof(IValidator<>)) // That implement IValidator Interface
                .WithService.Base()    // and its name contain "Validator"
                .LifestyleSingleton()
                );*/

            //builder.RegisterGeneratedFactory()
                
            // DI Registration for Typed Factory for Command and Event Handlers
            /*container.AddFacility<TypedFactoryFacility>()
                .Register(Component.For<ICommandHandlerFactory>().AsFactory())
                .Register(Component.For<ICommandValidatorFactory>().AsFactory())
                .Register(Component.For<IEventHandlerFactory>().AsFactory());*/
        }
    }


}