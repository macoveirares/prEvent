using System;

namespace EventWorld.DTO
{
    public class MessageDTO
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public UserDTO User { get; set; }

        public long EventId { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}
