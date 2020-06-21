namespace EventWorld.Web.Models
{
    public class DetailsEventModel
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Date { get; set; }

        public string ImagePath { get; set; }

        public long CreatorUserId { get; set; }

        public int AgeRequired { get; set; }

        public bool IsApproved { get; set; }
    }
}
