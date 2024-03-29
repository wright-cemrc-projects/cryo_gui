﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryoProject
{
    [Serializable]
    public class Metadata : INotifyPropertyChanged
    {
        // 1.06 adding fields for ModeOfCamera
        // 1.06 adding fields for OperatorID
        // 1.10 adding separate page for L120C options
        // 1.30 updating tomography page for VolZ and documentations.

        private String m_version = "1.3";
        public String Version
        {
            get { return m_version; }
            set
            {
                m_version = value;
                OnPropertyChanged("Version");
            }

        }

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

        private String m_instrument = "";
        public string Instrument
        {
            get { return m_instrument; }
            set
            {
                m_instrument = value;
                OnPropertyChanged("Insturment");
            }
        }


        private String m_operator = "";
        public String Operator
        {
            get { return m_operator; }
            set
            {
                m_operator = value;
                OnPropertyChanged("Operator");
            }
        }

        private String m_user = "";
        public String User
        {
            get { return m_user; }
            set
            {
                m_user = value;
                OnPropertyChanged("User");
            }
        }

        private String m_group = "";
        public String Group
        {
            get { return m_group; }
            set
            {
                m_group = value;
                OnPropertyChanged("Group");
            }
        }

        private String m_sampleDescription = "";
        public String SampleDescription
        {
            get { return m_sampleDescription; }
            set
            {
                m_sampleDescription = value;
                OnPropertyChanged("SampleDescription");
            }
        }

        private String m_biosafetyLevel = "";
        public String BiosafetyLevel
        {
            get { return m_biosafetyLevel; }
            set
            {
                m_biosafetyLevel = value;
                OnPropertyChanged("BiosafetyLevel");
            }
        }

        private String m_referenceDescription = "";
        public String ReferenceDescription
        {
            get { return m_referenceDescription; }
            set
            {
                m_referenceDescription = value;
                OnPropertyChanged("ReferenceDescription");
            }
        }

        private String m_purposeDescription = "";
        public String PurposeDescription
        {
            get { return m_purposeDescription; }
            set
            {
                m_purposeDescription = value;
                OnPropertyChanged("PurposeDescription");
            }
        }

        private String m_imagingMode = "TEM";
        public String ImagingMode
        {
            get { return m_imagingMode; }
            set
            {
                m_imagingMode = value;
                OnPropertyChanged("ImagingMode");
            }
        }

        private String m_imagingProbe = "NanoProbe";
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

        private float m_dosePerTiltSeries = 1.0f;
        public float DosePerTiltSeries
        {
            get { return m_dosePerTiltSeries; }
            set
            {
                m_dosePerTiltSeries = value;
                OnPropertyChanged("DosePerTiltSeries");
            }
        }

        private float m_dosePerFrame = 1.0f;
        public float DosePerFrame
        {
            get { return m_dosePerFrame; }
            set
            {
                m_dosePerFrame = value;
                OnPropertyChanged("DosePerFrame");
            }
        }

        private float m_doseRate = 1.0f;
        public float DoseRate
        {
            get { return m_doseRate; }
            set
            {
                m_doseRate = value;
                OnPropertyChanged("DoseRate");
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

        private float m_c2aperture = 100.0f;
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

        private float m_objectiveAperture = 100;
        public float ObjectiveAperture
        {
            get { return m_objectiveAperture; }
            set
            {
                m_objectiveAperture = value;
                OnPropertyChanged("ObjectiveAperture");
            }
        }

        private string m_typeOfCamera = "Gatan K3";
        public string TypeOfCamera
        {
            get { return m_typeOfCamera; }
            set
            {
                m_typeOfCamera = value;
                OnPropertyChanged("TypeOfCamera");
            }
        }

        private string m_modeOfCamera = "Not Available";
        public string ModeOfCamera
        {
            get { return m_modeOfCamera; }
            set
            {
                m_modeOfCamera = value;
                OnPropertyChanged("ModeOfCamera");
            }
        }

        private int m_numberOfFrames = 1;
        public int NumberOfFrames
        {
            get { return m_numberOfFrames; }
            set
            {
                m_numberOfFrames = value;
                OnPropertyChanged("NumberOfFrames");
            }
        }

        private int m_discardFirstFrames = 0;
        public int DiscardFirstFrames
        {
            get { return m_discardFirstFrames; }
            set
            {
                m_discardFirstFrames = value;
                OnPropertyChanged("DiscardFirstFrames");
            }
        }


        private string m_typeOfSession = "Screening Session";
        public string TypeOfSession
        {
            get { return m_typeOfSession; }
            set
            {
                m_typeOfSession = value;
                OnPropertyChanged("TypeOfSession");
            }
        }

        private string m_typeOfSoftware = "EPU";
        public string TypeOfSoftware
        {
            get { return m_typeOfSoftware; }
            set
            {
                m_typeOfSoftware = value;
                OnPropertyChanged("TypeOfSoftware");
            }
        }

        private float m_energyFilterSlitWidth = 0f;
        public float EnergyFilterSlitWidth
        {
            get { return m_energyFilterSlitWidth; }
            set
            {
                m_energyFilterSlitWidth = value;
                OnPropertyChanged("EnergyFilterSlitWidth");
            }
        }

        private string m_usingPhasePlate = "No";
        public string UsingPhasePlate
        {
            get { return m_usingPhasePlate; }
            set
            {
                m_usingPhasePlate = value;
                OnPropertyChanged("UsingPhasePlate");
            }
        }

        private string m_holder = "single-tilt";
        public string Holder
        {
            get { return m_holder; }
            set
            {
                m_holder = value;
                OnPropertyChanged("Holder");
            }
        }

        private string m_usingCDS = "No";
        public string UsingCDS
        {
            get { return m_usingCDS; }
            set
            {
                m_usingCDS = value;
                OnPropertyChanged("UsingCDS");
            }
        }

        /* DEPRECATATED
        private string m_tiltSeries = "Yes";
        public string TiltSeries
        {
            get { return m_tiltSeries; }
            set
            {
                m_tiltSeries = value;
                OnPropertyChanged("TiltSeries");
            }
        }
        */

        // Tilt-scheme (NA, uni-directional, bidirectional)
        private string m_tiltScheme = "NA";
        public string TiltScheme
        {
            get { return m_tiltScheme; }
            set
            {
                m_tiltScheme = value;
                OnPropertyChanged("TiltScheme");
            }
        }

        // Tilt-angle (2 or 3 degrees)
        private float m_tiltAngle = 2;
        public float TiltAngle
        {
            get { return m_tiltAngle; }
            set
            {
                m_tiltAngle = value;
                OnPropertyChanged("TiltAngle");
            }
        }

        // [Deprecated 1.10]
        // Tilt-range (0 degrees, disable checks)
        private float m_tiltRange = 0;
        public float TiltRange
        {
            get { return m_tiltRange; }
            set
            {
                m_tiltRange = value;
                OnPropertyChanged("TiltRange");
            }
        }

        private string m_tiltDirectory = "";
        public string TiltDirectory
        {
            get { return m_tiltDirectory; }
            set
            {
                m_tiltDirectory = value;
                OnPropertyChanged("TiltDirectory");
            }
        }

        private int m_AreTomo_VolZ = 1600;
        public int AreTomo_VolZ
        {
            get { return m_AreTomo_VolZ; }
            set
            {
                m_AreTomo_VolZ = value;
                OnPropertyChanged("AreTomo_VolZ");
            }
        }

        private int m_AreTomo_AlignZ = 1200;
        public int AreTomo_AlignZ
        {
            get { return m_AreTomo_AlignZ; }
            set
            {
                m_AreTomo_AlignZ = value;
                OnPropertyChanged("AreTomo_AlignZ");
            }
        }

        private string m_AreTomo_TiltCor = "Disabled";
        public string AreTomo_TiltCor
        {
            get { return m_AreTomo_TiltCor; }
            set
            {
                m_AreTomo_TiltCor = value;
                OnPropertyChanged("AreTomo_TiltCor");
            }
        }

        private string m_AreTomo_Patch = "Enabled";
        public string AreTomo_Patch
        {
            get { return m_AreTomo_Patch; }
            set
            {
                m_AreTomo_Patch = value;
                OnPropertyChanged("AreTomo_Patch");
            }
        }

        // Whether backend processing is enabled.
        /** [DEPRECATED in 1.11]
        private string m_workflow = "On";
        public string Workflow
        {
            get { return m_workflow; }
            set
            {
                m_workflow = value;
                OnPropertyChanged("Workflow");
            }
        }
        */

        private string m_workflowOptions = "MotionCor2";
        public string WorkflowOptions
        {
            get { return m_workflowOptions; }
            set
            {
                m_workflowOptions = value;
                OnPropertyChanged("WorkflowOptions");
            }
        }

        private bool m_projectSet = false;
        public bool ProjectSet
        {
            get { return m_projectSet; }
        }

        private string m_locationProject = ".";
        public string LocationProject
        {
            get { return m_locationProject; }
            set
            {
                if (Directory.Exists(value))
                {
                    m_projectSet = true;
                    m_locationProject = value;
                    OnPropertyChanged("LocationProject");
                }
            }
        }

        // DEPRECATED
        /*
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

        private string m_locationDestinationFrames = ".";
        public string LocationDestinationFrames
        {
            get { return m_locationDestinationFrames; }
            set
            {
                m_locationDestinationFrames = value;
                OnPropertyChanged("LocationDestinationFrames");
            }
        }
        */

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

        public String BuildText()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            // Page 1 : Project Info
            builder.AppendLine("Date = " + Date);
            builder.AppendLine("Instrument = " + Instrument);
            builder.AppendLine("Operator = " + Operator);
            builder.AppendLine("Client NetID = " + User);
            builder.AppendLine("Client Group = " + Group);
            builder.AppendLine("Sample = " + SampleDescription);
            builder.AppendLine("Biosafety Level = " + BiosafetyLevel);
            builder.AppendLine("Type of grid = " + TypeOfGrid);
            builder.AppendLine("Reference = " + ReferenceDescription);
            builder.AppendLine("Purpose = " + PurposeDescription);
            builder.AppendLine("Software = " + TypeOfSoftware);
            builder.AppendLine("Location of project = " + LocationProject);
            builder.AppendLine();

            // Page 2 : Optics
            builder.AppendLine("Imaging mode = " + ImagingMode);
            builder.AppendLine("Imaging probe = " + ImagingProbe);
            builder.AppendLine("Spot size = " + SpotSize);
            builder.AppendLine("C2 Aperture = " + C2Aperture);
            builder.AppendLine("C2 Lens Power = " + C2LensPower);
            builder.AppendLine("Illuminated area = " + IlluminatedArea);
            builder.AppendLine("Objective aperture = " + ObjectiveAperture);

            // Exclude for L120C:
            if (!Instrument.Equals("L120C"))
            {
                builder.AppendLine("Energy filter slit width (eV) = " + EnergyFilterSlitWidth);
                builder.AppendLine("Acceleration voltage = " + Voltage);
                builder.AppendLine("Using Phase Plate? = " + UsingPhasePlate);
            }
            builder.AppendLine();

            // Page 3 : Image 
            builder.AppendLine("Type of camera = " + TypeOfCamera);
            if (!Instrument.Equals("L120C"))
            {
                builder.AppendLine("Camera mode = " + ModeOfCamera);
                builder.AppendLine("Using CDS = " + UsingCDS);
            }

            if (TypeOfSession.Equals("Tomography Session"))
            {
                builder.AppendLine("Pixel size (A) (unbinned) = " + PixelSize);
                builder.AppendLine("Dose per tilt (e-/A2) = " + DosePerImage);
                builder.AppendLine("Total dose (e-/A2) = " + DosePerTiltSeries);
                builder.AppendLine("Exposure time per tilt (sec) = " + ExposureTimePerImage);
                builder.AppendLine("Dose rate (e-/pixel/sec) = " + DoseRate);
            } else 
            {
                builder.AppendLine("Pixel size (A) (unbinned) = " + PixelSize);
                builder.AppendLine("Total dose per image (e-/A2) = " + DosePerImage);
                builder.AppendLine("Number of frames = " + NumberOfFrames);
                builder.AppendLine("Dose per frame (e-/A2) = " + DosePerFrame);
                builder.AppendLine("Exposure time (sec) = " + ExposureTimePerImage);

                // Exclude for L120C:
                if (!Instrument.Equals("L120C"))
                {
                    builder.AppendLine("Dose rate (e-/pixel/sec) = " + DoseRate);
                    builder.AppendLine("Number of fractions = " + NumberOfFrames);
                }
            } 

            builder.AppendLine();

            // Page 4 : EPU specific
            builder.AppendLine("Location of EPU presets = " + LocationEPUPresets);
            builder.AppendLine("Location of EPU preferences = " + LocationEPUPreferences);
            builder.AppendLine();

            // Page 5 : Processing specific information
            builder.AppendLine("Automated processing options = " + WorkflowOptions);

            if (TypeOfSession.Equals("Tomography Session"))
            {
                builder.AppendLine("Tilt Scheme: " + TiltScheme);
                builder.AppendLine("Tilt Angle (degrees): " + TiltAngle);
                builder.AppendLine("Tilt Range (degrees): " + TiltRange);
                builder.AppendLine("AreTomo VolZ: " + AreTomo_VolZ);
                builder.AppendLine("AreTomo AlignZ: " + AreTomo_AlignZ);
                builder.AppendLine("AreTomo TiltCor: " + AreTomo_TiltCor);
                builder.AppendLine("AreTomo Patch: " + AreTomo_Patch);
            }

            return builder.ToString();
        }

        public void WriteToDisk(string readmePath)
        {
            using (StreamWriter outputFile = new StreamWriter(readmePath))
            {
                outputFile.Write(BuildText());
            }
        }
    }
}
