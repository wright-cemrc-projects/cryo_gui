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
    public partial class PageImageKriosG3i : Page
    {
        // Will be updated and used to save results.
        public PageImageKriosG3i(Metadata data)
        {
            InitializeComponent();
            DataContext = data;
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            Metadata data = (Metadata)DataContext;
            Page p;

            switch (data.TypeOfSession) {

                case "Single Particle Session":
                    if (data.TypeOfSoftware == "EPU")
                    {
                        p = new PageEPU((Metadata)DataContext);
                    }
                    if (data.TypeOfSoftware =="SerialEM")
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
