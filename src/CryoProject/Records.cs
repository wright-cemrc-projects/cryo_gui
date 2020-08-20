using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryoProject
{
    namespace Config { 

        public class Rootobject
        {
            public Page[] pages { get; set; }
        }

        public class Page
        {
            public string title { get; set; }
            public Field[] fields { get; set; }
        }

        public class Field
        {
            public string name { get; set; }
            public string type { get; set; }
            public string hint { get; set; }
            public Option[] options { get; set; }
            public string unit { get; set; }
        }

        public class Option
        {
            public string name { get; set; }
        }
    }
}
