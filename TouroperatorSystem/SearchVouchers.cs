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

    public partial class SearchVouchers : UserControl
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

        Functions f = new Functions();
        //
        public string CountryB { get; set; }
        public string CityB { get; set; }
        public string HotelB { get; set; }
        public string CountryA { get; set; }
        public string CityA { get; set; }
        public string Airport { get; set; }
        public DateTime DateA { get; set; } 
        public DateTime DateB { get; set; }
        public int CountPeople { get; set; }
        public int NightsA { get; set; }
        public int NightsB { get; set; }

        public string[] Result { get; set; }
        
        public string[] Arrive { get; set; }
        public string[] Departure { get; set; }

        

        public HomeForm Form { get; set; }
        public SearchVouchers(HomeForm hf)
        {
            DateA = DateTime.Now;
            DateB = DateTime.Now;
            Form = hf;
            InitializeComponent();
            pictureBox2.Visible = false;
        }
        public string[][] GetNextAirports(string port , DateTime time1, DateTime time2)
        {
            string[][] arr = new string[0][];
            string SQLA = $"SELECT Route.CodeAirportDeparture, Route.CodeAirportArrive, Flight.DateTime, Route.TimeFlight, Route.RouteNum, Flight.ID "+
"FROM Route, Flight "+
$"WHERE Route.RouteNum = Flight.NumRoute AND Route.CodeAirportDeparture = '{port}' "+
$"AND Flight.DateTime <= STR_TO_DATE('{time2.Year}-{time2.Month}-{time2.Day}-{time2.Hour}-{time2.Minute}', '%Y-%m-%d-%H-%i') "+
$"AND Flight.DateTime >= STR_TO_DATE('{time1.Year}-{time1.Month}-{time1.Day}-{time1.Hour}-{time1.Minute}', '%Y-%m-%d-%H-%i')";
            c.Open();
            MySqlCommand command = new MySqlCommand(SQLA, c);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string[] a = new string[6];
                a[0] = reader[0].ToString();
                a[1] = reader[1].ToString();
                a[2] = reader[2].ToString();
                a[3] = reader[3].ToString();
                a[4] = reader[4].ToString();
                a[5] = reader[5].ToString();
                Array.Resize(ref arr, arr.Length + 1);
                arr[arr.Length - 1] = a;
            }
            c.Close();
            return arr;
        }
        public bool IsFinish(string port, string[] arr)
        {
            for (int i  = 0; i < arr.Length; i++)
            {
                if(port == arr[i])
                {
                    return true;
                }
            }
            return false;
        }
        public void GetAirports()
        {
            
            if (Airport != "")
            {
                Departure = new string[1];
                Departure[0] = Airport.Substring(0, 3);
            }
            else if (CityA != "")
            {
                string[] arr = new string[0];
                string SQLA = $"SELECT Airport.Code FROM Airport, City, Country " +
                    $"WHERE Airport.idCity = City.ID AND City.idCountry = Country.ID AND City.Name ='{CityA}' AND Country.Name = '{CountryA}'";
                c.Open();
                MySqlCommand command = new MySqlCommand(SQLA, c);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length - 1] = reader[0].ToString();
                }
                c.Close();
                Departure = arr;
            }
            else
            {
                string[] arr = new string[0];
                string SQLA = $"SELECT Airport.Code FROM Airport, City, Country " +
                    $"WHERE Airport.idCity = City.ID AND City.idCountry = Country.ID  AND Country.Name = '{CountryA}'";
                c.Open();
                MySqlCommand command = new MySqlCommand(SQLA, c);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length - 1] = reader[0].ToString();
                }
                c.Close();
                Departure = arr;
            }

            if (CityB != "")
            {
                string[] arr = new string[0];
                string SQLA = $"SELECT Airport.Code FROM Airport, City c1, City c2, Country " +
                    $"WHERE Airport.idCity = c2.ID AND c1.idCityWithNearestAirport = c2.id AND c1.Name = '{CityB}' " +
                    $"AND Country.Name = '{CountryB}' AND Country.ID = c1.idCountry";
                c.Open();
                MySqlCommand command = new MySqlCommand(SQLA, c);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length - 1] = reader[0].ToString();
                }
                c.Close();
                Arrive = arr;
            }
            else
            {
                string[] arr = new string[0];
                string SQLA = $"SELECT Airport.Code FROM Airport, City, Country " +
                    $"WHERE Airport.idCity = City.ID AND City.idCountry = Country.ID  AND Country.Name = '{CountryB}'";
                c.Open();
                MySqlCommand command = new MySqlCommand(SQLA, c);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[arr.Length - 1] = reader[0].ToString();
                }
                c.Close();
                Arrive = arr;
            }
            
        }
        public void GetUpdate()
        {
            dataGridView1.Rows.Clear();
            string[] RESULT = new string[0];
            string[] result = new string[0];
            GetAirports();
            for(int i=0; i<Departure.Length; i++)
            {
                string[][] arr1 = GetNextAirports(Departure[i], DateA, DateB);
                
                for(int j = 0; j<arr1.Length; j++)
                {
                    if (IsFinish(arr1[j][1], Arrive))
                    {
                        Array.Resize(ref result, result.Length + 1);
                        result[result.Length - 1] = arr1[j][5]; ;
                    }
                    else
                    {
                        DateTime d1 = Convert.ToDateTime(arr1[j][2]).AddHours(Convert.ToDateTime(arr1[j][3]).Hour+1).AddMinutes(Convert.ToDateTime(arr1[j][3]).Minute);
                        
                        string[][] arr2 = GetNextAirports(arr1[j][1], d1, d1.AddHours(12));

                        for (int l = 0; l < arr2.Length; l++)
                        {
                            if (IsFinish(arr2[l][1], Arrive))
                            {
                                Array.Resize(ref result, result.Length + 1);
                                result[result.Length - 1] = arr1[j][5]+"-"+arr2[l][5]; 
                            }
                            else
                            {
                                DateTime d2 = Convert.ToDateTime(arr2[l][2]).AddHours(Convert.ToDateTime(arr2[l][3]).Hour + 1).AddMinutes(Convert.ToDateTime(arr2[l][3]).Minute);

                                string[][] arr3 = GetNextAirports(arr2[l][1], d2, d2.AddHours(12));

                                for (int m = 0; m < arr3.Length; m++)
                                {
                                    if (IsFinish(arr3[m][1], Arrive))
                                    {
                                        Array.Resize(ref result, result.Length + 1);
                                        result[result.Length - 1] = arr1[j][5] + "-" + arr2[l][5]+"-"+arr3[m][5];
                                    }
                                }
                            }
                        }
                    }
                }
            }
            for(int i=0; i<result.Length; i++)
            {
                int last = int.Parse(result[i].Split('-')[result[i].Split('-').Length - 1]);
                string SQLA = $"SELECT Flight.DateTime, Route.TimeFlight FROM Flight, Route " +
                    $"WHERE Route.RouteNum = Flight.NumRoute AND Flight.ID ={last}";
                c.Open();
                MySqlCommand command = new MySqlCommand(SQLA, c);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                DateTime HotelTime = Convert.ToDateTime(reader[0].ToString());
                DateTime TimeFlight = Convert.ToDateTime(reader[1].ToString());
                DateTime HotelStartDate = new DateTime();
                c.Close();
                HotelTime.AddHours(TimeFlight.Hour+2).AddMinutes(TimeFlight.Minute);
                if (HotelTime.Hour >= 6)
                {
                    HotelStartDate = HotelTime.AddDays(1);
                }
                else
                {
                    HotelStartDate = HotelTime;
                }
                DateTime Date1 = HotelStartDate.AddDays(NightsA + 1);
                DateTime Date2 = HotelStartDate.AddDays(NightsB + 1);

                string[] Hotels = new string[0];
                if (HotelB != "")
                {
                    Hotels = new string[1];
                    Hotels[0] = HotelB;
                }
                else if (CityB != "")
                {
                    string[] arr = new string[0];
                    string SQL = $"SELECT Hotel.Name FROM City, Hotel WHERE City.id =Hotel.idCity AND City.Name='{CityB}'";
                    c.Open();
                    MySqlCommand command0 = new MySqlCommand(SQL, c);
                    MySqlDataReader reader0 = command0.ExecuteReader();
                    while (reader0.Read())
                    {
                        Array.Resize(ref arr, arr.Length + 1);
                        arr[arr.Length - 1] = reader0[0].ToString();
                    }
                    c.Close();
                    Hotels = arr;
                }
                else
                {
                    string[] arr = new string[0];
                    string SQL = $"SELECT Hotel.Name FROM City, Country, Hotel WHERE City.id =Hotel.idCity " +
                        $"AND City.idCountry=Country.ID AND Country.Name = '{CountryB}'";
                    c.Open();
                    MySqlCommand command0 = new MySqlCommand(SQL, c);
                    MySqlDataReader reader0 = command0.ExecuteReader();
                    while (reader0.Read())
                    {
                        Array.Resize(ref arr, arr.Length + 1);
                        arr[arr.Length - 1] = reader0[0].ToString();
                    }
                    c.Close();
                    Hotels = arr;
                }


                for (int j = 0; j < Hotels.Length; j++)
                {
                    string namehotel = Hotels[j];
                    c.Close();

                    string SQLB = $"SELECT Airport.Code FROM Airport, City c1, Hotel, City c2 " +
                        $"WHERE Hotel.Name = '{namehotel}' AND Hotel.idCity = c1.ID AND c1.idCityWithNearestAirport = c2.ID AND Airport.idCity = c2.ID";
                    c.Open();
                    MySqlCommand command1 = new MySqlCommand(SQLB, c);
                    MySqlDataReader reader1 = command1.ExecuteReader();
                    string[] airports = new string[0];
                    while (reader1.Read())
                    {
                        Array.Resize(ref airports, airports.Length+1);
                        airports[airports.Length - 1] = reader1[0].ToString();
                    }
                    c.Close();


                    string[] res = new string[0];
                    for (int k = 0; k < airports.Length; k++)
                    {
                        string[][] arr1 = GetNextAirports(airports[k], Date1, Date2);

                        for (int s = 0; s < arr1.Length; s++)
                        {
                            if (IsFinish(arr1[s][1], Departure))
                            {
                                Array.Resize(ref res, res.Length + 1);
                                res[res.Length - 1] = arr1[s][5]; ;
                            }
                            else
                            {
                                DateTime d1 = Convert.ToDateTime(arr1[s][2]).AddHours(Convert.ToDateTime(arr1[s][3]).Hour + 1).AddMinutes(Convert.ToDateTime(arr1[s][3]).Minute);

                                string[][] arr2 = GetNextAirports(arr1[s][1], d1, d1.AddHours(12));

                                for (int l = 0; l < arr2.Length; l++)
                                {
                                    if (IsFinish(arr2[l][1], Departure))
                                    {
                                        Array.Resize(ref res, res.Length + 1);
                                        result[res.Length - 1] = arr1[s][5] + "-" + arr2[l][5];
                                    }
                                    else
                                    {
                                        DateTime d2 = Convert.ToDateTime(arr2[l][2]).AddHours(Convert.ToDateTime(arr2[l][3]).Hour + 1).AddMinutes(Convert.ToDateTime(arr2[l][3]).Minute);

                                        string[][] arr3 = GetNextAirports(arr2[l][1], d2, d2.AddHours(12));

                                        for (int m = 0; m < arr3.Length; m++)
                                        {
                                            if (IsFinish(arr3[m][1], Departure))
                                            {
                                                Array.Resize(ref res, res.Length + 1);
                                                res[res.Length - 1] = arr1[s][5] + "-" + arr2[l][5] + "-" + arr3[m][5];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }


                    for(int g=0; g<res.Length; g++)
                    {
                        Array.Resize(ref RESULT, RESULT.Length + 1);
                        RESULT[RESULT.Length - 1] = result[i] + "%" + Hotels[j] + "%" + res[g];
                    }

                }
            }

            for(int i=0; i<RESULT.Length; i++)
            {
                string Way1 = RESULT[i].Split('%')[0];
                string Hotel = RESULT[i].Split('%')[1];
                string Way2 = RESULT[i].Split('%')[2];
                int price = 0;
                string SQLA = $"SELECT  Min(Room.Price) FROM Room, Hotel " +
                $"WHERE Hotel.ID = Room.idHotel AND Hotel.Name = '{Hotel}' AND Room.NumPerson >={CountPeople}";
                c.Open();
                MySqlCommand command = new MySqlCommand(SQLA, c);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                try
                {
                    price += Convert.ToInt32(reader[0]);
                }
                catch {
                    price = -1;
                }
                c.Close();
                if (price != -1)
                {
                    for (int j = 0; j < Way1.Split('-').Length; j++)
                    {
                        string SQL = $"SELECT  Route.Price*{CountPeople} FROM Route, Flight " +
                    $"WHERE Flight.NumRoute= Route.RouteNum AND Flight.ID ={Way1.Split('-')[j]}";
                        c.Open();
                        MySqlCommand command0 = new MySqlCommand(SQL, c);
                        MySqlDataReader reader0 = command0.ExecuteReader();
                        reader0.Read();
                        price += Convert.ToInt32(reader0[0]);
                        c.Close();
                    }
                    for (int j = 0; j < Way2.Split('-').Length; j++)
                    {
                        string SQL = $"SELECT  Route.Price*{CountPeople} FROM Route, Flight " +
                    $"WHERE Flight.NumRoute= Route.RouteNum AND Flight.ID ={Way2.Split('-')[j]}";
                        c.Open();
                        MySqlCommand command0 = new MySqlCommand(SQL, c);
                        MySqlDataReader reader0 = command0.ExecuteReader();
                        reader0.Read();
                        price += Convert.ToInt32(reader0[0]);
                        c.Close();
                    }
                }
                RESULT[i] += "%" + price;
            }
            Result = RESULT;
           
            string[] DATA = new string[0];
            for(int i=0; i<RESULT.Length; i++)
            {
                bool t = true;
                for(int j=0; j<DATA.Length; j++)
                {
                    if(RESULT[i].Split('%')[1] == DATA[j].Split('%')[1])
                    {
                        if(int.Parse(RESULT[i].Split('%')[3])< int.Parse(DATA[j].Split('%')[3]))
                        {
                            DATA[j] = RESULT[i];
                            
                        }
                        t = false;
                        break;
                    }
                }
                if (t)
                {
                    Array.Resize(ref DATA, DATA.Length + 1);
                    DATA[DATA.Length - 1] = RESULT[i];
                }
            }
            for(int i=0; i<DATA.Length; i++)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = DATA[i].Split('%')[1];
                dataGridView1.Rows[num].Cells[3].Value = DATA[i].Split('%')[3];
                string SQL = $"SELECT Country.Name, City.Name FROM City, Country, Hotel " +
                    $"WHERE City.idCountry = Country.ID AND Hotel.idCity=City.ID AND Hotel.Name = '{ DATA[i].Split('%')[1]}'";
                c.Open();
                MySqlCommand command1 = new MySqlCommand(SQL, c);
                MySqlDataReader reader1 = command1.ExecuteReader();
                reader1.Read();
                dataGridView1.Rows[num].Cells[1].Value = reader1[0].ToString();
                dataGridView1.Rows[num].Cells[2].Value = reader1[1].ToString();
                c.Close();
                ;
            }
        }
        private void SearchVouchers_Load(object sender, EventArgs e)
        {
            FilterVoucher f = new FilterVoucher(this);
            f.Show();
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            string find = textBox0.Text;
            for(int i=0; i<dataGridView1.Rows.Count; i++)
            {
                for(int j=0; j<dataGridView1.Rows[i].Cells.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value.ToString().IndexOf(find) != -1)
                    {
                        dataGridView1.Rows[i].Selected = true;
                    }
                }
            }
        }

        private void PictureBox16_Click(object sender, EventArgs e)
        {
            FilterVoucher filter = new FilterVoucher(this);

            #region
            filter.comboBox2.SelectedItem = CountryB;
            filter.comboBox7.SelectedItem = CountryA;
            filter.comboBox3.SelectedItem = CityB;
            filter.comboBox6.SelectedItem = CityA;
            filter.comboBox1.SelectedItem = HotelB;
            filter.comboBox9.SelectedItem = Airport;
            filter.dateTimePicker1.Value = DateA;
            filter.dateTimePicker2.Value = DateB;
            filter.textBox3.Text = CountPeople+"";
            filter.textBox1.Text = NightsA+"";
            filter.textBox2.Text = NightsB + "";
            filter.Show();
            #endregion
        }

        private void SearchVouchers_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                pictureBox2.Visible = true;

            }
            else
            {
                pictureBox2.Visible = false;
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            
            Form.Controls.Remove(Form.State);
            VariantsOfVoucher vov = new VariantsOfVoucher(this);
            Form.State = vov;

            Form.Controls.Add(vov);
            vov.BringToFront();
            vov.Location = this.Location;
            vov.Visible = true;
            vov.Show();
            Form.panel12.Visible = true;
            vov.Show();
        }
    }
    public class NewVoucher
    {
        public int[] FlightsA { get; set; }
        public int[] FlightsB { get; set; }
        public string Hotel { get; set; }
        
    }
}
