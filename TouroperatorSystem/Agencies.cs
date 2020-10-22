using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TouroperatorSystem
{
    public partial class Agencies : UserControl
    {
       
        public Color orange = Color.LightSalmon;
        public Color blueUpPanel = Color.CornflowerBlue;
        public Color white = Color.White;
        public Color black = Color.Black;
        public Color trans = Color.Transparent;
        public Color red = Color.MistyRose;
        public Color blueLeftMenu = Color.FromArgb(130, 175, 255);
        public Color blueUpMenu = Color.FromArgb(168, 208, 248);

        public static string connect = "server=localhost;user=root;database=cursach;password=Danilpanass1;";
        public static MySqlConnection c = new MySqlConnection(connect);
        HomeForm Form { get; set; }
        Functions f = new Functions();
        public Agencies(HomeForm hf)
        {
            InitializeComponent();
            Form = hf;
            c.Open();
            string sql = "SELECT Name, Director,Login, DateLicense, Comission FROM Agency";
            MySqlCommand command = new MySqlCommand(sql, c);
            MySqlDataReader reader = command.ExecuteReader();
            f.CreateDataGridView(dataGridView1, reader);
            c.Close();
            for(int i=0; i<Form.panel2.Controls.Count; i++)
            {
                Form.panel2.Controls[i].Visible = false;
            }
            Form.Add.Visible = true;
            Form.Filter.Visible = true;
            Form.Update.Visible = true;
        }

        private void Agencies_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void Agencies_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                Form.Edit.Visible = false;
                Form.Delete.Visible = false;
                Form.Open.Visible = false;
            }
            else if(dataGridView1.SelectedRows.Count > 1)
            {
                Form.Edit.Visible = false;
                Form.Delete.Visible = true;
                Form.Open.Visible = false;
            }
            else
            {
                Form.Edit.Visible = true;
                Form.Delete.Visible = true;
                Form.Open.Visible = true;
            }
        }
    }
}
