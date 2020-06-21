using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventWorld.Data.Entities
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public bool IsEventAdmin { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public virtual ICollection<EventGuest> EventGuests { get; set; }
    }
}
