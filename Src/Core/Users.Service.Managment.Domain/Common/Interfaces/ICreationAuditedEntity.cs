using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Service.Managment.Domain.Common.Interfaces
{
    public interface ICreationAuditedEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
