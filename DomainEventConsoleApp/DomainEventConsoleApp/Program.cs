using System;
using Autofac;

namespace DomainEventConsoleApp
{
    internal class Program
    {
        public static IContainer Container { get; set; }

        private static void Main()
        {
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