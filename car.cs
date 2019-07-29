using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace comparlize
{
    class car
    {
        public List<image> list;
        public List<image> dlist;
        public string id;
        public car(string ID)
        {
            list = new List<image>();
            dlist = new List<image>();
            id = ID;
        }
    }
    class icar
    {
        string id;
        string counter;
    }
}
