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
    public partial class AddAirline : Form
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
        public AddAirline(AddRoute ar)
        {
            Form = ar;
            InitializeComponent();
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
            if(comboBox2.Text!="" && textBox0.Text != "")
            {
                if (textBox1.Text.Length == 3)
                {
                    string sql1 = $"SELECT Airline.Name FROM Airline WHERE Airline.Name = '{textBox0.Text}' ";
                    c.Open();
                    MySqlCommand command1 = new MySqlCommand(sql1, c);
                    MySqlDataReader reader1 = command1.ExecuteReader();
                    bool t1 = true;
                    while (reader1.Read())
                    {
                        t1 = false;
                    }
                    c.Close();
                    string sql2 = $"SELECT Airline.Code FROM Airline WHERE Airline.Code = '{textBox1.Text}' ";
                    c.Open();
                    MySqlCommand command2 = new MySqlCommand(sql2, c);
                    MySqlDataReader reader2 = command2.ExecuteReader();
                    bool t2 = true;
                    while (reader2.Read())
                    {
                        t2 = false;
                    }
                    c.Close();
                    if (t1)
                    {
                        if (t2)
                        {
                            c.Open();
                            string sql20 = $"SELECT Country.ID FROM Country WHERE Country.Name = '{comboBox2.Text}'";
                            MySqlCommand command20 = new MySqlCommand(sql20, c);
                            MySqlDataReader reader20 = command20.ExecuteReader();
                            int idc = 0;
                            while (reader20.Read())
                            {
                                idc = Convert.ToInt32(reader20[0]);
                            }
                            c.Close();
                            string sql3 = $"INSERT INTO Airline (Name, code, idCountry) VALUES ('{textBox0.Text}','{textBox1.Text}','{idc}')";
                            c.Open();
                            MySqlCommand command3 = new MySqlCommand(sql3, c);
                            command3.ExecuteNonQuery();
                            c.Close();
                            Form.comboBox6.Items.Clear();
                            string SQL2 = "SELECT Airline.Name FROM Airline";
                            c.Open();
                            MySqlCommand command100 = new MySqlCommand(SQL2, c);
                            MySqlDataReader reader100 = command100.ExecuteReader();
                            while (reader100.Read())
                            {
                                Form.comboBox6.Items.Add(reader100[0].ToString());
                            }
                            c.Close();
                            Form.comboBox6.SelectedItem = textBox0.Text;
                            Close();
                        }
                        else
                        {
                            MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Авиакомпания с таким кодом уже существует", "ОК", "", "ОК", "");
                            mmb.Show();
                        }
                    }
                    else
                    {
                        MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Авиакомпания с таким названием уже существует", "ОК", "", "ОК", "");
                        mmb.Show();
                    }
                }
                else
                {
                    MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Код должен состоять из 3 букв", "ОК", "", "ОК", "");
                    mmb.Show();
                }
            }
            else
            {
                MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Введите значение", "ОК", "", "ОК", "");
                mmb.Show();
            }
            
        }
    }
}
