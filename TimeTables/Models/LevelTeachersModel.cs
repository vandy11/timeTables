namespace TimeTables.Models
{
    public class LevelTeachersModel
    {
        public int Level { get; set; }
        
        public List<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();

        //public List<TeacherSubjectMapping> TeacherSubjects { get; set; } = new List<TeacherSubjectMapping>();
    }

    public class TeacherSubject
    {
        public string Teacher { get; set; } = null!;
        public List<string> Subjects { get; set; } = new List<string>();

    }
}
