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
    public partial class AddFlight : Form
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
        public HomeForm Form { get; set; }
        public bool PanelMouseDown { get; set; }
        public Point PanelMouseDownLocation { get; set; }
        public AddFlight(HomeForm frm)
        {
            Form = frm;
            InitializeComponent();
            string SQL1 = "SELECT Country.Name FROM Country";
            c.Open();
            MySqlCommand command = new MySqlCommand(SQL1, c);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader[0].ToString());
                comboBox3.Items.Add(reader[0].ToString());
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

        private void AddFlight_Load(object sender, EventArgs e)
        {

        }
        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox6.Items.Clear();
            comboBox5.Items.Clear();
            string SQL1 = "SELECT Airport.Code, Airport.Name FROM Airport, City, Country WHERE " +
                $"Country.Name='{comboBox2.SelectedItem}' AND Country.Id=City.IdCountry AND Airport.IdCity=City.ID";
            c.Open();
            MySqlCommand command = new MySqlCommand(SQL1, c);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox4.Items.Add(reader[0].ToString() + $" ({reader[1].ToString()})");

            }
            c.Close();
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox6.Items.Clear();
            comboBox5.Items.Clear();
            string SQL1 = "SELECT Airport.Code, Airport.Name FROM Airport, City, Country WHERE " +
                $"Country.Name='{comboBox3.SelectedItem}' AND Country.Id=City.IdCountry AND Airport.IdCity=City.ID";
            c.Open();
            MySqlCommand command = new MySqlCommand(SQL1, c);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0].ToString() + $" ({reader[1].ToString()})");

            }
            c.Close();
        }
        private void No_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            comboBox5.Items.Clear();
            if (comboBox4.Text!="" && comboBox1.Text != "")
            {
                string SQL1 = $"SELECT Route.RouteNum FROM Route " +
                    $"WHERE Route.CodeAirportDeparture = '{comboBox4.Text.Substring(0,3)}' AND Route.CodeAirportArrive = '{comboBox1.Text.Substring(0, 3)}'";
                c.Open();
                MySqlCommand command = new MySqlCommand(SQL1, c);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox6.Items.Add(reader[0].ToString());

                }
                c.Close();
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
  
            comboBox6.Items.Clear();
            comboBox5.Items.Clear();
            if (comboBox4.Text != "" && comboBox1.Text != "")
            {
                string SQL1 = $"SELECT Route.RouteNum FROM Route " +
                    $"WHERE Route.CodeAirportDeparture = '{comboBox4.Text.Substring(0, 3)}' AND Route.CodeAirportArrive = '{comboBox1.Text.Substring(0, 3)}'";
                c.Open();
                MySqlCommand command = new MySqlCommand(SQL1, c);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox6.Items.Add(reader[0].ToString());

                }
                c.Close();
            }
        }

        private void ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
                string SQL1 = $"SELECT Flight.Datetime FROM Flight " +
                    $"WHERE NumRoute = '{comboBox6.Text}'";
                c.Open();
                MySqlCommand command = new MySqlCommand(SQL1, c);
                MySqlDataReader reader = command.ExecuteReader();
            DateTime[] arr = new DateTime[0];
                while (reader.Read())
                {
                Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length-1] = Convert.ToDateTime(reader[0].ToString());

                }
            Array.Sort(arr);
            for(int i=0; i<arr.Length; i++)
            {
                comboBox5.Items.Add(arr[i].ToString());
            }
                c.Close();
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text != "")
            {
                string sql0 = $"SELECT VoucherFlight.idVoucher FROM VoucherFlight WHERE VoucherFlight.idFlight = "+
                $"(SELECT ID FROM Flight WHERE NumRoute = '{comboBox6}' AND " +
                       $"dateTime = STR_TO_DATE('{comboBox5.Text.Replace('.', '-').Replace(':', '-').Replace(' ', '-')}'" +
                       $",'%d-%m-%Y-%H-%i-%s')) AND" +
                       $" idVoucher = '{((OneVoucher)Form.State).label1.Text.Split(' ')[2]}'";
                c.Open();
                MySqlCommand command0 = new MySqlCommand(sql0, c);
                MySqlDataReader reader = command0.ExecuteReader();
                if (reader.Read())
                {
                    MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Данный полет уже присутствует в этой путевке", "ОК", "", "ОК", "");
                    mmb.Show();
                }
                else
                {
                    c.Close();
                    string sql = $"INSERT INTO VoucherFlight (idVoucher, idFlight) " +
                        $"VALUES('{((OneVoucher)Form.State).label1.Text.Split(' ')[2]}'," +
                        $"(SELECT ID FROM Flight WHERE NumRoute = '{comboBox6.Text}' AND " +
                        $"dateTime = STR_TO_DATE('{comboBox5.Text.Replace('.','-').Replace(':','-').Replace(' ','-')}'" +
                        $",'%d-%m-%Y-%H-%i-%s')))";
                    c.Open();
                    MySqlCommand command = new MySqlCommand(sql, c);
                    command.ExecuteNonQuery();
                    c.Close();
                }
                string sql2 = $"SELECT Route.RouteNum, Route.CodeAirportDeparture, Route.CodeAirportArrive, Flight.dateTime, Flight.ID " +
                $"FROM Route, Flight, Voucherflight, Voucher " +
                $"WHERE Voucher.ID ={((OneVoucher)Form.State).label1.Text.Split(' ')[2]} AND VoucherFlight.idVoucher = Voucher.ID AND " +
                $"Flight.ID = VoucherFlight.idFlight AND Flight.NumRoute = Route.RouteNum";

                c.Open();
                MySqlCommand comm2 = new MySqlCommand(sql2, c);
                MySqlDataReader reader2 = comm2.ExecuteReader();
                f.CreateDataGridView(((OneVoucher)Form.State).dataGridView2, reader2);
                c.Close();
                Close();
            }
            else
            {
                MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Введите значение", "ОК", "", "ОК", "");
                mmb.Show();
            }
        }

        private void ComboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            if (comboBox4.Text != "" && comboBox1.Text != "")
            {
                string SQL1 = $"SELECT Route.RouteNum FROM Route " +
                    $"WHERE Route.CodeAirportDeparture = '{comboBox4.Text.Substring(0, 3)}' AND Route.CodeAirportArrive = '{comboBox1.Text.Substring(0, 3)}'";
                c.Open();
                MySqlCommand command = new MySqlCommand(SQL1, c);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox6.Items.Add(reader[0].ToString());

                }
                c.Close();
            }
        }

        private void ComboBox4_TabIndexChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            if (comboBox4.Text != "" && comboBox1.Text != "")
            {
                string SQL1 = $"SELECT Route.RouteNum FROM Route " +
                    $"WHERE Route.CodeAirportDeparture = '{comboBox4.Text.Substring(0, 3)}' AND Route.CodeAirportArrive = '{comboBox1.Text.Substring(0, 3)}'";
                c.Open();
                MySqlCommand command = new MySqlCommand(SQL1, c);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox6.Items.Add(reader[0].ToString());

                }
                c.Close();
            }
        }
    }
}
