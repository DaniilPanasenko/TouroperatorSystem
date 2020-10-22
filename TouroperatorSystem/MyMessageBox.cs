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
    public partial class MyMessageBox : Form
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
        public string Met1 { get; set; }
        public string Met2 { get; set; }
        public HomeForm Frm { get; set; }
        public Form Form { get; set; }
        public MyMessageBox(Form frm, string name, string message, string but1, string but2, string met1, string met2)
        {
            InitializeComponent();
            Form = frm;
            label4.Text = name;
            label1.Text = message;
            Yes.Text = but1;
            if (but2 != "")
            {
                No.Text = but2;
            }
            else
            {
                No.Visible = false;
                Yes.BackColor = Color.CornflowerBlue;
            }
            Met1 = met1;
            Met2 = met2;
        }
        public MyMessageBox(HomeForm frm, string name, string message, string but1, string but2, string met1, string met2)
        {
            InitializeComponent();
            Frm = frm;
            label4.Text = name;
            label1.Text = message;
            Yes.Text = but1;
            if (but2 != "")
            {
                No.Text = but2;
            }
            else
            {
                No.Visible = false;
                Yes.BackColor = Color.CornflowerBlue;
            }
            Met1 = met1;
            Met2 = met2;
        }
        private void MyMessageBox_Load(object sender, EventArgs e)
        {
            int lenbut = Yes.Size.Width;
            if (No.Visible)
            {
                lenbut += No.Size.Width+ 50;
            }
            this.Size = new Size(130 + Math.Max(lenbut, label1.Size.Width), this.Size.Height);
            label1.Location = new Point((this.Size.Width - label1.Size.Width) / 2, label1.Location.Y);
            Yes.Location = new Point((this.Size.Width - lenbut) / 2, Yes.Location.Y);
            No.Location = new Point((this.Size.Width - lenbut) / 2+Yes.Size.Width+50, Yes.Location.Y);
            Size screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            this.Location = new Point((screen.Width-this.Size.Width)/2, (screen.Height - this.Size.Height) / 2);
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


        private void Exit_Yes()
        {
            Frm.Si.Show();
            Frm.Close();
            Close();
        }
        private void Exit_No()
        {
            Close();
        }

        private void Delete_Agency_Yes()
        {
            
            Agencies a = (Agencies)Frm.State;
            int l = a.dataGridView1.SelectedRows.Count;
            string[] arr = new string[l];
            for(int i=0; i<l; i++)
            {
                arr[i] =  a.dataGridView1.SelectedRows[i].Cells[2].Value.ToString();
            }
            for (int i =0; i<l; i++)  
            {
                string SQL1 = "DELETE FROM Agency WHERE Login = "+'"'+$"{arr[i]}"+'"';
                string SQL4 = "DELETE FROM Vpucherpeople WHERE Login = " + '"' + $"{arr[i]}" + '"';
                string SQL2 = "DELETE FROM Voucher WHERE Login = " + '"' + $"{arr[i]}" + '"';
                string SQL3 = "DELETE FROM Account WHERE Login = " + '"' + $"{arr[i]}" + '"';
                c.Open();
                MySqlCommand com2 = new MySqlCommand(SQL2, c);
                com2.ExecuteNonQuery();
                MySqlCommand com1 = new MySqlCommand(SQL1, c);
                com1.ExecuteNonQuery();
                MySqlCommand com3 = new MySqlCommand(SQL3, c);
                com3.ExecuteNonQuery();
                string sql = "SELECT Name, Director,Login, DateLicense, Comission FROM Agency";
                MySqlCommand command = new MySqlCommand(sql, c);
                MySqlDataReader reader = command.ExecuteReader();
                f.CreateDataGridView(a.dataGridView1, reader);
                c.Close();
            }
            a.dataGridView1.ClearSelection();
            Frm.Update();
            
            Close();
        }
        private void Delete_Room_Yes()
        {
            OneHotel a = (OneHotel)Frm.State;
            int l = a.dataGridView1.SelectedRows.Count;
            int[] arr = new int[l];
            for (int i = 0; i < l; i++)
            {
                arr[i] = int.Parse(a.dataGridView1.SelectedRows[i].Cells[3].Value.ToString());
            }
            for (int i = 0; i < l; i++)
            {
                string SQL1 = "DELETE FROM Room WHERE ID = " + '"' + $"{arr[i]}" + '"';
                string SQL2 = "DELETE FROM Voucher WHERE idTypeRoom = " + '"' + $"{arr[i]}" + '"';
                c.Open();
                MySqlCommand com2 = new MySqlCommand(SQL2, c);
                com2.ExecuteNonQuery();
                MySqlCommand com1 = new MySqlCommand(SQL1, c);
                com1.ExecuteNonQuery();
                string sql = $"SELECT TypeRoom, NumPerson, Price , ID FROM Room WHERE idHotel = {a.Hotel.ID}";
                MySqlCommand command = new MySqlCommand(sql, c);
                MySqlDataReader reader = command.ExecuteReader();
                f.CreateDataGridView(a.dataGridView1, reader);
                c.Close();
            }
            a.dataGridView1.ClearSelection();
            Frm.Update();

            Close();
        }
        private void Delete_Account_Yes()
        {

            Accounts a = (Accounts)Frm.State;
            if (a.dataGridView1.SelectedRows.Count != 0)
            {
                int l = a.dataGridView1.SelectedRows.Count;
                string[] arr = new string[l];
                for (int i = 0; i < l; i++)
                {
                    arr[i] = a.dataGridView1.SelectedRows[i].Cells[1].Value.ToString();
                }
                for (int i = 0; i < l; i++)
                {
                    string SQL1 = "DELETE FROM Agency WHERE Login = " + '"' + $"{arr[i]}" + '"';
                    string SQL2 = "DELETE FROM Voucher WHERE Login = " + '"' + $"{arr[i]}" + '"';
                    string SQL3 = "DELETE FROM Account WHERE Login = " + '"' + $"{arr[i]}" + '"';
                    c.Open();
                    MySqlCommand com2 = new MySqlCommand(SQL2, c);
                    com2.ExecuteNonQuery();
                    MySqlCommand com1 = new MySqlCommand(SQL1, c);
                    com1.ExecuteNonQuery();
                    MySqlCommand com3 = new MySqlCommand(SQL3, c);
                    com3.ExecuteNonQuery();
                    string sql = "SELECT Agency.Name, Account.Login, Account.Password FROM Agency, Account WHERE Account.Login = Agency.Login UNION SELECT '-', Account.Login, Account.Password FROM Account WHERE Account.Login NOT IN(SELECT Login From Agency) AND Account.IsAdmin = 0";
                    MySqlCommand command = new MySqlCommand(sql, c);
                    MySqlDataReader reader = command.ExecuteReader();
                    f.CreateDataGridView(a.dataGridView1, reader);
                    c.Close();
                }
            }
            else
            {
                int l = a.dataGridView2.SelectedRows.Count;
                string[] arr = new string[l];
                for (int i = 0; i < l; i++)
                {
                    arr[i] = a.dataGridView2.SelectedRows[i].Cells[0].Value.ToString();
                }
                for (int i = 0; i < l; i++)
                {
                    string SQL3 = "DELETE FROM Account WHERE Login = " + '"' + $"{arr[i]}" + '"';
                    c.Open();
                    MySqlCommand com3 = new MySqlCommand(SQL3, c);
                    com3.ExecuteNonQuery();
                    string sql = "SELECT Login, Password FROM Account WHERE IsAdmin = 1";
                    MySqlCommand command = new MySqlCommand(sql, c);
                    MySqlDataReader reader = command.ExecuteReader();
                    f.CreateDataGridView(a.dataGridView2, reader);
                    c.Close();
                }
            }
            a.dataGridView1.ClearSelection();
            a.dataGridView2.ClearSelection();
            Frm.Update();

            Close();
        }
        private void Delete_Hotel_Yes()
        {
            Hotels a = (Hotels)Frm.State;
            int l = a.dataGridView1.SelectedRows.Count;
            int[] arr = new int[l];
            for (int i = 0; i < l; i++)
            {
                arr[i] = Convert.ToInt32(a.dataGridView1.SelectedRows[i].Cells[5].Value.ToString());
            }
            for (int i = 0; i < l; i++)
            {
                string SQL1 = "DELETE FROM Voucher USING Voucher, Room WHERE Voucher.IdTypeRoom = Room.ID AND Room.IdHotel = " + '"' + $"{arr[i]}" + '"';
                string SQL2 = "DELETE FROM Room WHERE Room.IdHotel = " + '"' + $"{arr[i]}" + '"';
                string SQL3 = "DELETE FROM Hotel WHERE Hotel.ID = " + '"' + $"{arr[i]}" + '"';
                c.Open();
                MySqlCommand com2 = new MySqlCommand(SQL1, c);
                com2.ExecuteNonQuery();
                MySqlCommand com1 = new MySqlCommand(SQL2, c);
                com1.ExecuteNonQuery();
                MySqlCommand com3 = new MySqlCommand(SQL3, c);
                com3.ExecuteNonQuery();
                string sql = "SELECT Hotel.Name, Hotel.Stars, Hotel.Food, City.Name, Country.Name, Hotel.ID FROM Hotel, City, Country WHERE Hotel.IdCity = City.ID AND City.IdCountry = Country.ID";
                MySqlCommand command = new MySqlCommand(sql, c);
                MySqlDataReader reader = command.ExecuteReader();
                f.CreateDataGridView(a.dataGridView1, reader);
                c.Close();
            }
            a.dataGridView1.ClearSelection();
            Frm.Update();

            Close();
        }
        private void Delete_Voucher_Yes()
        {
            Vouchers a = (Vouchers)Frm.State;
            int l = a.dataGridView1.SelectedRows.Count;
            int[] arr = new int[l];
            for (int i = 0; i < l; i++)
            {
                arr[i] = Convert.ToInt32(a.dataGridView1.SelectedRows[i].Cells[0].Value.ToString());
            }
            for (int i = 0; i < l; i++)
            {
                string SQL1 = "DELETE FROM Voucher WHERE Voucher.Id  = " + '"' + $"{arr[i]}" + '"';
                c.Open();
                MySqlCommand com2 = new MySqlCommand(SQL1, c);
                com2.ExecuteNonQuery();
                string sql = "SELECT Voucher.ID, Agency.Name, Hotel.Name, minimal.miin, " +
            "Round((Room.Price * Voucher.NumNights + PairSummaVoucher.Summa * Countpeople.c) * 120 * (Agency.Comission + 100) / 10000, 0), " +
            "Voucher.Status " +
            "FROM Voucher, Agency, Hotel, Room, " +
            "(SELECT Min(datetimeflight) AS miin, voucherid " +
            "FROM " +
            "(SELECT flight.datetime AS datetimeflight, voucher.ID AS voucherid " +
            "FROM flight, voucher, voucherflight " +
            " WHERE flight.ID = voucherflight.idFlight AND voucher.ID = voucherflight.idVoucher " +
            " ) AS PairVoucherData " +
            "GROUP BY voucherid " +
            ") AS minimal, " +
            "(SELECT Sum(Flights.price) AS Summa, Flights.voucherid " +
            "FROM " +
            "(SELECT Voucherflight.idVoucher as voucherid, Route.Price AS price " +
            "FROM Voucherflight, Route, Flight " +
            "WHERE Voucherflight.idFlight = Flight.ID AND Flight.NumRoute = Route.RouteNum " +
            ") AS Flights " +
            "GROUP BY Flights.voucherid " +
            ") AS PairSummaVoucher, " +
            "(SELECT voucher.ID AS id, Count(voucherpeople.idVoucher) as c " +
            "FROM voucher " +
            "LEFT JOIN voucherpeople " +
            "ON voucherpeople.idVoucher = voucher.Id " +
            "GROUP BY voucher.ID) AS CountPeople " +
            "WHERE Agency.Login = Voucher.Login AND Voucher.IdTypeRoom = Room.ID AND Room.IdHotel = Hotel.ID AND " +
            "minimal.voucherid = Voucher.ID AND PairSummaVoucher.voucherid = Voucher.ID AND CountPeople.id = Voucher.ID " +
            "UNION " +
            "SELECT Voucher.ID, Agency.Name, Hotel.Name, Voucher.DateHotel , " +
            "Round((Room.Price * Voucher.NumNights) * 120 * (Agency.Comission + 100) / 10000, 0), " +
            "Voucher.Status " +
            "FROM Voucher, Agency, Hotel, Room, Voucherflight, " +
            "(SELECT voucher.ID AS id, Count(voucherpeople.idVoucher) as c " +
            "FROM voucher " +
            "LEFT JOIN voucherpeople " +
            "ON voucherpeople.idVoucher = voucher.Id " +
            "GROUP BY voucher.ID) AS CountPeople  " +
            "WHERE Agency.Login = Voucher.Login AND Voucher.IdTypeRoom = Room.ID AND Room.IdHotel = Hotel.ID " +
            " AND Voucher.ID NOT IN(Voucherflight.idVoucher) AND Countpeople.id = Voucher.ID"; MySqlCommand command = new MySqlCommand(sql, c);
                MySqlDataReader reader = command.ExecuteReader();
                f.CreateDataGridView(a.dataGridView1, reader);
                c.Close();
            }
            a.dataGridView1.ClearSelection();
            Frm.Update();

            Close();
        }
        private void Edit_Agency_Yes()
        {
            AddTouragency at = (AddTouragency)Form;
            string SQL = $"UPDATE Agency SET name='{at.textBox0.Text}', director='{at.textBox1.Text}', dateLicense='{at.dateTimePicker1.Value.Year}-{at.dateTimePicker1.Value.Month}-{at.dateTimePicker1.Value.Day}' WHERE Login='{at.textBox2.Text}'";
            c.Open();
            MySqlCommand com = new MySqlCommand(SQL, c);
            com.ExecuteNonQuery();
            c.Close();
            at.Close();
            Close();
            c.Open();
            string sql = "SELECT Name, Director,Login, DateLicense, Comission FROM Agency";
            MySqlCommand command = new MySqlCommand(sql, c);
            MySqlDataReader reader = command.ExecuteReader();
            Agencies ag = (Agencies)((AddTouragency)Form).Form.State;
            f.CreateDataGridView(ag.dataGridView1, reader);
            c.Close();
        }
        private void Delete_Route_Yes()
        {
            Routes a = (Routes)Frm.State;
            int l = a.dataGridView1.SelectedRows.Count;
            string[] arr = new string[l];
            for (int i = 0; i < l; i++)
            {
                arr[i] = a.dataGridView1.SelectedRows[i].Cells[0].Value.ToString();
            }
            for (int i = 0; i < l; i++)
            {
                c.Open();
                string sql0 = "SELECT DISTINCT Voucherpeople.idVoucher FROM Voucherpeople ";
                MySqlCommand command0 = new MySqlCommand(sql0, c);
                MySqlDataReader reader0 = command0.ExecuteReader();
                string str = "(";
                while (reader0.Read())
                {
                    str += "'" + reader0[0].ToString() + "',";
                }
                c.Close();
                str = str.Substring(0, str.Length - 1);
                str += ")";
                c.Open();
                string sql1 = $"UPDATE Voucher SET Status = 'Отменено' WHERE ID IN {str} ";
                MySqlCommand command1 = new MySqlCommand(sql1, c);
                command1.ExecuteNonQuery();
                c.Close();
                string SQL2 = "DELETE FROM Route WHERE Route.RouteNum = " + '"' + $"{arr[i]}" + '"';
                c.Open();
                MySqlCommand com1 = new MySqlCommand(SQL2, c);
                com1.ExecuteNonQuery();
                string sql = "SELECT Route.RouteNum, Airline.Name , Route.CodeAirportDeparture, Route.CodeAirportArrive, Route.TimeDeparture, Route.days, Route.Price FROM Route, Airline WHERE Route.CodeAirline = Airline.Code";
                MySqlCommand command = new MySqlCommand(sql, c);
                MySqlDataReader reader = command.ExecuteReader();
                f.CreateDataGridView(a.dataGridView1, reader);
                c.Close();
            }
            a.dataGridView1.ClearSelection();
            Frm.Update();

            Close();
        }
        private void Delete_People_Flight_Yes()
        {
            OneVoucher a = (OneVoucher)Frm.State;
            string[] kk = a.label1.Text.Split(' ');
            string id = kk[kk.Length - 1];
            int l = a.dataGridView1.SelectedRows.Count;
            int l0 = a.dataGridView2.SelectedRows.Count;
            if (l == 0)
            {
                string[] arr = new string[l0];
                for (int i = 0; i < l0; i++)
                {
                    arr[i] = a.dataGridView2.SelectedRows[i].Cells[4].Value.ToString();
                }
                for (int i = 0; i < l0; i++)
                {
                    string SQL2 = $"DELETE FROM VoucherFlight WHERE idVoucher =  '{id}' AND idFlight ='{arr[i]}'";
                    c.Open();
                    MySqlCommand com1 = new MySqlCommand(SQL2, c);
                    com1.ExecuteNonQuery();
                    string sql = $"SELECT Route.RouteNum, Route.CodeAirportDeparture, Route.CodeAirportArrive, Flight.dateTime, Flight.ID " +
                $"FROM Route, Flight, Voucherflight, Voucher " +
                $"WHERE Voucher.ID ={id} AND VoucherFlight.idVoucher = Voucher.ID AND " +
                $"Flight.ID = VoucherFlight.idFlight AND Flight.NumRoute = Route.RouteNum";
                    MySqlCommand command = new MySqlCommand(sql, c);
                    MySqlDataReader reader = command.ExecuteReader();
                    f.CreateDataGridView(a.dataGridView2, reader);
                    c.Close();
                }
                a.dataGridView2.ClearSelection();
                Frm.Update();

                Close();
            }
            else
            {
                string[] arr = new string[l];
                for (int i = 0; i < l; i++)
                {
                    arr[i] = a.dataGridView1.SelectedRows[i].Cells[2].Value.ToString();
                }
                for (int i = 0; i < l; i++)
                {
                    string SQL2 = $"DELETE FROM VoucherPeople WHERE idVoucher =  '{id}' AND passport ='{arr[i]}'";
                    c.Open();
                    MySqlCommand com1 = new MySqlCommand(SQL2, c);
                    com1.ExecuteNonQuery();
                    string sql = $"SELECT People.Surname, People.Name, People.Passport, People.Birthday, People.Sex, Country.Name " +
                $"FROM People, Voucherpeople, Country " +
                $"WHERE People.IdNational=Country.ID AND People.Passport = Voucherpeople.passport AND Voucherpeople.idVoucher ='{id}' ";
                    MySqlCommand command = new MySqlCommand(sql, c);
                    MySqlDataReader reader = command.ExecuteReader();
                    f.CreateDataGridView(a.dataGridView1, reader);
                    c.Close();
                }
                a.dataGridView1.ClearSelection();
                Frm.Update();

                Close();
            }
            
            
        }
        private void Yes_Click(object sender, EventArgs e)
        {
            if (Met1 == "Выход_Да")
            {
                Exit_Yes();
            }
            if(Met1 == "Удаление_Агентства_Да")
            {
                Delete_Agency_Yes();
            }
            if(Met1 == "ОК")
            {
                Close();
            }
            if(Met1 == "Изменить_Агентство_Да")
            {
                Edit_Agency_Yes();
            }
            if(Met1 == "Удаление_Аккаунта_Да")
            {
                Delete_Account_Yes();
            }
            if (Met1 == "Удаление_Отеля_Да")
            {
                Delete_Hotel_Yes();
            }
            if(Met1 == "Удаление_Путевки_Да")
            {
                Delete_Voucher_Yes();
            }
            if (Met1 == "Удаление_Рейса_Да")
            {
                Delete_Route_Yes();
            }
            if (Met1 == "Удаление_Номера_Да")
            {
                Delete_Room_Yes();
            }
            if (Met1 == "Удаление_Человека_Полета_Да")
            {
                Delete_People_Flight_Yes();
            }
        }

        private void No_Click(object sender, EventArgs e)
        {
            if (Met2 == "Выход_Нет")
            {
                Exit_No();
            }
        }
    }
}
