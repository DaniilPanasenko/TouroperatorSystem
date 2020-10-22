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
    public partial class Hotels : UserControl
    {
        public static string connect = "server=localhost;user=root;database=cursach;password=Danilpanass1;";
        public static MySqlConnection c = new MySqlConnection(connect);
        public Functions f = new Functions();
        public Color orange = Color.LightSalmon;
        public Color blue = Color.CornflowerBlue;
        public Color white = Color.White;
        public Color black = Color.Black;
        public Color trans = Color.Transparent;
        public Color red = Color.MistyRose;
        HomeForm Form { get; set; }
        public Hotels(HomeForm frm)
        {
            Form = frm;
            InitializeComponent();
            c.Open();
            string sql = "SELECT Hotel.Name, Hotel.Stars, Hotel.Food, City.Name, Country.Name, Hotel.ID FROM Hotel, City, Country WHERE Hotel.IdCity = City.ID AND City.IdCountry = Country.ID";
            MySqlCommand command = new MySqlCommand(sql, c);
            MySqlDataReader reader = command.ExecuteReader();
            f.CreateDataGridView(dataGridView1, reader);
            c.Close();
            for (int i = 0; i < Form.panel2.Controls.Count; i++)
            {
                Form.panel2.Controls[i].Visible = false;
            }
            Form.Add.Visible = true;
            Form.Filter.Visible = true;
        }

        private void Hotels_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }


        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Hotels_Click(object sender, EventArgs e)
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

        private void Yes_Click(object sender, EventArgs e)
        {
            DataGridViewColumn l = new DataGridViewTextBoxColumn();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add(l);
            l.HeaderText = "Путевок";
            l.Visible = true;
            l.Width = 200;
            dataGridView1.Columns[3].Width = 250;
            dataGridView1.Columns[4].Width = 250;
            c.Open();
            string sql = "SELECT Hotel.Name, Hotel.Stars, Hotel.Food, City.Name, Country.Name, Hotel.ID, Rate.CountVoucher " +
 "FROM Hotel, City, Country, " +
 "(SELECT Hotel.ID as ID, Sum(Rooms.CountVoucher) as CountVoucher FROM Hotel, Room, " +
 "(SELECT Voucher.idTypeRoom As ID, Count(Voucher.idTypeRoom) AS CountVoucher FROM Voucher GROUP BY idTypeRoom)AS Rooms " +
" WHERE Hotel.ID = Room.idHotel AND Room.id = Rooms.id " +
" GROUP BY Hotel.ID " +
 ")AS Rate " +
 "WHERE Hotel.IdCity = City.ID AND City.IdCountry = Country.ID AND Rate.ID = Hotel.ID " +
 "order by Rate.CountVoucher DESC ";
                MySqlCommand command = new MySqlCommand(sql, c);
            MySqlDataReader reader = command.ExecuteReader();
            f.CreateDataGridView(dataGridView1, reader);
            c.Close();

        }
    }
}
