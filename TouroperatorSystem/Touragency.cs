using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TouroperatorSystem
{
    public class Touragency
    {
        public static string connect = "server=localhost;user=root;database=cursach;password=Danilpanass1;";
        public static MySqlConnection c = new MySqlConnection(connect);
        public User Account { get; set; }
        public string Name { get; set; }
        public int Comission { get; set; }
        public string Director { get; set; }
        public DateTime Date{get; set;}
        public Touragency(string login)
        {
            string sql = $"SELECT Name, Comission, Director, DateLicense FROM Agency WHERE login='{login}'";
            Account = new User(login);
            c.Open();
            MySqlCommand com = new MySqlCommand(sql, c);
            MySqlDataReader reader = com.ExecuteReader();
            reader.Read();
            Name = reader[0].ToString();
            Comission = (int)reader[1];
            Director = reader[2].ToString();
            Date = Convert.ToDateTime(reader[3].ToString());
            c.Close();
        }
    }
}
