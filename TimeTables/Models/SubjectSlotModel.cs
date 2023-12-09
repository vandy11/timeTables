namespace TimeTables.Models
{
    public class SubjectSlotModel
    {
        public SubjectSlotModel(string subject, int slotPerWeek)
        {
            Subject = subject;
            SlotPerWeek = slotPerWeek;
        }

        public string Subject { get; set; } = null!;
        public int SlotPerWeek { get; set; }
    }
}
