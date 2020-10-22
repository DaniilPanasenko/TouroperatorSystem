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
    public partial class FilterAgency : Form
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
        public HomeForm Form{ get; set; }
        public FilterAgency(HomeForm frm)
        {
            Form = frm;
            InitializeComponent();
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

        private void Filter_Agency_Load(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void No_Click(object sender, EventArgs e)
        {
            int min = int.MinValue;
            int max = int.MaxValue;
            try
            {
                min = int.Parse(textBox3.Text);
            }
            catch { }
            try
            {
                max = int.Parse(textBox4.Text);
            }
            catch { }
            Agencies a = (Agencies)Form.State;
            c.Open();
            string sql = $"SELECT Name, Director,Login, DateLicense, Comission FROM Agency WHERE Name LIKE '%{textBox0.Text}%' AND Login LIKE '%{textBox2.Text}%' AND Director LIKE '%{textBox1.Text}%' AND Comission <= {max} AND Comission >= {min} AND DateLicense >= STR_TO_DATE('{dateTimePicker1.Value.Year}-{dateTimePicker1.Value.Month}-{dateTimePicker1.Value.Day}','%Y-%m-%d') AND DateLicense <= STR_TO_DATE('{dateTimePicker2.Value.Year}-{dateTimePicker2.Value.Month}-{dateTimePicker2.Value.Day}','%Y-%m-%d')";
            MySqlCommand command = new MySqlCommand(sql, c);
            MySqlDataReader reader = command.ExecuteReader();
            f.CreateDataGridView(a.dataGridView1, reader);
            c.Close();
            Close();
        }
    }
}
