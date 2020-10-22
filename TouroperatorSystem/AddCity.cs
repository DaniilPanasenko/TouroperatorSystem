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
    public partial class AddCity : Form
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
        public AddHotel Form { get; set; }
        public int ID { get; set; }
        public AddCity(AddHotel frm)
        {
            Form = frm;
            InitializeComponent();
            c.Open();
            string sql1 = "SELECT Name FROM Country ";
            MySqlCommand command1 = new MySqlCommand(sql1, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox2.Items.Add(reader1[0].ToString());
                comboBox1.Items.Add(reader1[0].ToString());
            }
            c.Close();
            int i = 1;
            c.Open();
            string sql = "SELECT ID FROM City ORDER BY ID ASC";
            MySqlCommand command = new MySqlCommand(sql, c);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (i != Convert.ToInt32(reader[0]))
                {
                    break;
                }
                i++;
            }
            c.Close();
            ID = i;
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
        private void Label8_Click(object sender, EventArgs e)
        {
            AddCountry a = new AddCountry(this);
            a.Show();
        }
        private void Label8_MouseEnter(object sender, EventArgs e)
        {
            label8.ForeColor = Color.LightGreen;
        }

        private void Label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.SeaGreen;
        }

        private void ComboBox2_TextUpdate(object sender, EventArgs e)
        {
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox1.SelectedItem = comboBox2.Text;
            c.Open();
            string sql1 = $"SELECT City.Name FROM City, Country WHERE City.IdCountry = Country.ID AND Country.Name = '{comboBox1.Text}' AND City.ID = City.IdCityWithNearestAirport";
            MySqlCommand command1 = new MySqlCommand(sql1, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox3.Items.Add(reader1[0].ToString());
            }
            c.Close();
            comboBox3.Items.Add(textBox0.Text);
            comboBox3.SelectedItem = textBox0.Text;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            c.Open();
            string sql1 = $"SELECT City.Name FROM City, Country WHERE City.IdCountry = Country.ID AND Country.Name = '{comboBox1.Text}' AND City.ID = City.IdCityWithNearestAirport";
            MySqlCommand command1 = new MySqlCommand(sql1, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox3.Items.Add(reader1[0].ToString());
            }
            c.Close();
            if (comboBox1.Text == comboBox2.Text)
            {
                comboBox3.Items.Add(textBox0.Text);
                comboBox3.SelectedItem = textBox0.Text;
            }
        }

        private void TextBox0_TextChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = comboBox2.Text;
            if (textBox0.Text != comboBox3.Text)
            {
                comboBox3.Items.Clear();
                c.Open();
                string sql1 = $"SELECT City.Name FROM City, Country WHERE City.IdCountry = Country.ID AND Country.Name = '{comboBox1.Text}' AND City.ID = City.IdCityWithNearestAirport";
                MySqlCommand command1 = new MySqlCommand(sql1, c);
                MySqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    comboBox3.Items.Add(reader1[0].ToString());
                }
                c.Close();
                comboBox3.Items.Add(textBox0.Text);
                comboBox3.SelectedItem = textBox0.Text;
            }
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            
            if(comboBox3.Text!="" && comboBox2.Text!="" && comboBox1.Text!="" && textBox0.Text != "")
            {
                c.Open();
                string sql1 = $"SELECT City.Name FROM Country, City WHERE City.IdCountry = Country.ID AND Country.Name = '{comboBox2.Text}' AND City.Name='{textBox0.Text}'";
                MySqlCommand command1 = new MySqlCommand(sql1, c);
                MySqlDataReader reader1 = command1.ExecuteReader();
                bool t = true;
                while (reader1.Read())
                {
                    t = false;
                }
                c.Close();
                if (t)
                {
                    c.Open();
                    string sql2 = $"SELECT Country.ID FROM Country WHERE Country.Name = '{comboBox1.Text}'";
                    MySqlCommand command2 = new MySqlCommand(sql2, c);
                    MySqlDataReader reader2 = command2.ExecuteReader();
                    int idc = 0;
                    while (reader2.Read())
                    {
                        idc = Convert.ToInt32(reader2[0]);
                    }
                    c.Close();
                    c.Open();
                    string sql3 = $"SELECT ID FROM City WHERE IdCountry='{idc}' AND Name ='{comboBox3.Text}'";
                    MySqlCommand command3 = new MySqlCommand(sql3, c);
                    MySqlDataReader reader3 = command3.ExecuteReader();
                    int idcity = 0;
                    while (reader3.Read())
                    {
                        idcity = Convert.ToInt32(reader3[0]);
                    }
                    c.Close();
                    if (idcity == 0)
                    {
                        idcity = ID;
                    }
                    string SQL = $"INSERT INTO City (ID, Name, IdCountry, IdCityWithNearestAirport) VALUES('{ID}','{textBox0.Text}','{idc}','{idcity}')";
                    c.Open();
                    MySqlCommand com = new MySqlCommand(SQL, c);
                    com.ExecuteNonQuery();
                    c.Close();
                    c.Open();
                    string sql = $"SELECT City.Name, Country.Name FROM City, Country WHERE Country.ID={idc} AND City.IdCountry=Country.ID ";
                    MySqlCommand command = new MySqlCommand(sql, c);
                    MySqlDataReader reader = command.ExecuteReader();
                    Form.comboBox3.Items.Clear();
                    while (reader.Read())
                    {
                        Form.comboBox3.Items.Add(reader[0].ToString());
                    }
                    c.Close();
                    Form.comboBox2.SelectedItem = comboBox2.Text;
                    Form.comboBox3.SelectedItem = textBox0.Text;
                    if (Form.FromAddAirport)
                    {
                        Form.addairport.comboBox1.Items.Clear();
                        c.Open();
                        string sql10 = "SELECT Name FROM Country ";
                        MySqlCommand command10 = new MySqlCommand(sql10, c);
                        MySqlDataReader reader10 = command10.ExecuteReader();
                        while (reader10.Read())
                        {
                            Form.addairport.comboBox1.Items.Add(reader10[0].ToString());
                        }
                        c.Close();
                        Form.addairport.comboBox1.SelectedItem = comboBox1.Text;
                        Form.addairport.comboBox3.SelectedItem = comboBox3.Text;
                    }

                    Close();
                }
                else
                {
                    MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Город в этой стране с таким названием уже существует", "ОК", "", "ОК", "");
                    mmb.Show();
                }
            }
            else
            {
                MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Введите значение", "ОК", "", "ОК", "");
                mmb.Show();
            }
        }

        private void No_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddCity_Load(object sender, EventArgs e)
        {

        }
    }
}
