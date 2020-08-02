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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryoProject
{
    /// <summary>
    /// Interaction logic for CollectionDonePage.xaml
    /// </summary>
    public partial class CollectionDonePage : Page
    {
        public CollectionDonePage()
        {
            InitializeComponent();
        }

        private void SaveProjectJSON()
        {
            Metadata data = (Metadata)DataContext;
            
            // TODO: write a JSON file
        }

        private void SaveProjectTextfile()
        {
            Metadata data = (Metadata)DataContext;

            // TODO: write a Text file
        }

        private void Done(object sender, RoutedEventArgs e)
        {
            SaveProjectJSON();
            SaveProjectTextfile();
            System.Windows.Application.Current.Shutdown();
        }
    }
}
