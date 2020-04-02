using System;
using Users.Service.Managment.Domain.Exceptions;

namespace Users.Service.Managment.Domain.ValueObjects
{
    public class RoomDescription
    {

        private RoomDescription()
        {

        }

        public static RoomDescription For(string description)
        {
            var account = new RoomDescription();

            try
            {
                var items = description.Split("-");
                account.Name = items[0];
                account.Type = items[1];
                account.Category = items[2];
                account.View = items[3];
            }
            catch (Exception ex)
            {
                throw new RoomDescriptionInvalidException(description, ex);
            }

            return account;
        }

        public string Name { get; set; }

        public string  Type { get; set; }

        public string Category { get; set; }

        public string View { get; set; }


        public static implicit operator string(RoomDescription desc)
        {
            return desc.ToString();
        }

        public static explicit operator RoomDescription(string desc)
        {
            return For(desc);
        }

        public override string ToString()
        {
            return $"{Name}-{Type}-{Category}-{View}";
        }
    }
}
