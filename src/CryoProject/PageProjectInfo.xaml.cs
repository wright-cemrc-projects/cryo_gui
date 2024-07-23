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
    public partial class PageProjectInfo : Page
    {
        // Will be updated and used to save results.
        public PageProjectInfo()
        {
            InitializeComponent();
        }

        public PageProjectInfo(Metadata data)
        {
            InitializeComponent();
            DataContext = data;

            // Subscribe to change events
            // BUG: this listener is triggered when values are loaded from a file, setting the InstrumentCB from bound metadata variable.
            //  - that results in defaults being applied.
            // InstrumentCB.SelectionChanged += InstrumentCB_SelectionChanged;
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
                    // string[] files = Directory.GetFiles(fbd.SelectedPath);
                    Metadata data = (Metadata)DataContext;
                    data.LocationProject = fbd.SelectedPath;

                    // Set the destination frames location.
                    //data.LocationDestinationFrames = System.IO.Path.Combine(data.LocationProject, "Frames");
                }
            }
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            Metadata data = (Metadata)DataContext;
            if (!data.ProjectSet)
            {
                System.Windows.Forms.MessageBox.Show("Please set the project path.", "Page incomplete.");
            } else if (data.TypeOfSoftware == "") {
                System.Windows.Forms.MessageBox.Show("Please set the software used.", "Page incomplete.");
            } else if (data.TypeOfSession == "")
            {
                System.Windows.Forms.MessageBox.Show("Please set the session type.", "Page incomplete.");
            }
            else {
                Page p;

                switch (data.Instrument) {
                    case "L120C":
                        p = new PageOpticsL120C((Metadata)DataContext);
                        break;
                    case "Arctica":
                        p = new PageOptics((Metadata)DataContext);
                        break;
                    case "Krios G3i":
                        p = new PageOptics((Metadata)DataContext);
                        break;
                    case "Krios G4":
                        p = new PageOptics((Metadata)DataContext);
                        break;
                    default:
                        p = new PageOptics((Metadata)DataContext);
                        break;
                }

                this.NavigationService.Navigate(p);
            }
        }

        private void InstrumentCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = InstrumentCB.SelectedItem as String;
            // System.Windows.MessageBox.Show($"Selected Item: {selectedItem}");

            SessionCB.Items.Clear();
            SoftwareCB.Items.Clear();

            Metadata data = (Metadata)DataContext;

            switch (selectedItem)
            {
                case "L120C":
                    List<string> sessionItems_L120C = new List<string> { "Screening Session", "Tomography Session", "Single Particle Session", "Other" };
                    foreach (var item in sessionItems_L120C) {  SessionCB.Items.Add(item); }

                    List<string> softwareItems_L120C = new List<string> { "SerialEM" };
                    foreach (var item in softwareItems_L120C) {  SoftwareCB.Items.Add(item); }

                    data.SetupL120C();

                    break;
                case "Arctica":
                    List<string> sessionItems_Arctica = new List<string> { "Screening Session", "Tomography Session", "Single Particle Session", "Other" };
                    foreach (var item in sessionItems_Arctica) { SessionCB.Items.Add(item); }

                    List<string> softwareItems_Arctica = new List<string> { "SerialEM", "EPU", "Tomo5" };
                    foreach (var item in softwareItems_Arctica) { SoftwareCB.Items.Add(item); }

                    data.SetupArctica();

                    break;

                case "Krios G3i":
                    List<string> sessionItems_G3i = new List<string> { "Screening Session", "Tomography Session", "Single Particle Session", "Microcrystal Electron Diffraction Session", "Other" };
                    foreach (var item in sessionItems_G3i) { SessionCB.Items.Add(item); }

                    List<string> softwareItems_G3i = new List<string> { "SerialEM", "EPU", "EPUD", "Tomo5" };
                    foreach (var item in softwareItems_G3i) { SoftwareCB.Items.Add(item); }

                    data.SetupKriosG3i();

                    break;

                case "Krios G4":
                    List<string> sessionItems_G4 = new List<string> { "Screening Session", "Tomography Session", "Single Particle Session", "Microcrystal Electron Diffraction Session", "Other" };
                    foreach (var item in sessionItems_G4) { SessionCB.Items.Add(item); }

                    List<string> softwareItems_G4 = new List<string> { "SerialEM", "EPU", "EPUD", "Tomo5" };
                    foreach (var item in softwareItems_G4) { SoftwareCB.Items.Add(item); }

                    data.SetupKriosG4();

                    break;

                default:
                    List<string> sessionItems_Default = new List<string> { "Screening Session", "Tomography Session", "Single Particle Session", "Microcrystal Electron Diffraction Session", "Other" };
                    foreach (var item in sessionItems_Default) { SessionCB.Items.Add(item); }

                    List<string> softwareItems_Default = new List<string> { "SerialEM", "EPU", "EPUD", "Tomo5" };
                    foreach (var item in softwareItems_Default) { SoftwareCB.Items.Add(item); }

                    break;
            }
        }
    }
}
