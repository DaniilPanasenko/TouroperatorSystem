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
    public partial class AddTouragency : Form
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
        public AddTouragency(HomeForm Frm)
        {
            Form = Frm;
            InitializeComponent();
            c.Open();
            string sql = "SELECT login FROM Account WHERE isAdmin=0 AND login NOT IN (SELECT login FROM agency)";
            MySqlCommand command = new MySqlCommand(sql, c);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0].ToString());
            }
            c.Close();
        }

        private void AddTouragency_Load(object sender, EventArgs e)
        {

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

        private void Label8_MouseEnter(object sender, EventArgs e)
        {
            label8.ForeColor = Color.LightGreen;
        }

        private void Label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.SeaGreen;
        }

        private void No_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            if (Yes.Text == "Добавить")
            {
                bool res = true;
                if (textBox0.Text.Length < 8)
                {
                    res = false;
                    label9.Visible=true;
                }
                if (comboBox1.Text == "")
                {
                    label10.Visible = true;
                    res = false;
                }
                if (textBox1.Text.Length < 8)
                {
                    res = false;
                    label1.Visible = true;
                }
                if (Convert.ToDateTime(dateTimePicker1.Value) > DateTime.Now)
                {
                    res = false;
                    label12.Visible = true;
                }
                if (res)
                {
                    string SQL = $"INSERT INTO Agency (login, name, director, dateLicense, comission) VALUES('{comboBox1.Text}', '{textBox0.Text}', '{textBox1.Text}','{dateTimePicker1.Value.Year}-{dateTimePicker1.Value.Month}-{dateTimePicker1.Value.Day}','10')";
                    c.Open();
                    MySqlCommand com = new MySqlCommand(SQL, c);
                    com.ExecuteNonQuery();
                    string sql = "SELECT Name, Director,Login, DateLicense, Comission FROM Agency";
                    MySqlCommand command = new MySqlCommand(sql, c);
                    MySqlDataReader reader = command.ExecuteReader();
                    Agencies ag = (Agencies)Form.State;
                    f.CreateDataGridView(ag.dataGridView1, reader);
                    c.Close();
                    Close();
                }
            }
            if (Yes.Text == "Изменить")
            {
                bool res = true;
                if (textBox0.Text.Length < 8)
                {
                    res = false;
                    label9.Visible = true;
                }
                if (textBox1.Text.Length < 8)
                {
                    res = false;
                    label1.Visible = true;
                }
                if (Convert.ToDateTime(dateTimePicker1.Value) > DateTime.Now)
                {
                    res = false;
                    label12.Visible = true;
                }
                if (res)
                {
                    MyMessageBox mb = new MyMessageBox(this, "Предупреждение", "Изменить агентство?", "Да", "Нет", "Изменить_Агентство_Да", "Выход_Нет");
                    mb.Show();
                }
            }
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dateTimePicker1.Value) <= DateTime.Now)
            {
                label12.Visible = false;

            }
            else
            {
                label12.Visible = true;
            }
        }

        private void TextBox0_TextChanged(object sender, EventArgs e)
        {
            if (textBox0.Text.Length > 7)
            {
                label9.Visible = false;
            }
            else
            {
                label9.Visible = true ;
            }
            
        
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 7)
            {
                label11.Visible = false;
            }
            else
            {
                label11.Visible = true;
            }
        }

        private void ComboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length != 0)
            {
                label10.Visible = false;
            }
            else
            {
                label10.Visible = true;
            }
        }

        private void Label8_Click(object sender, EventArgs e)
        {
            AddAccount aa = new AddAccount(this);
            aa.comboBox1.Visible = false;
            aa.textBox2.Visible = true;
            aa.Show();
        }
    }
}
