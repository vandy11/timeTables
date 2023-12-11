using TimeTables.Models;

namespace TimeTables.Extensions
{
    public static class AppExtensions
    {
        public static List<LevelTeachersModel> Clone(this List<LevelTeachersModel> levelTeachers)
        {
            if (levelTeachers == null) return new List<LevelTeachersModel>();

            List<LevelTeachersModel> result = new List<LevelTeachersModel>();

            foreach (var levelTeacher in levelTeachers)
            {
                result.Add(levelTeacher);
            }

            return result;

        }

        public static List<SubjectTimesModel> Clone(this List<SubjectTimesModel> subjectTimes)
        {
            if (subjectTimes == null) return new List<SubjectTimesModel>();

            List<SubjectTimesModel> result = new List<SubjectTimesModel>();

            foreach (var subjectTime in subjectTimes)
            {
                result.Add(subjectTime);
            }

            return result;

        }


        public static List<TeacherSupportModel> ToTeacherSlots(List<string> teachers, List<int> levels, List<LevelTeachersModel> levelTeachersModels, List<SubjectTimesModel> subjectTimes)
        {
            if (levelTeachersModels == null) return new List<TeacherSupportModel>();

            List<TeacherSupportModel> result = new List<TeacherSupportModel>();

            foreach (var teacher in teachers)
            {
                TeacherSupportModel teacherSupportModel = new TeacherSupportModel { Teacher = teacher };

                foreach (var level in levels)
                {
                    var byLevel = levelTeachersModels.FirstOrDefault(x => x.Level == level);
                    if(byLevel != null)
                    {
                        var byTeacher = byLevel.TeacherSubjects.FirstOrDefault(x => x.Teacher == teacher);
                        if(byTeacher != null)
                        {

                        }
                    }

                    teacherSupportModel.TeacherSupportLevels.Add(new TeacherSupportLevel
                    {
                        Level = level,
                        TeacherSupportSubjects = new List<TeacherSupportSubject>()
                    });
                }

                foreach (LevelTeachersModel levelTeachersModel in levelTeachersModels)
                {
                    TeacherSupportLevel teacherSupportLevel = new TeacherSupportLevel { Level = levelTeachersModel.Level };

                    foreach (var teacherSubject in levelTeachersModel.TeacherSubjects.Where(x => x.Teacher == teacher).SelectMany(x => x.Subjects))
                    {

                        //teacherSupportLevel.TeacherSupportSubjects.Add(new TeacherSupportSubject { Subject = teacherSubject.})
                    }

                }



                result.Add(teacherSupportModel);
            }

            return result;

        }
    }
}
