namespace TimeTables
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            buttonTimeSlots = new Button();
            label3 = new Label();
            buttonGenerate = new Button();
            buttonLevelSubjects = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            buttonTeacherSubjects = new Button();
            panel1 = new Panel();
            textBoxTeachers = new TextBox();
            panel2 = new Panel();
            textBoxSubjects = new TextBox();
            panel3 = new Panel();
            textBoxLevels = new TextBox();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panel4 = new Panel();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 1;
            label1.Text = "Teachers";
            // 
            // buttonTimeSlots
            // 
            buttonTimeSlots.Location = new Point(3, 3);
            buttonTimeSlots.Name = "buttonTimeSlots";
            buttonTimeSlots.Size = new Size(112, 51);
            buttonTimeSlots.TabIndex = 0;
            buttonTimeSlots.Text = "Time Slots";
            buttonTimeSlots.UseVisualStyleBackColor = true;
            buttonTimeSlots.Click += ButtonTimeSlots_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 6;
            label3.Text = "Subjects";
            // 
            // buttonGenerate
            // 
            buttonGenerate.BackColor = SystemColors.Highlight;
            buttonGenerate.Dock = DockStyle.Top;
            buttonGenerate.ForeColor = SystemColors.ButtonHighlight;
            buttonGenerate.Location = new Point(0, 0);
            buttonGenerate.Name = "buttonGenerate";
            buttonGenerate.Size = new Size(354, 55);
            buttonGenerate.TabIndex = 4;
            buttonGenerate.Text = "Generate Time Tables";
            buttonGenerate.UseVisualStyleBackColor = false;
            buttonGenerate.Click += buttonGenerate_Click;
            // 
            // buttonLevelSubjects
            // 
            buttonLevelSubjects.Location = new Point(121, 3);
            buttonLevelSubjects.Name = "buttonLevelSubjects";
            buttonLevelSubjects.Size = new Size(140, 49);
            buttonLevelSubjects.TabIndex = 7;
            buttonLevelSubjects.Text = "Subject Times";
            buttonLevelSubjects.UseVisualStyleBackColor = true;
            buttonLevelSubjects.Click += buttonSubjects_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(buttonTimeSlots);
            flowLayoutPanel1.Controls.Add(buttonLevelSubjects);
            flowLayoutPanel1.Controls.Add(buttonTeacherSubjects);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1148, 60);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // buttonTeacherSubjects
            // 
            buttonTeacherSubjects.Location = new Point(267, 3);
            buttonTeacherSubjects.Name = "buttonTeacherSubjects";
            buttonTeacherSubjects.Size = new Size(140, 49);
            buttonTeacherSubjects.TabIndex = 8;
            buttonTeacherSubjects.Text = "Teacher Subjects";
            buttonTeacherSubjects.UseVisualStyleBackColor = true;
            buttonTeacherSubjects.Click += buttonTeacherSubjects_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBoxTeachers);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(261, 712);
            panel1.TabIndex = 9;
            // 
            // textBoxTeachers
            // 
            textBoxTeachers.Dock = DockStyle.Fill;
            textBoxTeachers.Location = new Point(0, 20);
            textBoxTeachers.Multiline = true;
            textBoxTeachers.Name = "textBoxTeachers";
            textBoxTeachers.ScrollBars = ScrollBars.Both;
            textBoxTeachers.Size = new Size(261, 692);
            textBoxTeachers.TabIndex = 2;
            textBoxTeachers.TextChanged += textBoxTeachers_TextChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBoxSubjects);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(261, 60);
            panel2.Name = "panel2";
            panel2.Size = new Size(303, 712);
            panel2.TabIndex = 10;
            // 
            // textBoxSubjects
            // 
            textBoxSubjects.Dock = DockStyle.Fill;
            textBoxSubjects.Location = new Point(0, 20);
            textBoxSubjects.Multiline = true;
            textBoxSubjects.Name = "textBoxSubjects";
            textBoxSubjects.ScrollBars = ScrollBars.Both;
            textBoxSubjects.Size = new Size(303, 692);
            textBoxSubjects.TabIndex = 7;
            textBoxSubjects.Text = "ភាសាខ្មែរ\r\nភាសាបរទេស\r\nគណិតវិទ្យា\r\nផែនដី បរិស្ថានវិទ្យា\r\nគីមីវិទ្យា\r\nរូបវិទ្យា\r\nជីវវិទ្យា\r\nប្រវត្តិវិទ្យា\r\nភូមិវិទ្យា\r\nសីលធម៌ ពលរដ្ធ\r\nគេហកិច្ច\r\nសេដ្ធកិច្ច\r\nបំណិនជីវិត\r\nសិល្បៈ\r\nកីឡា\r\nសកម្មភាពពិសេស";
            textBoxSubjects.TextChanged += textBoxSubjects_TextChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(textBoxLevels);
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(564, 60);
            panel3.Name = "panel3";
            panel3.Size = new Size(230, 712);
            panel3.TabIndex = 11;
            // 
            // textBoxLevels
            // 
            textBoxLevels.BackColor = SystemColors.ControlLightLight;
            textBoxLevels.Dock = DockStyle.Fill;
            textBoxLevels.Location = new Point(0, 20);
            textBoxLevels.Multiline = true;
            textBoxLevels.Name = "textBoxLevels";
            textBoxLevels.ReadOnly = true;
            textBoxLevels.ScrollBars = ScrollBars.Both;
            textBoxLevels.Size = new Size(230, 692);
            textBoxLevels.TabIndex = 1;
            textBoxLevels.Text = "7\r\n8\r\n9\r\n10\r\n11";
            textBoxLevels.TextChanged += textBoxLevels_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 0;
            label2.Text = "Levels";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlLight;
            panel4.Controls.Add(buttonGenerate);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(794, 60);
            panel4.Name = "panel4";
            panel4.Size = new Size(354, 712);
            panel4.TabIndex = 12;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1148, 772);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormMain";
            Text = "Form Main";
            WindowState = FormWindowState.Maximized;
            Load += FormMain_Load;
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Button buttonTimeSlots;
        private Label label3;
        private Button buttonGenerate;
        private Button buttonLevelSubjects;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonTeacherSubjects;
        private Panel panel1;
        private TextBox textBoxTeachers;
        private Panel panel2;
        private TextBox textBoxSubjects;
        private Panel panel3;
        private TextBox textBoxLevels;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private Panel panel4;
    }
}