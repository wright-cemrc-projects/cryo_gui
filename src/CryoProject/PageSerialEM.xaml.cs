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
    public partial class PageSerialEM : Page
    {
        public PageSerialEM(Metadata data)
        {
            InitializeComponent();
            DataContext = data;

            if (data.WorkflowOptions.Equals(""))
            {
                data.WorkflowOptions = "Relion";
            }
        }

        private void Previous(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            PageDone p = new PageDone((Metadata)DataContext);
            this.NavigationService.Navigate(p);
        }

    }
}
