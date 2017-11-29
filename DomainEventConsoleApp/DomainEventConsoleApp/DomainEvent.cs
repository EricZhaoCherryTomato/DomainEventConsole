using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

namespace DomainEventConsoleApp
{
    public static class DomainEvent
    {
        static DomainEvent()
        {
            Container = IoC.LetThereBeIoC();
        }

        private static IContainer Container { get; }

        public static Task Raise<T>(T args) where T : IEvent
        {
            var handlers = Container.Resolve<IEnumerable<IEventHandles<T>>>();
            var task = Task.Factory.StartNew(() => RaiseAction(handlers, args));
            return task;
        }

        private static void RaiseAction<T>(IEnumerable<IEventHandles<T>> handlers, T args) where T : IEvent
        {
            try
            {
                handlers.AsParallel().ForAll(handler => handler.Handle(args));
            }
            catch (Exception ex)
            {
                //log error
            }
        }
    }
}