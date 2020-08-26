﻿ using Newtonsoft.Json;
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

    /// <summary>
    /// Interaction logic for CollectionDonePage.xaml
    /// </summary>
    public partial class CollectionDonePage : Page { 
        
        public CollectionDonePage(Metadata data)
        {
            InitializeComponent();
            DataContext = data;

            TextBlock block = (TextBlock) FindName("results");
            block.Text = data.BuildText();
        }

        private void SaveProjectJSON()
        {
            Metadata data = (Metadata)DataContext;

            string dataset = System.IO.Path.Combine(data.LocationProject, "dataset.json");

            //open file stream
            using (StreamWriter file = File.CreateText(dataset))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, data);
            }
        }

        private void SaveProjectTextfile()
        {
            Metadata data = (Metadata)DataContext;

            // Write a human-readable notes
            string readmePath = System.IO.Path.Combine(data.LocationProject, "README.txt");
            data.WriteToDisk(readmePath);
        }

        private void Done(object sender, RoutedEventArgs e)
        {
            SaveProjectJSON();
            SaveProjectTextfile();
            System.Windows.Application.Current.Shutdown();
        }
    }
}
