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
    public partial class AddHotel : Form
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
        public int ID { get; set; }
        public bool PanelMouseDown { get; set; }
        public Point PanelMouseDownLocation { get; set; }
        public HomeForm Form { get; set; }
        public AddAirport addairport {get; set;}
        public bool FromAddAirport { get; set; }
        public AddHotel(HomeForm frm)
        {
            FromAddAirport = false;
            Form = frm;
            InitializeComponent();
            if (label4.Text == "Add Hotel")
            {
                int i = 1;
                c.Open();
                string sql = "SELECT ID FROM Hotel ORDER BY ID ASC";
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
                c.Open();
                string sql1 = "SELECT Name FROM Country ";
                MySqlCommand command1 = new MySqlCommand(sql1, c);
                MySqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    comboBox2.Items.Add(reader1[0].ToString());
                }
                c.Close();
            }
            else
            {
                c.Open();
                string sql1 = "SELECT Name FROM Country ";
                MySqlCommand command1 = new MySqlCommand(sql1, c);
                MySqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    comboBox2.Items.Add(reader1[0].ToString());
                }
                c.Close();
            }
        }
        public AddHotel(HomeForm frm, AddAirport ar): this(frm)
        {

            FromAddAirport = true;
            addairport = ar;
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
        private void AddHotel_Load(object sender, EventArgs e)
        {
            
        }
        

        private void Plus_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) != 5)
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
        private void Label8_MouseEnter(object sender, EventArgs e)
        {
            label8.ForeColor = Color.LightGreen;
        }

        private void Label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.SeaGreen;
        }
        private void Label7_MouseEnter(object sender, EventArgs e)
        {
            label7.ForeColor = Color.LightGreen;
        }

        private void Label7_MouseLeave(object sender, EventArgs e)
        {
            label7.ForeColor = Color.SeaGreen;
        }

        private void ComboBox2_TextChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            c.Open();
            string sql1 = $"SELECT City.Name FROM City, Country WHERE City.IdCountry = Country.ID AND Country.Name = '{comboBox2.Text}' ";
            MySqlCommand command1 = new MySqlCommand(sql1, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox3.Items.Add(reader1[0].ToString());
            }
            c.Close();
        }

        private void Label8_Click(object sender, EventArgs e)
        {
            AddCountry a = new AddCountry(new AddCity(this));
            a.Show();
        }

        private void Label7_Click(object sender, EventArgs e)
        {
            AddCity a = new AddCity(this);
            a.Show();
        }

        private void No_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            if (label4.Text == "Add Hotel")
            {

                if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" )
                {
                    c.Open();
                    string sql = $"SELECT ID FROM City WHERE Name = '{comboBox3.Text}'";
                    MySqlCommand command = new MySqlCommand(sql, c);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    int id = Convert.ToInt32(reader[0]);
                    c.Close();
                    string SQL = $"INSERT INTO Hotel (ID, IdCity, name, stars, food) VALUES('{ID}','{id}','{textBox0.Text}', '{int.Parse(textBox1.Text)}','{comboBox1.Text.Split(' ')[0]}')";
                    c.Open();
                    MySqlCommand com = new MySqlCommand(SQL, c);
                    com.ExecuteNonQuery();
                    string sql0 = "SELECT Hotel.Name, Hotel.Stars, Hotel.Food, City.Name, Country.Name, Hotel.ID FROM Hotel, City, Country WHERE Hotel.IdCity = City.ID AND City.IdCountry = Country.ID";
                    MySqlCommand command0 = new MySqlCommand(sql0, c);
                    MySqlDataReader reader0 = command0.ExecuteReader();
                    Hotels ag = (Hotels)Form.State;
                    f.CreateDataGridView(ag.dataGridView1, reader0);
                    c.Close();
                    Close();
                }
                else
                {
                    MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Введите значение", "ОК", "", "ОК", "");
                    mmb.Show();
                }
            }
            else
            {
                if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
                {
                    c.Open();
                    string sql = $"SELECT ID FROM City WHERE Name = '{comboBox3.Text}'";
                    MySqlCommand command = new MySqlCommand(sql, c);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    int id = Convert.ToInt32(reader[0]);
                    c.Close();
                    string SQL = $"UPDATE Hotel SET IdCity='{id}', name='{textBox0.Text}', stars='{int.Parse(textBox1.Text)}', food='{comboBox1.Text.Split(' ')[0]}' WHERE ID={ID}";
                    c.Open();
                    MySqlCommand com = new MySqlCommand(SQL, c);
                    com.ExecuteNonQuery();
                    string sql0 = "SELECT Hotel.Name, Hotel.Stars, Hotel.Food, City.Name, Country.Name, Hotel.ID FROM Hotel, City, Country WHERE Hotel.IdCity = City.ID AND City.IdCountry = Country.ID";
                    MySqlCommand command0 = new MySqlCommand(sql0, c);
                    MySqlDataReader reader0 = command0.ExecuteReader();
                    Hotels ag = (Hotels)Form.State;
                    f.CreateDataGridView(ag.dataGridView1, reader0);
                    c.Close();
                    Close();
                }
                else
                {
                    MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Введите значение", "ОК", "", "ОК", "");
                    mmb.Show();
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Hotels a = (Hotels)Form.State;
            c.Open();
            string sql = "SELECT Hotel.Name, Hotel.Stars, Hotel.Food, City.Name, Country.Name, Hotel.ID FROM Hotel, City, Country WHERE Hotel.IdCity = City.ID AND City.IdCountry = Country.ID";
            string str = comboBox1.Text;
            sql += $" AND Hotel.Name LIKE '%{textBox0.Text}%' AND Hotel.Stars = {int.Parse(textBox1.Text)} AND  Hotel.Food LIKE '%{str.Split(' ')[0]}%' AND City.Name LIKE '%{comboBox3.Text}%' AND Country.Name LIKE '%{comboBox2.Text}%'";
            MySqlCommand command = new MySqlCommand(sql, c);
            MySqlDataReader reader = command.ExecuteReader();
            f.CreateDataGridView(a.dataGridView1, reader);
            c.Close();
            Close();
        }
    }
}
