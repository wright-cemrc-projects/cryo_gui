using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryoProject
{
    public class Metadata : INotifyPropertyChanged
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

        private String m_referenceDescription = "(Reference to notes)";
        public String ReferenceDescription
        {
            get { return m_referenceDescription; }
            set
            {
                m_referenceDescription = value;
                OnPropertyChanged("ReferenceDescription");
            }
        }

        private String m_purposeDescription = "(Short description for purpose)";
        public String PurposeDescription
        {
            get { return m_purposeDescription; }
            set
            {
                m_purposeDescription = value;
                OnPropertyChanged("PurposeDescription");
            }
        }

        private String m_imagingMode = "(TEM/EFTEM)";
        public String ImagingMode
        {
            get { return m_imagingMode; }
            set
            {
                m_imagingMode = value;
                OnPropertyChanged("ImagingMode");
            }
        }

        private String m_imagingProbe = "(Microprobe/Nanoprobe)";
        public String ImagingProbe
        {
            get { return m_imagingProbe; }
            set
            {
                m_imagingProbe = value;
                OnPropertyChanged("ImagingProbe");
            }
        }

        private float m_pixelSize = 1.0f;
        public float PixelSize
        {
            get { return m_pixelSize; }
            set
            {
                m_pixelSize = value;
                OnPropertyChanged("PixelSize");
            }
        }

        private int m_voltage = 300;
        public int Voltage
        {
            get { return m_voltage; }
            set
            {
                m_voltage = value;
                OnPropertyChanged("Voltage");
            }
        }

        private float m_dosePerImage = 1.0f;
        public float DosePerImage
        {
            get { return m_dosePerImage; }
            set
            {
                m_dosePerImage = value;
                OnPropertyChanged("DosePerImage");
            }
        }

        private float m_exposureTimePerImage = 1.0f;
        public float ExposureTimePerImage
        {
            get { return m_exposureTimePerImage; }
            set
            {
                m_exposureTimePerImage = value;
                OnPropertyChanged("ExposureTimePerImage");
            }
        }

        private float m_spotSize = 1.0f;
        public float SpotSize
        {
            get { return m_spotSize; }
            set
            {
                m_spotSize = value;
                OnPropertyChanged("SpotSize");
            }
        }

        private float m_sphericalAberration = 2.7f;
        public float SphericalAberration
        {
            get { return m_sphericalAberration; }
            set
            {
                m_sphericalAberration = value;
                OnPropertyChanged("SphericalAberration");
            }
        }

        private float m_amplitudeContrast = 0.1f;
        public float AmplitudeContrast
        {
            get { return m_amplitudeContrast; }
            set
            {
                m_amplitudeContrast = value;
                OnPropertyChanged("AmplitudeContrast");
            }
        }

        private float m_c2aperture = 0.1f;
        public float C2Aperture
        {
            get { return m_c2aperture; }
            set
            {
                m_c2aperture = value;
                OnPropertyChanged("C2Aperture");
            }
        }

        private float m_c2lensPower = 0.1f;
        public float C2LensPower
        {
            get { return m_c2lensPower; }
            set
            {
                m_c2lensPower = value;
                OnPropertyChanged("C2LensPower");
            }
        }

        private float m_illuminatedArea = 0.1f;
        public float IlluminatedArea
        {
            get { return m_illuminatedArea; }
            set
            {
                m_illuminatedArea = value;
                OnPropertyChanged("IlluminatedArea");
            }
        }

        private String m_typeOfGrid = "Carbon Foil";
        public String TypeOfGrid
        {
            get { return m_typeOfGrid; }
            set
            {
                m_typeOfGrid = value;
                OnPropertyChanged("TypeOfGrid");
            }
        }

        private float m_objectiveAperture = 10000;
        public float ObjectiveAperture
        {
            get { return m_objectiveAperture; }
            set
            {
                m_objectiveAperture = value;
                OnPropertyChanged("ObjectiveAperture");
            }
        }

        private string m_typeOfCamera = "CETA";
        public string TypeOfCamera
        {
            get { return m_typeOfCamera; }
            set
            {
                m_typeOfCamera = value;
                OnPropertyChanged("TypeOfCamera");
            }
        }

        private string m_locationProject = ".";
        public string LocationProject
        {
            get { return m_locationProject; }
            set
            {
                m_locationProject = value;
                OnPropertyChanged("LocationProject");
            }
        }

        private string m_locationFrames = ".";
        public string LocationFrames
        {
            get { return m_locationFrames; }
            set
            {
                m_locationFrames = value;
                OnPropertyChanged("LocationFrames");
            }
        }

        private string m_locationEPUPresets = ".";
        public string LocationEPUPresets
        {
            get { return m_locationEPUPresets; }
            set
            {
                m_locationEPUPresets = value;
                OnPropertyChanged("LocationEPUPresets");
            }
        }

        private string m_locationEPUPreferences = ".";
        public string LocationEPUPreferences
        {
            get { return m_locationEPUPreferences; }
            set
            {
                m_locationEPUPreferences = value;
                OnPropertyChanged("LocationEPUPreferences");
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
