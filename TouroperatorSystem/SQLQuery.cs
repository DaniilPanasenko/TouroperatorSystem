using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TouroperatorSystem
{
    public partial class SQLQuery : UserControl
    {
        HomeForm Form { get; set; }
        public SQLQuery(HomeForm hf)
        {
            Form = hf;
            InitializeComponent();
            for (int i = 0; i < Form.panel2.Controls.Count; i++)
            {
                Form.panel2.Controls[i].Visible = false;
            }
            Form.Help.Visible = true;
            Form.Clear.Visible = true;
            Form.Play.Visible = true;
        }

        private void SQLQuery_Load(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
