using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for CollectionSoftware.xaml
    /// </summary>
    public partial class PageEPU : Page
    {
        public PageEPU(Metadata data)
        {
            InitializeComponent();
            DataContext = data;
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
                    Metadata data = (Metadata)DataContext;
                    data.LocationFrames = fbd.SelectedPath;
                }
            }
        }

        private void ChooseEPUPresets(object sender, RoutedEventArgs e)
        {
            // Open a file dialog
            // Select the presets file

            using (var fbd = new OpenFileDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {
                    Metadata data = (Metadata)DataContext;
                    data.LocationEPUPresets = fbd.FileName;
                }
            }
        }

        private void ChooseEPUPreferences(object sender, RoutedEventArgs e)
        {
            // Open a file dialog
            // Select the preferences file

            using (var fbd = new OpenFileDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {
                    Metadata data = (Metadata)DataContext;
                    data.LocationEPUPreferences = fbd.FileName;
                }
            }
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            PageStrategy p = new PageStrategy((Metadata)DataContext);
            this.NavigationService.Navigate(p);
        }

    }
}
