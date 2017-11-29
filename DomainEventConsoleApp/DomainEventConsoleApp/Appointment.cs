using System;
using Autofac;

namespace DomainEventConsoleApp
{
    public class Appointment : IEntity
    {
        public Appointment():this(Guid.NewGuid())
        {
        }

        public Appointment(Guid id)
        {
            Id = id;
        }
        private readonly IEventer _eventer;

        
        public Guid Id { get; }
        public DateTime? ConfirmationReceivedDate { get; private set; }

        public static Appointment Create(string emailAddress)
        {
            Console.WriteLine("Appointment::Create()");
            var appointment = new Appointment {EmailAddress = emailAddress};
            DomainEvent.Raise(new AppointmentCreatedEvent());
            return appointment;
        }

        public void Confirm(DateTime dateConfirmed)
        {
            ConfirmationReceivedDate = dateConfirmed;
            ConsoleWriter.FromUIEventHandlers("[UI] User Interface informed appointment for {0} confirmed at {1}",
                EmailAddress,
                ConfirmationReceivedDate.ToString());
            
        }

        public string EmailAddress { get; set; }
    }
}