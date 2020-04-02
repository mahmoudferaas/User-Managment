using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Service.Managment.Domain.Common
{
    public class Entity : Entity<int> {}

    public class Entity<T>
    {
        public virtual T Id { get; set; }
    }
}
