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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace TouroperatorSystem
{
    public partial class HomeForm : Form
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
        public bool PanelMouseDown { get; set; }
        public Point PanelMouseDownLocation { get; set; }
        public User User { get; set; }
        public SignIn Si {get;set;}
        public UserControl State { get; set; }
        public HomeForm(SignIn s,User user)
        {
            InitializeComponent();
            User = user;
            PanelMouseDown = false;
            PanelMouseDownLocation = new Point(0, 0);
            Si = s;
            for(int i = 0; i<panel1.Controls.Count; i++)
            {
                if(panel1.Controls[i].GetType() == typeof(Panel))
                {
                    panel1.Controls[i].Click += ButtonHome1_Click;
                    for (int j = 0; j<panel1.Controls[i].Controls.Count; j++)
                    {
                        panel1.Controls[i].Controls[j].Click += ButtonHome1_Click;
                    }
                }
            }
            for (int i = 0; i < panel2.Controls.Count; i++)
            {
                if (panel2.Controls[i].GetType() == typeof(Panel))
                {
                    panel2.Controls[i].Click += ButtonHome2_Click;
                    for (int j = 0; j < panel2.Controls[i].Controls.Count; j++)
                    {
                        panel2.Controls[i].Controls[j].Click += ButtonHome2_Click;
                    }
                }
            }
            
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            if (User.IsAdmin)
            {
                Agencies ag = new Agencies(this);
                State = ag;
                this.Controls.Add(ag);
                ag.Location = new Point(panel3.Location.X + panel3.Size.Width, panel3.Location.Y + panel3.Size.Height + PanelForm.Size.Height);
                ag.Visible = true;
                ag.Show();
                panel6.Visible = false;
            }
            else
            {
                label3.Text = "Турагентство";
                OneAgency ag = new OneAgency(this, new Touragency(User.Login));
                State = ag;
                this.Controls.Add(ag);
                ag.Location = new Point(panel3.Location.X + panel3.Size.Width, panel3.Location.Y + panel3.Size.Height + PanelForm.Size.Height);
                ag.Visible = true;
                ag.Show();
                panel11.Visible = false;
                panel10.Visible = false;
            }
        }
        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            PanelMouseDown = false;
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

        private void Close_MouseEnter(object sender, EventArgs e)
        {
            Close.BackColor = orange;
            Close.ForeColor = black;
        }

        private void Close_MouseLeave(object sender, EventArgs e)
        {
            Close.BackColor = trans;
            Close.ForeColor = white;
        }
        private void ButtonHome2_Click(object sender, EventArgs e)
        {
            string name = "";
            try
            {
                Panel p = (Panel)sender;
                name = f.GetNameOfButton(p);
            }
            catch { }
            try
            {
                Label l = (Label)sender;
                name = l.Text;
            }
            catch { }
            try
            {
                PictureBox pb = (PictureBox)sender;
                name = f.GetNameOfButton(panel2, pb);
            }
            catch { }
            if (name == "Удалить")
            {
                if (State.GetType() == typeof(Agencies))
                {
                    Agencies cur = (Agencies)State;
                    MyMessageBox message = new MyMessageBox(this, "Предупреждение", $"Вы хотите удалить это турагенство ({cur.dataGridView1.SelectedRows.Count}), его аккаунт и все путевки?", "Да", "Нет", "Удаление_Агентства_Да", "Выход_Нет");
                    message.Show();
                }
                if (State.GetType() == typeof(OneHotel))
                {
                    OneHotel cur = (OneHotel)State;
                    MyMessageBox message = new MyMessageBox(this, "Предупреждение", $"Вы хотите удалить этот тип номера ({cur.dataGridView1.SelectedRows.Count})?", "Да", "Нет", "Удаление_Номера_Да", "Выход_Нет");
                    message.Show();
                }
                if (State.GetType() == typeof(OneVoucher))
                {
                    OneVoucher cur = (OneVoucher)State;
                    MyMessageBox message = new MyMessageBox(this, "Предупреждение", $"Вы хотите удалить эту составляющую путевки?", "Да", "Нет", "Удаление_Человека_Полета_Да", "Выход_Нет");
                    message.Show();
                }
                if (State.GetType() == typeof(Vouchers))
                {
                    Vouchers cur = (Vouchers)State;
                    MyMessageBox message = new MyMessageBox(this, "Предупреждение", $"Вы хотите удалить эту путевку ({cur.dataGridView1.SelectedRows.Count})?", "Да", "Нет", "Удаление_Путевки_Да", "Выход_Нет");
                    message.Show();
                }
                if (State.GetType() == typeof(Hotels))
                {
                    Hotels cur = (Hotels)State;
                    MyMessageBox message = new MyMessageBox(this, "Предупреждение", $"Вы хотите удалить этот отель ({cur.dataGridView1.SelectedRows.Count}) и все его путевки?", "Да", "Нет", "Удаление_Отеля_Да", "Выход_Нет");
                    message.Show();
                }
                if (State.GetType() == typeof(Routes))
                {
                    Routes cur = (Routes)State;
                    MyMessageBox message = new MyMessageBox(this, "Предупреждение", $"Вы хотите удалить этот рейс ({cur.dataGridView1.SelectedRows.Count}) и отменить все путевки по нем?", "Да", "Нет", "Удаление_Рейса_Да", "Выход_Нет");
                    message.Show();
                }
                if (State.GetType() == typeof(Accounts))
                {
                    Accounts cur = (Accounts)State;
                    int i = cur.dataGridView1.SelectedRows.Count;
                    i = Math.Max(i, cur.dataGridView2.SelectedRows.Count);
                    string str = $"Вы хотите удалить этот аккаунт ({i}), его тураегнтство и все путевки?";
                    if (cur.dataGridView2.SelectedRows.Count != 0)
                    {
                        str = $"Вы хотите удалить этот аккаунт ({i})?";
                    }
                    MyMessageBox message = new MyMessageBox(this, "Предупреждение", str, "Да", "Нет", "Удаление_Аккаунта_Да", "Выход_Нет");
                    message.Show();
                }
            }
            if (name == "Изменить")
            {
                if (State.GetType() == typeof(Agencies))
                {
                    Agencies cur = (Agencies)State;
                    AddTouragency at = new AddTouragency(this);
                    at.label4.Text = "Edit Touragency";
                    at.Yes.Text = "Изменить";
                    at.textBox0.Text = cur.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    at.comboBox1.Visible = false;
                    at.textBox2.Visible = true;
                    at.label8.Visible = false;
                    at.textBox2.Text = cur.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    at.textBox1.Text = cur.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    at.dateTimePicker1.Text = cur.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    at.textBox3.Text = cur.dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    at.Show();
                }
                if (State.GetType() == typeof(Vouchers))
                {
                    DataGridViewRow cur = ((Vouchers)State).dataGridView1.SelectedRows[0];
                    AddVoucher at = new AddVoucher(this);
                    at.label4.Text = "Edit Voucher";
                    at.Yes.Text = "Изменить";
                    at.textBox2.Text = cur.Cells[0].Value.ToString() ;
                    at.comboBox5.SelectedItem = cur.Cells[5].Value.ToString();
                    at.dateTimePicker1.Value = Convert.ToDateTime(cur.Cells[3].Value.ToString());
                    c.Open();
                    string sql = $"SELECT Agency.Name, a.Name, aa.Name, Airport.Code, Airport.Name, h.Name, hh.Name" +
                        $", Hotel.Name, Room.TypeRoom, Voucher.NumNights "+
                         "FROM Agency, Country a, Country h, City aa, City hh, Airport, Hotel, Room, voucher "+
                         $"WHERE Voucher.ID = '{cur.Cells[0].Value.ToString()}' AND Voucher.idTypeRoom = Room.ID AND Voucher.CodeAirport = Airport.Code "+
                        "AND Airport.idCity = aa.ID AND aa.idCountry = a.ID AND Room.idHotel = Hotel.ID AND Hotel.idCity = hh.ID "+
                        "AND hh.idCountry = h.ID AND Voucher.Login = Agency.Login";
                    MySqlCommand command1 = new MySqlCommand(sql, c);
                    MySqlDataReader reader1 = command1.ExecuteReader();
                    reader1.Read();
                    at.comboBox8.SelectedItem = reader1[0].ToString();
                    at.comboBox7.SelectedItem = reader1[1].ToString();
                    at.comboBox6.SelectedItem = reader1[2].ToString();
                    at.comboBox9.SelectedItem = reader1[3].ToString()+$" ({reader1[4].ToString()})";
                    at.comboBox2.SelectedItem = reader1[5].ToString();
                    at.comboBox3.SelectedItem = reader1[6].ToString();
                    at.comboBox1.SelectedItem = reader1[7].ToString();
                    at.comboBox4.SelectedItem = reader1[8].ToString();
                    at.textBox1.Text = reader1[9].ToString();
                    c.Close();
                    at.Show();
                }
                if (State.GetType() == typeof(OneHotel))
                {
                    OneHotel cur = (OneHotel)State;
                    AddRoom at = new AddRoom(this);
                    at.label4.Text = "Edit Room";
                    at.Yes.Text = "Изменить";
                    at.textBox1.Text = cur.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    at.textBox2.Text = cur.dataGridView1.SelectedRows[0].Cells[2].Value.ToString().Split(' ')[0];
                    at.textBox3.Text = cur.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    at.Show();
                }
                if (State.GetType() == typeof(Routes))
                {
                    AddRoute at = new AddRoute(this, false);
                    at.Show();
                }
                if (State.GetType() == typeof(Accounts))
                {
                    Accounts cur = (Accounts)State;
                    string p = "";
                    if (cur.dataGridView1.SelectedRows.Count != 0)
                    {
                        p = cur.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    }
                    else
                    {
                        p = cur.dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                    }
                    AddAccount at = new AddAccount(new AddTouragency(this), new User(p));
                    at.label4.Text = "Edit Account";
                    at.Yes.Text = "Изменить";
                    if (cur.dataGridView1.SelectedRows.Count != 0)
                    {
                        at.textBox0.Text = cur.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                        at.comboBox1.Visible = false;
                        at.textBox2.Visible = true;
                        at.textBox1.Text = cur.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                        at.Show();
                    }
                    else
                    {
                        at.textBox0.Text = cur.dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                        at.comboBox1.Visible = false;
                        at.textBox2.Visible = true;
                        at.textBox2.Text = "Администратор";
                        at.textBox1.Text = cur.dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                        at.Show();
                    }
                }
                if (State.GetType() == typeof(Hotels))
                {
                    Hotels cur = (Hotels)State;
                    AddHotel at = new AddHotel(this);
                    at.label4.Text = "Edit Hotel";
                    at.Yes.Text = "Изменить";
                    at.textBox0.Text = cur.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    at.textBox1.Text = cur.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    string str = cur.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                   
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
                    at.comboBox1.Text = str;
                    at.comboBox2.SelectedItem = cur.dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    at.comboBox3.SelectedItem = cur.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    at.ID = int.Parse(cur.dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
                    at.Show();
                }
            }
            if (name == "Добавить")
            {
                if (State.GetType() == typeof(Agencies))
                {
                    Agencies cur = (Agencies)State;
                    AddTouragency at = new AddTouragency(this);

                    at.Show();
                }
                if (State.GetType() == typeof(OneHotel))
                {
                    OneHotel cur = (OneHotel)State;
                    AddRoom at = new AddRoom(this);

                    at.Show();
                }
                if (State.GetType() == typeof(Accounts))
                {
                    Accounts acc = (Accounts)State;
                    AddAccount aa = new AddAccount(new AddTouragency(this));
                    aa.Show();
                }
                if (State.GetType() == typeof(Hotels))
                {
                    Hotels acc = (Hotels)State;
                    AddHotel aa = new AddHotel(this);
                    aa.Show();
                }
                if (State.GetType() == typeof(Routes))
                {
                    Routes acc = (Routes)State;
                    AddRoute aa = new AddRoute(this);
                    aa.Show();
                }
                if (State.GetType() == typeof(Vouchers))
                {
  
                    AddVoucher aa = new AddVoucher(this);
                    aa.Show();
                }
            }
            if (name == "Фильтр")
            {
                if (State.GetType() == typeof(Agencies))
                {
                    string SQL1 = "SELECT Max(comission) FROM Agency";
                    string SQL2 = "SELECT Min(comission) FROM Agency";
                    string SQL3 = "SELECT Max(dateLicense) FROM Agency";
                    string SQL4 = "SELECT Min(dateLicense) FROM Agency";
                    int maxc = 0;
                    c.Open();
                    MySqlCommand command = new MySqlCommand(SQL1, c);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        maxc = Convert.ToInt32(reader[0]);
                    }
                    c.Close();
                    Agencies cur = (Agencies)State;
                    FilterAgency filter = new FilterAgency(this);
                    int minc = 0;
                    c.Open();
                    MySqlCommand command1 = new MySqlCommand(SQL2, c);
                    MySqlDataReader reader1 = command1.ExecuteReader();
                    while (reader1.Read())
                    {
                        minc = Convert.ToInt32(reader1[0]);
                    }
                    c.Close();
                    DateTime maxd = new DateTime();
                    c.Open();
                    MySqlCommand command2 = new MySqlCommand(SQL3, c);
                    MySqlDataReader reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                    {
                        maxd = Convert.ToDateTime(reader2[0]);
                    }
                    c.Close();
                    DateTime mind = new DateTime();
                    c.Open();
                    MySqlCommand command3 = new MySqlCommand(SQL4, c);
                    MySqlDataReader reader3 = command3.ExecuteReader();
                    while (reader3.Read())
                    {
                        mind = Convert.ToDateTime(reader3[0]);
                    }
                    c.Close();
                    filter.textBox3.Text = minc.ToString();
                    filter.textBox4.Text = maxc.ToString();
                    filter.dateTimePicker1.Value = mind;
                    filter.dateTimePicker2.Value = maxd;
                    filter.Show();
                }
                if (State.GetType() == typeof(Hotels))
                {
                    Hotels acc = (Hotels)State;
                    AddHotel aa = new AddHotel(this);
                    aa.label4.Text = "Filter";
                    aa.Yes.Visible = false;
                    aa.No.Visible = false;
                    aa.button1.Visible = true;
                    aa.label7.Visible = false;
                    aa.label8.Visible = false;
                    aa.Show();
                }
                if (State.GetType() == typeof(Routes))
                {
                    Routes acc = (Routes)State;
                    FilterRoute aa = new FilterRoute(this);
                    aa.label4.Text = "Filter";


                    aa.Show();
                }
            }
            if (name == "Выполнить")
            {
                if (State.GetType() == typeof(SQLQuery))
                {
                    
                        SQLQuery sq = (SQLQuery)State;
                        c.Open();
                        MySqlCommand command = new MySqlCommand(sq.richTextBox1.Text, c);
                        MySqlDataReader reader = command.ExecuteReader();
                        sq.dataGridView1.Rows.Clear();
                        sq.dataGridView1.Columns.Clear();
                        for (int i = 0; i < reader.VisibleFieldCount; i++)
                        {
                            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                            column.Name = "column" + i;
                            column.HeaderText = reader.GetName(i);
                            column.Width = (sq.dataGridView1.Width - 35) / reader.VisibleFieldCount;
                            sq.dataGridView1.Columns.Add(column);
                        }
                        while (reader.Read())
                        {
                            int num = sq.dataGridView1.Rows.Add();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {

                                sq.dataGridView1.Rows[num].Cells[i].Value = reader[i];
                                if (reader[i].GetType() == typeof(DateTime))
                                {
                                    DateTime dt = Convert.ToDateTime(reader[i]);
                                    if (dt.Hour == 0 && dt.Minute == 0 && dt.Second == 0)
                                    {
                                        sq.dataGridView1.Rows[num].Cells[i].Value = dt.ToShortDateString();
                                    }
                                }
                            }
                        }
                        c.Close();
                    
                    
                }
            }
            if (name == "Очистить")
            {
                if (State.GetType() == typeof(SQLQuery))
                {
                    SQLQuery sq = (SQLQuery)State;
                    sq.richTextBox1.Text = "SELECT";
                    sq.richTextBox1.SelectionStart = 6;
                    sq.richTextBox1.SelectionLength = 0;
                }
            }
            if (name == "Справка")
            {
                if (State.GetType() == typeof(SQLQuery))
                {
                    Help h = new Help();
                    h.Show();
                }
            }
            if (name == "Просмотр")
            {
                if (State.GetType() == typeof(Hotels))
                {
                    Hotels h = (Hotels)State;
                    Controls.Remove(State);
                    OneHotel ag = new OneHotel(this, new Hotel(Convert.ToInt32(h.dataGridView1.SelectedRows[0].Cells[5].Value)));
                    State = ag;
                    this.Controls.Add(ag);
                    ag.Location = new Point(panel3.Location.X + panel3.Size.Width, panel3.Location.Y + panel3.Size.Height + PanelForm.Size.Height);
                    ag.Visible = true;
                    ag.Show();
                }
                if (State.GetType() == typeof(Agencies))
                {
                    Agencies h = (Agencies)State;
                    Controls.Remove(State);
                    OneAgency ag = new OneAgency(this, new Touragency(h.dataGridView1.SelectedRows[0].Cells[2].Value.ToString()));
                    State = ag;
                    this.Controls.Add(ag);
                    ag.Location = new Point(panel3.Location.X + panel3.Size.Width, panel3.Location.Y + panel3.Size.Height + PanelForm.Size.Height);
                    ag.Visible = true;
                    ag.Show();
                }
                if (State.GetType() == typeof(Vouchers))
                {

                    Vouchers h = (Vouchers)State;
                    OneVoucher ag = new OneVoucher(this);
                    Controls.Remove(State);

                    State = ag;
                    this.Controls.Add(ag);
                    ag.Location = new Point(panel3.Location.X + panel3.Size.Width, panel3.Location.Y + panel3.Size.Height + PanelForm.Size.Height);
                    ag.Visible = true;
                    ag.Show();
                }
            }
            if (name == "Обновить")
            {
                if (State.GetType() == typeof(Routes))
                {
                    UpdateRoutes u = new UpdateRoutes();
                    u.Show();
                }
                if (State.GetType() == typeof(Agencies))
                {
                    UpdateRoutes u = new UpdateRoutes(this, 1);
                    u.Show();
                }
            }
            if (name == "Отчет")
            {
                if (State.GetType() == typeof(OneAgency))
                {
                    OneAgency a = (OneAgency)State;
                    var document = new iTextSharp.text.Document();
                    using (var writer = PdfWriter.GetInstance(document, new FileStream("ReportTourAgency.pdf", FileMode.Create)))
                    {
                        document.Open();

                        BaseFont baseFont = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 20, 0);


                        document.Add(new Paragraph($"{a.label1.Text}", new iTextSharp.text.Font(baseFont, 30, 0)));
                        document.Add(new Paragraph($"         ", new iTextSharp.text.Font(baseFont, 10, 0)));
                        iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;

                        cb.MoveTo(30, 745);
                        cb.LineTo(560, 745);
                        cb.Stroke();

                        document.Add(new Paragraph($"{a.label2.Text}", font));
                        document.Add(new Paragraph($"{a.label4.Text}", font));
                        document.Add(new Paragraph($"{a.label3.Text}", font));
                        document.Add(new Paragraph($"{a.label6.Text}", font));
                        document.Add(new Paragraph($"         ", new iTextSharp.text.Font(baseFont, 3, 0)));
                        DataGridView d = a.dataGridView1;
                        int sum = 0;
                        int suma = 0;
                        int sumb = 0;
                        for (int i = 0; i < d.Rows.Count; i++)
                        {
                            if (d.Rows[i].Cells[4].Value.ToString() == "Выполнено" || d.Rows[i].Cells[4].Value.ToString() == "В процессе" || d.Rows[i].Cells[4].Value.ToString() == "Оплачено")
                            {
                                if (DateTime.Now <= Convert.ToDateTime(d.Rows[i].Cells[2].Value.ToString()).AddYears(1))
                                {
                                    if (DateTime.Now <= Convert.ToDateTime(d.Rows[i].Cells[2].Value.ToString()).AddMonths(1))
                                    {
                                        sumb += Convert.ToInt32(d.Rows[i].Cells[3].Value);
                                    }
                                    suma += Convert.ToInt32(d.Rows[i].Cells[3].Value);
                                }
                                sum += Convert.ToInt32(d.Rows[i].Cells[3].Value);
                            }
                        }
                        document.Add(new Paragraph($"Прибыль от турагентства за все время: {sum}$", font));
                        document.Add(new Paragraph($"Прибыль от турагентства за месяц: {sumb}$", font));
                        document.Add(new Paragraph($"Прибыль от турагентства за год: {suma}$", font));

                        bool t = false;
                        for (int i = 0; i < d.Rows.Count; i++)
                        {
                            if (d.Rows[i].Cells[4].Value.ToString() == "Забронировано")
                            {
                                if (!t)
                                {
                                    document.Add(new Paragraph($"К оплате:", font));
                                    t = true;
                                }
                                document.Add(new Paragraph($"    Путевка №{d.Rows[i].Cells[0].Value.ToString()} - {d.Rows[i].Cells[3].Value.ToString()}$ ", font));
                            }
                        }
                        document.Add(new Paragraph($" ", font));
                        document.Add(new Paragraph($" ", font));
                        
                        document.Add(new Paragraph("Дата создания отчета: "+DateTime.Now.ToString(), new iTextSharp.text.Font(baseFont, 10, 0)));
                        document.Close();
                        writer.Close();
                        ReportPDF r = new ReportPDF(true);

                    }
                }
                if (State.GetType() == typeof(OneVoucher))
                {
                    OneVoucher a = (OneVoucher)State;
                    var document = new Document();
                    using (var writer = PdfWriter.GetInstance(document, new FileStream("ReportVoucher.pdf", FileMode.Create)))
                    {
                        document.Open();

                        BaseFont baseFont = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 20, 0);


                        document.Add(new Paragraph($"{a.label1.Text}", new iTextSharp.text.Font(baseFont, 30, 0)));
                        document.Add(new Paragraph($"         ", new iTextSharp.text.Font(baseFont, 10, 0)));
                        iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;

                        cb.MoveTo(30, 745);
                        cb.LineTo(560, 745);
                        cb.Stroke();

                        document.Add(new Paragraph($"{a.label4.Text}", font));
                        document.Add(new Paragraph($"{a.label6.Text}", font));
                        document.Add(new Paragraph($"{a.label3.Text}", font));
                        document.Add(new Paragraph($"{a.label8.Text}", font));
                        document.Add(new Paragraph($"{a.label7.Text}", font));
                        document.Add(new Paragraph($"{a.label2.Text}", font));
                        document.Add(new Paragraph($"Перелеты: ", font));
                        document.Add(new Paragraph($"            ", font));
                        PdfPTable table = new PdfPTable(4);
                        for(int g=0; g<4; g++)
                        {
                            table.AddCell(new Paragraph($"{a.dataGridView2.Columns[g].HeaderText}", new iTextSharp.text.Font(baseFont, 10, 0)));

                        }
                        for (int g = 0; g < a.dataGridView2.Rows.Count; g++)
                        {
                            for (int s = 0; s < a.dataGridView2.Rows[g].Cells.Count-1; s++)
                            {
                                table.AddCell(new Paragraph($"{a.dataGridView2.Rows[g].Cells[s].Value.ToString()}", new iTextSharp.text.Font(baseFont, 10, 0)));
                            }
                        }
                        document.Add(table);
                        document.Add(new Paragraph($"Люди: ", font));
                        document.Add(new Paragraph($"            ", font));
                        PdfPTable table1 = new PdfPTable(6);
                        for (int g = 0; g < 6; g++)
                        {
                            table1.AddCell(new Paragraph($"{a.dataGridView1.Columns[g].HeaderText}", new iTextSharp.text.Font(baseFont, 10, 0)));

                        }
                        for (int g = 0; g < a.dataGridView1.Rows.Count; g++)
                        {
                            for (int s = 0; s < a.dataGridView1.Rows[g].Cells.Count; s++)
                            {
                                table1.AddCell(new Paragraph($"{a.dataGridView1.Rows[g].Cells[s].Value.ToString()}", new iTextSharp.text.Font(baseFont, 10, 0)));
                            }
                        }
                        document.Add(table1);
                        document.Add(new Paragraph($" ", font));
                        document.Add(new Paragraph($" ", font));

                        document.Add(new Paragraph("Дата создания отчета: " + DateTime.Now.ToString(), new iTextSharp.text.Font(baseFont, 10, 0)));

                        document.Close();
                        writer.Close();
                        ReportPDF r = new ReportPDF(false);
                    }

                }
            }
        }
        private void ButtonHome1_Click(object sender, EventArgs e)
        {
            string name="";
            try
            {
                Panel p = (Panel)sender;
                name = f.GetNameOfButton(p);
            }
            catch { }
            try
            {
                Label l = (Label)sender;
                name=l.Text;
            }
            catch { }
            try
            {
                PictureBox pb = (PictureBox)sender;
                name = f.GetNameOfButton(panel1, pb);
            }
            catch { }
            if (name != "")
            {
                if (name != "Выход")
                {
                    for (int i = 0; i < panel1.Controls.Count; i++)
                    {
                        if (panel1.Controls[i].GetType() == typeof(Panel))
                        {
                            for (int j = 0; j < panel1.Controls[i].Controls.Count; j++)
                            {
                                if (panel1.Controls[i].Controls[j].GetType() == typeof(Panel))
                                {
                                    panel1.Controls[i].Controls[j].Visible = false;
                                }
                            }
                        }
                    }
                }
                if (name == "Турагентства")
                {
                    Controls.Remove(State);
                    Agencies ag = new Agencies(this);
                    State = ag;
                    this.Controls.Add(ag);
                    ag.Location = new Point(panel3.Location.X + panel3.Size.Width, panel3.Location.Y + panel3.Size.Height + PanelForm.Size.Height);
                    ag.Visible = true;
                    ag.Show();
                    panel4.Visible = true;
                }
                if (name == "Турагентство")
                {
                    Controls.Remove(State);

                    OneAgency ag = new OneAgency(this, new Touragency(User.Login));
                    State = ag;
                    this.Controls.Add(ag);
                    ag.Location = new Point(panel3.Location.X + panel3.Size.Width, panel3.Location.Y + panel3.Size.Height + PanelForm.Size.Height);
                    ag.Visible = true;
                    ag.Show();
                    panel4.Visible = true;
                }
                if (name == "SQL запросы")
                {
                    Controls.Remove(State);
                    SQLQuery sq = new SQLQuery(this);
                    State = sq;
                    this.Controls.Add(sq);
                    sq.Location = new Point(panel3.Location.X + panel3.Size.Width, panel3.Location.Y + panel3.Size.Height + PanelForm.Size.Height);
                    sq.Visible = true;
                    sq.Show();
                    panel17.Visible = true;
                }
                if (name == "Отели")
                {
                    Controls.Remove(State);
                    Hotels a = new Hotels(this);
                    State = a;
                    this.Controls.Add(a);
                    a.Location = new Point(panel3.Location.X + panel3.Size.Width, panel3.Location.Y + panel3.Size.Height + PanelForm.Size.Height);
                    a.Visible = true;
                    a.Show();
                    panel14.Visible = true;
                }
                if (name == "Авиарейсы")
                {
                    Controls.Remove(State);
                    Routes a = new Routes(this);
                    State = a;
                    this.Controls.Add(a);
                    a.Location = new Point(panel3.Location.X + panel3.Size.Width, panel3.Location.Y + panel3.Size.Height + PanelForm.Size.Height);
                    a.Visible = true;
                    a.Show();
                    panel15.Visible = true;
                }
                if (name == "Аккаунты")
                {
                    Controls.Remove(State);
                    Accounts a = new Accounts(this);
                    State = a;
                    this.Controls.Add(a);
                    a.Location = new Point(panel3.Location.X + panel3.Size.Width, panel3.Location.Y + panel3.Size.Height + PanelForm.Size.Height);
                    a.Visible = true;
                    a.Show();
                    panel16.Visible = true;
                }
                if (name == "Путевки")
                {
                    Controls.Remove(State);
                    Vouchers a = new Vouchers(this);
                    State = a;
                    this.Controls.Add(a);
                    a.Location = new Point(panel3.Location.X + panel3.Size.Width, panel3.Location.Y + panel3.Size.Height + PanelForm.Size.Height);
                    a.Visible = true;
                    a.Show();
                    panel12.Visible = true;
                }
                if (name == "Поиск")
                {
                    Controls.Remove(State);
                    SearchVouchers a = new SearchVouchers(this);
                    State = a;
                   
                    this.Controls.Add(a);
                    a.BringToFront();
                    a.Location = new Point(panel3.Location.X + panel3.Size.Width, panel3.Location.Y + panel3.Size.Height + PanelForm.Size.Height-84);
                    a.Visible = true;
                    a.Show();
                    panel13.Visible = true;
                }
                if (name == "Выход")
                {
                    MyMessageBox message = new MyMessageBox(this, "Предупреждение", "Выйти из аккаунта?", "Да", "Нет", "Выход_Да", "Выход_Нет");
                    message.Show();
                }
            }
        }

        private void ButtonHome1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Add_VisibleChanged(object sender, EventArgs e)
        {
            if (!User.IsAdmin)
            {
                Add.Visible = false;
            }
        }

        private void Edit_VisibleChanged(object sender, EventArgs e)
        {
            if (!User.IsAdmin)
            {
                Edit.Visible = false;
            }
        }

        private void Delete_VisibleChanged(object sender, EventArgs e)
        {
            if (!User.IsAdmin)
            {
                Delete.Visible = false;
            }
        }

        private void Update_VisibleChanged(object sender, EventArgs e)
        {
            if (!User.IsAdmin)
            {
                Update.Visible = false;
            }
        }
    }
}
