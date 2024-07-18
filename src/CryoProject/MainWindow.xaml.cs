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
using Microsoft.Win32;

namespace CryoProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        // Make this field locked to avoid choosing other incorrect options.
        private bool editableInstrument = true;

        public MainWindow()
        {
            InitializeComponent();
            NewProject();
        }

        private void ClearNavigationHistory()
        {
            var navigationService = MainFrame.NavigationService;
            while (navigationService.CanGoBack)
            {
                navigationService.RemoveBackEntry();
            }
        }

        private void NewProject() { 

            // Setup a dictionary for commandline arguments.
            string[] args = Environment.GetCommandLineArgs();

            // If specified, choose a default state for the metadata.
            Dictionary<string, string> arguments =
                new Dictionary<string, string>();

            for (int index = 1; index < args.Length; index += 2)
            {
                string arg = args[index].Replace("--", "");
                if (args.Length > index + 1)
                {
                    string value = args[index + 1].Replace("_", " ");
                    arguments.Add(arg, value);
                    Console.WriteLine("Found this argument: " + arg + " " + value);
                }
            }

            Metadata state = new Metadata();
            if (arguments.ContainsKey("instrument"))
            {
                state.SetDefaults(arguments["instrument"]);
            }

            if (arguments.ContainsKey("lock"))
            {
                editableInstrument = false;
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

            // Clear navigation history after navigation
            // MainFrame.Navigated += (s, n_args) => ClearNavigationHistory();

            // Create the application state and set for the first time.
            PageProjectInfo p = new PageProjectInfo(state);
            p.InstrumentCB.IsEnabled = editableInstrument;
            MainFrame.Navigate(p);

        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            // Handle New menu item click
            NewProject();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            // Handle Open menu item click
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON file (*.json)|*.json|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                // Handle file open logic here
                string selectedFilePath = openFileDialog.FileName;

                // Read the content of the file
                string fileContent = File.ReadAllText(openFileDialog.FileName);
                Metadata meta = JsonConvert.DeserializeObject<Metadata>(fileContent);

                // Clear navigation history after navigation
                // MainFrame.Navigated += (s, n_args) => ClearNavigationHistory();
                PageProjectInfo p = new PageProjectInfo(meta);
                p.InstrumentCB.IsEnabled = editableInstrument;
                MainFrame.Navigate(new PageProjectInfo(meta));
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            // Handle Exit menu item click
            this.Close();
        }
    }
}
