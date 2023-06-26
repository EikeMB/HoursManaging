﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HoursManaging;

namespace HoursManagerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ViewInterface
    {

        private string? fileName = "";
        private string? folderName = "";

        private Presenter presenter;
        public MainWindow()
        {
            InitializeComponent();
            ShowMenu();
        }


        private void ShowMenu()
        {
            Menu menuWindow = new Menu(this, fileName, folderName, presenter);

            menuWindow.ShowDialog();

        }
        public void DisplayError(string error)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("../../../../ErrorSound.wav");
            player.Play();
            MessageBox.Show(error, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void SetupDataGridByWeek(List<DaysByWeek> daysByWeeks)
        {
            DataGrid.ItemsSource = daysByWeeks;
            DataGrid.Columns.Clear();

            var column1 = new DataGridTextColumn();
            column1.Header = "Week";
            column1.Binding = new System.Windows.Data.Binding("Week");
            DataGrid.Columns.Add(column1);

            var column2 = new DataGridTextColumn();
            column2.Header = "Total Hours";
            column2.Binding = new System.Windows.Data.Binding("TotalHours");
            DataGrid.Columns.Add(column2);

            var column3 = new DataGridTextColumn();
            column3.Header = "Total Minutes";
            column3.Binding = new System.Windows.Data.Binding("TotalMinutes");
            DataGrid.Columns.Add(column3);
        }

        public void SetupDataGridDefault(List<Day> days)
        {
            DataGrid.ItemsSource = days;
            DataGrid.Columns.Clear();

            var column1 = new DataGridTextColumn();
            column1.Header = "Start Time";
            column1.Binding = new System.Windows.Data.Binding("StartTime");
            column1.Binding.StringFormat = "{dd/MM/yyyy HH:mm}";
            DataGrid.Columns.Add(column1);

            var column2 = new DataGridTextColumn();
            column2.Header = "End Time";
            column2.Binding = new System.Windows.Data.Binding("EndTime");
            column2.Binding.StringFormat = "{dd/MM/yyyy HH:mm}";
            DataGrid.Columns.Add(column2);

            var column3 = new DataGridTextColumn();
            column3.Header = "Total Hours";
            column3.Binding = new System.Windows.Data.Binding("TotalHours");
            DataGrid.Columns.Add(column3);

            var column4 = new DataGridTextColumn();
            column4.Header = "Total Minutes";
            column4.Binding = new System.Windows.Data.Binding("TotalMinutes");
            DataGrid.Columns.Add(column4);
        }
    }
}
