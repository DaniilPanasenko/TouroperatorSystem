using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TouroperatorSystem
{
    public class Functions
    {
        public static string connect = "server=localhost;user=root;database=cursach;password=Danilpanass1;";
        public static MySqlConnection c = new MySqlConnection(connect);
        public void CreateDataGridView(DataGridView dataGridView, MySqlDataReader reader)
        {
            dataGridView.Rows.Clear();
            while (reader.Read())
            {
                int num = dataGridView.Rows.Add();
                for(int i = 0; i<reader.FieldCount; i++)
                {
                   
                    dataGridView.Rows[num].Cells[i].Value = reader[i];
                    if(reader[i].GetType() == typeof(DateTime))
                    {
                        DateTime dt = Convert.ToDateTime(reader[i]);
                        if(dt.Hour==0 && dt.Minute==0 && dt.Second == 0)
                        {
                            dataGridView.Rows[num].Cells[i].Value = dt.ToShortDateString();
                        }
                        if (dataGridView.Columns[i].Name =="Column3")
                        {
                            dataGridView.Rows[num].Cells[i].Value = dt.ToShortDateString();
                        }
                        if(dataGridView.Columns[i].Name == "Time2")
                        {
                            dataGridView.Rows[num].Cells[i].Value = dt.Hour+":"+dt.Minute;
                        }
                    }
                    if (dataGridView.Columns[i].Name == "Time2")
                    {
                        string[] arr = reader[i].ToString().Split(':');
                        dataGridView.Rows[num].Cells[i].Value = arr[0] + ":" + arr[1];
                    }
                    if (dataGridView.Columns[i].Name == "Price")
                    {
                        dataGridView.Rows[num].Cells[i].Value = reader[i].ToString() + " $";
                    }
                }
            }
            
        }
        public string GetNameOfButton(Panel panel)
        {
            for(int i=0; i<panel.Controls.Count; i++)
            {
                if(panel.Controls[i].GetType() == typeof(Label))
                {
                    return panel.Controls[i].Text;
                }
            }
            return "";
        }
        public string GetNameOfButton(Panel p, PictureBox pb)
        {
            for (int i = 0; i < p.Controls.Count; i++)
            {
                for(int j = 0; j<p.Controls[i].Controls.Count; j++)
                {
                    if (p.Controls[i].Controls[j] == pb)
                    {
                        for (int k = 0; k < p.Controls[i].Controls.Count; k++)
                        {
                            if (p.Controls[i].Controls[k].GetType() == typeof(Label))
                            {
                                return p.Controls[i].Controls[k].Text;
                            }
                        }
                    }
                }
            }
            return "";
        }
        public void Generate_Standart_Value()
        {
            for (int i = 1; i < 20; i++)
            {
                string SQL1 = "DELETE FROM Agency WHERE Login = " + '"' + $"{i}" + '"';
                string SQL2 = "DELETE FROM Voucher WHERE ID = " + '"' + $"{i}" + '"';
                string SQL3 = "DELETE FROM Account WHERE Login = " + '"' + $"{i}" + '"';
                string SQL1a = $"INSERT INTO Agency (login, name, director, dateLicense, comission) VALUES('{i}', '1', '1', '2020-01-01', '1')";
                string SQL3a = $"INSERT INTO Account (login, password, isAdmin) VALUES('{i}', '1', '0')";
                c.Open();
                MySqlCommand com2 = new MySqlCommand(SQL2, c);
                com2.ExecuteNonQuery();
                MySqlCommand com1 = new MySqlCommand(SQL1, c);
                com1.ExecuteNonQuery();
                MySqlCommand com3 = new MySqlCommand(SQL3, c);
                com3.ExecuteNonQuery();
                MySqlCommand com3a = new MySqlCommand(SQL3a, c);
                com3a.ExecuteNonQuery();
                MySqlCommand com1a = new MySqlCommand(SQL1a, c);
                com1a.ExecuteNonQuery();
                c.Close();
            }
        }
        public bool FirstTimeIdBiggerThenSecond(DateTime d1, DateTime d2)
        {
            if (d1.Hour > d2.Hour)
            {
                return true;
            }
            else if(d1.Hour== d2.Hour)
            {
                if (d1.Minute > d2.Minute)
                {
                    return true;
                }
                else if (d1.Minute == d2.Minute)
                {
                    if (d1.Second > d2.Second)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
    }
}
