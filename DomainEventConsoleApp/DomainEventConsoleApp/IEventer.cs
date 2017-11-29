using System.Threading.Tasks;

namespace DomainEventConsoleApp
{
    public interface IEventer
    {
        Task Raise<T>(T args) where T : IEvent;
    }
}