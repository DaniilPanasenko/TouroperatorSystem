using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TouroperatorSystem
{
    
    public partial class UpdateRoutes : Form
    {
        public static string connect = "server=localhost;user=root;database=cursach;password=Danilpanass1;";
        public static MySqlConnection c = new MySqlConnection(connect);
        public Route[] Routes;
        public string[] Logins;
        public bool PanelMouseDown { get; set; }
        public Point PanelMouseDownLocation { get; set; }
        public Color orange = Color.LightSalmon;
        public Color blue = Color.CornflowerBlue;
        public Color white = Color.White;
        public Color black = Color.Black;
        public Color trans = Color.Transparent;
        public Color red = Color.MistyRose;
        Functions f = new Functions();
        public HomeForm Form { get; set; }
        public int I { get; set; }
        public UpdateRoutes()
        {
            InitializeComponent();
            Route[] R = new Route[0];
            string sql = "SELECT RouteNum, NumPlace, Days, TimeDeparture FROM Route";
            c.Open();
            MySqlCommand com = new MySqlCommand(sql, c);
            MySqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                Array.Resize(ref R, R.Length + 1);
                R[R.Length - 1] = new Route(reader[0].ToString(), Convert.ToInt32(reader[1]), reader[2].ToString(), Convert.ToDateTime(reader[3].ToString()));
            }
            Routes = R;
            progressBar1.Maximum = Routes.Length*2;
            progressBar1.Minimum = 0;
            c.Close();

        }
        public UpdateRoutes(HomeForm hf , int i)
        {
            I = i;
            Form = hf;
            InitializeComponent();
            string[] R = new string[0];
            string sql = "SELECT Login FROM Agency";
            c.Open();
            MySqlCommand com = new MySqlCommand(sql, c);
            MySqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                Array.Resize(ref R, R.Length + 1);
                R[R.Length - 1] = reader[0].ToString();
            }
            Logins = R;
            progressBar1.Maximum = R.Length+2;
            progressBar1.Minimum = 0;
            c.Close();
        }
        private void UpdateRoutes_Load(object sender, EventArgs e)
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
        private void Yes_Click(object sender, EventArgs e)
        {
            if (Yes.Text == "Обновить")
            {

                if (I == 1)
                {
                    string SQL = "";
                    for(int i=0; i<Logins.Length; i++)
                    {
                        OneAgency a = new OneAgency(Form, new Touragency(Logins[i]));
                        DataGridView d = a.dataGridView1;
                        int sum = 0;
                        for(int j=0; j<d.Rows.Count; j++)
                        {
                            if (d.Rows[j].Cells[4].Value.ToString() == "Выполнено" || d.Rows[j].Cells[4].Value.ToString() == "В процессе" || d.Rows[j].Cells[4].Value.ToString() == "Оплачено")
                            {
                                sum += Convert.ToInt32(d.Rows[j].Cells[3].Value);
                            }
                        }
                        sum /= 10000;
                        int k = 0;
                        int q = 1;
                        while (Math.Pow(2,q)<=sum)
                        {
                            k++;
                            q++;
                            sum -= (int)Math.Pow(2, q);
                        }
                        SQL += $"UPDATE Agency SET Comission = '{k+10}' WHERE Login='{Logins[i]}';";
                        progressBar1.Value ++;
                    }
                    c.Open();
                    MySqlCommand com = new MySqlCommand(SQL, c);
                    com.ExecuteNonQuery();
                    c.Close();
                    c.Open();
                    string sql = "SELECT Name, Director,Login, DateLicense, Comission FROM Agency";
                    MySqlCommand command = new MySqlCommand(sql, c);
                    MySqlDataReader reader = command.ExecuteReader();
                    f.CreateDataGridView(((Agencies)Form.State).dataGridView1, reader);
                    c.Close();
                    progressBar1.Value = progressBar1.Maximum;
                    Yes.Text = "Ок";
                    Yes.Location = new Point((this.Size.Width - Yes.Size.Width) / 2, Yes.Location.Y);
                    Yes.Visible = true;
                    label3.Text = "Обновление завершено";
                    label3.Location = new Point((this.Size.Width - label3.Size.Width) / 2, label3.Location.Y);
                }
                else
                {
                    int[][] result = new int[Routes.Length][];
                    label3.Text = "Обновляем";
                    label3.Location = new Point((this.Size.Width - label3.Size.Width) / 2, label3.Location.Y);
                    label3.Visible = true;

                    for (int i = 0; i < Routes.Length; i++)
                    {
                        string sql = $"SELECT Datetime FROM Flight WHERE NumRoute = '{Routes[i].Num}'";
                        c.Open();
                        int[] arr = new int[0];
                        MySqlCommand com = new MySqlCommand(sql, c);
                        MySqlDataReader reader = com.ExecuteReader();
                        while (reader.Read())
                        {
                            Array.Resize(ref arr, arr.Length + 1);
                            if (f.FirstTimeIdBiggerThenSecond(DateTime.Now, Convert.ToDateTime(reader[0])))
                            {
                                arr[arr.Length - 1] = (Convert.ToDateTime(reader[0]) - DateTime.Now).Days + 1;
                            }
                            else
                            {
                                arr[arr.Length - 1] = (Convert.ToDateTime(reader[0]) - DateTime.Now).Days;
                            }
                        }
                        c.Close();
                        int today = 0;
                        string day = DateTime.Now.DayOfWeek.ToString();
                        switch (day)
                        {
                            case "Monday":
                                today = 1;
                                break;
                            case "Tuesday":
                                today = 2;
                                break;
                            case "Wednesday":
                                today = 3;
                                break;
                            case "Thursday":
                                today = 4;
                                break;
                            case "Friday":
                                today = 5;
                                break;
                            case "Saturday":
                                today = 6;
                                break;
                            case "Sunday":
                                today = 7;
                                break;
                        }
                        result[i] = new int[0];
                        for (int j = 0; j < 200; j++)
                        {
                            int l = (today + j) % 7;
                            if (l == 0)
                            {
                                l = 7;
                            }
                            if (Routes[i].Days[l - 1])
                            {
                                bool h = false;
                                for (int s = 0; s < arr.Length; s++)
                                {
                                    if (arr[s] == j)
                                    {
                                        h = true;
                                        break;
                                    }
                                }
                                if (!h)
                                {
                                    Array.Resize(ref result[i], result[i].Length + 1);
                                    result[i][result[i].Length - 1] = j;
                                }
                            }
                        }
                        progressBar1.Value++;
                    }

                    string SQL = "SELECT Max(ID) FROM Flight";
                    c.Open();
                    MySqlCommand com1 = new MySqlCommand(SQL, c);
                    MySqlDataReader reader1 = com1.ExecuteReader();
                    int max = 1;
                    while (reader1.Read())
                    {
                        try
                        {
                            max = Convert.ToInt32(reader1[0]);
                        }
                        catch
                        {

                        }
                    }
                    c.Close();
                    for (int i = 0; i < result.Length; i++)
                    {
                        string sql0 = "";
                        c.Open();
                        for (int j = 0; j < result[i].Length; j++)
                        {
                            max++;
                            string date = DateTime.Now.AddDays(result[i][j]).ToShortDateString().Replace('.', '-');
                            date += "-" + Routes[i].Time.Hour + "-" + Routes[i].Time.Minute;
                            sql0 += $"INSERT INTO Flight (ID, NumRoute, Datetime, FreePlaces) " +
                                $"VALUES ('{max}','{Routes[i].Num}',STR_TO_DATE('{date}','%d-%m-%Y-%H-%i'),'{Routes[i].Place}');";

                        }
                        if (sql0 != "")
                        {
                            MySqlCommand comm = new MySqlCommand(sql0, c);

                            comm.ExecuteNonQuery();
                        }
                        c.Close();
                        progressBar1.Value++;
                    }

                    Yes.Text = "Ок";
                    Yes.Location = new Point((this.Size.Width - Yes.Size.Width) / 2, Yes.Location.Y);
                    Yes.Visible = true;
                    label3.Text = "Обновление завершено";
                    label3.Location = new Point((this.Size.Width - label3.Size.Width) / 2, label3.Location.Y);
                }
            }
            else
            {
                Close();
            }
        }
    }
    public class Route
    {
        public string Num { get; set; }
        public int Place { get; set; }
        public bool[] Days { get; set; }
        public DateTime Time { get; set; }
        public Route(string num, int place, string days, DateTime time)
        {
            Num = num;
            Place = place;
            string[] arr = days.Split(',');
            int[] newarr = new int[arr.Length];
            bool[] b = new bool[7];
            for(int i=0; i<7; i++)
            {
                b[i] = false;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                newarr[i] = int.Parse(arr[i]);
                b[newarr[i] - 1] = true;
            }
            Time = time;
            Days = b;
        }
    }
}
