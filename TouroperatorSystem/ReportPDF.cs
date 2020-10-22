using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TouroperatorSystem
{
    public partial class ReportPDF : Form
    {
        public ReportPDF(bool h)
        {
            InitializeComponent();
            if (h)
            {
                webBrowser1.Navigate(@"C:\Users\Danil\source\repos\TouroperatorSystem\TouroperatorSystem\bin\Debug\ReportTourAgency.pdf");
            }
            else
            {
                webBrowser1.Navigate(@"C:\Users\Danil\source\repos\TouroperatorSystem\TouroperatorSystem\bin\Debug\ReportVoucher.pdf");
            }
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void ReportPDF_Load(object sender, EventArgs e)
        {


            


        }
    }
}
