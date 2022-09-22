using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TrialsSystem.UsersService.Domain.AggregatesModel.Base
{
    public abstract class Entity
    {
        [NotMapped]
        private List<INotification> _domainEvents;

        [NotMapped]
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        [Key]
        public Guid Id { get; protected set; }
        public bool IsDeleted { get; protected set; }

        public DateTime CreatedDate { get; protected set; }

        public DateTime LastModifiedDate { get; protected set; }

    }
}
