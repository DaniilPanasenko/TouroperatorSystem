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
    public partial class AddAirport : Form
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
        public AddRoute Form { get; set; }
        public AddAirport(AddRoute ar)
        {
            Form = ar;
            InitializeComponent();
            c.Open();
            string sql1 = "SELECT Name FROM Country ";
            MySqlCommand command1 = new MySqlCommand(sql1, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox1.Items.Add(reader1[0].ToString());
            }
            c.Close();
        }

        private void AddAirport_Load(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            c.Open();
            string sql1 = $"SELECT City.Name FROM City, Country WHERE City.IdCountry = Country.ID AND Country.Name = '{comboBox1.Text}' ";
            MySqlCommand command1 = new MySqlCommand(sql1, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox3.Items.Add(reader1[0].ToString());
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
        private void No_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox3.Text != "" && textBox0.Text != "")
            {
                if (textBox1.Text.Length == 3)
                {
                    string sql1 = $"SELECT Airport.Code FROM Airport WHERE Airport.Code = '{textBox1.Text}'";
                    c.Open();
                    MySqlCommand com1 = new MySqlCommand(sql1, c);
                    MySqlDataReader reader1 = com1.ExecuteReader();
                    bool t1 = true;
                    while (reader1.Read())
                    {
                        t1 = false;
                    }
                    c.Close();
                    string sql2 = $"SELECT Airport.Code FROM Airport WHERE Airport.Name = '{textBox0.Text}'";
                    c.Open();
                    MySqlCommand com2 = new MySqlCommand(sql2, c);
                    MySqlDataReader reader2 = com2.ExecuteReader();
                    bool t2 = true;
                    while (reader2.Read())
                    {
                        t2 = false;
                    }
                    c.Close();
                    if (t2)
                    {
                        if (t1)
                        {
                            string SQL = $"INSERT INTO Airport(Code, idCity, Name) VALUES ('{textBox1.Text}',(SELECT ID FROM City WHERE City.Name = '{comboBox3.Text}'),'{textBox0.Text}')";
                            c.Open();
                            MySqlCommand com = new MySqlCommand(SQL, c);
                            com.ExecuteNonQuery();
                            c.Close();
                            string SQL10 = $"UPDATE City SET idCityWithNearestAirport = ID WHERE City.Name = '{comboBox3.Text}'";
                            c.Open();
                            MySqlCommand com10 = new MySqlCommand(SQL10, c);
                            com10.ExecuteNonQuery();
                            c.Close();
                            
                            Close();
                            
                        }
                        else
                        {
                            MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Аэропорт с таким кодом уже существует", "ОК", "", "ОК", "");
                            mmb.Show();
                        }
                    }
                    else
                    {
                        MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Аэропорт с таким названием уже существует", "ОК", "", "ОК", "");
                        mmb.Show();
                    }
                }
                else
                {
                    MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Код должен  состоять из трех букв", "ОК", "", "ОК", "");
                    mmb.Show();
                }
            }
            else
            {
                MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Введите значение", "ОК", "", "ОК", "");
                mmb.Show();
            }
            
        }

        private void Label8_MouseEnter(object sender, EventArgs e)
        {
            label8.ForeColor = Color.LightGreen;
        }

        private void Label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.SeaGreen;
        }

        private void Label8_Click(object sender, EventArgs e)
        {
            AddHotel ah = new AddHotel(Form.Form, this);
            AddCity ac = new AddCity(ah);
            ac.Show();
        }
    }
}
