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
    public partial class OneHotel : UserControl
    {
        public static string connect = "server=localhost;user=root;database=cursach;password=Danilpanass1;";
        public static MySqlConnection c = new MySqlConnection(connect);
        Functions f = new Functions();
        public HomeForm Form { get; set; }
        public Hotel Hotel { get; set; }
        public OneHotel(HomeForm hf, Hotel h)
        {
            Hotel = h;
            Form = hf;
            InitializeComponent();
            label1.Text = Hotel.Name + " " + Hotel.Stars + "★";
            label2.Text = Hotel.Country;
            label4.Text = Hotel.City;
            string str = Hotel.Food;
            switch (str)
            {
                case "RO":
                    str = "RO - Room Only";
                    break;
                case "BB":
                    str = "BB - Bed & Breakfast";
                    break;
                case "HB":
                    str = "HB - Half Board";
                    break;
                case "FB":
                    str = "FB - Full Board";
                    break;
                case "AI":
                    str = "AI - All Inclusive";
                    break;
                case "UAI":
                    str = "UAI - Ultra All Inclusive";
                    break;
            }
            label3.Text = str;
            c.Open();
            string sql1 = $"SELECT TypeRoom, NumPerson, Price, id FROM Room WHERE idHotel = {Hotel.ID}";
            MySqlCommand command1 = new MySqlCommand(sql1, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            f.CreateDataGridView(dataGridView1, reader1);
            c.Close();
            for (int i = 0; i < Form.panel2.Controls.Count; i++)
            {
                Form.panel2.Controls[i].Visible = false;
            }
            Form.Add.Visible = true;
        }

        private void OneHotel_Load(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                Form.Edit.Visible = false;
                Form.Delete.Visible = false;
            }
            else if (dataGridView1.SelectedRows.Count > 1)
            {
                Form.Edit.Visible = false;
                Form.Delete.Visible = true;
            }
            else
            {
                Form.Edit.Visible = true;
                Form.Delete.Visible = true;
            }
        }
    }
}
