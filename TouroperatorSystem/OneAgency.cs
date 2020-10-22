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
    public partial class OneAgency : UserControl
    {
        public static string connect = "server=localhost;user=root;database=cursach;password=Danilpanass1;";
        public static MySqlConnection c = new MySqlConnection(connect);
        public HomeForm Form { get; set; }
        public Touragency Touragency { get; set; }
        Functions f = new Functions();
        public OneAgency(HomeForm hf, Touragency t)
        {
            Form = hf;
            Touragency = t;
            InitializeComponent();
            label1.Text = Touragency.Name;
            label2.Text = "Логин: "+Touragency.Account.Login;
            label4.Text = "Директор: "+Touragency.Director;
            label3.Text = "Дата получения лицензии: "+Touragency.Date.ToShortDateString();
            label6.Text = "Комиссия: "+Touragency.Comission+"";
            string sql = "SELECT Voucher.ID, Hotel.Name, minimal.miin, " +
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
            $"WHERE Agency.Login='{Touragency.Account.Login}' AND Agency.Login = Voucher.Login AND Voucher.IdTypeRoom = Room.ID AND Room.IdHotel = Hotel.ID AND " +
            "minimal.voucherid = Voucher.ID AND PairSummaVoucher.voucherid = Voucher.ID AND CountPeople.id = Voucher.ID " +
            "UNION " +
            "SELECT Voucher.ID, Hotel.Name, Voucher.DateHotel , " +
            "Round((Room.Price * Voucher.NumNights) * 120 * (Agency.Comission + 100) / 10000, 0), " +
            "Voucher.Status " +
            "FROM Voucher, Agency, Hotel, Room, Voucherflight, " +
            "(SELECT voucher.ID AS id, Count(voucherpeople.idVoucher) as c " +
            "FROM voucher " +
            "LEFT JOIN voucherpeople " +
            "ON voucherpeople.idVoucher = voucher.Id " +
            "GROUP BY voucher.ID) AS CountPeople  " +
            $"WHERE Agency.Login='{Touragency.Account.Login}' AND Agency.Login = Voucher.Login AND Voucher.IdTypeRoom = Room.ID AND Room.IdHotel = Hotel.ID " +
            " AND Voucher.ID NOT IN(Voucherflight.idVoucher) AND Countpeople.id = Voucher.ID";
            c.Open();
            MySqlCommand command1 = new MySqlCommand(sql, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            f.CreateDataGridView(dataGridView1, reader1);
            c.Close();
            for (int i = 0; i < Form.panel2.Controls.Count; i++)
            {
                Form.panel2.Controls[i].Visible = false;
            }
            Form.Report.Visible = true;
        }

        private void OneAgency_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
