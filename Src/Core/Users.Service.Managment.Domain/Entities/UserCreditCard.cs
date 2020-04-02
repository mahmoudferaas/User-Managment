using System;
using Users.Service.Managment.Domain.Common;

namespace Users.Service.Managment.Domain.Entities
{
    public class UserCreditCard : Entity<long>
    {
        public Guid UserId { get; set; }

        public string CardNumber { get; set; }

        public string CardDisplayNumber { get; set; }

        public string CardHolderName { get; set; }

        public string ExpiryDate { get; set; }

        public virtual User User { get; set; }
    }
}
