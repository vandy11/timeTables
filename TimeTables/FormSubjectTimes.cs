using TimeTables.Models;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TimeTables
{
    public partial class FormSubjectTimes : Form
    {
        public List<SubjectTimesModel> SubjectTimesModels { get; set; }
        
        public FormSubjectTimes(List<string> levels, List<string> subjects, List<SubjectTimesModel> subjectTimesModels)
        {
            SubjectTimesModels = subjectTimesModels;
            InitializeComponent();

            dataGridViewSubjectTimes.AllowUserToAddRows = false;
            dataGridViewSubjectTimes.AllowUserToDeleteRows = false;

            RenderDataGridView(levels, subjects, subjectTimesModels, dataGridViewSubjectTimes);

        }

        void RenderDataGridView(List<string> levels, List<string> subjects, List<SubjectTimesModel> subjectTimesModels, DataGridView dataGridView)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn($"colLevel", typeof(string)));

            int ind = 1;
            foreach (string subject in subjects)
            {
                var col = new DataColumn($"subject_{ind}", typeof(int));
                col.Caption = subject;

                dt.Columns.Add(col);
                ind++;
            }

            foreach (string level in levels)
            {
                var byLevel = subjectTimesModels.Where(x => x.Level == level).FirstOrDefault();

                var newRow = dt.NewRow();
                newRow[0] = level;

                for (int i = 0; i < subjects.Count; i++)
                {
                    int slotPerWeek = 0;

                    if (byLevel != null)
                    {
                        var exist = byLevel.SubjectSlots.FirstOrDefault(x => x.Subject == subjects[i]);
                        if (exist != null)
                        {
                            slotPerWeek = exist.SlotPerWeek;
                        }
                    }
                    newRow[i + 1] = slotPerWeek;
                }
                dt.Rows.Add(newRow);
            }

            dataGridView.DataSource = dt;

            dataGridView.AutoGenerateColumns = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridView.Columns[0].HeaderText = @"Level\Subject";
            dataGridView.Columns[0].ReadOnly = true;
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < subjects.Count; i++)
            {
                dataGridView.Columns[i + 1].HeaderText = subjects[i];
                dataGridView.Columns[i + 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DataTable dt = (DataTable)dataGridViewSubjectTimes.DataSource;

            List<SubjectTimesModel> list = new List<SubjectTimesModel>();

            foreach (DataRow row in dt.Rows)
            {
                SubjectTimesModel subjectTimesModel = new SubjectTimesModel();
                foreach (DataColumn col in row.Table.Columns)
                {
                    if (col.ColumnName == "colLevel")
                    {
                        subjectTimesModel.Level = $"{row[col]}";
                    }
                    else
                    {
                        try
                        {
                            int slotPerWeek = (int)row[col];
                            string subject = $"{col.Caption}";
                            subjectTimesModel.SubjectSlots.Add(new SubjectSlot { Subject = subject, SlotPerWeek = slotPerWeek });
                        }
                        catch (Exception)
                        {

                        }

                    }
                }

                list.Add(subjectTimesModel);
            }
            SubjectTimesModels = list;

            base.OnClosing(e);
        }
    }
}
