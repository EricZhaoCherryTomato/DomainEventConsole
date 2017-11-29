namespace DomainEventConsoleApp
{
    public class AppointmentSvc
    {
        private readonly IEventer _eventer;
        public AppointmentSvc(IEventer eventer)
        {
            _eventer = eventer;
        }

        public void Raise<T>(T job) where T : IEvent
        {
            _eventer.Raise(job);
        }
    }
}