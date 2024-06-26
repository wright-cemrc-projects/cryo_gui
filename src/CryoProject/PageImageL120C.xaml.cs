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
    public partial class PageImageL120C : Page
    {
        // Will be updated and used to save results.
        public PageImageL120C(Metadata data)
        {
            InitializeComponent();
            DataContext = data;
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            Metadata data = (Metadata)DataContext;
            Page p;

            // L120C doesn't have EPU, next page is either additional SerialEM Tomography details, or ending.
            if (data.TypeOfSession == "Tomography Session")
            {
                p = new PageTomography((Metadata)DataContext);
            }
            else
            {
                p = new PageDone((Metadata)DataContext);
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
