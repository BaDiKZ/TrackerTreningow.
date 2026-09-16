namespace TrackerTreningow
{
    public class Training
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; } = DateTime.Today;
        public string Type { get; set; } = "Inne";
        public int Minutes { get; set; }
        public string Note { get; set; } = "";
        public bool IsImportant { get; set; }
    }
}