using Newtonsoft.Json;
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

            string dataset = System.IO.Path.Combine(data.ProjectPath, "dataset.json");

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
