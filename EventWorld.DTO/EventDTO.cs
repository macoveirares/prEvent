using System;

namespace EventWorld.DTO
{
    public class EventDTO
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public long EventTypeId { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public int AgeRequired { get; set; }
    }
}
