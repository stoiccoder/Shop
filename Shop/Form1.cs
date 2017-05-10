using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace Shop
{
    public partial class Form1 : Form
    {
        
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
       
        public Form1()
        {
            InitializeComponent();
            
        }
        public void connect1()
        {
            String oradb = "Data Source=sg140797;User ID=shop;Password=qwer1234";
            conn = new OracleConnection(oradb);
            conn.Open();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            connect1();
            comm = new OracleCommand();
            comm.CommandText = "Select sysdate from dual";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "dual");
            dt = ds.Tables["dual"];
            dr = dt.Rows[0];
            MessageBox.Show(dr["sysdate"].ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
