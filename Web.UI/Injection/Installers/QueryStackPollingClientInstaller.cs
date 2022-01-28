using Autofac;

namespace Web.UI.Injection.Installers
{
    public class QueryStackPollingClientInstaller : Module 
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Lazy Dependencies
            //builder.RegisterType<LazyOfTComponentLoader>().As<ILazyComponentLoader>();
            //container.Register(Component.For<ILazyComponentLoader>().ImplementedBy<LazyOfTComponentLoader>());
            //DI Registration for isolated-thread PollingClient
            /*container.Register(Component.For<ICheckpointRepository>().ImplementedBy<CheckpointRepository>());
            container.Register(Component.For<IObserver<ICommit>>().ImplementedBy<ReadModelCommitObserver>());
            container.Register(Component.For<EventObserverSubscriptionFactory>().LifeStyle.Transient);
            container.Register(Component.For<IObserveCommits>().UsingFactoryMethod(() => container.Resolve<EventObserverSubscriptionFactory>().Construct()));
            container.Register(Component.For<IPipelineHook>().ImplementedBy<LowLatencyPollingPipelineHook>().LifeStyle.Singleton);
            // Thread isolated pollingClient starter
            container.Register(Component.For<CommitObserverStarter>());*/
        }
    }
}