using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comparlize
{
    class Database
    {

        public static string query = "SELECT cars.[id car], hits.[size of], hits.[num of hits], hits.avarge FROM((cars INNER JOIN shot ON cars.[id car] = shot.[id car]) INNER JOIN hits ON shot.[auto id] = hits.[id shot]) INNER JOIN[con + car + shot] ON cars.[id car] = [con+car+shot].[id car] GROUP BY cars.[id car], hits.[size of], hits.[num of hits], hits.avarge;";
       public static string query2 = "SELECT hits.[aout hit counter], shot.[id car], hits.[num of hits], hits.[size of], hits.avarge FROM shot INNER JOIN hits ON shot.[auto id] = hits.[id shot];";
        public string con = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/asafl/Source/Repos/Final/comparlize/sqlouk.accdb";
        Boolean isConnect
        {
            get { return isConnect; }
            set { isConnect = value; }
        }
        string conectionsString
        {
            get { return conectionsString; }
            set { conectionsString = value; }
        }
        //need to relise
        public int[] getFrom(string query = "Select (*) from Customer" )
        {
            try
            {
                int i = 0;
                int[] ar = new int[500];
                string cmdText = query;
                using (OleDbConnection conn = new OleDbConnection(con))
                using (OleDbCommand cmd = new OleDbCommand(cmdText, conn))
                {
                    conn.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() && i < ar.Length)
                        {
                            ar[i++] = int.Parse(reader.GetString(2));        // chose index from table to calculate 
                        }

                    }
                }
                return ar;
            }
            catch (Exception)
            {
                return null;
            }
           
        }
        public string  Q2()
        {
            return "SELECT * FROM [hits]";

        }
        public void CreateMyOleDbDataReader(string queryString, string connectionString)
        {
            
            using (OleDbConnection myCon = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = queryString;
                //cmd.Parameters.AddWithValue("@aout hit counter", null);
                cmd.Parameters.AddWithValue("@id shot", 2);
                cmd.Parameters.AddWithValue("@num of hits", 20);
                cmd.Parameters.AddWithValue("@size of", 2);
                cmd.Parameters.AddWithValue("@avarge", 2);
                cmd.Connection = myCon;
                myCon.Open();
                cmd.ExecuteNonQuery();
                //System.Windows.Forms.MessageBox.Show("An Item has been successfully added", "Caption", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }


        }
        public void Addcar( string data, string id)
        {

            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\asafl\Source\Repos\Final\comparlize\sqlouk.accdb");
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "Insert into cars (id car,name,location,date start,end start) values(" + data + ")";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Submitted", "Congrats");
                con.Close();
            }
            catch (Exception)
            {
                return;
            }
        }
        public void AddHit( string data, string id)
        {

            try
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\asafl\Source\Repos\Final\comparlize\sqlouk.accdb");
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "Insert into hits (aout hit counter,id shot,num of hits,size of, avarge) values(NULL," + data + ")";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Submitted", "Congrats");
                con.Close();
            }
            catch (Exception)
            {
                return;
            }
        }
        public void Remove(string table, string data, string id) { }
        public void Update(string table, string data, string id) { }
        public List<Bitmap> getCarD(string id) { return null; }
        public void Creates(string ConString)
        {

            string path = @"C:\Users\asafl\Documents\SQLPARTcCc.txt";
            if (!File.Exists(path))
            {
                string createText = "CREATE TABLE [dbo].[' Empty ']("
                                + "[Empty0] INT NOT NULL , "
                                + "[Empty1] NCHAR(20) NULL,"
                                + "[Empty2] INT NULL,"
                                + "CONSTRAINT ['pk_Empty'] PRIMARY KEY CLUSTERED "
                                + "("
                                + "[ID] ASC"
                                + ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]"
                                + ") ON [PRIMARY]";
                using (SqlCommand cmd = new SqlCommand(createText, new SqlConnection(ConString)))
                    try
                    {



                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();





                    }
                    catch (Exception)
                    {


                    }
                    finally
                    {
                        cmd.Connection.Close();
                    }
            }



            String readText = File.ReadAllText(path);
            try
            {
                using (SqlCommand cmd = new SqlCommand(readText, new SqlConnection(ConString)))
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();



                    cmd.Connection.Close();
                }
            }
            catch (Exception)
            {

                return;
            }
        }

    }
}
