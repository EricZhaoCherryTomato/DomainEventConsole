using System;
using Autofac;
using Autofac.Builder;

namespace DomainEventConsoleApp
{
    public static class IoC
    {
        public static IContainer LetThereBeIoC(ContainerBuildOptions containerBuildOptions = ContainerBuildOptions.None)
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(AppDomain.CurrentDomain.GetAssemblies());
            return builder.Build(containerBuildOptions);
        }
    }
}