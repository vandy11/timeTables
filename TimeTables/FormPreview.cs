using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTables.Models;

namespace TimeTables
{
    public partial class FormPreview : Form
    {
        public FormPreview(List<DaySlotModel> daySlots, List<SubjectTimesModel> levelSubjects, List<string> teachers, List<string> classes)
        {
            InitializeComponent();

            
        }
    }
}
