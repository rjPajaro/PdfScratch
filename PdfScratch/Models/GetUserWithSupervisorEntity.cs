namespace PdfScratch.Models
{
    public class GetUserWithSupervisorEntity
    {
        public int ID { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string Position { get; set; }

        public string SupervisorDisplayName { get; set; }

        public string SupervisorEmail { get; set; }

        public string SupervisorPosition { get; set; }
    }
}
