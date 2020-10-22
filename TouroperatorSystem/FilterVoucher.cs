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
    public partial class FilterVoucher : Form
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
        SearchVouchers Search { get; set; }
        public FilterVoucher(SearchVouchers s)
        {
            Search = s;
            InitializeComponent();
            c.Open();
            string sql1 = "SELECT Name FROM Country ";
            MySqlCommand command1 = new MySqlCommand(sql1, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox2.Items.Add(reader1[0].ToString());
                comboBox7.Items.Add(reader1[0].ToString());
            }
            c.Close();
            dateTimePicker2.Value = DateTime.Now.AddDays(14);
            comboBox7.SelectedItem = "Украина";
            comboBox2.SelectedIndex = 0;
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            if(comboBox2.Text!="" && comboBox7.Text != "")
            {
                Search.CountryA = comboBox7.Text;
                Search.CityA = comboBox6.Text;
                Search.Airport = comboBox9.Text;
                Search.CountryB = comboBox2.Text;
                Search.CityB = comboBox3.Text;
                Search.HotelB = comboBox1.Text;
                Search.NightsA = int.Parse(textBox1.Text);
                Search.NightsB = int.Parse(textBox2.Text);
                Search.CountPeople =int.Parse(textBox3.Text);
                Search.DateA =dateTimePicker1.Value;
                Search.DateB =dateTimePicker2.Value;
                Search.GetUpdate();
                Close();
            }
            else
            {
                MyMessageBox mmb = new MyMessageBox(Search.Form, "Ошибка", "Введите значение для стран", "ОК", "", "ОК", "");
                mmb.Show();
            }
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

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox3.Items.Clear();
            string SQL1 = $"SELECT City.Name FROM City, Country WHERE City.idCountry =Country.ID AND Country.Name='{comboBox2.Text}'";
            c.Open();
            MySqlCommand command = new MySqlCommand(SQL1, c);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox3.Items.Add(reader[0].ToString());
            }
            c.Close();
        }

        private void ComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            comboBox9.Items.Clear();
            string SQL1 = $"SELECT City.Name FROM City, Country WHERE City.idCountry =Country.ID AND Country.Name='{comboBox7.Text}' AND" +
                $" City.ID = City.idCityWithNearestAirport";
            c.Open();
            MySqlCommand command = new MySqlCommand(SQL1, c);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox6.Items.Add(reader[0].ToString());
            }
            c.Close();
        }

        private void ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox9.Items.Clear();
            string SQL1 = $"SELECT Airport.Code, Airport.Name" +
                $" FROM City, Airport WHERE Airport.idCity =City.ID AND City.Name='{comboBox6.Text}'";
            c.Open();
            MySqlCommand command = new MySqlCommand(SQL1, c);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox9.Items.Add(reader[0].ToString()+$" ({reader[1].ToString()})");
            }
            c.Close();
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string SQL1 = $"SELECT Hotel.Name FROM City, Hotel WHERE City.id =Hotel.idCity AND City.Name='{comboBox3.Text}'";
            c.Open();
            MySqlCommand command = new MySqlCommand(SQL1, c);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0].ToString());
            }
            c.Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }
        private void Plus_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) != 31)
            {
                textBox1.Text = (int.Parse(textBox1.Text) + 1).ToString();
            }
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) != 1)
            {
                textBox1.Text = (int.Parse(textBox1.Text) - 1).ToString();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox2.Text) != 31)
            {
                textBox2.Text = (int.Parse(textBox2.Text) + 1).ToString();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox2.Text) != 1)
            {
                textBox2.Text = (int.Parse(textBox2.Text) - 1).ToString();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox3.Text) != 7)
            {
                textBox3.Text = (int.Parse(textBox3.Text) + 1).ToString();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox3.Text) != 1)
            {
                textBox3.Text = (int.Parse(textBox3.Text) - 1).ToString();
            }
        }
    }
}
