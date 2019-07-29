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
    public partial class shots : Form
    {
        public shots()
        {
            InitializeComponent();
        }

        private void ShotBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.shotBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sqloukDataSet);

        }

        private void Shots_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sqloukDataSet.shot' table. You can move, or remove it, as needed.
            this.shotTableAdapter.Fill(this.sqloukDataSet.shot);

        }
    }
}
