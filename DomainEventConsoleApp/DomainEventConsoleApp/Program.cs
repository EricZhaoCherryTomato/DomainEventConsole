using System;
using System.Linq;
using Autofac;
using Autofac.Core;

namespace DomainEventConsoleApp
{
    internal class Program
    {
        public static IContainer Container { get; set; }

        private static void Main()
        {
            //var container = IoC.LetThereBeIoC();


            //var builder = new ContainerBuilder();
            //var asm = Assembly.GetExecutingAssembly();
            //var handlerType = typeof(IHandleDomainEvents<>);

            //builder.RegisterAssemblyTypes(asm)
            //    .AsClosedTypesOf(handlerType)
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<EventDispatcher>()
            //    .As<IEventDispatcher>()
            //    .InstancePerLifetimeScope();           


            //var builder = new ContainerBuilder();


            //Func<Type, bool> predicate = n => n.GetGenericTypeDefinition() == typeof(IEventHandles<>);

            //var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            //var classes = assemblies
            //    .SelectMany(n => n.GetTypes())
            //    .ToArray();

            //var handlerClasses = classes
            //    .Where(n =>
            //        n.GetInterfaces()
            //            .Where(i => i.IsGenericType)
            //            .Any(predicate))
            //    .Select(n => new
            //    {
            //        Type = n,
            //        HandlerTypes = n.GetInterfaces().Where(i => i.IsGenericType).Where(predicate).ToArray()
            //    })
            //    .ToArray();

            //foreach (var handlerClass in handlerClasses)
            //{
            //    foreach (var handler in handlerClass.HandlerTypes)
            //    {
            //        var hc = handlerClass;
            //        builder.Register(c => c.Resolve(hc.Type)).As(handler);
            //    }
            //}

            //Container = builder.Build();

            Console.WriteLine("Starting application.");

            var service = new AppointmentSchedulingService();
            service.ScheduleAppointment("test@example.com", DateTime.Now);

            Console.WriteLine("Creating an appointment.");
            var appointment = Appointment.Create("steve@test2.com");
            Console.WriteLine("Confirming an appointment.");
            appointment.Confirm(DateTime.Now);

            Console.WriteLine("Application done.");
            Console.ReadLine();

        }
    }
}