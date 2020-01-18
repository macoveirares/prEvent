﻿using System.ComponentModel.DataAnnotations;

namespace EventWorld.Data.Entities
{
    public class EventGuest
    {
        [Required]
        public virtual long EventId { get; set; }

        public virtual Event Event { get; set; }

        [Required]
        public virtual long UserId { get; set; }

        public virtual User User { get; set; }
    }
}
