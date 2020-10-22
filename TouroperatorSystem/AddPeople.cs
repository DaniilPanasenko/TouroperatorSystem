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
    public partial class AddPeople : Form
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
        HomeForm Form { get; set; }
        public int ID { get; set; }
        public AddPeople(HomeForm hf, int id)
        {
            ID = id;
            Form = hf;
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
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void No_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            string pas = textBox0.Text;
            string apas = textBox1.Text;
            string inn = textBox2.Text;
            string name = textBox3.Text;
            string sur = textBox4.Text;
            string nat = comboBox2.Text;
            string date = dateTimePicker1.Value.ToShortDateString().Replace('.', '-');
            int sex = -1;
            if (comboBox1.Text == "")
            {

            }
            else
            {
                if (comboBox1.Text[0] == 'М')
                {
                    sex = 1;
                }
                if (comboBox1.Text[0] == 'Ж')
                {
                    sex = 0;
                }
            }
            
            if (pas!="" && apas!="" && inn!="" && name!="" && sur!="" && nat!="" && sex!=-1)
            {
                c.Open();
                string sql1 = $"SELECT ID FROM Country WHERE Name ='{nat}' ";
                MySqlCommand command1 = new MySqlCommand(sql1, c);
                MySqlDataReader reader1 = command1.ExecuteReader();
                reader1.Read();
                int cou = Convert.ToInt32(reader1[0]);
                c.Close();
                bool t = false;
                c.Open();
                sql1 = $"SELECT Passport FROM People WHERE passport ='{pas}' ";
                command1 = new MySqlCommand(sql1, c);
                reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    t = true;
                }
                c.Close();
                if (t)
                {
                   
                    c.Open();
                    string sql = $"UPDATE People SET abroadPassport='{apas}', INN = '{inn}', name = '{name}', " +
                        $"surname ='{sur}', idNational ='{cou}', sex = '{sex}', birthday = STR_TO_DATE('{date}','%d-%m-%Y') " +
                        $"WHERE passport={pas}";
                    MySqlCommand command = new MySqlCommand(sql, c);
                    command.ExecuteNonQuery();
                    c.Close();
                }
                else
                {
                    c.Open();
                    string sql = $"INSERT INTO People (passport, abroadPassport, inn, name, surname, sex, idNational, birthday) " +
                        $"VALUES ('{pas}','{apas}','{inn}','{name}','{sur}','{sex}','{cou}', STR_TO_DATE('{date}','%d-%m-%Y'))";
                    MySqlCommand command = new MySqlCommand(sql, c);
                    command.ExecuteNonQuery();
                    c.Close();
                }
                c.Open();
                sql1 = $"SELECT idVoucher FROM VoucherPeople WHERE passport ='{pas}' AND idVoucher = '{ID}' ";
                command1 = new MySqlCommand(sql1, c);
                reader1 = command1.ExecuteReader();
                bool h = false;
                while (reader1.Read())
                {
                    h = true;
                }
                c.Close();
                if (!h)
                {
                    c.Open();
                    string sql = $"INSERT INTO VoucherPeople (passport, idVoucher) " +
                        $"VALUES ('{pas}','{ID}')";
                    MySqlCommand command = new MySqlCommand(sql, c);
                    command.ExecuteNonQuery();
                    c.Close();
                }
                
                string sql10 = $"SELECT People.Surname, People.Name, People.Passport, People.Birthday, People.Sex, Country.Name " +
                $"FROM People, Voucherpeople, Country " +
                $"WHERE People.IdNational=Country.ID AND People.Passport = Voucherpeople.passport AND Voucherpeople.idVoucher ='{ID}' ";
                c.Open();
                MySqlCommand comm10 = new MySqlCommand(sql10, c);
                MySqlDataReader reader10 = comm10.ExecuteReader();
                f.CreateDataGridView(((OneVoucher)Form.State).dataGridView1, reader10);
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
