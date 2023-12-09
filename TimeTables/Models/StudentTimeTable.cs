
namespace TimeTables.Models
{
    public class StudentTimeTable
    {
        public ClassroomModel Classroom { get; set; } = new ClassroomModel();
        public DaySlotMapping Monday { get; set; } = new DaySlotMapping();
        public DaySlotMapping Tuesday { get; set; } = new DaySlotMapping();
        public DaySlotMapping Wednesday { get; set; } = new DaySlotMapping();
        public DaySlotMapping Thursday { get; set; } = new DaySlotMapping();
        public DaySlotMapping Friday { get; set; } = new DaySlotMapping();
        public DaySlotMapping Saturday { get; set; } = new DaySlotMapping();
    }


    public class DaySlotMapping
    {
        public List<SubjectTimeSlot> SubjectTimeSlots { get; set; } = new List<SubjectTimeSlot>();
    }

    public class SubjectTimeSlot
    {
        public string Subject { get; set; } = null!;
        public string Teacher { get; set; } = null!;
        public string TimeSlot { get; set; } = null!;
    }

}
