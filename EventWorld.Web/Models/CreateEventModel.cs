using System;
using System.ComponentModel.DataAnnotations;

namespace EventWorld.Web.Models
{
    public class CreateEventModel
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(50)]
        public string Description { get; set; }

        public long CreatorUserId { get; set; }

        [Required]
        public long EventTypeId { get; set; }

        public EventTypeModel EventType { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int AgeRequired { get; set; }

        public bool IsApproved { get; set; }
    }
}
