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
            }
            else {
                Page p;
                if (data.Instrument == "L120C")
                {
                    p = new PageOpticsL120C((Metadata)DataContext);
                } else
                {
                    p = new PageOptics((Metadata)DataContext);
                }
                this.NavigationService.Navigate(p);
            }
        }

    }
}
