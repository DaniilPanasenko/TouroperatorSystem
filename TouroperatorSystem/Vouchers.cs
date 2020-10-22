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
    public partial class Vouchers : UserControl
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
        HomeForm Form { get; set; }
        Functions f = new Functions();
        public Vouchers(HomeForm frm)
        {
            Form = frm;
            InitializeComponent();
            string sql = "";
            if (Form.User.IsAdmin)
            {
                sql = "SELECT Voucher.ID, Agency.Name, Hotel.Name, minimal.miin, " +
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
                " AND Voucher.ID NOT IN (SELECT idVoucher FROM Voucherflight) AND Countpeople.id = Voucher.ID";
            }
            else
            {
                sql = "SELECT Voucher.ID, Agency.Name, Hotel.Name, minimal.miin, " +
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
                "AND Agency.Login = '{Form.User.Login}' " +
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
                $"  AND Countpeople.id = Voucher.ID AND Agency.Login = '{Form.User.Login}' ";
            }
            c.Open();
            MySqlCommand command1 = new MySqlCommand(sql, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            f.CreateDataGridView(dataGridView1, reader1);
            c.Close();
            for (int i = 0; i < Form.panel2.Controls.Count; i++)
            {
                Form.panel2.Controls[i].Visible = false;
            }
            for(int i=0; i<dataGridView1.Rows.Count; i++)
            {
                switch (dataGridView1.Rows[i].Cells[5].Value.ToString())
                {
                    case "Выполнено":
                        dataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.SeaGreen;
                        break;
                    case "Отменено":
                        dataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.Red;
                        break;
                    //case "Забронировано":
                    //    dataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.Red;
                    //    break;
                    //case "В процессе":
                    //    dataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.LightSalmon;
                    //    break;
                    //case "Оплачено":
                    //    dataGridView1.Rows[i].Cells[5].Style.ForeColor = Color.Gold;
                    //    break;
                }
            }
            Form.Add.Visible = true;
        }

        private void Vouchers_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                Form.Edit.Visible = false;
                Form.Delete.Visible = false;
                Form.Open.Visible = false;
            }
            else if (dataGridView1.SelectedRows.Count > 1)
            {
                Form.Edit.Visible = false;
                Form.Delete.Visible = true;
                Form.Open.Visible = false;
            }
            else
            {
                Form.Edit.Visible = true;
                Form.Delete.Visible = true;
                Form.Open.Visible = true;
            }
        }
    }
}
