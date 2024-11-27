namespace PdfScratch.Models
{
    public class QuarterEntity
    {
        public int Quarter { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Guid TenantId { get; set; }

        public string Year { get; set; }

        public string QuarterStatus { get; set; }
    }
}
