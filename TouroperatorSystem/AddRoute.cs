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
    public partial class AddRoute : Form
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
        public AddRoute(HomeForm frm)
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
            string SQL2 = "SELECT Airline.Name FROM Airline";
            c.Open();
            MySqlCommand command1 = new MySqlCommand(SQL2, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox6.Items.Add(reader1[0].ToString());
            }
            c.Close();
        }
        public AddRoute(HomeForm frm, bool t) : this(frm)
        {
            label4.Text = "Edit Route";
            Yes.Text = "Изменить";
            Routes cur = (Routes)frm.State;
            string sql = $"SELECT Country.Name, Airport.Name, Airport.Code FROM Airport, Country, City WHERE Airport.idCity = City.Id AND City.IdCountry = Country.ID AND Airport.Code='{cur.dataGridView1.SelectedRows[0].Cells[2].Value.ToString()}'";
            c.Open();
            MySqlCommand command = new MySqlCommand(sql, c);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string[] arr = { reader[0].ToString(), reader[1].ToString(), reader[2].ToString() };
            c.Close();
            comboBox2.SelectedItem = arr[0];
            comboBox4.SelectedItem = arr[2]+" ("+arr[1]+")";
            string sql1 = $"SELECT Country.Name, Airport.Name, Airport.Code FROM Airport, Country, City WHERE Airport.idCity = City.Id AND City.IdCountry = Country.ID AND Airport.Code='{cur.dataGridView1.SelectedRows[0].Cells[3].Value.ToString()}'";
            c.Open();
            MySqlCommand command1 = new MySqlCommand(sql1, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            reader1.Read();
            string[] arr1 = { reader1[0].ToString(), reader1[1].ToString(), reader1[2].ToString() };
            c.Close();
            comboBox3.SelectedItem = arr1[0];
            comboBox1.SelectedItem = arr1[2] + " (" + arr1[1]+ ")";
            comboBox6.SelectedItem = cur.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string sql2 = $"SELECT TimeFlight, NumPlace, Price, Plane, Days FROM Route WHERE Route.RouteNum ='{cur.dataGridView1.SelectedRows[0].Cells[0].Value.ToString()}'";
            c.Open();
            MySqlCommand command2 = new MySqlCommand(sql2, c);
            MySqlDataReader reader2 = command2.ExecuteReader();
            reader2.Read();
            string strr = reader2[0].ToString();
            DateTime d = Convert.ToDateTime(strr);
            textBox1.Text = reader2[3].ToString();
            textBox2.Text = reader2[1].ToString();
            textBox3.Text = reader2[2].ToString();
            string[] array = reader2[4].ToString().Split(',');
            for(int i=0; i<array.Length; i++)
            {
                if (array[i] == "1")
                {
                    checkBox3.Checked = true;
                }
                if (array[i] == "2")
                {
                    checkBox1.Checked = true;
                }
                if (array[i] == "3")
                {
                    checkBox2.Checked = true;
                }
                if (array[i] == "4")
                {
                    checkBox4.Checked = true;
                }
                if (array[i] == "5")
                {
                    checkBox5.Checked = true;
                }
                if (array[i] == "6")
                {
                    checkBox6.Checked = true;
                }
                if (array[i] == "7")
                {
                    checkBox7.Checked = true;
                }
            }
            c.Close();
            numericUpDown2.Value = Convert.ToInt32(cur.dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Substring(0,2));
            numericUpDown1.Value = Convert.ToInt32(cur.dataGridView1.SelectedRows[0].Cells[4].Value.ToString().Substring(3, 2));
            numericUpDown3.Value = d.Hour;
            numericUpDown4.Value = d.Minute;
            textBox0.Text = cur.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox0.ReadOnly = true;
            textBox0.BorderStyle = BorderStyle.None;
        }
        private void AddRoute_Load(object sender, EventArgs e)
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

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            if (c.Checked)
            {
                c.ForeColor = white;
            }
            else
            {
                c.ForeColor = black ;
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            string SQL1 = "SELECT Airport.Code, Airport.Name FROM Airport, City, Country WHERE " +
                $"Country.Name='{comboBox2.SelectedItem}' AND Country.Id=City.IdCountry AND Airport.IdCity=City.ID";
            c.Open();
            MySqlCommand command = new MySqlCommand(SQL1, c);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox4.Items.Add(reader[0].ToString()+$" ({reader[1].ToString()})");

            }
            c.Close();
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
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

        private void Yes_Click(object sender, EventArgs e)
        {
            if (Yes.Text == "Добавить")
            {
                string airport1 = "";
                string airport2 = "";
                if (comboBox4.Text != "" && comboBox1.Text != "")
                {
                    airport1 = comboBox4.Text.Substring(0, 3);
                    airport2 = comboBox1.Text.Substring(0, 3);
                }
                string airline = "";
                if (comboBox6.Text != "")
                {
                    string SQL2 = $"SELECT Airline.Code FROM Airline WHERE Airline.Name = '{comboBox6.Text}'";
                    c.Open();
                    MySqlCommand command2 = new MySqlCommand(SQL2, c);
                    MySqlDataReader reader2 = command2.ExecuteReader();
                    reader2.Read();
                    airline = reader2[0].ToString();
                }
                c.Close();
                string num = textBox0.Text;
                string timedep = numericUpDown2.Value.ToString() + '-' + numericUpDown1.Value.ToString();
                string timefly = numericUpDown3.Value.ToString() + '-' + numericUpDown4.Value.ToString();
                string plane = textBox1.Text;
                string places = textBox2.Text;
                string price = textBox3.Text;
                string days = "";
                if (checkBox3.Checked)
                {
                    days += "1,";
                }
                if (checkBox1.Checked)
                {
                    days += "2,";
                }
                if (checkBox2.Checked)
                {
                    days += "3,";
                }
                if (checkBox4.Checked)
                {
                    days += "4,";
                }
                if (checkBox5.Checked)
                {
                    days += "5,";
                }
                if (checkBox6.Checked)
                {
                    days += "6,";
                }
                if (checkBox7.Checked)
                {
                    days += "7,";
                }
                if (days != "")
                {
                    days = days.Substring(0, days.Length - 1);
                }
                string SQL = $"INSERT INTO Route (Price, RouteNum, CodeAirline, CodeAirportDeparture, CodeAirportArrive, Plane, NumPlace, TimeFlight, TimeDeparture, days) " +
                    $"VALUES('{price}','{num}','{airline}','{airport1}','{airport2}' ,'{plane}',{places},STR_TO_DATE('{timefly}','%H-%i'),STR_TO_DATE('{timedep}','%H-%i'),{days})";
                if (days != "" && price != "" && places != "" && plane != "" && num != "" && airline != "" && airport1 != "" && airport2 != "")
                {
                    if (airport1 != airport2)
                    {
                        string SQL3 = $"SELECT Route.RouteNum FROM Route WHERE Route.RouteNum = '{textBox0.Text}'";
                        c.Open();
                        MySqlCommand command3 = new MySqlCommand(SQL3, c);
                        MySqlDataReader reader3 = command3.ExecuteReader();
                        int i = 0;
                        while (reader3.Read())
                        {
                            i++;
                        }
                        c.Close();
                        if (i == 0)
                        {
                            c.Open();
                            MySqlCommand com = new MySqlCommand(SQL, c);
                            com.ExecuteNonQuery();
                            c.Close();
                        }
                        else
                        {
                            MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Рейс с таким номером уже существует", "ОК", "", "ОК", "");
                            mmb.Show();
                        }
                    }
                    else
                    {
                        MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Нельзя создать рейс с одним аэропортом отбытия и прибытия", "ОК", "", "ОК", "");
                        mmb.Show();
                    }
                }
                else
                {
                    MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Введите значение", "ОК", "", "ОК", "");
                    mmb.Show();
                }
                c.Open();
                string sql = "SELECT Route.RouteNum, Airline.Name , Route.CodeAirportDeparture, Route.CodeAirportArrive, Route.TimeDeparture, Route.days, Route.Price FROM Route, Airline WHERE Route.CodeAirline = Airline.Code";
                MySqlCommand command = new MySqlCommand(sql, c);
                MySqlDataReader reader = command.ExecuteReader();
                Routes r = (Routes)Form.State;
                f.CreateDataGridView(r.dataGridView1, reader);
                c.Close();
                Close();
            }
            else
            {
                string airport1 = "";
                string airport2 = "";
                if (comboBox4.Text != "" && comboBox1.Text != "")
                {
                    airport1 = comboBox4.Text.Substring(0, 3);
                    airport2 = comboBox1.Text.Substring(0, 3);
                }
                string airline = "";
                if (comboBox6.Text != "")
                {
                    string SQL2 = $"SELECT Airline.Code FROM Airline WHERE Airline.Name = '{comboBox6.Text}'";
                    c.Open();
                    MySqlCommand command2 = new MySqlCommand(SQL2, c);
                    MySqlDataReader reader2 = command2.ExecuteReader();
                    reader2.Read();
                    airline = reader2[0].ToString();
                }
                c.Close();
                string num = textBox0.Text;
                string timedep = numericUpDown2.Value.ToString() + '-' + numericUpDown1.Value.ToString();
                string timefly = numericUpDown3.Value.ToString() + '-' + numericUpDown4.Value.ToString();
                string plane = textBox1.Text;
                string places = textBox2.Text;
                string price = textBox3.Text;
                string days = "";
                if (checkBox3.Checked)
                {
                    days += "1,";
                }
                if (checkBox1.Checked)
                {
                    days += "2,";
                }
                if (checkBox2.Checked)
                {
                    days += "3,";
                }
                if (checkBox4.Checked)
                {
                    days += "4,";
                }
                if (checkBox5.Checked)
                {
                    days += "5,";
                }
                if (checkBox6.Checked)
                {
                    days += "6,";
                }
                if (checkBox7.Checked)
                {
                    days += "7,";
                }
                if (days != "")
                {
                    days = days.Substring(0, days.Length - 1);
                }
                string SQL = $"UPDATE Route SET Price = '{price}', CodeAirline = '{airline}'" +
                    $", CodeAirportDeparture = '{airport1}', CodeAirportArrive = '{airport2}'," +
                    $" Plane = '{plane}', NumPlace = '{places}', TimeFlight = STR_TO_DATE('{timefly}','%H-%i')" +
                    $", TimeDeparture = STR_TO_DATE('{timedep}','%H-%i'), days = '{days}' WHERE RouteNum = '{num}'";
                    
                if (days != "" && price != "" && places != "" && plane != "" && num != "" && airline != "" && airport1 != "" && airport2 != "")
                {
                    if (airport1 != airport2)
                    {
                        c.Open();
                        MySqlCommand com = new MySqlCommand(SQL, c);
                        com.ExecuteNonQuery();
                        c.Close();
                    }
                    else
                    {
                        MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Нельзя создать рейс с одним аэропортом отбытия и прибытия", "ОК", "", "ОК", "");
                        mmb.Show();
                    }
                }
                else
                {
                    MyMessageBox mmb = new MyMessageBox(Form, "Ошибка", "Введите значение", "ОК", "", "ОК", "");
                    mmb.Show();
                }
                c.Open();
                string sql = "SELECT Route.RouteNum, Airline.Name , Route.CodeAirportDeparture, Route.CodeAirportArrive, Route.TimeDeparture, Route.days, Route.Price FROM Route, Airline WHERE Route.CodeAirline = Airline.Code";
                MySqlCommand command = new MySqlCommand(sql, c);
                MySqlDataReader reader = command.ExecuteReader();
                Routes r = (Routes)Form.State;
                f.CreateDataGridView(r.dataGridView1, reader);
                c.Close();
                Close();
            
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            char[] arr = new char[textBox2.Text.Length];
            string newstr = "";
            for(int i =0; i<arr.Length; i++)
            {
                arr[i] = textBox2.Text[i];
                try
                {
                    int l = int.Parse(arr[i] + "");
                    newstr += l;
                }
                catch
                {
                    
                }
            }
            textBox2.Text = newstr;
            textBox2.SelectionStart = newstr.Length;
            textBox2.SelectionLength = 0;
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            char[] arr = new char[textBox3.Text.Length];
            string newstr = "";
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = textBox3.Text[i];
                try
                {
                    int l = int.Parse(arr[i] + "");
                    newstr += l;
                }
                catch
                {

                }
            }
            textBox3.Text = newstr;
            textBox3.SelectionStart = newstr.Length;
            textBox3.SelectionLength = 0;
        }

        private void Label8_MouseEnter(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            l.ForeColor = Color.LightGreen;
        }

        private void Label8_MouseLeave(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            l.ForeColor = Color.SeaGreen;
        }

        private void Label8_Click(object sender, EventArgs e)
        {
            AddAirport aa = new AddAirport(this);
            aa.Show();
        }

        private void Label7_Click(object sender, EventArgs e)
        {
            AddAirline aa = new AddAirline(this);
            aa.Show();
        }
    }
}
