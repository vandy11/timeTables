using System.ComponentModel;
using System.Data;
using TimeTables.Models;

namespace TimeTables
{
    public partial class FormLevelClassrooms : Form
    {
        public List<LevelClassroomsModel> LevelClassrooms { get; set; }
        public FormLevelClassrooms(List<int> levels, List<LevelClassroomsModel> levelClassrooms)
        {
            InitializeComponent();

            LevelClassrooms = levelClassrooms;

            foreach (int level in levels.OrderBy(x => x))
            {
                TabPage tabPage = new TabPage { Text = $"Level {level}", Tag = level };

                DataGridView dataGridView = new DataGridView()
                {
                    Name = $"dataGridView_{level}",
                    Dock = DockStyle.Fill,
                    ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                };

                var classroomColumn = new DataGridViewTextBoxColumn
                {
                    Width = 500,
                    HeaderText = "Classroom",

                };


                dataGridView.Columns.Add(classroomColumn);

                var existLevel = levelClassrooms.FirstOrDefault(x => x.Level == level);
                if (existLevel != null)
                {
                    foreach (var className in existLevel.ClassNames.OrderBy(x => x))
                    {
                        dataGridView.Rows.Add(className);
                    }
                }

                tabPage.Controls.Add(dataGridView);

                tabControl1.TabPages.Add(tabPage);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            List<LevelClassroomsModel> result = new List<LevelClassroomsModel>();
            foreach (TabPage tabPage in tabControl1.TabPages)
            {
                int? level = (int?)tabPage.Tag;
                if (level.HasValue)
                {
                    try
                    {
                        LevelClassroomsModel levelClassrooms = new LevelClassroomsModel() { Level = level.Value };
                        foreach (var control in tabPage.Controls)
                        {
                            var grid = control as DataGridView;
                            if (grid != null)
                            {
                                foreach (DataGridViewRow row in grid.Rows)
                                {
                                    var className = $"{row.Cells[0].Value}";
                                    if (!string.IsNullOrEmpty(className))
                                    {
                                        levelClassrooms.ClassNames.Add(className);
                                    }
                                }
                            }
                        }

                        result.Add(levelClassrooms);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        e.Cancel = true;
                    }
                }
            }
            LevelClassrooms = result;

            base.OnClosing(e);
        }
    }
}
