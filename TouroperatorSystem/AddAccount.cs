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
    public partial class AddAccount : Form
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
        public AddTouragency AT { get; set; }
        public User user { get; set; }
        public AddAccount(AddTouragency at)
        {
            InitializeComponent();
            AT = at;
            comboBox1.SelectedItem = "турагентство";
        }
        public AddAccount(AddTouragency at, User us)
        {
            user = us;
            InitializeComponent();
            AT = at;
            comboBox1.SelectedItem = "турагентство";
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
            if (Yes.Text != "Изменить")
            {
                if (!label9.Visible && !label1.Visible && textBox0.Text != "" && textBox1.Text != "")
                {
                    c.Open();
                    string sql = "SELECT Login FROM Account";
                    MySqlCommand command = new MySqlCommand(sql, c);
                    MySqlDataReader reader = command.ExecuteReader();
                    bool t = true;
                    while (reader.Read())
                    {
                        if (reader[0].ToString() == textBox0.Text)
                        {
                            t = false;
                        }
                    }
                    c.Close();
                    if (t)
                    {
                        c.Open();
                        int i = 0;
                        if (comboBox1.Text == "Администратор")
                        {
                            i = 1;
                        }
                        string SQL = $"INSERT INTO Account (login, password, isAdmin) VALUES ('{textBox0.Text}', '{textBox1.Text}','{i}')";
                        MySqlCommand com = new MySqlCommand(SQL, c);
                        com.ExecuteNonQuery();
                        string sqll = "SELECT login FROM Account WHERE isAdmin=0 AND login NOT IN (SELECT login FROM agency)";
                        MySqlCommand commandd = new MySqlCommand(sqll, c);
                        MySqlDataReader readerr = commandd.ExecuteReader();
                        AT.comboBox1.Items.Clear();
                        while (readerr.Read())
                        {
                            AT.comboBox1.Items.Add(readerr[0].ToString());
                        }
                        AT.comboBox1.SelectedItem = textBox0.Text;
                        c.Close();
                        Close();
                    }
                    else
                    {
                        MyMessageBox mmb = new MyMessageBox(AT.Form, "Ошибка", "Пользователь с таким логином уже существует", "ОК", "", "ОК", "");
                        mmb.Show();
                        c.Close();
                    }
                }
            }
            else if(!label9.Visible && !label1.Visible)
            {
                if (textBox2.Text == "Турагентство")
                {
                    string newlog = textBox0.Text;
                    if (newlog != user.Login)
                    {
                        c.Open();
                        string sql = "SELECT Login FROM Account";
                        MySqlCommand command = new MySqlCommand(sql, c);
                        MySqlDataReader reader = command.ExecuteReader();
                        bool t = true;
                        while (reader.Read())
                        {
                            if (reader[0].ToString() == newlog)
                            {
                                t = false;
                            }
                        }
                        c.Close();
                        if (t)
                        {
                            c.Open();
                            string SQL = $"INSERT INTO Account (login, password, isAdmin) VALUES ('{textBox0.Text}', '{textBox1.Text}','0')";
                            MySqlCommand com = new MySqlCommand(SQL, c);
                            com.ExecuteNonQuery();
                            string sql00 = $"INSERT INTO Account (login, password, isAdmin) VALUES ('current1308', 'current1308','0')";
                            MySqlCommand com00 = new MySqlCommand(sql00, c);
                            com00.ExecuteNonQuery();
                            string sql0 = $"INSERT INTO Agency (login, director, name, dateLicense, comission) VALUES ('current1308', 'current1308','current1308',STR_TO_DATE('2000-01-01','%Y-%m-%d'),10)";
                            MySqlCommand com0 = new MySqlCommand(sql0, c);
                            com0.ExecuteNonQuery();
                            string sql2 = $"UPDATE Voucher SET Login = 'current1308' WHERE Login = '{user.Login}'";
                            MySqlCommand com2 = new MySqlCommand(sql2, c);
                            com2.ExecuteNonQuery();
                            string sql1 = $"UPDATE Agency SET Login = '{newlog}'WHERE Login = '{user.Login}'";
                            MySqlCommand com1 = new MySqlCommand(sql1, c);
                            com1.ExecuteNonQuery();
                            string sql3 = $"UPDATE Voucher SET Login = '{newlog}' WHERE Login = 'current1308'";
                            MySqlCommand com3 = new MySqlCommand(sql3, c);
                            com3.ExecuteNonQuery();
                            string SQL3 = $"DELETE FROM Account WHERE Login = '{user.Login}' ";
                            MySqlCommand Com3 = new MySqlCommand(SQL3, c);
                            Com3.ExecuteNonQuery();
                            string SQL4 = $"DELETE FROM Agency WHERE Login = 'current1308' ";
                            MySqlCommand Com4 = new MySqlCommand(SQL4, c);
                            Com4.ExecuteNonQuery();
                            string SQL5 = $"DELETE FROM Account WHERE Login = 'current1308' ";
                            MySqlCommand Com5 = new MySqlCommand(SQL5, c);
                            Com5.ExecuteNonQuery();
                            c.Close();
                            if (AT.Form.State.GetType() == typeof(Accounts))
                            {
                                Accounts a = (Accounts)AT.Form.State;
                                c.Open();
                                string sql7 = "SELECT Agency.Name, Account.Login, Account.Password FROM Agency, Account WHERE Account.Login = Agency.Login UNION SELECT '-', Account.Login, Account.Password FROM Account WHERE Account.Login NOT IN(SELECT Login From Agency) AND Account.IsAdmin = 0";
                                MySqlCommand command0 = new MySqlCommand(sql7, c);
                                MySqlDataReader reader0 = command0.ExecuteReader();
                                f.CreateDataGridView(a.dataGridView1, reader0);
                                c.Close();
                                c.Open();
                                string sql8 = "SELECT Login, Password FROM Account WHERE IsAdmin = 1";
                                MySqlCommand command1 = new MySqlCommand(sql8, c);
                                MySqlDataReader reader1 = command1.ExecuteReader();
                                f.CreateDataGridView(a.dataGridView2, reader1);
                                c.Close();
                                a.dataGridView1.ClearSelection();
                                a.dataGridView2.ClearSelection();
                            }
                            Close();
                        }
                        else
                        {
                            MyMessageBox mmb = new MyMessageBox(AT.Form, "Ошибка", "Пользователь с данным логином уже существует", "ОК", "", "ОК", "");
                            mmb.Show();
                        }
                    }
                    else
                    {
                        c.Open();
                        string sql = $"UPDATE Account SET Password='{textBox1.Text}' WHERE Login='{newlog}'";
                        MySqlCommand command = new MySqlCommand(sql, c);
                        command.ExecuteNonQuery();
                        c.Close();
                        if (AT.Form.State.GetType() == typeof(Accounts))
                        {
                            Accounts a = (Accounts)AT.Form.State;
                            c.Open();
                            string sql0 = "SELECT Agency.Name, Account.Login, Account.Password FROM Agency, Account WHERE Account.Login = Agency.Login UNION SELECT '-', Account.Login, Account.Password FROM Account WHERE Account.Login NOT IN(SELECT Login From Agency) AND Account.IsAdmin = 0";
                            MySqlCommand command0 = new MySqlCommand(sql0, c);
                            MySqlDataReader reader0 = command0.ExecuteReader();
                            f.CreateDataGridView(a.dataGridView1, reader0);
                            c.Close();
                            c.Open();
                            string sql1 = "SELECT Login, Password FROM Account WHERE IsAdmin = 1";
                            MySqlCommand command1 = new MySqlCommand(sql1, c);
                            MySqlDataReader reader1 = command1.ExecuteReader();
                            f.CreateDataGridView(a.dataGridView2, reader1);
                            c.Close();
                            a.dataGridView1.ClearSelection();
                            a.dataGridView2.ClearSelection();
                        }
                        Close();
                    }
                }
                else
                {
                    string newlog = textBox0.Text;
                    if (newlog != user.Login)
                    {
                        c.Open();
                        string sql = "SELECT Login FROM Account";
                        MySqlCommand command = new MySqlCommand(sql, c);
                        MySqlDataReader reader = command.ExecuteReader();
                        bool t = true;
                        while (reader.Read())
                        {
                            if (reader[0].ToString() == newlog)
                            {
                                t = false;
                            }
                        }
                        c.Close();
                        if (t)
                        {
                            c.Open();
                            string sql1 = $"UPDATE Account SET Password='{textBox1.Text}', Login = '{newlog}' WHERE Login='{user.Login}'";
                            MySqlCommand command1 = new MySqlCommand(sql1, c);
                            command1.ExecuteNonQuery();
                            c.Close();
                            if (AT.Form.State.GetType() == typeof(Accounts))
                            {
                                Accounts a = (Accounts)AT.Form.State;
                                c.Open();
                                string sql0 = "SELECT Agency.Name, Account.Login, Account.Password FROM Agency, Account WHERE Account.Login = Agency.Login UNION SELECT '-', Account.Login, Account.Password FROM Account WHERE Account.Login NOT IN(SELECT Login From Agency) AND Account.IsAdmin = 0";
                                MySqlCommand command0 = new MySqlCommand(sql0, c);
                                MySqlDataReader reader0 = command0.ExecuteReader();
                                f.CreateDataGridView(a.dataGridView1, reader0);
                                c.Close();
                                c.Open();
                                string sql10 = "SELECT Login, Password FROM Account WHERE IsAdmin = 1";
                                MySqlCommand command10 = new MySqlCommand(sql10, c);
                                MySqlDataReader reader1 = command10.ExecuteReader();
                                f.CreateDataGridView(a.dataGridView2, reader1);
                                c.Close();
                                a.dataGridView1.ClearSelection();
                                a.dataGridView2.ClearSelection();
                            }
                            Close();
                        }
                        else
                        {
                            MyMessageBox mmb = new MyMessageBox(AT.Form, "Ошибка", "Пользователь с данным логином уже существует", "ОК", "", "ОК", "");
                            mmb.Show();
                        }
                    }
                    else
                    {
                        c.Open();
                        string sql = $"UPDATE Account SET Password='{textBox1.Text}' WHERE Login='{newlog}'";
                        MySqlCommand command = new MySqlCommand(sql, c);
                        command.ExecuteNonQuery();
                        c.Close();
                        if (AT.Form.State.GetType() == typeof(Accounts))
                        {
                            Accounts a = (Accounts)AT.Form.State;
                            c.Open();
                            string sql0 = "SELECT Agency.Name, Account.Login, Account.Password FROM Agency, Account WHERE Account.Login = Agency.Login UNION SELECT '-', Account.Login, Account.Password FROM Account WHERE Account.Login NOT IN(SELECT Login From Agency) AND Account.IsAdmin = 0";
                            MySqlCommand command0 = new MySqlCommand(sql0, c);
                            MySqlDataReader reader0 = command0.ExecuteReader();
                            f.CreateDataGridView(a.dataGridView1, reader0);
                            c.Close();
                            c.Open();
                            string sql1 = "SELECT Login, Password FROM Account WHERE IsAdmin = 1";
                            MySqlCommand command1 = new MySqlCommand(sql1, c);
                            MySqlDataReader reader1 = command1.ExecuteReader();
                            f.CreateDataGridView(a.dataGridView2, reader1);
                            c.Close();
                            a.dataGridView1.ClearSelection();
                            a.dataGridView2.ClearSelection();
                        }
                        Close();
                    }
                }
            }
        }

        private void TextBox0_TextChanged(object sender, EventArgs e)
        {
            if (textBox0.Text.Length > 7)
            {
                label9.Visible = false;
            }
            else
            {
                label9.Visible = true;
            }

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 7)
            {
                label1.Visible = false;
            }
            else
            {
                label1.Visible = true;
            }

        }

        private void No_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
