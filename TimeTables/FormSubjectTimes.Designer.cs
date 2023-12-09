namespace TimeTables
{
    partial class FormSubjectTimes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewSubjectTimes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubjectTimes).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewSubjectTimes
            // 
            dataGridViewSubjectTimes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSubjectTimes.Dock = DockStyle.Fill;
            dataGridViewSubjectTimes.Location = new Point(0, 0);
            dataGridViewSubjectTimes.Name = "dataGridViewSubjectTimes";
            dataGridViewSubjectTimes.Size = new Size(1138, 728);
            dataGridViewSubjectTimes.TabIndex = 0;
            // 
            // FormSubjectTimes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1138, 728);
            Controls.Add(dataGridViewSubjectTimes);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormSubjectTimes";
            Text = "Subject Times";
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubjectTimes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewSubjectTimes;
    }
}