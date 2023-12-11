using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using TimeTables.Configurations;
using TimeTables.Extensions;
using TimeTables.Models;

namespace TimeTables
{
    public partial class FormMain : Form
    {
        private List<string> teachers = new List<string>();
        private List<string> subjects = new List<string>();
        private List<int> levels = new List<int>();

        private List<DaySlotModel> _daySlots=new List<DaySlotModel>();
        public List<DaySlotModel> DaySlots
        {
            get
            {
                return _daySlots;
            }
            set
            {
                _daySlots = value;
                try
                {
                    var daySlotsStr = JsonConvert.SerializeObject(DaySlots);
                    var daySlotFile = Path.Combine(Application.StartupPath, "Data", "daySlots.json");

                    File.WriteAllText(daySlotFile, daySlotsStr);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private List<SubjectTimesModel> _subjectTimes =new List<SubjectTimesModel>();
        public List<SubjectTimesModel> SubjectTimes
        {
            get
            {
                return _subjectTimes;
            }
            set
            {
                _subjectTimes = value;
                try
                {
                    var levelSubjectsStr = JsonConvert.SerializeObject(SubjectTimes);
                    var levelSubjectsFile = Path.Combine(Application.StartupPath, "Data", "subjectTimes.json");

                    File.WriteAllText(levelSubjectsFile, levelSubjectsStr);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private List<LevelTeachersModel> _levelTeachers = new List<LevelTeachersModel>();
        public List<LevelTeachersModel> LevelTeachers
        {
            get { return _levelTeachers; }
            set
            {
                _levelTeachers = value;
                try
                {
                    var str = JsonConvert.SerializeObject(LevelTeachers);
                    var filePath = Path.Combine(Application.StartupPath, "Data", "levelTeachers.json");
                    File.WriteAllText(filePath, str);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private List<LevelClassroomsModel> _levelClassrooms =new List<LevelClassroomsModel>();
        public List<LevelClassroomsModel> LevelClassrooms
        {
            get
            {
                return _levelClassrooms;
            }
            set
            {
                _levelClassrooms = value;
                try
                {
                    var str = JsonConvert.SerializeObject(LevelClassrooms);
                    var filePath = Path.Combine(Application.StartupPath, "Data", "levelClassrooms.json");
                    File.WriteAllText(filePath, str);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        bool teachersChanged, subjectsChanged, levelsChanged;
        public FormMain()
        {
            InitializeComponent();

            #region Method In constructor

            List<string> TryLoadTeachersData()
            {
                var result = new List<string>();
                try
                {
                    var daySlotFile = Path.Combine(Application.StartupPath, "Data", "teachers.json");
                    if (File.Exists(daySlotFile))
                    {
                        var contentStr = File.ReadAllText(daySlotFile);
                        if (!string.IsNullOrEmpty(contentStr))
                        {
                            result = JsonConvert.DeserializeObject<List<string>>(contentStr);
                        }
                        else
                        {
                            result = new List<string>();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    result = new List<string>();
                }
                return result ?? new List<string>();

            }

            List<string> TryLoadSubjectsData()
            {
                var result = new List<string>();
                try
                {
                    var filePath = Path.Combine(Application.StartupPath, "Data", "subjects.json");
                    if (File.Exists(filePath))
                    {
                        var contentStr = File.ReadAllText(filePath);
                        if (!string.IsNullOrEmpty(contentStr))
                        {
                            result = JsonConvert.DeserializeObject<List<string>>(contentStr);
                        }
                        else
                        {
                            result = new List<string>();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    result = new List<string>();
                }
                return result ?? new List<string>();

            }

            List<int> TryLoadLevelsData()
            {
                var result = new List<int>();
                try
                {
                    var filePath = Path.Combine(Application.StartupPath, "Data", "levels.json");
                    if (File.Exists(filePath))
                    {
                        var contentStr = File.ReadAllText(filePath);
                        if (!string.IsNullOrEmpty(contentStr))
                        {
                            result = JsonConvert.DeserializeObject<List<int>>(contentStr);
                        }
                        else
                        {
                            result = new List<int>();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    result = new List<int>();
                }
                return result ?? new List<int>();

            }

            List<DaySlotModel> TryLoadDaySlotsData()
            {
                var daySlotModels = new List<DaySlotModel>();
                try
                {
                    var daySlotFile = Path.Combine(Application.StartupPath, "Data", "daySlots.json");
                    if (File.Exists(daySlotFile))
                    {
                        var contentStr = File.ReadAllText(daySlotFile);
                        if (!string.IsNullOrEmpty(contentStr))
                        {
                            daySlotModels = JsonConvert.DeserializeObject<List<DaySlotModel>>(contentStr);
                        }
                        else
                        {
                            daySlotModels = AppConstants.daySlotModels;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    daySlotModels = AppConstants.daySlotModels;
                }
                return daySlotModels ?? AppConstants.daySlotModels;
            }

            List<SubjectTimesModel> TryLoadSubjectTimes()
            {
                List<SubjectTimesModel> GetDefault()
                {
                    List<SubjectTimesModel> result = new List<SubjectTimesModel>();

                    foreach (var level in levels)
                    {
                        SubjectTimesModel levelSubjects = new SubjectTimesModel { Level = level };
                        result.Add(levelSubjects);
                    }
                    return result;
                }

                var levelSubjectsModels = new List<SubjectTimesModel>();
                try
                {
                    var filePath = Path.Combine(Application.StartupPath, "Data", "subjectTimes.json");
                    if (File.Exists(filePath))
                    {
                        var contentStr = File.ReadAllText(filePath);
                        if (!string.IsNullOrEmpty(contentStr))
                        {
                            levelSubjectsModels = JsonConvert.DeserializeObject<List<SubjectTimesModel>>(contentStr);
                        }
                        else
                        {
                            levelSubjectsModels = GetDefault();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    levelSubjectsModels = GetDefault();
                }

                return levelSubjectsModels ?? GetDefault();
            }

            List<LevelTeachersModel> TryLoadLevelTeachers()
            {
                List<LevelTeachersModel> GetDefault()
                {
                    List<LevelTeachersModel> result = new List<LevelTeachersModel>();

                    var level7 = new LevelTeachersModel { Level = 7 };

                    foreach (var teacher in teachers)
                    {
                        level7.TeacherSubjects.Add(new TeacherSubject { Teacher = teacher });
                    }
                    result.Add(level7);

                    var level8 = new LevelTeachersModel { Level = 8 };

                    foreach (var teacher in teachers)
                    {
                        level8.TeacherSubjects.Add(new TeacherSubject { Teacher = teacher });
                    }
                    result.Add(level8);

                    var level9 = new LevelTeachersModel { Level = 9 };

                    foreach (var teacher in teachers)
                    {
                        level9.TeacherSubjects.Add(new TeacherSubject { Teacher = teacher });
                    }
                    result.Add(level9);

                    var level10 = new LevelTeachersModel { Level = 10 };
                    foreach (var teacher in teachers)
                    {
                        level10.TeacherSubjects.Add(new TeacherSubject { Teacher = teacher });
                    }
                    result.Add(level10);

                    var level11 = new LevelTeachersModel { Level = 11 };
                    foreach (var teacher in teachers)
                    {
                        level11.TeacherSubjects.Add(new TeacherSubject { Teacher = teacher });
                    }
                    result.Add(level11);


                    var level12 = new LevelTeachersModel { Level = 12 };
                    foreach (var teacher in teachers)
                    {
                        level12.TeacherSubjects.Add(new TeacherSubject { Teacher = teacher });
                    }
                    result.Add(level12);
                    return result;
                }

                var teacherSubjectsModels = new List<LevelTeachersModel>();
                try
                {
                    var filePath = Path.Combine(Application.StartupPath, "Data", "levelTeachers.json");
                    if (File.Exists(filePath))
                    {
                        var contentStr = File.ReadAllText(filePath);
                        if (!string.IsNullOrEmpty(contentStr))
                        {
                            teacherSubjectsModels = JsonConvert.DeserializeObject<List<LevelTeachersModel>>(contentStr);
                        }
                        else
                        {
                            teacherSubjectsModels = GetDefault();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    teacherSubjectsModels = GetDefault();
                }

                return teacherSubjectsModels ?? GetDefault();
            }

            List<LevelClassroomsModel> TryLoadLevelClassrooms()
            {
                List<LevelClassroomsModel> GetDefault()
                {
                    List<LevelClassroomsModel> levelModels = new List<LevelClassroomsModel>();
                    foreach (var level in (levels ?? new List<int>()).OrderBy(x => x))
                    {
                        LevelClassroomsModel levelModel = new LevelClassroomsModel { Level = level, ClassNames = new List<string>() };
                        levelModels.Add(levelModel);
                    }
                    return levelModels;
                }

                var levelClassrooms = new List<LevelClassroomsModel>();
                try
                {
                    var filePath = Path.Combine(Application.StartupPath, "Data", "levelClassrooms.json");
                    if (File.Exists(filePath))
                    {
                        var contentStr = File.ReadAllText(filePath);
                        if (!string.IsNullOrEmpty(contentStr))
                        {
                            levelClassrooms = JsonConvert.DeserializeObject<List<LevelClassroomsModel>>(contentStr);
                        }
                        else
                        {
                            levelClassrooms = GetDefault();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    levelClassrooms = GetDefault();
                }

                return levelClassrooms ?? GetDefault();
            }
            #endregion

            teachers = TryLoadTeachersData();
            subjects = TryLoadSubjectsData();
            levels = TryLoadLevelsData();

            textBoxTeachers.Text = string.Join(Environment.NewLine, teachers);
            textBoxSubjects.Text = string.Join(Environment.NewLine, subjects);
            textBoxLevels.Text = string.Join(Environment.NewLine, levels);

            LevelClassrooms = TryLoadLevelClassrooms();
            DaySlots = TryLoadDaySlotsData();
            SubjectTimes = TryLoadSubjectTimes();
            LevelTeachers = TryLoadLevelTeachers();

            timer1.Interval = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;
            timer1.Tick += Timer1_Tick;

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            timer1.Stop();

            if (teachersChanged) SaveTeachers();
            if (subjectsChanged) SaveSubjects();
            if (levelsChanged) SaveLevels();

            base.OnClosing(e);
        }
        private void Timer1_Tick(object? sender, EventArgs e)
        {
            try
            {
                //SaveDaySlotsSetting();
                //SaveLevelSubjectsSetting();
                SaveTeachers();
                SaveSubjects();
                SaveLevels();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        void SaveTeachers()
        {
            try
            {
                var str = JsonConvert.SerializeObject(teachers);
                var filePath = Path.Combine(Application.StartupPath, "Data", "teachers.json");

                File.WriteAllText(filePath, str);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            teachersChanged = false;
        }

        void SaveSubjects()
        {
            try
            {
                var str = JsonConvert.SerializeObject(subjects);
                var filePath = Path.Combine(Application.StartupPath, "Data", "subjects.json");

                File.WriteAllText(filePath, str);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            subjectsChanged = false;
        }

        void SaveLevels()
        {
            try
            {
                var str = JsonConvert.SerializeObject(levels);
                var filePath = Path.Combine(Application.StartupPath, "Data", "levels.json");

                File.WriteAllText(filePath, str);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            levelsChanged = false;
        }

        private void ButtonTimeSlots_Click(object sender, EventArgs e)
        {
            var form = new FormTimeSlots(DaySlots) { StartPosition = FormStartPosition.CenterScreen, Owner = this };
            form.ShowDialog();

            DaySlots = form.DaySlotModels;
        }

        private void buttonSubjects_Click(object sender, EventArgs e)
        {
            var form = new FormSubjectTimes(levels, subjects, SubjectTimes) { StartPosition = FormStartPosition.CenterParent, Owner = this };
            form.ShowDialog();

            SubjectTimes = form.SubjectTimesModels;
        }

        private void buttonTeacherSubjects_Click(object sender, EventArgs e)
        {
            var formTeacherSubjects = new FormTeacherSubjects(teachers, subjects, LevelTeachers)
            {
                StartPosition = FormStartPosition.CenterParent,
                Owner = this
            };

            formTeacherSubjects.ShowDialog();

            LevelTeachers = formTeacherSubjects.TeacherSubjects;

        }
        private void buttonClassroom_Click(object sender, EventArgs e)
        {

            var form = new FormLevelClassrooms(levels, LevelClassrooms)
            {
                Owner = this,
                StartPosition = FormStartPosition.CenterParent
            };

            form.ShowDialog();

            LevelClassrooms = form.LevelClassrooms;


        }

        private void textBoxTeachers_TextChanged(object sender, EventArgs e)
        {

            var temp = from t in $"{textBoxTeachers.Text}".Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                       where !string.IsNullOrEmpty(t)
                       select t;
            teachers = temp.ToList();

            teachersChanged = true;
        }

        private void textBoxSubjects_TextChanged(object sender, EventArgs e)
        {
            var temp = from t in $"{textBoxSubjects.Text}".Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                       where !string.IsNullOrEmpty(t)
                       select t;
            subjects = temp.ToList();

            subjectsChanged = true;
        }

        private void textBoxLevels_TextChanged(object sender, EventArgs e)
        {
            var temp = from t in $"{textBoxLevels.Text}".Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                       where !string.IsNullOrEmpty(t) && int.TryParse(t, out int test)
                       select int.Parse(t);

            levels = temp.ToList();

            levelsChanged = true;
        }


        internal class TeacherSubjectFilter
        {
            public string Teacher { get; set; } = null!;
            public string Subject { get; set; } = null!;
        }
        private TeacherSubjectFilter? GetAvailableTeacherSubject(List<LevelTeachersModel> levelTeachers, int level, List<string>? excludeSubjects)
        {
            if (levelTeachers == null || levelTeachers.Count == 0) return null;

            if (excludeSubjects == null) excludeSubjects = new List<string>();

            foreach (var levelTeacher in levelTeachers.Where(x => x.Level == level))
            {
                foreach (var teacherSubject in levelTeacher.TeacherSubjects)
                {
                    //var isAvailabeSubject = teacherSubject.Subjects.Where()
                    foreach (var subject in teacherSubject.Subjects)
                    {
                        var isAvailable = excludeSubjects.Where(x => x == subject).Count() == 0;

                    }
                }
            }
            return null;
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            bool isSubjectDoubleSlot(List<SubjectSlot> subjectDoubleSlots, SubjectSlot subject)
            {
                var isValid = subjectDoubleSlots.Any(x => x.Subject == subject.Subject);
                return isValid;
            }

            var subjectTimesClone = SubjectTimes.Clone();

            var teacherSubjects = LevelTeachers.Clone();

            List<SubjectSlot> subjectDoubleSlots = new List<SubjectSlot>();

            if (DaySlots.Any() && SubjectTimes.Any() && teachers.Any() && LevelClassrooms.Any() && LevelTeachers.Any())
            {
                foreach (var levelModel in LevelClassrooms.OrderBy(x => x.Level))
                {
                    //var teacherByLevel = teacherResources.Where(x => x.Level == level.Level);


                    SubjectTimesModel subjectTimesByLevel = subjectTimesClone.FirstOrDefault(x => x.Level == levelModel.Level) ?? new SubjectTimesModel();

                    subjectDoubleSlots = subjectTimesByLevel.SubjectSlots.Where(x => x.SlotPerWeek > 2).ToList();

                    foreach (var className in levelModel.ClassNames)
                    {
                        StudentTimeTable studentTime = new StudentTimeTable
                        {
                            Classroom = new ClassroomModel { Level = levelModel.Level, ClassName = className }
                        };

                        foreach (var daySlot in DaySlots.OrderBy(x => x.Day))
                        {
                            switch (daySlot.Day)
                            {
                                case DayOfWeek.Sunday:
                                    studentTime.Saturday = new DaySlotMapping
                                    {

                                    };

                                    break;
                                case DayOfWeek.Monday:
                                    //refill slots for Monday
                                    studentTime.Monday = new DaySlotMapping();
                                    foreach (var timeSlot in daySlot.slots)
                                    {

                                        //select subject and then select teacher for this slot

                                        var subject = subjectTimesByLevel.SubjectSlots.FirstOrDefault(x => x.SlotPerWeek > 0);
                                        if (subject != null)
                                        {
                                            if (isSubjectDoubleSlot(subjectDoubleSlots, subject))
                                            {
                                                for (var i = 0; i < 2; i++)
                                                {
                                                    if (subject.SlotPerWeek > 0)
                                                    {
                                                        SubjectTimeSlot subjectTimeSlot = new SubjectTimeSlot
                                                        {
                                                            TimeSlot = timeSlot,
                                                            Subject = subject.Subject,
                                                            Teacher = ""
                                                        };

                                                        studentTime.Monday.SubjectTimeSlots.Add(subjectTimeSlot);
                                                        subject.SlotPerWeek--;
                                                    }

                                                }
                                                if (subject.SlotPerWeek >= 2)
                                                {

                                                }
                                            }
                                        }


                                    }

                                    break;
                                case DayOfWeek.Tuesday:
                                    studentTime.Tuesday = new DaySlotMapping
                                    {

                                    };
                                    break;
                                case DayOfWeek.Wednesday:
                                    studentTime.Wednesday = new DaySlotMapping
                                    {

                                    };
                                    break;
                                case DayOfWeek.Thursday:
                                    studentTime.Thursday = new DaySlotMapping
                                    {

                                    };
                                    break;
                                case DayOfWeek.Friday:
                                    studentTime.Friday = new DaySlotMapping
                                    {

                                    };
                                    break;
                                case DayOfWeek.Saturday:
                                    studentTime.Saturday = new DaySlotMapping
                                    {

                                    };
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                //FormPreview formPreview = new FormPreview(daySlotModels, levelSubjectsModels, teachers.ToList(), null);
                //formPreview.ShowDialog();

            }
            else
            {
                MessageBox.Show("Invalid Request.");
            }
        }


    }
}