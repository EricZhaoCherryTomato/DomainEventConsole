using System;

namespace DomainEventConsoleApp
{
    public class AppointmentSchedulingService
    {
        private readonly Repository<Appointment> _apptRepository = new Repository<Appointment>();


        public void ScheduleAppointment(string email, DateTime appointmentTime)
        {
            var appointment = Appointment.Create(email);
            _apptRepository.Save(appointment);
        }
    }
}