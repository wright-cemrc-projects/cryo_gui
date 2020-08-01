using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryoProject
{
    /// <summary>
    /// Interaction logic for CollectionInfoPage.xaml
    /// </summary>
    public partial class CollectionInfoPage : Page
    {
        public CollectionInfoPage()
        {
            InitializeComponent();
        }

        private void ChooseProjectDirectory(object sender, RoutedEventArgs e)
        {
            // Open a file dialog
            // If valid directory:
            //  - write the project 'dataset.json'
            //  - write a README.txt
            //  exit program

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");

                    System.Windows.Application.Current.Shutdown();
                }
            }
        }

        private void ChooseImageDirectory(object sender, RoutedEventArgs e)
        {
            // Open a file dialog
            // If valid directory: update the image directory location.
            // We will need a relative location of image directory vs. project directory.
            // If this is EPU, we will need to copy frames to the expected location.

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");

                }
            }
        }
    }

}
