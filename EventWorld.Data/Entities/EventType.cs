using System.ComponentModel.DataAnnotations;

namespace EventWorld.Data.Entities
{
    public class EventType
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImagePath { get; set; }
    }
}
