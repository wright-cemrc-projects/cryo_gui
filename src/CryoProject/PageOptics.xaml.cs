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
    public partial class PageOptics : Page
    {
        // Will be updated and used to save results.

        public PageOptics(Metadata data)
        {
            InitializeComponent();
            DataContext = data;
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            Metadata data = (Metadata)DataContext;
            Page p;
            if (data.TypeOfSession.Equals("Tomography Session"))
            {
                p = new PageImageTomo(data);
            }
            else
            {
                switch (data.Instrument)
                {
                    case "Krios G3i":
                        p = new PageImageKriosG3i(data); break;
                    case "Krios G4":
                        p = new PageImageKriosG4(data); break;
                    case "Arctica":
                        p = new PageImageArctica(data); break;
                    case "L120C":
                        p = new PageImageL120C(data); break;
                    default:
                        p = new PageImage(data);
                        break;
                }
            }
            this.NavigationService.Navigate(p);

          
        }

     }
}
