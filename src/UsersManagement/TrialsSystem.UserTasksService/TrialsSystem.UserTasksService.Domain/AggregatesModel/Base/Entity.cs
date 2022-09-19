using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrialsSystem.UserTasksService.Domain.AggregatesModel.Base
{
    public abstract class Entity
    {
        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public DateTime CreatedDateTime { get; protected set; }
        public DateTime LastUpdatedDateTime { get; protected set; }
        public string CreatedBy { get; protected set; }

    }
}
