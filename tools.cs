using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
//EMGU
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;


namespace comparlize
{
    class tools
    {
        Database db = new Database();
        public string server;
        public List<car> list;
        public int distance = 38;
        #region Variables
        Capture _capture;
        int dif__ = 570;
        Image<Bgr, Byte> Frame;
        Image<Bgr, Byte> Previous_Frame; 
        Image<Bgr, Byte> Difference; 

        double ContourThresh = 0.003;
        int Threshold = 60; 
        #endregion
        private int hitsize;
        public string loc = "TLV";
        private List<Delegate> dds
        {
            get { return dds; }
            set { dds = value; }
        }
        private List<EventArgs> args
        {
            get { return args; }
            set { args = value; }
        }
        string name
        {
            get { return name; }
            set { name = value; }
        }
        public Bitmap filter(string filterID, Bitmap imageToproces)//pure finctions
        {


            return null;
        }
        public Bitmap CompareAlgo(string algo, Bitmap img1, Bitmap img2)
        {


            return null;
        }
        public Bitmap filter(int filterID, Bitmap imageToproces)//pure finctions
        {


            return null;
        }
        public Bitmap CompareAlgo(int algo, Bitmap img1, Bitmap img2)
        {


            return null;
        }
        public tools()
        {
            list = new List<car>();
        }
        public List<Bitmap> Scan()// pure and safe
        {
            try
            {
                //open 
                List<Bitmap> images8 = new List<Bitmap>();
                DirectoryInfo d = new DirectoryInfo(@"\server");//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles("*.png"); //Getting Text files
                string str = "";
                foreach (FileInfo file in Files)
                {
                    str = str + ", " + file.Name;
                    images8.Add(new Bitmap(file.Name));
                }
                return images8;
            }
            catch (Exception) { return null; }

        }
        public bool createNewShotFolder(string id, string path = @"\server\cars")
        {
            int counter = 0;
            try {
                counter = GetcarFolderCounter(id, path);
                ++counter;
                System.IO.File.WriteAllText(path + @"\" + id + @"\counter.txt", "" + counter);

                try
                {
                    if (Directory.Exists(path + @"\" + id+@"\"+counter))
                    {
                        return false;
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(path + @"\" + id + @"\" + counter);
                        using (StreamWriter sw = File.CreateText(path + @"\" + id + @"\" + counter + @"\" + @"date.txt"))
                        {
                            sw.WriteLine("" + DateTime.Now);
                        }
                    }

                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            }
            catch (Exception) { return false; }
            
        }
        public int GetcarFolderCounter(string id, string path = @"\server\cars")
        {
            using (StreamReader sr = File.OpenText((path + @"\" + id+@"\counter.txt")))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    return int.Parse(s);
                }
            }
            return 0;
        }
        public bool createCarFolder(string id, string path = @"\server\cars") {

            try {
                if (Directory.Exists(path + @"\" + id))
                {
                    return false;
                }
                else
                {
                    System.IO.Directory.CreateDirectory(path + @"\" + id);
                    using (StreamWriter sw = File.CreateText(path + @"\" + id + @"\" + @"counter.txt"))
                    {
                        sw.WriteLine("0");
                    }
                    using (StreamWriter sw = File.CreateText(path + @"\" + id + @"\" + @"date.txt"))
                    {
                        sw.WriteLine("" + DateTime.Now);
                    }
                    try
                    {
                        db.CreateMyOleDbDataReader("insert into car ([id car],[name],[location],[date start],[date end]) values (" + id + "," + shot + "," + loc + "," + DateTime.Now + ");", db.con);
                    }
                    catch (Exception v)
                    {

                        return true;
                    }
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public string[] getListofCarsinserver(string pathString = @"\server\cars")
        {
            List<string> files = new List<string>();
            string[] subdirs = null;
            try
            {



                subdirs = Directory.GetDirectories(pathString);

                
            }
            catch (Exception)
            {

                System.IO.Directory.CreateDirectory(pathString);
            }
            return subdirs;
        }
        public string[] getListofCarsinserver(string s,int t,string pathString = @"\server\cars")
        {
            List<string> files = new List<string>();
            string[] subdirs = null;
            try
            {



                subdirs = Directory.GetDirectories(pathString+@"\"+s);
               

            }
            catch (Exception)
            {

                
            }
            return subdirs;
        }
        public List<Bitmap> Scan(string id , int pos, string path = @"\server\cars\")
        {
            try
            {
                //open 
                List<Bitmap> images8 = new List<Bitmap>();
                int counter = GetcarFolderCounter(id);
                DirectoryInfo d = new DirectoryInfo(@""+path + id+@"\"+(counter-pos-1));//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles("*.png"); //Getting Text files
                
                string str = "";
                foreach (FileInfo file in Files)
                {
                    str = str + ", " + file.Name;
                    Image openpng = Image.FromFile(file.FullName);
                    images8.Add(new Bitmap(openpng));
                }
                return images8;
            }
            catch (Exception) { return null; }

        }
        public List<Bitmap> Scan(string p , string path = @"\server\cars\")
        {
            try
            {
                //open 
                List<Bitmap> images8 = new List<Bitmap>();

                DirectoryInfo d = new DirectoryInfo(@""+ path+ @"\"+p);//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles("*.png"); //Getting Text files

                string str = "";
                foreach (FileInfo file in Files)
                {
                    str = str + ", " + file.Name;
                    Image openpng = Image.FromFile(file.FullName);
                    images8.Add(new Bitmap(openpng));
                }
                return images8;
            }
            catch (Exception) { return null; }

        }
        public List<Bitmap> Scani(string p="cam", string path = @"\server\")
        {
            try
            {
                //open 
                List<Bitmap> images8 = new List<Bitmap>();

                DirectoryInfo d = new DirectoryInfo(@"" + path + @"\" + p);//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles("*.png"); //Getting Text files
                if(Files.Length == 0)
                {
                    Files = d.GetFiles("*.JPG");
                }
                string str = "";
                foreach (FileInfo file in Files)
                {
                    str = str + ", " + file.Name;
                    Image openpng = Image.FromFile(file.FullName);
                    //openpng.Save();
                    openpng = ResizeImage(openpng, 700, 525);
                    images8.Add(new Bitmap(openpng));
                }
                //d.Delete(true);
                System.IO.Directory.CreateDirectory(@"" + path + @"\" + p);



                return images8;
            }
            catch (Exception) { return null; }

        }
        public List<Bitmap> DeltaCalculation(List<Bitmap> a, List<Bitmap> b)
        {
            try
            {
                List<Bitmap> newdeltalist = new List<Bitmap>();

                for (int i = 0; i < a.Count; i++)
                {
                    newdeltalist.Add(alg(a[i], b[i]));
                }

                return newdeltalist;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public image DeltaCalculationi(List<Bitmap> a, List<Bitmap> b)
        {
            try
            {
                List<Bitmap> newdeltalist = new List<Bitmap>();
                image nl = new image(newdeltalist, DateTime.Now);
                for (int i = 0; i < a.Count; i++)
                {
                    newdeltalist.Add(alg(a[i], b[i], nl));
                }


                return nl;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public void createfolder(string path)
        {

        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        public image DeltaCalculationsave(List<Bitmap> a, List<Bitmap> b,string path,string id)
        {
            try
            {
                string pathchanges = path + @"\changes";
                List<Bitmap> newdeltalist = new List<Bitmap>();
                image nl = new image(newdeltalist, DateTime.Now);
                try
                {

                    path += @"\deltas";

                    System.IO.Directory.CreateDirectory(path);
                    System.IO.Directory.CreateDirectory(pathchanges);
                }
                catch { }
                for (int i = 0; i < a.Count; i++)
                {
                    Bitmap temp = alg(a[i], b[i], nl);
                    Bitmap temp2 = alg2(a[i], b[i], nl, pathchanges + @"\p(" + (i + 1) + ").txt",id);
                    try
                    {
                        temp2.Save(pathchanges + @"\p(" + (i + 1) + ").png");
                        temp.Save(path+@"\p("+(i+1)+").png");
                    } catch (Exception)
                    {

                    }
                    try
                    {
                        db.CreateMyOleDbDataReader("insert into shot ([id car],[id shot round],[num of hits]) values (" + id + "," + shot + "," + hitsize + ");", db.con);
                    }
                    catch (Exception v)
                    {

                    }

                    newdeltalist.Add(temp);
                }


                return nl;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public Bitmap alg1(Bitmap a, Bitmap b)
        {
            return new Bitmap("");
        }
        public List<Bitmap> FullScan(List<Bitmap> a, string pathb)
        {
            return DeltaCalculation(a, Scan(pathb));
        }


        public List<Bitmap> FullScan(List<Bitmap> a, List<Bitmap> b)
        {
            return DeltaCalculation(a, b);
        }
        public image FullScani(List<Bitmap> a, List<Bitmap> b)
        {
            return DeltaCalculationi(a, b);
        }
        public int shot = 0;
        public image FullScani(string id,int pos=0, string path = @"\server\cars\")
        {
            List<Bitmap> bt = Scani();
           
            createNewShotFolder(id);
            shot = GetcarFolderCounter(id);
            string carnowfolder = @"" + path + id + @"\" + shot;
            try
            {
                int i = 0;
                foreach (Bitmap b in bt)
                {
                    b.Save(carnowfolder+ @"\p(" + (i+1) + ").png");
                    i++;
                }
               

            }
            catch (Exception)
            {
                try
                {
                    createCarFolder(id);
                    MessageBox.Show("server has got error , we create ferce folder for this shot itll linked as well");
                    foreach (Bitmap b in bt)
                    {
                        b.Save(carnowfolder);
                    }
                    return DeltaCalculationsave(bt, Scan(id, pos, path), carnowfolder,id);
                }
                catch (Exception)
                {
                    return DeltaCalculationsave(bt, Scan(id, pos, path), carnowfolder, id);
                }
              
            }
            return DeltaCalculationsave(bt, Scan(id,pos,path),carnowfolder, id);
        }
        public void alg3_whitespaces(Bitmap bm1, Bitmap bm2)
        {
            List<dpoint> deltagroup = new List<dpoint>();
            int group = 1;

            int wid = Math.Min(bm1.Width, bm2.Width);
            int hgt = Math.Min(bm1.Height, bm2.Height);

            // Get the differences.
            int[,] diffs = new int[wid, hgt];

            int max_diff = 0;
            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hgt; y++)
                {
                    // lCalculate the pixels' difference.                                                         //asaf louk 311581144
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

        }


            public List<Bitmap> FullScan(car c, int i)
        {
            return DeltaCalculation(c.list[i].img, c.list[i + 1].img);
        }
        public Bitmap alg(Bitmap bm1, Bitmap bm2)
        {
            List<dpoint> deltagroup = new List<dpoint>();
            int group = 1;

            int wid = Math.Min(bm1.Width, bm2.Width);
            int hgt = Math.Min(bm1.Height, bm2.Height);

            // Get the differences.
            int[,] diffs = new int[wid, hgt];

            int max_diff = 0;
            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hgt; y++)
                {
                    // lCalculate the pixels' difference.
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
            //omax_diff = 255;
            dpoint p;
            Boolean added = false;
            // uCreate the difference image.
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
                    int clr = 255;

                    if (diffs[x, y] != 0)
                        clr = 255 - (int)(255.0 / max_diff * diffs[x, y]);

                    bm3.SetPixel(x, y, Color.FromArgb(clr, clr, clr));
                }
            }

            Graphics g = Graphics.FromImage(bm3);

            Font f = new Font("Times New Roman", 6);
            for (int i = 1; i <= group; ++i)
            {
                foreach (dpoint dd in deltagroup)
                {
                    if (dd.group == i)
                    {

                        g.DrawString("hit(" + dd.p.X + "," + dd.p.Y + ") v" + dd.value + "|" + dd.group, f, Brushes.Red, dd.p);
                       
                        //klistBox1.Items.Add("hit num(" + dd.group + ") in(" + dd.p.X + ", " + dd.p.Y + ") value: " + dd.value + ". ");
                        i++;
                    }
                }
            }


            // new pictureshow(bm1,bm3,bm2).Show();

            return bm3;
        }

        int  deltaline = 80;
        public Bitmap alg(Bitmap bm1, Bitmap bm2, image c)
        {
            List<dpoint> deltagroup = new List<dpoint>();

            int group = 1;

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
                        if (diffs[x, y] != 0 && diffs[x, y] < dif__) diffs[x, y] = 0;
                        if (diffs[x, y] > max_diff)
                            max_diff = diffs[x, y];
                    
                    
                }
            }
            //max_diff = 255;
            dpoint p;
            Boolean added = false;
            // Create the difference image.
            Bitmap bm3 = new Bitmap(wid, hgt);
            for (int x = 10; x < wid; x++)
            {
                for (int y = 10; y < hgt; y++)
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
                    int clr = 255;

                    if (diffs[x, y] != 0)
                        clr = 255 - (int)(255.0 / max_diff * diffs[x, y]);

                    bm3.SetPixel(x, y, Color.FromArgb(clr, clr, clr));
                }
            }

            Graphics g = Graphics.FromImage(bm3);

            Font f = new Font("Times New Roman", 6);
            for (int i = 1; i <= group; ++i)
            {
                foreach (dpoint dd in deltagroup)
                {
                    if (dd.group == i)
                    {
                        if (dd.p.Y > 80 && dd.p.Y < 200)
                            g.DrawString("*", f, Brushes.Blue, dd.p);
                        else
                            g.DrawString("*", f, Brushes.Green, dd.p);
                        //listBox1.Items.Add("hit num(" + dd.group + ") in(" + dd.p.X + ", " + dd.p.Y + ") value: " + dd.value + ". ");llouk
                        i++;
                    }
                }
            }


           // new pictureshow(bm1, bm3, bm2).Show();
            c.dplist.Add(deltagroup);
            return bm3;
        }
        private void DisplayImage(Bitmap Image, PictureBox Control)
        {
            //if (CurrentFrame.InvokeRequired)
            //{
            //    try
            //    {
            //        DisplayImageDelegate DI = new DisplayImageDelegate(DisplayImage);
            //        this.BeginInvoke(DI, new object[] { Image, Control });
            //    }
            //    catch (Exception ex)
            //    {
            //    }
            //}
            //else
            //{
            //    Control.Image = Image;
            //}
        }

        // controls
        /// <summary>
        /// 
        public void func()
        {
            ////acquire the frame
            //Frame = _capture.RetrieveBgrFrame(); //aquire a frame

            //Difference = Previous_Frame.AbsDiff(Frame); //find the absolute difference 
            //                                            /*Play with the value 60 to set a threshold for movement*/
            //Difference = Difference.ThresholdBinary(new Bgr(Threshold, Threshold, Threshold), new Bgr(255, 255, 255)); //if value > 60 set to 255, 0 otherwise 
            //DisplayImage(Difference.ToBitmap(), resultbox); //display the absolute difference 

            //Previous_Frame = Frame.Copy(); //copy the frame to act as the previous frame

            //#region Draw the contours of difference
            ////this is tasken from the ShapeDetection Example
            //using (MemStorage storage = new MemStorage()) //allocate storage for contour approximation
            //                                              //detect the contours and loop through each of them
            //    for (Contour<Point> contours = Difference.Convert<Gray, Byte>().FindContours(
            //          Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
            //          Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST,
            //          storage);
            //       contours != null;
            //       contours = contours.HNext)
            //    {
            //        //Create a contour for the current variable for us to work with
            //        Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);

            //        //Draw the detected contour on the image
            //        if (currentContour.Area > ContourThresh) //only consider contours with area greater than 100 as default then take from form control
            //        {
            //            Frame.Draw(currentContour.BoundingRectangle, new Bgr(Color.Red), 2);
            //        }
            //    }
            //#endregion

            //DisplayImage(Frame.ToBitmap(), CurrentFrame); //display the image using thread safe call
            //DisplayImage(Previous_Frame.ToBitmap(), PreviousFrame); //display the previous image using thread safe call

        }
        public Bitmap alg2(Bitmap bm1, Bitmap bm2, image c , string path,string id)
        {
            List<dpoint> deltagroup = new List<dpoint>();

            int group = 1;

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
                       if (diffs[x, y] != 0 && diffs[x, y] < dif__) diffs[x, y] = 0;
                        if (diffs[x, y] > max_diff)
                            max_diff = diffs[x, y];
                   
                }
            }
            //max_diff = 255;
            dpoint p;
            Boolean added = false;
            // Create the difference image.
            int delta = 2;
            Bitmap bm3 = new Bitmap(wid, hgt);
            for (int x = 0; x < wid- delta; x+= delta)
            {
                for (int y = 0; y < hgt- delta; y+= delta)
                {
                    //if(diffs[x, y] != 0 )
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
                    hitsize = deltagroup.Count;
                    int clr = 255;

                    if (diffs[x, y] != 0)
                        clr = 255 - (int)(255.0 / max_diff * diffs[x, y]);

                    bm3.SetPixel(x, y, Color.FromArgb(clr, clr, clr));
                }
            }

            Graphics g = Graphics.FromImage(bm2);
            string st = "";
            Font f = new Font("Times New Roman", 24);
            for (int i = 1; i <= group; ++i)
            {
                foreach (dpoint dd in deltagroup)
                {
                    if (dd.group == i)
                    {
                       

                        if (dd.p.Y > 80 && dd.p.Y < 200)
                            g.DrawString("*", f, Brushes.Blue, dd.p);
                        else
                            g.DrawString("*", f, Brushes.Green, dd.p);

                            st += "hit num(" + dd.group + ") in(" + dd.p.X + ", " + dd.p.Y + ") value: " + dd.value + ". " + Environment.NewLine;
                            i++;
                        
                        //try
                        //{
                        //    //db.CreateMyOleDbDataReader("insert into hits ([id shot],[num of hits],[size of],[avarge]) values (" + this.GetcarFolderCounter(id) + "," + dd.p.Y + "," + dd.value + "," + dd.group + ");", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/asafl/Source/Repos/Final/comparlize/sqlouk.accdb");
                        //}
                        //catch (Exception v)
                        //{
                        //    continue;
                        //}
                    }
                }
            }


           // new pictureshow(bm1, bm3, bm2).Show();
            c.dplist.Add(deltagroup);
            try
            {
                System.IO.File.WriteAllText(@""+path, contents: "" + st + Environment.NewLine + DateTime.Now + Environment.NewLine);

            }
            catch (Exception) { return bm2; }
            return bm2;
        }
      
        private bool canGroupingEdges(int t, int t2)
        {
            return Math.Abs(t - t2) <= distance;
        }
    }
}
