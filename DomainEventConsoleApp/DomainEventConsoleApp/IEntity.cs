using System;

namespace DomainEventConsoleApp
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}