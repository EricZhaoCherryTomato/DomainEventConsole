using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DomainEventConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
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

    public class AppointmentSchedulingService
    {
        private readonly Repository<Appointment> _apptRepository = new Repository<Appointment>();


        public void ScheduleAppointment(string email, DateTime appointmentTime)
        {
            var appointment = Appointment.Create(email);
            _apptRepository.Save(appointment);
        }
    }

    public class Appointment : IEntity
    {
        public Appointment():this(Guid.NewGuid())
        {
        }

        public Appointment(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
        public DateTime? ConfirmationReceivedDate { get; private set; }

        public static Appointment Create(string emailAddress)
        {
            Console.WriteLine("Appointment::Create()");
            var appointment = new Appointment {EmailAddress = emailAddress};
            return appointment;
        }

        public void Confirm(DateTime dateConfirmed)
        {
            ConfirmationReceivedDate = dateConfirmed;
        }

        public string EmailAddress { get; set; }
    }

    public interface IRepository<TEntity> where TEntity : IEntity
    {
        TEntity GetById(Guid id);
        IList<TEntity> GetAll<TEntity>();
        void Save(TEntity entity);
    }

    public interface IEntity
    {
        Guid Id { get; }
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        private readonly Dictionary<Guid, TEntity> entities = new Dictionary<Guid, TEntity>();
        public TEntity GetById(Guid id)
        {
            return entities[id];
        }

        public IList<TEntity> GetAll<TEntity>()
        {
            return (IList<TEntity>)entities.Values.ToList();
        }

        public void Save(TEntity entity)
        {
            entities[entity.Id] = entity;
            ConsoleWriter.FromRepositories("[DATABASE] Saved entity {0}", entity.Id.ToString());
        }
    }

    public static class ConsoleWriter
    {
        public static void FromUIEventHandlers(string message, params string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message, args);
            Console.ResetColor();
        }

        public static void FromEmailEventHandlers(string message, params string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message, args);
            Console.ResetColor();
        }

        public static void FromRepositories(string message, params string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message, args);
            Console.ResetColor();
        }
    }
}