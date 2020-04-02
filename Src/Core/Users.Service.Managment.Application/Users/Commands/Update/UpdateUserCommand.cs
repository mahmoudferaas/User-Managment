using System;
using System.Collections.Generic;
using BaseClasses.Core.Serializations.Api;
using MediatR;
using Users.Service.Managment.Domain.Entities;

namespace Users.Service.Managment.Application.Users.Commands.Update
{
    public class UpdateUserCommand : RequestDetails , IRequest<Guid> 
    {
        public Guid? Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string CountryIsoCode { get; set; }
        public string Image { get; set; }
        public Guid ParentUserId { get; set; }
        public bool IsActive { get; set; }
        public string ExternalLoginId { get; set; }
        public string SecurityStamp { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public int AccessFailedCount { get; set; }
        public bool CanUseCoupon { get; set; } = true;
        public decimal DisplayMarkup { get; set; } = new decimal();
        public User ParentUser { get; set; }
        public virtual ICollection<User> SubUsers { get; set; }
        public virtual ICollection<UserPointsRedeemPlan> UserPointsRedeemPlans { get; set; }
        public virtual ICollection<UserMarkupPlan> UserMarkupPlans { get; set; }
        public virtual ICollection<UserCreditCard> UserCreditCards { get; set; }

    }
}
