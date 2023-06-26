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
    /// Interaction logic for AddDay.xaml
    /// </summary>
    public partial class AddDay : Window
    {
        private string? fileName = "";
        private string? folderName = "";
        private Presenter pr;
        private ViewInterface view;
        public AddDay(ViewInterface view, ref string? fileName, ref string? folderName, ref Presenter pr)
        {
            InitializeComponent();
            Date.SelectedDate = DateTime.Now;
            this.view = view;
            this.fileName = fileName;
            this.folderName = folderName;
            this.pr = pr;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                DateTime dateTime = new DateTime(Date.SelectedDate.Value.Year, Date.SelectedDate.Value.Month, Date.SelectedDate.Value.Day, int.Parse(hour.Text), int.Parse(minute.Text), 0);
                DateTime dateTime2 = new DateTime(Date.SelectedDate.Value.Year, Date.SelectedDate.Value.Month, Date.SelectedDate.Value.Day, int.Parse(hour2.Text), int.Parse(minute2.Text), 0);

                pr.processAdd(dateTime, dateTime2);
            }
            catch (Exception error)
            {

                view.DisplayError(error.Message);
            }
            
            view.getFilters();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
