namespace TimeTables.Models
{
    public class DaySlotModel
    {
        public DayOfWeek Day { get; set; }
        public List<string> slots { get; set; } = new List<string>();

    }
}
