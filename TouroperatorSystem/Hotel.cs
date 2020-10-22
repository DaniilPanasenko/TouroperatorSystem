using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TouroperatorSystem
{
    public class Hotel
    {
        public static string connect = "server=localhost;user=root;database=cursach;password=Danilpanass1;";
        public static MySqlConnection c = new MySqlConnection(connect);
        Functions f = new Functions();
        public int ID { get; set; }
        public int Stars { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Food { get; set; }
        public string Name { get; set; }
        public  Hotel(int id)
        {
            ID = id;
            c.Open();
            string sql1 = $"SELECT Hotel.Stars, Hotel.Food, City.Name, Country.Name , Hotel.Name FROM Country, City, Hotel WHERE Country.ID = City.idCountry AND City.ID = Hotel.idCity AND Hotel.ID = {ID} ";
            MySqlCommand command1 = new MySqlCommand(sql1, c);
            MySqlDataReader reader1 = command1.ExecuteReader();
            reader1.Read();
            Stars = Convert.ToInt32(reader1[0]);
            Food = reader1[1].ToString();
            City = reader1[2].ToString();
            Country = reader1[3].ToString();
            Name = reader1[4].ToString();
            c.Close();
        }
    }
}
