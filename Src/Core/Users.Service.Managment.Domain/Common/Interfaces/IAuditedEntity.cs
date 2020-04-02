using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Service.Managment.Domain.Common.Interfaces
{
    public interface IAuditedEntity : ICreationAuditedEntity
    {
        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedOn { get; set; }
    }
}
