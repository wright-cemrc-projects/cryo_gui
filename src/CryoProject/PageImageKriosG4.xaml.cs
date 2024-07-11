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
    public partial class PageImageKriosG4 : Page
    {
        // Will be updated and used to save results.
        public PageImageKriosG4(Metadata data)
        {
            InitializeComponent();
            DataContext = data;
            // Filter based on data.ImagingMode == TEM or EFTEM
            ApplyFilter(data.ImagingMode);
        }

        private void ApplyFilter(String mode)
        {
            switch (mode)
            {
                case "EFTEM":
                    TypeOfCameraCB.Items.Clear();
                    List<string> camera_EFTEM_List = new List<string> { "EF-Falcon 4i" };
                    foreach (var item in camera_EFTEM_List) { TypeOfCameraCB.Items.Add(item); }
                    TypeOfCameraCB.SelectedIndex = 0;
                    break;
                case "TEM":
                    TypeOfCameraCB.Items.Clear();
                    List<string> camera_TEM_List = new List<string> { "BM-Falcon 4i", "Ceta-D" };
                    foreach (var item in camera_TEM_List) { TypeOfCameraCB.Items.Add(item); }
                    TypeOfCameraCB.SelectedIndex = 0;
                    break;

            }
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            Metadata data = (Metadata)DataContext;
            Page p;

            switch (data.TypeOfSession)
            {

                case "Single Particle Session":
                    if (data.TypeOfSoftware == "EPU")
                    {
                        p = new PageEPU((Metadata)DataContext);
                    }
                    if (data.TypeOfSoftware == "SerialEM")
                    {
                        p = new PageSerialEM((Metadata)DataContext);
                    }
                    else
                    {
                        p = new PageDone((Metadata)DataContext);
                    }
                    break;
                case "Screening Session":
                    if (data.TypeOfSoftware == "EPU")
                    {
                        p = new PageEPU((Metadata)DataContext);
                    }
                    if (data.TypeOfSoftware == "SerialEM")
                    {
                        p = new PageSerialEM((Metadata)DataContext);
                    }
                    else
                    {
                        p = new PageDone((Metadata)DataContext);
                    }
                    break;
                case "Tomography Session":
                    p = new PageTomography((Metadata)DataContext);
                    break;
                default:
                    p = new PageDone((Metadata)DataContext);
                    break;
            }

            this.NavigationService.Navigate(p);
        }

        private void Previous(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }
    }
}
