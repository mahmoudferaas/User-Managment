using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Users.Service.Managment.Application.Common.Dtos
{
    public class UserCreditCardDto
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "userid")]
        public string UserId { get; set; }

        [DataMember(Name = "cardnumber")]
        public string CardNumber { get; set; }

        [DataMember(Name = "carddisplaynumber")]
        public string CardDisplayNumber { get; set; }

        [DataMember(Name = "cardholdername")]
        public string CardHolderName { get; set; }

        [DataMember(Name = "expirydate")]
        public string ExpiryDate { get; set; }
    }
}
