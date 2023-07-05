using System;
using HoursManaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace HoursManagerApp
{
    /// <summary>
    /// Interaction logic for WeekView.xaml
    /// </summary>
    public partial class WeekView : Window
    {
        HoursManaging.DaysByWeek days;
        private string? fileName = "";
        private string? folderName = "";
        private Presenter pr;
        private ViewInterface view;
        public WeekView(ViewInterface view, ref string? fileName, ref string? folderName, ref Presenter pr, HoursManaging.DaysByWeek daysByWeek)
        {
            InitializeComponent();
            this.view = view;
            this.fileName = fileName;
            this.folderName = folderName;
            this.pr = pr;
            this.days = daysByWeek;
            SetupDataGridDefault(days.Days);
        }


        private void Delete_btn(object sender, RoutedEventArgs e)
        {
            Day selectedDay = dtgd.SelectedItem as Day;
            if (selectedDay != null)
            {
                pr.processDelete(selectedDay);
            }

            List<Day> Days = pr.secondWindowGetDays(days.Week, days.Week.AddDays(7));

            SetupDataGridDefault(Days);
            
        }

        private void Update_btn(object sender, RoutedEventArgs e)
        {
            Day selectedDay = dtgd.SelectedItem as Day;
            if (selectedDay != null)
            {
                UpdateDay updateWindow = new UpdateDay(this.Parent as ViewInterface, ref fileName, ref folderName, ref pr, selectedDay);

                updateWindow.ShowDialog();
            }

            List<Day> Days = pr.secondWindowGetDays(days.Week, days.Week.AddDays(7));

            SetupDataGridDefault(Days);
        }

        public void SetupDataGridDefault(List<Day> days)
        {
            dtgd.ItemsSource = days;
            dtgd.Columns.Clear();


            var column1 = new DataGridTextColumn();
            column1.Header = "Start Time";
            column1.Binding = new System.Windows.Data.Binding("StartTime");
            column1.Binding.StringFormat = "dd/MM/yyyy HH:mm";
            dtgd.Columns.Add(column1);

            var column2 = new DataGridTextColumn();
            column2.Header = "End Time";
            column2.Binding = new System.Windows.Data.Binding("EndTime");
            column2.Binding.StringFormat = "dd/MM/yyyy HH:mm";
            dtgd.Columns.Add(column2);

            var column3 = new DataGridTextColumn();
            column3.Header = "Total Hours";
            column3.Binding = new System.Windows.Data.Binding("TotalHours");
            dtgd.Columns.Add(column3);

            var column4 = new DataGridTextColumn();
            column4.Header = "Total Minutes";
            column4.Binding = new System.Windows.Data.Binding("TotalMinutes");
            dtgd.Columns.Add(column4);
        }
    }
}
