namespace TimeTables.Models
{
    public class TeacherSupportModel
    {
        public string Teacher { get; set; } = null!;
        public List<TeacherSupportLevel> TeacherSupportLevels { get; set; } = new List<TeacherSupportLevel>();

    }
    public class TeacherSupportLevel
    {
        public int Level { get; set; }
        public List<TeacherSupportSubject> TeacherSupportSubjects { get; set; } = new List<TeacherSupportSubject>();

    }

    public class TeacherSupportSubject
    {
        public string Subject { get; set; } = null!;
        public int SlotAvailable { get; set; }
        public int SlotRemain { get; set; }
    }
}
