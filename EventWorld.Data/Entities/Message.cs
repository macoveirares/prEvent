using System;
using System.ComponentModel.DataAnnotations;

namespace EventWorld.Data.Entities
{

    public class Message
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public virtual long UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public virtual long EventId { get; set; }

        public virtual Event Event { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
