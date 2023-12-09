using System.ComponentModel;
using System.Data;
using TimeTables.Models;

namespace TimeTables
{
    public partial class FormTimeSlots : Form
    {

        public List<DaySlotModel> DaySlotModels { get; set; }

        public FormTimeSlots(List<DaySlotModel> daySlotModels)
        {
            InitializeComponent();
            DaySlotModels = daySlotModels;

            var mondaySlots = DaySlotModels.FirstOrDefault(x => x.Day == DayOfWeek.Monday);
            var tuesdaySlots = DaySlotModels.FirstOrDefault(x => x.Day == DayOfWeek.Tuesday);
            var wednesdaySlots = DaySlotModels.FirstOrDefault(x => x.Day == DayOfWeek.Wednesday);
            var thursdaySlots = DaySlotModels.FirstOrDefault(x => x.Day == DayOfWeek.Thursday);
            var fridaySlots = DaySlotModels.FirstOrDefault(x => x.Day == DayOfWeek.Friday);
            var saturdaySlots = DaySlotModels.FirstOrDefault(x => x.Day == DayOfWeek.Saturday);
            var sundaySlots = DaySlotModels.FirstOrDefault(x => x.Day == DayOfWeek.Sunday);

            RenderDataGridView(dataGridViewMonday, mondaySlots);

            RenderDataGridView(dataGridViewTuesday, tuesdaySlots);

            RenderDataGridView(dataGridViewWednesday, wednesdaySlots);

            RenderDataGridView(dataGridViewThursday, thursdaySlots);

            RenderDataGridView(dataGridViewFriday, fridaySlots);

            RenderDataGridView(dataGridViewSaturday, saturdaySlots);

            RenderDataGridView(dataGridViewSunday, sundaySlots);

        }

        private void RenderDataGridView(DataGridView dataGridView, DaySlotModel? daySlotModel)
        {
            dataGridView.Rows.Clear();
            if(daySlotModel != null)
            {
                foreach (var item in daySlotModel.slots.OrderBy(x => x))
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        dataGridView.Rows.Add(item);
                    }
                }
            }
            
        }

        private DaySlotModel GetFromDataGridView(DataGridView dataGridView, DayOfWeek dayOfWeek)
        {
            DaySlotModel daySlotModel = new DaySlotModel { Day = dayOfWeek, slots = new List<string>() };
            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                string timeSlot = $"{item.Cells[0].Value}";
                if (!string.IsNullOrEmpty(timeSlot))
                {
                    daySlotModel.slots.Add(timeSlot);
                }
            }
            return daySlotModel;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            DaySlotModel monday = GetFromDataGridView(dataGridViewMonday, DayOfWeek.Monday);

            DaySlotModel tuesday = GetFromDataGridView(dataGridViewTuesday, DayOfWeek.Tuesday);

            DaySlotModel wednesday = GetFromDataGridView(dataGridViewTuesday, DayOfWeek.Wednesday);

            DaySlotModel thursday = GetFromDataGridView(dataGridViewThursday, DayOfWeek.Thursday);

            DaySlotModel friday = GetFromDataGridView(dataGridViewFriday, DayOfWeek.Friday);

            DaySlotModel saturday = GetFromDataGridView(dataGridViewSaturday, DayOfWeek.Saturday);

            DaySlotModel sunday = GetFromDataGridView(dataGridViewSunday, DayOfWeek.Sunday);

            for (int i = 0; i < DaySlotModels.Count; i++)
            {
                switch (DaySlotModels[i].Day)
                {
                    case DayOfWeek.Sunday:
                        DaySlotModels[i] = sunday;
                        break;
                    case DayOfWeek.Monday:
                        DaySlotModels[i] = monday;
                        break;
                    case DayOfWeek.Tuesday:
                        DaySlotModels[i] = tuesday;
                        break;
                    case DayOfWeek.Wednesday:
                        DaySlotModels[i] = wednesday;
                        break;
                    case DayOfWeek.Thursday:
                        DaySlotModels[i] = thursday;
                        break;
                    case DayOfWeek.Friday:
                        DaySlotModels[i] = friday;
                        break;
                    case DayOfWeek.Saturday:
                        DaySlotModels[i] = saturday;
                        break;
                    default:
                        break;
                }
            }

            base.OnClosing(e);
        }

    }
}
