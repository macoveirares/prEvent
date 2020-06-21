using System;

namespace EventWorld.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Rating { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsEventAdmin { get; set; }

    }
}
