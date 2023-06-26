using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private string? fileName = "";
        private string? folderName = "";
        private Presenter pr;
        private MainWindow window;
        private ViewInterface view;
        public Menu(MainWindow view, ref string? fileName, ref string? folderName, ref Presenter pr)
        {
            InitializeComponent();
            this.window = view;
            this.fileName = fileName;
            this.folderName = folderName;
            this.pr = pr;
            this.view = (ViewInterface)view;
        }

        private void BTN_newDB_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            if (folderName == "")
            {
                saveDialog.InitialDirectory = "c:\\";
            }
            else
            {
                saveDialog.InitialDirectory = folderName;
            }
            saveDialog.Title = "Select location and name of the new database.";
            saveDialog.Filter = "Database File (*.db)|*.db";
            saveDialog.FileName = "dbName";
            saveDialog.DefaultExt = ".db";

            if (saveDialog.ShowDialog() == true)
            {
                fileName = saveDialog.FileName;
                try
                {
                    File.WriteAllText(fileName, "");
                    MessageBox.Show("New DB file has been created", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.pr = new Presenter(view, fileName, true);
                    this.window.presenter = this.pr;
                    folderName = System.IO.Path.GetDirectoryName(fileName);

                    WriteAppData();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error");
                }
            }
        }

        private void BTN_existingDB_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (folderName == "")
            {
                dialog.InitialDirectory = "c:\\";
            }
            else
            {
                dialog.InitialDirectory = folderName;
            }

            dialog.Filter = "Database File {*.db)|*.db";

            if(dialog.ShowDialog() == true)
            {
                fileName = dialog.FileName;

                MessageBox.Show("Existing DB file has been picked", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                folderName = System.IO.Path.GetDirectoryName(dialog.FileName);
                WriteAppData();

                this.pr = new Presenter(view, fileName, false);
                this.window.presenter = this.pr;
                this.Close();

            }
        }

        private void WriteAppData()
        {
            //inspiration taken from here https://stackoverflow.com/questions/10563148/where-is-the-correct-place-to-store-my-application-specific-data
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Directory.CreateDirectory(directory + "\\TicTacToeWPF");
            string path = (System.IO.Path.Combine(directory, "TicTacToeWPF", "FolderPath.txt"));

            File.WriteAllText(path, folderName);
        }
    }
}
