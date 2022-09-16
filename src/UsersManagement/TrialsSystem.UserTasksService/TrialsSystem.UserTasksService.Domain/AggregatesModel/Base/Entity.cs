using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TrialsSystem.UserTasksService.Domain.AggregatesModel.Base
{
    public abstract class Entity
    {
        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public string Id { get; protected set; }
        public bool IsDeleted { get; protected set; }

        public DateTime CreatedDate { get; protected set; }
        public string CreatedBy { get; protected set; }

        public DateTime LastModifiedDateDate { get; protected set; }

    }
}
