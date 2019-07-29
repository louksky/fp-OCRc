using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging;
using System.Drawing.Imaging;

namespace comparlize
{
   
    public partial class Poc : Form
    {
        
        List<dpoint> deltagroup = new List<dpoint>();
        static int group = 1;
        public Poc()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            // Load the images.
            Bitmap bm1 = (Bitmap)pictureBox1.Image;
            Bitmap bm2 = (Bitmap)pictureBox2.Image;

            // Make a difference image.
            int wid = Math.Min(bm1.Width, bm2.Width);
            int hgt = Math.Min(bm1.Height, bm2.Height);

            // Get the differences.
            int[,] diffs = new int[wid, hgt];
            
            int max_diff = 0;
            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hgt; y++)
                {
                    // Calculate the pixels' difference.
                    Color color1 = bm1.GetPixel(x, y);
                    Color color2 = bm2.GetPixel(x, y);
                    diffs[x, y] = (int)(
                        Math.Abs(color1.R - color2.R) +
                        Math.Abs(color1.G - color2.G) +
                        Math.Abs(color1.B - color2.B));
                    if (diffs[x, y] > max_diff)
                        max_diff = diffs[x, y];
                }
            }
            //max_diff = 255;
            dpoint p;
            Boolean added = false;
            // Create the difference image.
            Bitmap bm3 = new Bitmap(wid, hgt);
            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hgt; y++)
                {
                    if (diffs[x, y] != 0)
                    {
                        p = new dpoint();
                        p.p.X = x; p.p.Y = y;
                        p.value = diffs[x, y];
                        added = false;
                        if (deltagroup.Count == 0)
                        {
                            p.group = group;
                            deltagroup.Add(p);
                            added = true;
                        }
                        foreach (dpoint dd in deltagroup)
                        {

                            if (canGroupingEdges(p.p.X, dd.p.X) && canGroupingEdges(dd.p.Y, p.p.Y))
                            {
                                p.group = dd.group;
                                deltagroup.Add(p);
                                added = true;
                                break;
                            }
                        }
                        if (added == false)
                        {
                            p.group = ++group;
                            deltagroup.Add(p);
                        }
                    }
                    int clr = 255 - (int)(255.0 / max_diff * diffs[x, y]);
                    bm3.SetPixel(x, y, Color.FromArgb(clr, clr, clr));
                }
            }
          
            

            // Display the result.
            pictureBox3.Image = bm3;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            Graphics g = Graphics.FromImage(pictureBox3.Image);
            ListViewItem l;
            Font f = new Font("Times New Roman", 6);
           for(int i =1;i<=group;++i)
            {
                foreach (dpoint dd in deltagroup)
                {
                    if (dd.group == i)
                    {
                        
                        g.DrawString("hit("+dd.p.X+","+dd.p.Y+") v"+dd.value+"|" + dd.group, f, Brushes.Red, dd.p);
                        listBox1.Items.Add("hit num("+ dd.group + ") in(" + dd.p.X + ", " + dd.p.Y + ") value: " + dd.value + ". " );
                        i++;
                    }
                }
            }

            DateTime end = DateTime.Now;
            label2.Text = (end - start).ToString();
            this.Cursor = Cursors.Default;
        }
        private bool canGroupingEdges(int t , int t2 )
        {
            return Math.Abs(t-t2) <= 2;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            // Load the images.
            Bitmap bm1 = (Bitmap)pictureBox1.Image;
            Bitmap bm2 = (Bitmap)pictureBox2.Image;

            // Make a difference image.
            int wid = Math.Min(bm1.Width, bm2.Width);
            int hgt = Math.Min(bm1.Height, bm2.Height);
            Bitmap bm3 = new Bitmap(wid, hgt);

            // Create the difference image.
            bool are_identical = true;
            Color eq_color = Color.White;
            Color ne_color = Color.Red;
            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hgt; y++)
                {
                    if (bm1.GetPixel(x, y).Equals(bm2.GetPixel(x, y)))
                        bm3.SetPixel(x, y, eq_color);
                    else
                    {
                        bm3.SetPixel(x, y, ne_color);
                        are_identical = false;
                    }
                }
            }

            // Display the result.
            pictureBox3.Image = bm3;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Cursor = Cursors.Default;
            if ((bm1.Width != bm2.Width) || (bm1.Height != bm2.Height)) are_identical = false;

            DateTime end = DateTime.Now;
            label2.Text = (end - start).ToString();

           // if (are_identical)
                //lblResult.Text = "The images are identical";
            //else
                //lblResult.Text = "The images are different";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if(openFileDialog1.CheckFileExists)
            textBox1.Text = openFileDialog1.FileName;
            pictureBox1.Image = System.Drawing.Image.FromFile(@""+ textBox1.Text);
            //pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            //pictureBox1.Image = pictureBox1.Image.GetThumbnailImage(1024, 1024, null, IntPtr.Zero);
        }//hellouk

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            if(openFileDialog1.CheckFileExists)
            textBox2.Text = openFileDialog2.FileName;
            pictureBox2.Image = System.Drawing.Image.FromFile(@"" + textBox2.Text);
            //pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
            //pictureBox2.Image= pictureBox2.Image.GetThumbnailImage(1024, 1024, null, IntPtr.Zero);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            pictureBox1.Image = ImageBrightnessNormalizer.NormalizeImageBrightness(new
             Bitmap(pictureBox1.Image));
            pictureBox2.Image = ImageBrightnessNormalizer.NormalizeImageBrightness(new
                         Bitmap(pictureBox2.Image));
            this.Cursor = Cursors.Default;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if(folderBrowserDialog1.SelectedPath.Length > 0)
            {
                pictureBox3.Image.Save("a.jpg");
            }
        }
        public class dpoint
        {
            public Point p;
            public int value;
            public int group;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap b = (Bitmap)pictureBox1.Image;
            ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0.925f);
            // find all matchings with specified above similarity
            TemplateMatch[] matchings = tm.ProcessImage(b, (Bitmap)pictureBox2.Image);
            // highlight found matchings
            BitmapData data = b.LockBits(
                new Rectangle(0, 0, b.Width, b.Height),
                ImageLockMode.ReadWrite, b.PixelFormat);
            foreach (TemplateMatch m in matchings)
            {
                Drawing.Rectangle(data, m.Rectangle, Color.White);
                // do something else with matching
            }
            b.UnlockBits(data);
            // SusanCornersDetector scd = new SusanCornersDetector(30, 18);
            //List<AForge.IntPoint> points = scd.ProcessImage((Bitmap)pictureBox1.Image);

            // // create block matching algorithm's instance
            // ExhaustiveBlockMatching bm = new ExhaustiveBlockMatching(8, 12);
            // // process images searching for block matchings
            // List <BlockMatch> matches = bm.ProcessImage((Bitmap)pictureBox1.Image, points, (Bitmap)pictureBox2.Image);

            // // draw displacement vectors
            // BitmapData data = b.LockBits(
            //     new Rectangle(0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height),
            //      ImageLockMode.ReadWrite, pictureBox1.Image.PixelFormat);

            // foreach (BlockMatch match in matches)
            // {
            //     // highlight the original point in source image
            //     Drawing.FillRectangle(data,
            //         new Rectangle(match.SourcePoint.X - 1, match.SourcePoint.Y - 1, 3, 3),
            //         Color.Yellow);
            //     // draw line to the point in search image
            //     Drawing.Line(data, match.SourcePoint, match.MatchPoint, Color.Red);

            //     // check similarity
            //     if (match.Similarity > 0.98f)
            //     {
            //         // process block with high similarity somehow special
            //     }
            // }
            // b.UnlockBits(data);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(pictureBox3.Image);
            while (group != 0)
            {
                foreach (dpoint dd in deltagroup)
                {
                    if (dd.group == group)
                    {
                        group--;
                        g.DrawString("hit in " + dd.group, label8.Font, Brushes.Red, dd.p);
                    }
                }
            }
            pictureBox3.Update();

        }
        public static int int32_ToColor(int m, int n)
        {
            return (int)(255.0 / m * n);
        }
        private void sqlConnection1_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
        {

        }
    }
}
