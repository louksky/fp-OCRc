using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comparlize
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            Thread.Sleep(2500);
            this.Close();
        }
    }
}
