using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
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
    public class OutputJson
    {
        public DateTime date { get; set; }
        public string name { get; set; }
        public string sample_description { get; set; }
        public float spherical_aberration { get; set; }
        public float pixel_size { get; set; }
        public int voltage { get; set; }
        public float dose_per_image { get; set; }
        public float amplitude_contrast { get; set; }
    }

    /// <summary>
    /// Interaction logic for CollectionDonePage.xaml
    /// </summary>
    public partial class CollectionDonePage : Page { 
        
        public CollectionDonePage(Metadata data)
        {
            InitializeComponent();
            DataContext = data;
        }

        private void SaveProjectJSON()
        {
            Metadata data = (Metadata)DataContext;
            
            // write a JSON file
            OutputJson json = new OutputJson();
            json.date = data.Date;
            json.name = data.User;
            json.sample_description = data.SampleDescription;
            json.spherical_aberration = data.SphericalAberration;
            json.pixel_size = data.PixelSize;
            json.voltage = data.Voltage;
            json.dose_per_image = data.DosePerImage;
            json.amplitude_contrast = data.AmplitudeContrast;

            string dataset = System.IO.Path.Combine(data.LocationProject, "dataset.json");

            //open file stream
            using (StreamWriter file = File.CreateText(dataset))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, json);
            }
        }

        private void SaveProjectTextfile()
        {
            Metadata data = (Metadata)DataContext;

            // Write a human-readable notes
            string readmePath = System.IO.Path.Combine(data.LocationProject, "README.txt");
            using (StreamWriter outputFile = new StreamWriter(readmePath))
            {
                outputFile.WriteLine("Date = " + data.Date);
                outputFile.WriteLine("Sample = " + data.SampleDescription);
                outputFile.WriteLine("Reference = " + data.ReferenceDescription);
                outputFile.WriteLine("Purpose = " + data.PurposeDescription);
                outputFile.WriteLine("Imaging mode (TEM, EFTEM) = " + data.ImagingMode);
                outputFile.WriteLine("Imaging probe = " + data.ImagingProbe);
                outputFile.WriteLine("Pixel size = " + data.PixelSize);
                outputFile.WriteLine("Acceleration voltage = " + data.Voltage);
                outputFile.WriteLine("Total dose per image (e-/A2) = " + data.DosePerImage);
                outputFile.WriteLine("Exposure time (sec) = " + data.ExposureTimePerImage);
                outputFile.WriteLine("Spot size = " + data.SpotSize);
                outputFile.WriteLine("C2 Aperture = " + data.C2Aperture);
                outputFile.WriteLine("C2 Lens Power = " + data.C2LensPower);
                outputFile.WriteLine("Illuminated area = " + data.IlluminatedArea);
                outputFile.WriteLine("Type of grid = " + data.TypeOfGrid);
                outputFile.WriteLine("Objective aperture = " + data.ObjectiveAperture);
                outputFile.WriteLine("Type of camera = " + data.TypeOfCamera);
                outputFile.WriteLine("Location of project = " + data.LocationProject);
                outputFile.WriteLine("Location of frames = " + data.LocationFrames);
                outputFile.WriteLine("Location of EPU presets = " + data.LocationEPUPresets);
                outputFile.WriteLine("Location of EPU preferences = " + data.LocationEPUPreferences);
            }
        }

        private void Done(object sender, RoutedEventArgs e)
        {
            SaveProjectJSON();
            SaveProjectTextfile();
            System.Windows.Application.Current.Shutdown();
        }
    }
}
