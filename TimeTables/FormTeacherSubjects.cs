using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using TimeTables.Models;

namespace TimeTables
{
    public partial class FormTeacherSubjects : Form
    {
        public List<LevelTeachersModel> TeacherSubjects { get; set; }
        public FormTeacherSubjects(List<string> teachers, List<string> subjects, List<LevelTeachersModel> teacherSubjects)
        {
            TeacherSubjects = teacherSubjects;

            InitializeComponent();

            dataGridView7.AllowUserToAddRows = false;
            dataGridView7.AllowUserToDeleteRows = false;

            dataGridView8.AllowUserToAddRows = false;
            dataGridView8.AllowUserToDeleteRows = false;

            dataGridView9.AllowUserToAddRows = false;
            dataGridView9.AllowUserToDeleteRows = false;

            dataGridView10.AllowUserToAddRows = false;
            dataGridView10.AllowUserToDeleteRows = false;

            dataGridView11.AllowUserToAddRows = false;
            dataGridView11.AllowUserToDeleteRows = false;

            dataGridView12.AllowUserToAddRows = false;
            dataGridView12.AllowUserToDeleteRows = false;

            RenderTeacherSubjectGrid(teachers, subjects, teacherSubjects, dataGridView7, 7);
            RenderTeacherSubjectGrid(teachers, subjects, teacherSubjects, dataGridView8, 8);
            RenderTeacherSubjectGrid(teachers, subjects, teacherSubjects, dataGridView9, 9);
            RenderTeacherSubjectGrid(teachers, subjects, teacherSubjects, dataGridView10, 10);
            RenderTeacherSubjectGrid(teachers, subjects, teacherSubjects, dataGridView11, 11);
            RenderTeacherSubjectGrid(teachers, subjects, teacherSubjects, dataGridView12, 12);

            dataGridView7.CurrentCellDirtyStateChanged += DataGridView_CurrentCellDirtyStateChanged;
            dataGridView8.CurrentCellDirtyStateChanged += DataGridView_CurrentCellDirtyStateChanged;
            dataGridView9.CurrentCellDirtyStateChanged += DataGridView_CurrentCellDirtyStateChanged;
            dataGridView10.CurrentCellDirtyStateChanged += DataGridView_CurrentCellDirtyStateChanged;
            dataGridView11.CurrentCellDirtyStateChanged += DataGridView_CurrentCellDirtyStateChanged;
            dataGridView12.CurrentCellDirtyStateChanged += DataGridView_CurrentCellDirtyStateChanged;
        }

        private void DataGridView_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                DataGridView? dgv = sender as DataGridView;
                if (dgv != null)
                {
                    if (dgv.IsCurrentCellDirty)
                    {
                        dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }
                }
            }

        }

        void RenderTeacherSubjectGrid(List<string> teachers, List<string> subjects, List<LevelTeachersModel> teacherSubjects, DataGridView dataGridView, int level)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn($"colTeacherName", typeof(string)));

            int ind = 1;
            foreach (string subject in subjects)
            {
                var col = new DataColumn($"subject_{ind}", typeof(bool));
                col.Caption = subject;

                dt.Columns.Add(col);
                ind++;
            }

            foreach (string teacher in teachers)
            {
                var byLevel = teacherSubjects.Where(x => x.Level == level).FirstOrDefault();

                var newRow = dt.NewRow();
                newRow[0] = teacher;

                for (int i = 0; i < subjects.Count; i++)
                {
                    var canTeach = false;

                    if (byLevel != null)
                    {
                        var byTeacher = byLevel.TeacherSubjects.FirstOrDefault(x => x.Teacher == teacher);
                        if (byTeacher != null)
                        {
                            canTeach = byTeacher.Subjects.Any(x => x == subjects[i]);
                        }
                    }
                    newRow[i + 1] = canTeach;
                }
                dt.Rows.Add(newRow);
            }

            dataGridView.DataSource = dt;

            dataGridView.AutoGenerateColumns = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView.Columns[0].HeaderText = @"Teacher\Subject";
            dataGridView.Columns[0].ReadOnly = true;

            for (int i = 0; i < subjects.Count; i++)
            {
                dataGridView.Columns[i + 1].HeaderText = subjects[i];

            }
        }


        LevelTeachersModel GetTeacherSubjectsModel(DataGridView dataGridView, int level)
        {
            DataTable levelTable = (DataTable)dataGridView.DataSource;

            LevelTeachersModel teacherSubjectsModel = new LevelTeachersModel { Level = level };

            foreach (DataRow row in levelTable.Rows)
            {
                var teacherSubjects = new List<TeacherSubject>();

                DataColumn firstCol = row.Table.Columns[0];

                TeacherSubject teacherSubject = new TeacherSubject { Teacher = $"{row[firstCol]}" };

                foreach (DataColumn col in row.Table.Columns)
                {
                    if (col.ColumnName == "colTeacherName")
                    {
                        teacherSubject.Teacher = $"{row[col]}";
                    }
                    else
                    {
                        var subject = col.Caption;

                        bool isTeach = (bool)row[col];
                        if (isTeach == true)
                        {
                            teacherSubject.Subjects.Add(subject);
                        }

                    }
                }

                teacherSubjects.Add(teacherSubject);

                teacherSubjectsModel.TeacherSubjects.Add(teacherSubject);

            }

            return teacherSubjectsModel;

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            LevelTeachersModel level7 = GetTeacherSubjectsModel(dataGridView7, 7);
            LevelTeachersModel level8 = GetTeacherSubjectsModel(dataGridView8, 8);
            LevelTeachersModel level9 = GetTeacherSubjectsModel(dataGridView9, 9);
            LevelTeachersModel level10 = GetTeacherSubjectsModel(dataGridView10, 10);
            LevelTeachersModel level11 = GetTeacherSubjectsModel(dataGridView11, 11);
            LevelTeachersModel level12 = GetTeacherSubjectsModel(dataGridView12, 12);

            TeacherSubjects = new List<LevelTeachersModel> { level7, level8, level9, level10, level11, level12 };

            base.OnClosing(e);
        }
    }
}
