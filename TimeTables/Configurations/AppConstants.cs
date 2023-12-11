using TimeTables.Models;

namespace TimeTables.Configurations
{
    public static class AppConstants
    {
        public static List<DaySlotModel> daySlotModels = new()
        {
            new DaySlotModel
            {
                Day = DayOfWeek.Monday,
                slots =new List<string>{ "07:00-08:00", "08:00-09:00", "09:00-10:00", "10:00-11:00", "14:00-15:00", "15:00-16:00", "16:00-17:00"}
            },

            new DaySlotModel
            {
                Day = DayOfWeek.Tuesday,
                slots =new List<string>{ "07:00-08:00", "08:00-09:00", "09:00-10:00", "10:00-11:00", "14:00-15:00", "15:00-16:00", "16:00-17:00"}
            },
            new DaySlotModel
            {
                Day = DayOfWeek.Wednesday,
                slots =new List<string>{ "07:00-08:00", "08:00-09:00", "09:00-10:00", "10:00-11:00", "14:00-15:00", "15:00-16:00", "16:00-17:00"}
            },
            new DaySlotModel
            {
                Day = DayOfWeek.Thursday,
                slots =new List<string>{ "07:00-08:00", "08:00-09:00", "09:00-10:00", "10:00-11:00", "14:00-15:00", "15:00-16:00", "16:00-17:00"}
            },
            new DaySlotModel
            {
                Day = DayOfWeek.Friday,
                slots =new List<string>{ "07:00-08:00", "08:00-09:00", "09:00-10:00", "10:00-11:00", "14:00-15:00", "15:00-16:00", "16:00-17:00"}
            },
            new DaySlotModel
            {
                Day = DayOfWeek.Saturday,
                slots =new List<string>{ "07:00-08:00", "08:00-09:00", "09:00-10:00", "10:00-11:00"}
            },
            new DaySlotModel
            {
                Day = DayOfWeek.Sunday,
                slots =new List<string>{}
            }
        };

        //public static List<string> Levels = new List<string> { "7", "8", "9", "10", "11", "12" };
        public static List<LevelClassroomsModel> Levels = new List<LevelClassroomsModel>
        {
            new LevelClassroomsModel { Level = 7, ClassNames = new List<string>{"7A","7B","7C", "7D"}},
            new LevelClassroomsModel { Level = 8, ClassNames = new List<string>{"8A","8B","8C", "8D"}},
            new LevelClassroomsModel { Level = 9, ClassNames = new List<string>{"9A","9B","9C", "9D"}},
            new LevelClassroomsModel { Level = 10, ClassNames = new List<string>{"10A", "10B" }},
            new LevelClassroomsModel { Level = 11, ClassNames = new List<string>{"11A", "11B"}},
            new LevelClassroomsModel { Level = 12, ClassNames = new List<string>{"12A", "12B" }}
        };

        //public static List<SubjectSlotModel> subjectSlots = new List<SubjectSlotModel>
        //{
        //    new SubjectSlotModel(@"ភាសាខ្មែរ",6),
        //    new SubjectSlotModel(@"ភាសាបរទេស", 6),
        //    new SubjectSlotModel(@"គណិតវិទ្យា", 6),
        //    new SubjectSlotModel(@"ផែនដី បរិស្ថានវិទ្យា", 3),
        //    new SubjectSlotModel(@"គីមីវិទ្យា", 3),
        //    new SubjectSlotModel(@"រូបវិទ្យា", 3),
        //    new SubjectSlotModel(@"ជីវវិទ្យា", 2),
        //    new SubjectSlotModel(@"ប្រវត្តិវិទ្យា", 2),
        //    new SubjectSlotModel(@"ភូមិវិទ្យា", 2),
        //    new SubjectSlotModel(@"សីលធម៌ ពលរដ្ធ", 2),
        //    new SubjectSlotModel(@"គេហកិច្ច", 2),
        //    new SubjectSlotModel(@"សេដ្ធកិច្ច", 2),
        //    new SubjectSlotModel(@"បំណិនជីវិត", 2),
        //    new SubjectSlotModel(@"សិល្បៈ", 2),
        //    new SubjectSlotModel(@"កីឡា", 2),
        //    new SubjectSlotModel(@"សកម្មភាពពិសេស", 2)
        //};

        //public static List<LevelSubjectsModel> levelSubjects = new List<LevelSubjectsModel>
        //{
        //    new LevelSubjectsModel{ Level = 7 },
        //    new LevelSubjectsModel{ Level = 8 },
        //    new LevelSubjectsModel{ Level = 9 },
        //    new LevelSubjectsModel{ Level = 10 },
        //    new LevelSubjectsModel{ Level = 11 },
        //    new LevelSubjectsModel{ Level = 12 }

        //};

    }
}
