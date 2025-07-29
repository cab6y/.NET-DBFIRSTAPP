using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.common;
public abstract class BaseEntity
{
    public int Id { get; set; }

    private readonly List<BaseEvent> _domainEvents = new();


    public void AddDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

}