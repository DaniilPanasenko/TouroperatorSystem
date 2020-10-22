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
    public partial class AddRoom : Form
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
        public HomeForm Form { get; set; }
        public AddRoom(HomeForm frm)
        {
            Form = frm;
            InitializeComponent();
            textBox0.Text = ((OneHotel)Form.State).Hotel.Name;
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

        private void Plus_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox3.Text) != 9)
            {
                textBox3.Text = (int.Parse(textBox3.Text) + 1).ToString();
            }
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox3.Text) != 1)
            {
                textBox3.Text = (int.Parse(textBox3.Text) - 1).ToString();
            }
        }
        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar<=47 || e.KeyChar>=58)&& e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            if (Yes.Text == "Добавить")
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    int idHotel = ((OneHotel)Form.State).Hotel.ID;
                    int i = 1;
                    c.Open();
                    string sql = "SELECT ID FROM Room ORDER BY ID ASC";
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
                    string SQL = $"INSERT INTO Room (id, idHotel, price, NumPerson, TypeRoom) VALUES('{i}', '{idHotel}', '{textBox2.Text}', '{textBox3.Text}','{textBox1.Text}')";
                    c.Open();
                    MySqlCommand com = new MySqlCommand(SQL, c);
                    com.ExecuteNonQuery();
                    c.Close();
                    c.Open();
                    string sql1 = $"SELECT TypeRoom, NumPerson, Price, id FROM Room WHERE idHotel = {idHotel}";
                    MySqlCommand command1 = new MySqlCommand(sql1, c);
                    MySqlDataReader reader1 = command1.ExecuteReader();
                    f.CreateDataGridView(((OneHotel)Form.State).dataGridView1, reader1);
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
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    int idHotel = ((OneHotel)Form.State).Hotel.ID;
                    
                    string SQL = $"UPDATE Room SET TypeRoom = '{textBox1.Text}', NumPerson = '{textBox3.Text}', price = '{textBox2.Text}' WHERE ID = '{((OneHotel)Form.State).dataGridView1.SelectedRows[0].Cells[3].Value.ToString()}'";
                    c.Open();
                    MySqlCommand com = new MySqlCommand(SQL, c);
                    com.ExecuteNonQuery();
                    c.Close();
                    c.Open();
                    string sql1 = $"SELECT TypeRoom, NumPerson, Price, id FROM Room WHERE idHotel = {idHotel}";
                    MySqlCommand command1 = new MySqlCommand(sql1, c);
                    MySqlDataReader reader1 = command1.ExecuteReader();
                    f.CreateDataGridView(((OneHotel)Form.State).dataGridView1, reader1);
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
    }
}
