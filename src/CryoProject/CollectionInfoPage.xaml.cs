﻿using System;
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
    public partial class CollectionInfoPage : Page
    {
        // Will be updated and used to save results.
        public CollectionInfoPage()
        {
            InitializeComponent();
            this.DataContext = new Metadata();
        }

        private void SaveProjectJSON()
        {
            Metadata data = (Metadata)DataContext;
            System.Windows.Forms.MessageBox.Show("Notes: " + data.SampleDescription, "Message");
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
                    data.ProjectPath = fbd.SelectedPath;
                }
            }
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            CollectionSoftwarePage p = new CollectionSoftwarePage();
            this.NavigationService.Navigate(p);
        }

     }
}
