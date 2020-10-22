using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TouroperatorSystem
{
    public class User
    {
        private static string connect = "server=localhost;user=root;database=cursach;password=Danilpanass1;";
        private static MySqlConnection c = new MySqlConnection(connect);
        public string Login { get; set; }
        private string Password { get; set; }
        public bool IsAdmin { get; set; }
        public User(string login)
        {
            c.Open();
            string sql = "SELECT Login, Password, isAdmin FROM Account";
            MySqlCommand command = new MySqlCommand(sql, c);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader[0].ToString() == login)
                {
                    Login = reader[0].ToString();
                    Password = reader[1].ToString();
                    if (Convert.ToInt32(reader[2]) == 1)
                    {
                        IsAdmin = true;
                    }
                    else
                    {
                        IsAdmin = false;
                    }
                    break;
                }
            }
            c.Close();
        }
    }
}
