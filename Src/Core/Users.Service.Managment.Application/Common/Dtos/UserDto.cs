using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Users.Service.Managment.Application.Common.Dtos
{
    public class UserDto
    {

        public string UserId { get; set; } = Guid.NewGuid().ToString();
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string CountryIsoCode { get; set; }
        public string Image { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public int AccessFailedCount { get; set; }
        public List<UserMarkupPlanDto> MarkupPlans { get; set; }
        public List<UserPointsRedeemPlanDto> PointsRedeemPlans { get; set; }
        public bool CanUseCoupon { get; set; } = true;
        public decimal DisplayMarkup { get; set; } = new decimal();
    }
}
