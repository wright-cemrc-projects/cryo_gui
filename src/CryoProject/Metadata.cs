using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryoProject
{
    class Metadata : INotifyPropertyChanged
    {
        private DateTime m_date = DateTime.Now;
        public DateTime Date
        {
            get { return m_date; }
            set
            {
                m_date = value;
                OnPropertyChanged("Date");
            }
        }

        private String m_user = "(First, Last Name)";
        public String User
        {
            get { return m_user; }
            set
            {
                m_user = value;
                OnPropertyChanged("User");
            }
        }

        private String m_sampleDescription = "(Describe your experiment)";
        public String SampleDescription
        {
            get { return m_sampleDescription; }
            set
            {
                m_sampleDescription = value;
                OnPropertyChanged("SampleDescription");
            }
        }

        public float m_pixelSize = 1.0f;
        public float PixelSize
        {
            get { return m_pixelSize; }
            set
            {
                m_pixelSize = value;
                OnPropertyChanged("PixelSize");
            }
        }

        public int m_voltage = 300;
        public int Voltage
        {
            get { return m_voltage; }
            set
            {
                m_voltage = value;
                OnPropertyChanged("Voltage");
            }
        }

        public float m_dosePerImage = 1.0f;
        public float DosePerImage
        {
            get { return m_dosePerImage; }
            set
            {
                m_dosePerImage = value;
                OnPropertyChanged("DosePerImage");
            }
        }

        public float m_sphericalAberration = 2.7f;
        public float SphericalAberration
        {
            get { return m_sphericalAberration; }
            set
            {
                m_sphericalAberration = value;
                OnPropertyChanged("SphericalAberration");
            }
        }

        public float m_amplitudeContrast = 0.1f;
        public float AmplitudeContrast
        {
            get { return m_amplitudeContrast; }
            set
            {
                m_amplitudeContrast = value;
                OnPropertyChanged("AmplitudeContrast");
            }
        }

        private string m_projectPath;
        public string ProjectPath
        {
            get { return m_projectPath; }
            set
            {
                m_projectPath = value;
                OnPropertyChanged("ProjectPath");
            }
        }


        // Data model changed events.
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
