using System;

namespace EventWorld.DTO
{
    public class EventDTO
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public long CreatorUserId { get; set; }

        public long EventTypeId { get; set; }

        public EventTypeDTO EventType { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public int AgeRequired { get; set; }

        public bool IsApproved { get; set; }
    }
}
