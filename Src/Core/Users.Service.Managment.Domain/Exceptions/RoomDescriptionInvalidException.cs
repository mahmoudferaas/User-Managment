using System;

namespace Users.Service.Managment.Domain.Exceptions
{
    public class RoomDescriptionInvalidException : Exception
    {
        public RoomDescriptionInvalidException(string description, Exception ex)
            : base($"Invalid {description}", ex)
        {

        }
    }
}
