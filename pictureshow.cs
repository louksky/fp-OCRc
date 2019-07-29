using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comparlize
{
    public partial class pictureshow : Form
    {
        public pictureshow(Bitmap bm1, Bitmap bm2, Bitmap bm3)
        {
            InitializeComponent();

            pictureBox1.Image = bm1;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = bm2;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = bm3;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
