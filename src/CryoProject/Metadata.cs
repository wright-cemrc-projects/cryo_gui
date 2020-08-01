using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryoProject
{
    class Metadata
    {
        public string notes { get; set; }
        public float pixel_size { get; set; }
        public int voltage { get; set; }
        public float spherical_aberration { get; set; }
        public float amplitude_contrast { get; set; }
        public List<string> image_directories { get; set; }
    }
}
