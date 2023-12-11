namespace TimeTables.Models
{
    public class SubjectTimesModel
    {
        public int Level { get; set; }
        public List<SubjectSlot> SubjectSlots { get; set; } = new List<SubjectSlot>();
    }
    
    public class SubjectSlot
    {
        public string Subject { get; set; } = null!;
        public int SlotPerWeek { get; set; }
    }
}
