using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventWorld.Data.Entities
{
    public class Event
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public long CreatorUserId { get; set; }

        [Required]
        public virtual long EventTypeId { get; set; }

        public virtual EventType EventType { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int AgeRequired { get; set; }

        [Required]
        public bool IsApproved { get; set; }

        [Required]
        public bool Deleted { get; set; }

        public virtual ICollection<EventGuest> EventGuests { get; set; }
    }
}
