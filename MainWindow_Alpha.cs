using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FloodFill2;
namespace comparlize
{
    public partial class MainWindow_Alpha : Form
    {
        List<car> list;
        car c;
        string cons = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\asafl\Source\Repos\Final\comparlize\sqlouk.accdb";
        static tools p = new tools();
        List<Bitmap> bt_sowlist;
        Database db = new Database();
        public MainWindow_Alpha()
        {
            InitializeComponent();
           
            list = new List<car>();
            //handle init
            TimeInit();
            carlistinit();
        }

        private void carlistinit()
        {
            string[] strs = p.getListofCarsinserver();

            foreach (string s in strs) {
                string[] getid = s.Split('\\');
                carid.Items.Add(getid[getid.Length-1]);
            }

            comboBox2.Items.Add("Canny_edges");
            comboBox2.Items.Add("filter2D");
            comboBox2.Items.Add("bilateralFilter");
            comboBox2.Items.Add("blur");
            comboBox2.Items.Add("GaussianBlur");
            comboBox2.Items.Add("laplacian");
            comboBox2.Items.Add("medianBlur");
            comboBox2.Items.Add("sobelx"); 
                 comboBox2.Items.Add("sobely");

            tabControl1.SelectedIndex = 1;
        }

        private void TimeInit()
        {
           c= new car("1128");
            image img = new image(p.Scan(carid.SelectedText+@"\0"), DateTime.Now);
            c.list.Add(img);
            list.Add(c);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            c.list.Add(new image(p.Scan(carid.SelectedText + @"\1"), DateTime.Now));
            c.dlist.Add(p.FullScani(c.list[0].img, c.list[1].img));


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int indexi = 0,indexj=0;
            PictureBox p = (PictureBox)sender;
          
            switch (p.Name)
            {
                case "pictureBox1":
                    indexi= 0; indexj = 0;
                    break;
                case "pictureBox2":

                    indexi = 0;  indexj = 1;
                    break;
                case "pictureBox6":
                    indexi = 0; indexj = 2;
                    break;
                case "pictureBox3":
                    indexi = 0; indexj = 3;
                    break;
                case "pictureBox10":
                    indexi = 0; indexj = 4;
                    break;
                case "pictureBox9":
                    indexi = 0; indexj = 5;
                    break;
                case "pictureBox8":
                    indexi = 0; indexj = 6;
                    break;
                case "pictureBox7":
                    indexi = 0; indexj = 7;
                    break;
            }
            pictureBox12.Image = c.list[indexi].img[indexj];
            pictureBox4.Image = c.dlist[indexi].img[indexj];
            pictureBox11.Image = c.list[indexi + 1].img[indexj];

            //data set to screen
            label5.Text = c.dlist[indexi].dplist[indexj].Count.ToString();
            try
            {
                label6.Text = c.dlist[indexi].dplist[indexj].ElementAt(c.dlist[indexi].dplist[indexj].Count - 1).group.ToString();

                label8.Text =(double.Parse(label5.Text)/ double.Parse(label6.Text)).ToString();
                if(label8.Text.Length > 5)
                {
                    label8.Text = label8.Text.Substring(0, 5);
                }
            }
            catch (Exception) { }


            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            new Poc().Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void welcome(object sender, EventArgs e)
        {
            Thread.Sleep(2200);
            panel3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string str="";
            //folderBrowserDialog1.ShowDialog();
            //str = folderBrowserDialog1.SelectedPath;
            //LaunchCommandLineApp(str);
        }
        static void LaunchCommandLineApp(string str)
        {
           

            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = @"C:\Users\asafl\Source\Repos\Final\comparlize\dist\filter\filter.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = str ;

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                // Log error.
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            paint_them_all(sender, e);
            tabControl1.SelectedIndex = 5;
            button6.BackColor = Color.SteelBlue;

            try
            {
                comboBox4.Items.Clear();
                string[] strs = p.getListofCarsinserver();

                foreach (string s in strs)
                {
                    string[] getid = s.Split('\\');
                    comboBox4.Items.Add(getid[getid.Length - 1]);
                }
            }
            catch (Exception) { return; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            paint_them_all(sender, e);
            tabControl1.SelectedIndex = 1;
            button3.BackColor = Color.SteelBlue;
        }
        private void paint_them_all(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button6.BackColor = Color.White;
            button2.BackColor = Color.White;
            button22.BackColor = Color.White;
            button5.BackColor = Color.White;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (p.createCarFolder(newcarIDaddtxtbox.Text))
            {
                //logi.Text = "new car added id: " + newcarIDaddtxtbox.Text + "more deatils press history";
                carlistinit();
                
                try
                {
                    db.Addcar(newcarIDaddtxtbox.Text +","+ textBox2.Text+",TLV,"+ textBox3.Text, newcarIDaddtxtbox.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("please check that database is conncted and run , u must have server folder on C driver to make things run . RUN");
                    return;
                }
                MessageBox.Show("CAR HAS ADDED");
            }
        }

        private void udatesun(object sender, EventArgs e)
        {
            //string[] getid = comboBox1.SelectedItem.ToString().Split('\\');
            string[] strs = p.getListofCarsinserver(carid.SelectedItem.ToString(), 0);
            shotnumcobobox.Items.Clear();
            foreach (string s in strs)
            {
                string[] getid = s.Split('\\');
                shotnumcobobox.Items.Add(getid[getid.Length - 1]);
            }


        }
        private void udatesun2(object sender, EventArgs e)
        {
            //string[] getid = comboBox1.SelectedItem.ToString().Split('\\');
            string[] strs = p.getListofCarsinserver(comboBox1.SelectedItem.ToString(), 0);
            comboBox3.Items.Clear();
            foreach (string s in strs)
            {
                string[] getid = s.Split('\\');
                comboBox3.Items.Add(getid[getid.Length - 1]);
            }


        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            DateTime dtstart = DateTime.Now;
            try
            {
                  p.FullScani(carid.Text);
                  bt_sowlist = p.Scan(carid.Text + @"\" + p.GetcarFolderCounter(carid.Text)+@"\changes");
            }
            catch (Exception)
            {

            }
            DateTime end = DateTime.Now;

            try
            {
                int s = end.Second - dtstart.Second;
                int mm = end.Millisecond - dtstart.Millisecond;
                int min = end.Minute - dtstart.Minute;


                string times__ = "|"+min+":"+s+":"+mm+"|";

                label20.Text = times__;                                                                                                                                                             //louk creator
            }
            catch(Exception err)
            {
                MessageBox.Show("");
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        int picount = 0;
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (picount == 0) return;
                else picount--;
                pictureBox14.Image = bt_sowlist[picount];
               

                pictureBox14.Image = bt_sowlist[picount];
            }
            catch(Exception c)
            {

            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (picount == 7) { return; }
                else picount++;


                pictureBox14.Image = bt_sowlist[picount];


                pictureBox14.Image = bt_sowlist[picount];
            }catch(Exception c)
            {

            }
           
        }
        private void showmychanges(object sender, EventArgs e)
        {

            bt_sowlist = p.Scan(carid.Text + @"\" + shotnumcobobox.Text + @"\changes");
            pictureBox14.Image = bt_sowlist[picount];
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                bt_sowlist = p.Scan(carid.Text + @"\" + (int.Parse(shotnumcobobox.Text) - 1) + @"\changes");
                pictureBox14.Image = bt_sowlist[picount];
            }
            catch (Exception) { bt_sowlist = p.Scan(carid.Text + @"\" + shotnumcobobox.Text + @"\changes");
                pictureBox14.Image = bt_sowlist[picount];
            }
          
        }

        private void button16_Click(object sender, EventArgs e)
        {
            bt_sowlist = p.Scan(carid.Text + @"\" + shotnumcobobox.Text + @"\changes");
            pictureBox14.Image = bt_sowlist[picount];
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\asafl\Source\Repos\Final\addable\FloodFill2\bin\Debug\FloodFill2.exe");
        }
        Image img;
        private void draw(object sender, MouseEventArgs e)
        {

            try
            {
                if (Draw)
                {

                     img = pictureBox14.Image;

                    Graphics g = Graphics.FromImage(img);

                    g.DrawEllipse(Pens.DarkBlue, new Rectangle(e.Location.X, e.Location.Y, 5, 1));

                    g.DrawImage(img, new Point(0, 0));

                    pictureBox14.Image = img;
                   }
            }
            catch (Exception)
            {
                return;
            }
        }
        private bool Draw = false;
        private void Button19_Click(object sender, EventArgs e)
        {
            Draw = Draw ? false : true;
        }

        private void SAVE_HandleChanges(object sender, EventArgs e)
        {
            try {
                img.Save(@"C:\server\cars\" + carid.Text + @"\" + shotnumcobobox.Text + @"\p_hand.png", System.Drawing.Imaging.ImageFormat.Png);
                System.IO.File.WriteAllText(@"C:\server\cars\" + carid.Text + @"\" + shotnumcobobox.Text + @"\p_hand.txt", contents: "" + description.Text + Environment.NewLine + DateTime.Now + Environment.NewLine);
            }
            catch (Exception)
            {
                try {
                    img.Save(@"C:\server\cars\" + carid.Text + @"\" + shotnumcobobox.Text + @"\hand.png", System.Drawing.Imaging.ImageFormat.Png);
                }
                catch (Exception) { return; }
            }
            
        }

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }

        private void MainWindow_Alpha_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sqloukDataSet.GetDeatails2' table. You can move, or remove it, as needed.
            this.getDeatails2TableAdapter.Fill(this.sqloukDataSet.GetDeatails2);
            // TODO: This line of code loads data into the 'sqloukDataSet.GetDeatails2' table. You can move, or remove it, as needed.
            //this.getDeatails2TableAdapter.Fill(this.sqloukDataSet.GetDeatails2);
            // TODO: This line of code loads data into the 'sqloukDataSet.cars' table. You can move, or remove it, as needed.
            //this.carsTableAdapter.Fill(this.sqloukDataSet.cars);

        }

        private void Button21_Click(object sender, EventArgs e)
        {
            int i = picount;


            try
            {


                using (StreamReader sr = File.OpenText((@"C:\server\cars\" + carid.Text + @"\" + shotnumcobobox.Text + @"\p(" + (i + 1) + ").txt")))
                {
                    string s = "",st="";
                    while ((s = sr.ReadLine()) != null)
                    {
                        st += s;
                    }
                    new showlist(st);
                }
               
            }
            catch (Exception)
            {
                //there is no handle comments do nothing
                return;
            }
            
        }

        private void Button22_Click(object sender, EventArgs e)
        {
            paint_them_all(sender, e);
            tabControl1.SelectedIndex = 3;
            button22.BackColor = Color.SteelBlue;
            comboBox1.Items.Clear();
            try
            {
                string[] strs = p.getListofCarsinserver();

                foreach (string s in strs)
                {
                    string[] getid = s.Split('\\');
                    comboBox1.Items.Add(getid[getid.Length - 1]);
                }
            }
            catch (Exception) { return; }

        }

        private void CarsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            

        }

        private void car_S(object sender, EventArgs e)
        {
            new historyDatabase().Show();
        }

        private void hit_s(object sender, EventArgs e)
        {
            new Hits().Show();
        }

        private void shot_s(object sender, EventArgs e)
        {
            new shots().Show();
        }

        private void Button34_Click(object sender, EventArgs e)
        {
          
                try
                {
                    OleDbConnection connection = new OleDbConnection(db.con);

                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM [hits] ";
                    // chart1.Series["Salary"].Points.AddXY("Ajay", "10000");
                    List<string> result = new List<string>();
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                         {


                        chart3.Series[1].Points.AddXY((double)reader.GetInt32(2), (double)reader.GetInt32(0));

                        chart3.Series[0].Points.AddXY((double)reader.GetInt32(3), (double)reader.GetInt32(0));

                        chart1.Series[0].Points.AddXY((double)reader.GetInt32(0), (double)reader.GetInt32(4));
                        chart1.Series[1].Points.AddXY((double)reader.GetInt32(0), (double)reader.GetInt32(3));
                        chart1.Series[2].Points.AddXY((double)reader.GetInt32(0), (double)reader.GetInt32(2));


                        getDeatails2DataGridView.Visible = true;
                        }
                    }
                }
                catch (Exception v)
                {

                }
              
        }

       

        private void Button36_Click_1(object sender, EventArgs e)
        {
            try {

                OleDbConnection cn = new OleDbConnection(cons);

                cn.Open();
                OleDbDataReader reader = null;
                OleDbCommand cmd = new OleDbCommand(db.Q2(), cn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   
                        
                    if(reader["id car"].Equals(comboBox4.SelectedItem)) {
                        chart1.Series["cars use"].Points.AddXY(1, reader["num of hits"]);
                        chart1.Series["avarage"].Points.AddXY(1, reader["size of"]);
                        chart1.Series["Hit count"].Points.AddXY(1, reader["aout hit counter"]);
                        chart1.Series["cars use"].Points.AddXY(2, reader["num of hits"]);
                        chart1.Series["avarage"].Points.AddXY(2, reader["size of"]);
                        chart1.Series["Hit count"].Points.AddXY(2, reader["aout hit counter"]);
                        chart1.Series["cars use"].Points.AddXY(3, reader["num of hits"]);
                        chart1.Series["avarage"].Points.AddXY(3, reader["size of"]);
                        chart1.Series["Hit count"].Points.AddXY(3, reader["aout hit counter"]);
                    }
                    

                }

                getDeatails2DataGridView.Visible = true;
            } catch (Exception) { return;  }
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            paint_them_all(sender, e);
            tabControl1.SelectedIndex = 4;
            button2.BackColor = Color.SteelBlue;
        }

        private void Button35_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(db.con);

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [hits] ";
                // chart1.Series["Salary"].Points.AddXY("Ajay", "10000");
                List<string> result = new List<string>();
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {



                        chart2.Series[0].Points.AddXY(reader.GetInt32(0), reader.GetInt32(4));
                        chart2.Series[1].Points.AddXY(reader.GetInt32(0), reader.GetInt32(2));
                        chart2.Series[2].Points.AddXY(reader.GetInt32(0), reader.GetInt32(3));


                        getDeatails2DataGridView.Visible = true;
                    }
                }
            }
            catch (Exception v)
            {

            }


        }

        private void Button27_Click(object sender, EventArgs e)
        {

        }
       
        private void Button5_Click(object sender, EventArgs e)
        {
            paint_them_all(sender, e);
            tabControl1.SelectedIndex = 2;
            button5.BackColor = Color.SteelBlue;
        }

        private void Button37_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.ShowDialog();
            severtxt.Text = folderBrowserDialog2.SelectedPath;
        }

        private void Button38_Click(object sender, EventArgs e)
        {
            try
            {
                p.loc = loctx.Text;
                p.distance = int.Parse(duis.Text);
                p.server = severtxt.Text;


            }
            catch (Exception)
            {
                return;;
            }
        }

        private void setpoints(object sender, MouseEventArgs e)
        {
           
                lkl.Text = "x - " + e.X + " y - " + e.Y;
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void cngi(object sender, EventArgs e)
        {
            pictureBox14.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
