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
    public partial class Routes : UserControl
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
        Functions f = new Functions();
        public HomeForm Form { get; set; }
        public Routes(HomeForm frm)
        {
            Form = frm;
            InitializeComponent();
            c.Open();
            string sql = "SELECT Route.RouteNum, Airline.Name , Route.CodeAirportDeparture, Route.CodeAirportArrive, Route.TimeDeparture, Route.days, Route.Price FROM Route, Airline WHERE Route.CodeAirline = Airline.Code";
            MySqlCommand command = new MySqlCommand(sql, c);
            MySqlDataReader reader = command.ExecuteReader();
            f.CreateDataGridView(dataGridView1, reader);
            c.Close();
            for (int i = 0; i < Form.panel2.Controls.Count; i++)
            {
                Form.panel2.Controls[i].Visible = false;
            }
            Form.Add.Visible = true;
            Form.Filter.Visible = true;
            Form.Update.Visible = true;
        }

        private void Routes_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                Form.Edit.Visible = false;
                Form.Delete.Visible = false;
            }
            else if (dataGridView1.SelectedRows.Count > 1)
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

        private void Routes_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
