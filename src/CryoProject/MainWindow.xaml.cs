using Newtonsoft.Json;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryoProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            Metadata state = new Metadata();

            string filename = "defaults.json";

            // Try loading "default.json" which could provide per instrument settings.
            if (File.Exists(filename))
            {
                using (StreamReader file = File.OpenText(filename))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    state = (Metadata)serializer.Deserialize(file, typeof(Metadata));
                    state.Date = DateTime.Now;
                }
            }

            // Create the application state and set for the first time.
            Content = new PageProjectInfo(state);
        }
    }
}
