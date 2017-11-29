namespace DomainEventConsoleApp
{
    public interface IEventHandles<T> where T : IEvent
    {
        void Handle(T args);
    }
}