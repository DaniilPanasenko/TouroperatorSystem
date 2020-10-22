using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TouroperatorSystem
{
    public partial class FilterRoute : Form
    {
        public static string connect = "server=localhost;user=root;database=cursach;password=Danilpanass1;";
        public static MySqlConnection c = new MySqlConnection(connect);
        public Color orange = Color.LightSalmon;
        public Color blue = Color.CornflowerBlue;
        public Color white = Color.White;
        public Color black = Color.Black;
        public Color trans = Color.Transparent;
        public Color red = Color.MistyRose;
        Functions f = new Functions();
        public bool PanelMouseDown { get; set; }
        public Point PanelMouseDownLocation { get; set; }
        public HomeForm Form{get; set;}
        public FilterRoute(HomeForm frm)
        {
            Form = frm;
            InitializeComponent();
            string SQL1 = "SELECT Country.Name FROM Country";
            c.Open();
            MySqlCommand command = new MySqlCommand(SQL1, c);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader[0].ToString());
                comboBox3.Items.Add(reader[0].ToString());
            }
            c.Close();
            string SQL2 = "SELECT Airline.Name FROM Airline";
            c.Open();
            MySqlCommand command1 = new MySqlCommand(SQL2, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox6.Items.Add(reader1[0].ToString());
            }
            c.Close();
            
        }
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SQL1 = "SELECT Airport.Code, Airport.Name FROM Airport, City, Country WHERE " +
                $"Country.Name='{comboBox2.SelectedItem}' AND Country.Id=City.IdCountry AND Airport.IdCity=City.ID";
            c.Open();
            MySqlCommand command = new MySqlCommand(SQL1, c);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox4.Items.Add(reader[0].ToString() + $" ({reader[1].ToString()})");

            }
            c.Close();
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SQL1 = "SELECT Airport.Code, Airport.Name FROM Airport, City, Country WHERE " +
                $"Country.Name='{comboBox3.SelectedItem}' AND Country.Id=City.IdCountry AND Airport.IdCity=City.ID";
            c.Open();
            MySqlCommand command = new MySqlCommand(SQL1, c);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0].ToString() + $" ({reader[1].ToString()})");

            }
            c.Close();
        }
        private void PanelForm_MouseDown(object sender, MouseEventArgs e)
        {
            PanelMouseDown = true;
            PanelMouseDownLocation = new Point(e.X, e.Y);
        }
        private void PanelForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (PanelMouseDown)
            {
                this.Location = new Point(this.Location.X - PanelMouseDownLocation.X + e.X, this.Location.Y - PanelMouseDownLocation.Y + e.Y);
            }
        }
        private void PanelForm_MouseUp(object sender, MouseEventArgs e)
        {
            PanelMouseDown = false;
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            Close.BackColor = orange;
            Close.ForeColor = black;
        }
        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            Close.BackColor = trans;
            Close.ForeColor = white;
        }
        private void FilterRoute_Load(object sender, EventArgs e)
        {

        }

        private void No_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            c.Open();
            string sql = "SELECT Route.RouteNum, Airline.Name , Route.CodeAirportDeparture, Route.CodeAirportArrive," +
" Route.TimeDeparture, Route.days, Route.Price" +
" FROM Route, Airline, Airport a1, Airport a2, City c1, City c2, Country cc1, Country cc2" +
" WHERE Route.CodeAirline = Airline.Code AND Route.CodeAirportDeparture = a1.Code AND a1.idCity = c1.ID AND c1.idCountry = cc1.ID" +
" AND Route.CodeAirportArrive = a2.Code AND a2.idCity = c2.ID AND c2.idCountry = cc2.ID " +
$"AND cc1.Name LIKE '%{comboBox2.Text}%' AND cc2.Name LIKE '{comboBox3.Text}%' AND " +
$"a1.Code LIKE '%{comboBox4.Text.Split(' ')[0]}%' AND a2.Code LIKE '%{comboBox1.Text.Split(' ')[0]}%' AND " +
$"Airline.Name LIKE '%{comboBox6.Text}%' AND Route.RouteNum LIKE '%{textBox0.Text}%'";
            if (textBox3.Text != "")
            {
                sql+= $"AND Route.Price <={ textBox3.Text}";
            }
            MySqlCommand command = new MySqlCommand(sql, c);
            MySqlDataReader reader = command.ExecuteReader();
            f.CreateDataGridView(((Routes)Form.State).dataGridView1, reader);
            c.Close();
            Close();
        }
    }
}
