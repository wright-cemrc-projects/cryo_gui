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
    public partial class PageStrategy : Page
    {
        // Will be updated and used to save results.

        public PageStrategy(Metadata data)
        {
            InitializeComponent();
            DataContext = data;

            if (data.WorkflowOptions.Equals(""))
            {
                data.WorkflowOptions = "MotionCor2";
            }
   
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            Metadata data = (Metadata)DataContext;
            Page p = new PageDone(data);
            this.NavigationService.Navigate(p);
        }

        private void ChooseTiltDirectory(object sender, RoutedEventArgs e)
        {
            // Open a file dialog
            // Select the preferences file


            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    // string[] files = Directory.GetFiles(fbd.SelectedPath);
                    Metadata data = (Metadata)DataContext;
                    data.TiltDirectory = fbd.SelectedPath;
                }
            }
        }
    }
}
