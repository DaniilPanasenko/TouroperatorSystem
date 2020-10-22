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
    public partial class AddVoucher : Form
    {
        public static string connect = "server=localhost;user=root;database=cursach;password=Danilpanass1;";
        public static MySqlConnection c = new MySqlConnection(connect);
        public Color orange = Color.LightSalmon;
        public Color blue = Color.CornflowerBlue;
        public Color white = Color.White;
        public Color black = Color.Black;
        public Color trans = Color.Transparent;
        public Color red = Color.MistyRose;
        public int[] CurIDRomms { get; set; }
        Functions f = new Functions();
        public bool PanelMouseDown { get; set; }
        public Point PanelMouseDownLocation { get; set; }
        HomeForm Form { get; set; }
        public AddVoucher(HomeForm hf)
        {
            Form = hf;
            InitializeComponent();
            
            c.Open();
            string sql1 = "SELECT Name FROM Country ";
            MySqlCommand command1 = new MySqlCommand(sql1, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox7.Items.Add(reader1[0].ToString());
                comboBox2.Items.Add(reader1[0].ToString());
            }
            c.Close();
            c.Open();
            string sql2 = "SELECT Name FROM Agency ";
            MySqlCommand command2 = new MySqlCommand(sql2, c);
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                comboBox8.Items.Add(reader2[0].ToString());
            }
            c.Close();
            c.Open();
            string sql3 = "SELECT Max(ID) FROM  Voucher ";
            MySqlCommand command3 = new MySqlCommand(sql3, c);
            MySqlDataReader reader3 = command3.ExecuteReader();
            reader3.Read();
            textBox2.Text = (Convert.ToInt32(reader3[0]) + 1) + "";
            c.Close();
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
        private void AddVoucher_Load(object sender, EventArgs e)
        {

        }

        private void No_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox1.Items.Clear();
            comboBox4.Items.Clear();
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

        private void ComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            comboBox9.Items.Clear();
            c.Open();
            string sql1 = $"SELECT City.Name FROM City, Country WHERE City.IdCountry = Country.ID AND Country.Name = '{comboBox7.Text}' ";
            MySqlCommand command1 = new MySqlCommand(sql1, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox6.Items.Add(reader1[0].ToString());
            }
            c.Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            c.Open();
            string sql1 = $"SELECT Room.TypeRoom, Room.ID FROM Room, Hotel WHERE Hotel.Id = Room.idHotel AND Hotel.Name = '{comboBox1.Text}' ";
            MySqlCommand command1 = new MySqlCommand(sql1, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            int[] r = new int[0];
            while (reader1.Read())
            {
                comboBox4.Items.Add(reader1[0].ToString());
                Array.Resize(ref r, r.Length + 1);
                r[r.Length - 1] = Convert.ToInt32(reader1[1]);
            }
            c.Close();
            CurIDRomms = r;
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox4.Items.Clear();
            c.Open();
            string sql1 = $"SELECT Hotel.Name FROM City, Hotel WHERE Hotel.IdCity = City.ID AND City.Name = '{comboBox3.Text}' ";
            MySqlCommand command1 = new MySqlCommand(sql1, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox1.Items.Add(reader1[0].ToString());
            }
            c.Close();
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            if(comboBox4.Text!="" && comboBox9.Text != "" && comboBox5.Text!="" && comboBox8.Text!="")
            {
                string login = "";
                c.Open();
                string sql1 = $"SELECT Login FROM Agency WHERE Agency.Name = '{comboBox8.Text}' ";
                MySqlCommand command1 = new MySqlCommand(sql1, c);
                MySqlDataReader reader1 = command1.ExecuteReader();
                reader1.Read();
                login = reader1[0].ToString();
                c.Close();
                c.Open();
                string sql = "";
                if (Yes.Text == "Добавить")
                {
                     sql = $"INSERT INTO Voucher (ID, idTypeRoom, NumNights, DateHotel, login, CodeAirport, Status) " +
                        $"VALUES ('{textBox2.Text}','{CurIDRomms[comboBox4.SelectedIndex]}','{textBox1.Text}' , " +
                        $"STR_TO_DATE('{dateTimePicker1.Value.ToShortDateString().Replace('.', '-')}','%d-%m-%Y'),'{login}'," +
                        $"'{comboBox9.Text.Split(' ')[0]}','{comboBox5.Text}')";
                }
                else
                {
                    sql = $"UPDATE Voucher SET idTypeRoom = (SELECT Room.id FROM Room, Hotel WHERE Room.TypeRoom='{comboBox4.Text}' AND Hotel.Name = '{comboBox1.Text}' AND Room.IdHotel= Hotel.ID), NumNights = '{textBox1.Text}', " +
                        $"DateHotel = STR_TO_DATE('{dateTimePicker1.Value.ToShortDateString().Replace('.', '-')}','%d-%m-%Y'), " +
                        $"login = '{login}', CodeAirport ='{comboBox9.Text.Split(' ')[0]}' , Status ='{comboBox5.Text}' " +
                        $"WHERE ID = '{textBox2.Text}'";
                }
                MySqlCommand command = new MySqlCommand(sql, c);
                command.ExecuteNonQuery();
                c.Close();
                Close();
                Point p = ((Vouchers)Form.State).Location;
                Form.Controls.Remove(Form.State);
                Vouchers a = new Vouchers(Form);
                Form.State = a;
                Form.Controls.Add(a);
                a.Location = p;
                a.Visible = true;
                a.Show();
                Form.panel12.Visible = true;
            }
            else
            {
                MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Введите значение", "ОК", "", "ОК", "");
                mmb.Show();
            }
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox9.Items.Clear();
            c.Open();
            string sql1 = $"SELECT Airport.Code, Airport.Name FROM City, Airport WHERE Airport.idCity = City.ID AND City.Name = '{comboBox6.Text}' ";
            MySqlCommand command1 = new MySqlCommand(sql1, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox9.Items.Add(reader1[0].ToString()+$" ({reader1[1].ToString()})");
            }
            c.Close();
        }
    }
}
