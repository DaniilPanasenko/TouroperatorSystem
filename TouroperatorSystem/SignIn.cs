using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using MySql.Data.MySqlClient;

namespace TouroperatorSystem
{

    public partial class SignIn : Form
    {
        public static string connect = "server=localhost;user=root;database=cursach;password=Danilpanass1;";

        public static MySqlConnection c = new MySqlConnection(connect);

        public Color orange = Color.LightSalmon;
        public Color blue = Color.CornflowerBlue;
        public Color white = Color.White;
        public Color black = Color.Black;
        public Color trans = Color.Transparent;
        public Color red = Color.MistyRose;

        public bool PanelMouseDown { get; set; }
        public Point PanelMouseDownLocation { get; set; }
        
        static byte CheckPassword(string log, string pas)
        {
            c.Open();
            string sql = "SELECT Login, Password FROM Account";
            MySqlCommand command = new MySqlCommand(sql, c);
            MySqlDataReader reader = command.ExecuteReader();
            byte b = 2;
            while (reader.Read())
            {
                if (reader[0].ToString() == log)
                {
                    if (reader[1].ToString() == pas)
                    {
                        b = 0;
                        break;
                    }
                    b = 1;
                    break;
                }
            }
            c.Close();
            return b;
        }
        public SignIn()
        {
            InitializeComponent();
            PanelMouseDown = false;
            PanelMouseDownLocation = new Point(0, 0);
            
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
        private void SignInButton_Click(object sender, EventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;
            byte check = CheckPassword(login, password);
            if (check == 0 && (login!="" || password!=""))
            {
                User user = new User(LoginTextBox.Text);
                HomeForm hf = new HomeForm(this,user);
                hf.Show();
                this.Hide();
            }
            else if (check == 1)
            {
                PasswordTextBox.Text = "";
                PasswordTextBox.BackColor = red;
            }
            else
            {
                LoginTextBox.Text = "";
                LoginTextBox.BackColor = red;
                PasswordTextBox.Text = "";
            }
        }
        private void LoginTextBox_TextChanged(object sender, EventArgs e)
        {
            LoginTextBox.BackColor = white;
        }
        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            PasswordTextBox.BackColor = white;
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

        private void Label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
