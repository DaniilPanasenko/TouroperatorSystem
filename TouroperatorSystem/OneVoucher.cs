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
    public partial class OneVoucher : UserControl
    {
        public static string connect = "server=localhost;user=root;database=cursach;password=Danilpanass1;";
        public static MySqlConnection c = new MySqlConnection(connect);

        Functions f = new Functions();
        public HomeForm Form{get; set;}
        public int ID { get; set; }
        public OneVoucher(HomeForm hf)
        {
            Form = hf;
            InitializeComponent();
            DataGridViewCellCollection co = ((Vouchers)Form.State).dataGridView1.SelectedRows[0].Cells;
            ID = Convert.ToInt32(co[0].Value);
            label1.Text += co[0].Value.ToString();
            label2.Text += co[1].Value.ToString();
            label4.Text += co[2].Value.ToString();
            label3.Text += co[3].Value.ToString();
            label8.Text += co[4].Value.ToString()+"$";
            label7.Text += co[5].Value.ToString();
            string sql = $"SELECT Room.TypeRoom FROM Room, Voucher WHERE Voucher.idTypeRoom = Room.ID AND Voucher.ID = {co[0].Value.ToString()}";
            c.Open();
            MySqlCommand comm = new MySqlCommand(sql, c);
            MySqlDataReader reader = comm.ExecuteReader();
            reader.Read();
            label6.Text += reader[0].ToString();
            c.Close();
            string sql1 = $"SELECT People.Surname, People.Name, People.Passport, People.Birthday, People.Sex, Country.Name " +
                $"FROM People, Voucherpeople, Country " +
                $"WHERE People.IdNational=Country.ID AND People.Passport = Voucherpeople.passport AND Voucherpeople.idVoucher ='{co[0].Value.ToString()}' ";
            c.Open();
            MySqlCommand comm1 = new MySqlCommand(sql1, c);
            MySqlDataReader reader1 = comm1.ExecuteReader();
            f.CreateDataGridView(dataGridView1, reader1);
            c.Close();
            string sql2 = $"SELECT Route.RouteNum, Route.CodeAirportDeparture, Route.CodeAirportArrive, Flight.dateTime, Flight.ID " +
                $"FROM Route, Flight, Voucherflight, Voucher " +
                $"WHERE Voucher.ID ={co[0].Value.ToString()} AND VoucherFlight.idVoucher = Voucher.ID AND " +
                $"Flight.ID = VoucherFlight.idFlight AND Flight.NumRoute = Route.RouteNum";

            c.Open();
            MySqlCommand comm2 = new MySqlCommand(sql2, c);
            MySqlDataReader reader2 = comm2.ExecuteReader();
            f.CreateDataGridView(dataGridView2, reader2);
            c.Close();
            for (int i = 0; i < Form.panel2.Controls.Count; i++)
            {
                Form.panel2.Controls[i].Visible = false;
            }
            Form.Report.Visible = true;
        }

        private void OneVoucher_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label10_MouseEnter(object sender, EventArgs e)
        {
            label10.ForeColor = Color.LightGreen;
        }

        private void Label10_MouseLeave(object sender, EventArgs e)
        {
            label10.ForeColor = Color.SeaGreen;
        }

        private void Label10_Click(object sender, EventArgs e)
        {
            AddPeople p = new AddPeople(Form, ID);
            p.Show();
        }

        private void OneVoucher_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            Form.Delete.Visible = false;
        }

        private void DataGridView2_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            Form.Delete.Visible = true ;
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            dataGridView2.ClearSelection();
            Form.Delete.Visible = true;
        }
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void DataGridView2_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void Label11_MouseLeave(object sender, EventArgs e)
        {
            label11.ForeColor = Color.SeaGreen;
        }
        private void Label11_MouseEnter(object sender, EventArgs e)
        {
            label11.ForeColor = Color.LightGreen;
        }

        private void Label11_Click(object sender, EventArgs e)
        {
            AddFlight a = new AddFlight(Form);
            a.Show();
        }
    }
}
