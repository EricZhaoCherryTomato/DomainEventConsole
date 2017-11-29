namespace DomainEventConsoleApp
{
    public class AppointmentHanlder : IEventHandles<JobNoteCreated>
    {

        public void Handle(JobNoteCreated args)
        {
            ConsoleWriter.FromEmailEventHandlers("[EMAIL] Notification email sent to {0}", "Test1");
            ConsoleWriter.FromUIEventHandlers("[UI] User Interface informed appointment created for {0}", "Test2");
        }
    }
}