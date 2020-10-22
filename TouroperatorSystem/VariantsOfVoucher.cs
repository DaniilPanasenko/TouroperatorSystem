using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TouroperatorSystem
{
    public partial class VariantsOfVoucher : UserControl
    {
        public Color orange = Color.LightSalmon;
        public Color blueUpPanel = Color.CornflowerBlue;
        public Color white = Color.White;
        public Color black = Color.Black;
        public Color trans = Color.Transparent;
        public Color red = Color.MistyRose;
        public Color blueLeftMenu = Color.FromArgb(130, 175, 255);
        public Color blueUpMenu = Color.FromArgb(168, 208, 248);

        public static string connect = "server=localhost;user=root;database=cursach;password=Danilpanass1;";
        public static MySqlConnection c = new MySqlConnection(connect);
        public int CurPrice { get; set; }
        Functions f = new Functions();
        public SearchVouchers Search { get; set; }
        public VariantsOfVoucher(SearchVouchers s)
        {
            
            Search = s;
            InitializeComponent();
            label1.Text = Search.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string SQL = $"SELECT Room.TypeRoom FROM Room, Hotel WHERE Hotel.Id = Room.IdHotel AND Hotel.Name = '{Search.dataGridView1.SelectedRows[0].Cells[0].Value.ToString()}'";
            c.Open();
            MySqlCommand command1 = new MySqlCommand(SQL, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                comboBox2.Items.Add(reader1[0].ToString());
            }
            c.Close();
            int price = 0;
            string SQL1 = $"SELECT  Min(Room.Price) FROM Room, Hotel " +
                $"WHERE Hotel.ID = Room.idHotel AND Hotel.Name = '{Search.dataGridView1.SelectedRows[0].Cells[0].Value.ToString()}' AND Room.NumPerson >={Search.CountPeople}";
            c.Open();
            MySqlCommand command2 = new MySqlCommand(SQL1, c);
            MySqlDataReader reader2 = command2.ExecuteReader();
            reader2.Read();
            try
            {
                price = Convert.ToInt32(reader2[0]);
                CurPrice = Convert.ToInt32(reader2[0]);
            }
            catch
            {

            }
            c.Close();
            string SQLA = $"SELECT Room.TypeRoom FROM Room, Hotel WHERE Room.idHotel = Hotel.ID AND " +
                $"Hotel.Name = '{Search.dataGridView1.SelectedRows[0].Cells[0].Value.ToString()}' AND " +
                $"Room.Price =(SELECT  Min(Room.Price) FROM Room, Hotel " +
                $"WHERE Hotel.ID = Room.idHotel AND Hotel.Name = '{Search.dataGridView1.SelectedRows[0].Cells[0].Value.ToString()}' AND Room.NumPerson >={Search.CountPeople})";
            c.Open();
            MySqlCommand command = new MySqlCommand(SQLA, c);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            try
            {
                comboBox2.SelectedItem = reader[0];
            }
            catch
            {
               
            }
            c.Close();
            string[] arr = new string[0];
            for(int i=0; i<Search.Result.Length; i++)
            {
                if(Search.Result[i].Split('%')[1]== Search.dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length - 1] = Search.Result[i];
                }
            }
            for(int i=0; i<arr.Length; i++)
            {
                string way1 = arr[i].Split('%')[0];
                string way2 = arr[i].Split('%')[2];
                int allprice = int.Parse(arr[i].Split('%')[3]);
                string SQL0 = $"SELECT Route.CodeAirportDeparture, Flight.DateTime FROM Route, Flight " +
                    $"WHERE Flight.NumRoute = Route.RouteNum AND Flight.ID = '{way1.Split('-')[0]}' ";
                    c.Open();
                MySqlCommand command0 = new MySqlCommand(SQL0, c);
                MySqlDataReader reader0 = command0.ExecuteReader();
                reader0.Read();
                string airportstart = reader0[0].ToString();
                DateTime datestart1 = Convert.ToDateTime(reader0[1].ToString());
                c.Close();
                 SQL0 = $"SELECT Route.CodeAirportDeparture, Flight.DateTime FROM Route, Flight " +
                    $"WHERE Flight.NumRoute = Route.RouteNum AND Flight.ID = '{way2.Split('-')[0]}' ";
                c.Open();
                command0 = new MySqlCommand(SQL0, c);
                reader0 = command0.ExecuteReader();
                reader0.Read();
                string airportstart2 = reader0[0].ToString();
                DateTime datestart2 = Convert.ToDateTime(reader0[1].ToString());
                c.Close();
                string marsh = airportstart+"-";
                DateTime datefinish1 = new DateTime();
                for (int j= 0; j<way1.Split('-').Length; j++)
                {
                    string SQL3 = $"SELECT Route.CodeAirportArrive, Flight.Datetime, Route.TimeFlight FROM Route, Flight " +
                    $"WHERE Flight.NumRoute = Route.RouteNum AND Flight.ID = '{way1.Split('-')[j]}' ";
                    c.Open();
                MySqlCommand command3 = new MySqlCommand(SQL3, c);
                MySqlDataReader reader3 = command3.ExecuteReader();
                reader3.Read();
                    marsh += reader3[0].ToString() + "-";
                    if (j==way1.Split('-').Length-1)
                    {
                        datefinish1 = Convert.ToDateTime(reader3[1]).AddHours(((TimeSpan)reader3[2]).Hours).AddMinutes(((TimeSpan)reader3[2]).Minutes);
                    }
                c.Close();
                }
                marsh = marsh.Substring(0, marsh.Length - 1);
                marsh += " / "+airportstart2+"-";
                DateTime datefinish2 = new DateTime();
                for (int j = 0; j < way2.Split('-').Length; j++)
                {
                    string SQL3 = $"SELECT Route.CodeAirportArrive, Flight.Datetime, Route.TimeFlight FROM Route, Flight " +
                    $"WHERE Flight.NumRoute = Route.RouteNum AND Flight.ID = '{way2.Split('-')[j]}' ";
                    c.Open();
                    MySqlCommand command3 = new MySqlCommand(SQL3, c);
                    MySqlDataReader reader3 = command3.ExecuteReader();
                    reader3.Read();
                    marsh += reader3[0].ToString() + "-";
                    if (j == way2.Split('-').Length - 1)
                    {
                        datefinish2 = Convert.ToDateTime(reader3[1]).AddHours(((TimeSpan)reader3[2]).Hours).AddMinutes(((TimeSpan)reader3[2]).Minutes);
                    }
                    c.Close();
                }
                string SQL30 = $"SELECT Room.Price FROM Room, Hotel WHERE Room.idHotel = Hotel.ID AND Hotel.Name = '{label1.Text}' AND Room.TypeRoom = '{comboBox2.Text}' ";
                c.Open();
                MySqlCommand command30 = new MySqlCommand(SQL30, c);
                MySqlDataReader reader30 = command30.ExecuteReader();
                reader30.Read();
                int pricee = Convert.ToInt32(reader30[0]);
                c.Close();
                marsh = marsh.Substring(0, marsh.Length - 1);
                int l = dataGridView1.Rows.Add();
                dataGridView1.Rows[l].Cells[1].Value = datestart1.ToShortDateString();
                dataGridView1.Rows[l].Cells[0].Value = marsh;
                dataGridView1.Rows[l].Cells[2].Value = (datefinish2 - datestart1).Days.ToString();
                dataGridView1.Rows[l].Cells[3].Value = (datefinish1 - datestart1).ToString()+ " / " + (datefinish2 - datestart2).ToString();
                dataGridView1.Rows[l].Cells[4].Value = (allprice+pricee*int.Parse(dataGridView1.Rows[l].Cells[2].Value.ToString())).ToString();
            }
        }

        private void Filter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void VariantsOfVoucher_Load(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SQL1 = $"SELECT  Room.Price FROM Room, Hotel " +
                $"WHERE Hotel.ID = Room.idHotel AND Hotel.Name = '{Search.dataGridView1.SelectedRows[0].Cells[0].Value.ToString()}' AND Room.TypeRoom = '{comboBox2.Text}'";
            c.Open();
            MySqlCommand command2 = new MySqlCommand(SQL1, c);
            MySqlDataReader reader2 = command2.ExecuteReader();
            reader2.Read();
            for(int i=0; i<dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[4].Value  = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value)-CurPrice*Search.CountPeople+Convert.ToInt32(reader2[0])*Search.CountPeople;
                
            }
            CurPrice = Convert.ToInt32(reader2[0]);
            c.Close();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
            }
        }

        private void Panel2_Click(object sender, EventArgs e)
        {
            int j = dataGridView1.SelectedRows[0].Index;
            string[] arr = new string[0];
            for (int i = 0; i < Search.Result.Length; i++)
            {
                if (Search.Result[i].Split('%')[1] == Search.dataGridView1.SelectedRows[0].Cells[0].Value.ToString())
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length - 1] = Search.Result[i];
                }
            }
            int max = 0;
            c.Open();
            MySqlCommand command1 = new MySqlCommand("SELECT Max(Id) FROM Voucher", c);
            MySqlDataReader reade = command1.ExecuteReader();
            reade.Read();
            max = Convert.ToInt32(reade[0]) + 1;
            c.Close();
            string way1  = arr[j].Split('%')[0];
            string way2 = arr[j].Split('%')[2];
            string sql = $"INSERT INTO Voucher (ID, idTypeRoom, NumNights, DateHotel, login, CodeAirport, Status) " +
                        $"VALUES ('{max}',(SELECT Room.ID FRom Room, Hotel WHERE Room.idHotel =Hotel.ID " +
                        $"AND Hotel.Name= '{label1.Text}' AND Room.TypeRoom='{comboBox2.Text}'),'{dataGridView1.SelectedRows[0].Cells[2].Value}' , " +
                        $"STR_TO_DATE('{dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Replace('.', '-')}','%d-%m-%Y')" +
                        $",'{Search.Form.User.Login}'," +
                        $"(SELECT Route.CodeAirportDeparture FROM Route, Flight WHERE Flight.id = {way1.Split('-')[0]} AND Flight.NumRoute = Route.RouteNum),'Забронировано')";
            c.Open();
            MySqlCommand command = new MySqlCommand(sql, c);
            command.ExecuteNonQuery();
            c.Close();
            for (int i =0; i< way1.Split('-').Length; i++)
            {
                string sql0 = $"INSERT INTO VoucherFlight (idVoucher, idFlight) " +
                    $"VALUES ('{max}', {way1.Split('-')[i]})";
                c.Open();
                MySqlCommand command0 = new MySqlCommand(sql0, c);
                command0.ExecuteNonQuery();
                c.Close();
            }
            for (int i = 0; i < way2.Split('-').Length; i++)
            {
                string sql0 = $"INSERT INTO VoucherFlight (idVoucher, idFlight) " +
                    $"VALUES ('{max}', {way2.Split('-')[i]})";
                c.Open();
                MySqlCommand command0 = new MySqlCommand(sql0, c);
                command0.ExecuteNonQuery();
                c.Close();
            }
            MyMessageBox mmb = new MyMessageBox(Search.Form, "Бронирование", "Путевка забронирована", "ОК", "", "ОК", "");
            mmb.Show();
        }
    }
}
