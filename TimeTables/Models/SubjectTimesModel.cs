namespace TimeTables.Models
{
    public class SubjectTimesModel
    {
        public string Level { get; set; } = null!;
        public List<SubjectSlot> SubjectSlots { get; set; } = new List<SubjectSlot>();
    }
    
    public class SubjectSlot
    {
        public string Subject { get; set; } = null!;
        public int SlotPerWeek { get; set; }
    }
}
