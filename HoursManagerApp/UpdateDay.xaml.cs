using System;
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

namespace HoursManagerApp
{
    /// <summary>
    /// Interaction logic for UpdateDay.xaml
    /// </summary>
    public partial class UpdateDay : Window
    {

        HoursManaging.Day day;
        private string? fileName = "";
        private string? folderName = "";
        private Presenter pr;
        private ViewInterface view;

        public UpdateDay(ViewInterface view, ref string? fileName, ref string? folderName, ref Presenter pr, HoursManaging.Day day)
        {
            InitializeComponent();
            stDate.SelectedDate = DateTime.Now;
            this.view = view;
            this.fileName = fileName;
            this.folderName = folderName;
            this.pr = pr;
            this.day = day;
            stDate.SelectedDate = day.StartTime;
            hour.Text = day.StartTime.Hour.ToString();
            minute.Text = day.StartTime.Minute.ToString();
            hour2.Text = day.EndTime.Hour.ToString();
            minute2.Text = day.EndTime.Minute.ToString();
        }

        private void hour_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;

            box.Text = string.Empty;
        }

        private void minute_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;

            box.Text = string.Empty;
        }

        private void hour2_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;

            box.Text = string.Empty;
        }

        private void minute2_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;

            box.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime dateTime = new DateTime(stDate.SelectedDate.Value.Year, stDate.SelectedDate.Value.Month, stDate.SelectedDate.Value.Day, int.Parse(hour.Text), int.Parse(minute.Text), 0);
                DateTime dateTime2 = new DateTime(stDate.SelectedDate.Value.Year, stDate.SelectedDate.Value.Month, stDate.SelectedDate.Value.Day, int.Parse(hour2.Text), int.Parse(minute2.Text), 0);


                pr.processUpdate(day, dateTime, dateTime2);

                this.Close();
            }
            catch (Exception error)
            {

                view.DisplayError(error.Message);
            }

        }
    }
}
