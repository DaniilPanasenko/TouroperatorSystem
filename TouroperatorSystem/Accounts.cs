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
    public partial class Accounts : UserControl
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
        public Accounts(HomeForm frm)
        {
            Form = frm;
            InitializeComponent();
            c.Open();
            string sql = "SELECT Agency.Name, Account.Login, Account.Password FROM Agency, Account WHERE Account.Login = Agency.Login UNION SELECT '-', Account.Login, Account.Password FROM Account WHERE Account.Login NOT IN(SELECT Login From Agency) AND Account.IsAdmin = 0";
            MySqlCommand command = new MySqlCommand(sql, c);
            MySqlDataReader reader = command.ExecuteReader();
            f.CreateDataGridView(dataGridView1, reader);
            c.Close();
            c.Open();
            string sql1 = "SELECT Account.Login, Account.Password FROM Account WHERE Account.IsAdmin = 1";
            MySqlCommand command1 = new MySqlCommand(sql1, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            f.CreateDataGridView(dataGridView2, reader1);
            c.Close();
            for (int i = 0; i < Form.panel2.Controls.Count; i++)
            {
                Form.panel2.Controls[i].Visible = false;
            }
            Form.Add.Visible = true;
        }

        private void Accounts_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
        }

        private void Accounts_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
        }

        private void DataGridView2_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            dataGridView2.ClearSelection();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count + dataGridView2.SelectedRows.Count == 0)
            {
                Form.Edit.Visible = false;
                Form.Delete.Visible = false;
            }
            else if (dataGridView1.SelectedRows.Count+ dataGridView2.SelectedRows.Count > 1)
            {
                Form.Edit.Visible = false;
                Form.Delete.Visible = true;
            }
            else
            {
                Form.Edit.Visible = true;
                Form.Delete.Visible = true;
            }
        }

        private void DataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count + dataGridView2.SelectedRows.Count == 0)
            {
                Form.Edit.Visible = false;
                Form.Delete.Visible = false;
            }
            else if (dataGridView1.SelectedRows.Count + dataGridView2.SelectedRows.Count > 1)
            {
                Form.Edit.Visible = false;
                Form.Delete.Visible = true;
            }
            else
            {
                Form.Edit.Visible = true;
                Form.Delete.Visible = true;
            }
        }
    }
}
