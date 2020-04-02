using Users.Service.Managment.Domain.Common.Interfaces;
using System;

namespace Users.Service.Managment.Domain.Common
{
    public class AuditedEntity : AuditedEntity<int> {}

    public class AuditedEntity<T> : CreationAuditedEntity<T>, IAuditedEntity
    {
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }

    public class CreationAuditedEntity : CreationAuditedEntity<int> {}

    public class CreationAuditedEntity<T> : Entity<T>, ICreationAuditedEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }


}
