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

            // Setup a dictionary for commandline arguments.
            string[] args = Environment.GetCommandLineArgs();

            // If specified, choose a default state for the metadata.
            Dictionary<string, string> arguments =
                new Dictionary<string, string>();

            Console.WriteLine("Should have arguments:");

            for (int index = 1; index < args.Length; index += 2)
            {
                string arg = args[index].Replace("--", "");
                Console.WriteLine("Found this argument: " + arg);
                if (args.Length > index + 1)
                {
                    string value = args[index + 1].Replace("_", " ");
                    arguments.Add(arg, value);
                }
            }

            Metadata state = new Metadata();
            if (arguments.ContainsKey("instrument"))
            {
                state.SetDefaults(arguments["instrument"]);
            }

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
