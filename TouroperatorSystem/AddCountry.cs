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
    public partial class AddCountry : Form
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
        public AddCity Form { get; set; }
        public int ID { get; set; }
        public AddCountry(AddCity frm)
        {
            Form=frm;
            InitializeComponent();
            int i = 1;
            c.Open();
            string sql = "SELECT ID FROM Country ORDER BY ID ASC";
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
        private void Yes_Click(object sender, EventArgs e)
        {
            if (textBox0.Text != "")
            {
                c.Open();
                string sql = $"SELECT ID FROM Country WHERE Name = '{textBox0.Text}'";
                MySqlCommand command = new MySqlCommand(sql, c);
                MySqlDataReader reader = command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    i++;
                }
                c.Close();
                if (i==0)
                {
                    string SQL = $"INSERT INTO Country (ID, Name) VALUES('{ID}','{textBox0.Text}')";
                    c.Open();
                    MySqlCommand com = new MySqlCommand(SQL, c);
                    com.ExecuteNonQuery();
                    c.Close();
                    c.Open();
                    string sql1 = "SELECT Name FROM Country ";
                    MySqlCommand command1 = new MySqlCommand(sql1, c);
                    MySqlDataReader reader1 = command1.ExecuteReader();
                    Form.Form.comboBox2.Items.Clear();
                    Form.comboBox2.Items.Clear();
                    Form.comboBox1.Items.Clear();
                    while (reader1.Read())
                    {
                        Form.Form.comboBox2.Items.Add(reader1[0].ToString());
                        Form.comboBox2.Items.Add(reader1[0].ToString());
                        Form.comboBox1.Items.Add(reader1[0].ToString());
                    }
                    c.Close();
                    Form.Form.comboBox2.SelectedItem = textBox0.Text;
                    Form.comboBox2.SelectedItem = textBox0.Text;
                    Form.comboBox1.SelectedItem = textBox0.Text;
                    Close();
                }
                else
                {
                    MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Страна с таким названием уже существует", "ОК", "", "ОК", "");
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
    }
}
