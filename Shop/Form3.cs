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
    public partial class Form3 : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        String ono = Form2.orderno;
        public void connect1()
        {
            String oradb = "Data Source=sg140797;User ID=shop;Password=qwer1234";
            conn = new OracleConnection(oradb);
            conn.Open();
        }
        public Form3()
        {
            connect1();
            InitializeComponent();
            abcd();
            setono();
        }
        private void setono()
        {
            if (ono == "New")
            {
                int i = 0;
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "Select max(orderno) as abc from orders";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "orders");
                dt = ds.Tables["orders"];
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                }
                ono = dr["abc"].ToString();
            }
            else
            {
                load_prev_order();
            }
                   

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void abcd()
        {
            listBox1.Items.Clear();
            fetch_cname();
        }
        private String fetch_typeno(String a,String b)
        {
            
            int i = 0;
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "Select typeno from tile where cname='"+a+"' and design_no='"+b+"'";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "tile");
            dt = ds.Tables["tile"];
            String name;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
            }
            return (dr["typeno"].ToString());
        }
        private void fetch_cname()
        {
            comboBox1.Items.Clear();
            int i = 0;
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "Select distinct(cname) from tile";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "tile");
            dt = ds.Tables["tile"];
            String name;
            for (i = 0; i < dt.Rows.Count; i++)
            {

                dr = dt.Rows[i];
                name = dr["cname"].ToString().ToLower();
                comboBox1.Items.Add(name);
            }
        }
        private void fetch_designno()
        {
            String check = comboBox1.Text.ToLower();

            comboBox2.Items.Clear();
            int i = 0;
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "Select design_no from tile where cname='" + check + "'";

            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "tile");
            dt = ds.Tables["tile"];
            String name;
            for (i = 0; i < dt.Rows.Count; i++)
            {

                dr = dt.Rows[i];
                name = dr["design_no"].ToString();
                comboBox2.Items.Add(name);
            }
        }

        private void total_price()
        {
            int count = listBox5.Items.Count;
            int sum = 0;
            String[] x = new String[30];
            for (int i = 0; i < count; i++)
            {
                x[i] = listBox5.Items[i].ToString();
                sum = sum + Int32.Parse(x[i]);
            }
            textBox2.Text = sum.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String j = textBox1.Text;
            if (!(String.IsNullOrEmpty(j)) && char.IsDigit(j[0]))
            {
                String a = comboBox1.Text;
                String b = comboBox2.Text;
                String c = fetch_typeno(a, b);
                int i = 0;
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "Select typeno, location_id, wsprice from tile natural join stock where cname='" + a + "' and design_no ='" + b + "'";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "tile natural join stock");
                dt = ds.Tables["tile natural join stock"];
                String d, e1, f, g, h;

                for (i = 0; i < dt.Rows.Count; i++)
                {

                    dr = dt.Rows[i];
                    f = dr["location_id"].ToString();
                    g = dr["wsprice"].ToString();
                    listBox1.Items.Add(c);
                    listBox2.Items.Add(g);
                    listBox3.Items.Add(f);
                    listBox4.Items.Add(j);
                    int k = Int32.Parse(j) * Int32.Parse(g);
                    listBox5.Items.Add(k);
                    listBox6.Items.Add(a);
                }

                total_price();
                comboBox2.Text = "";
            }
            else
            {
                MessageBox.Show("enter a valid quantity!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetch_designno();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String a = comboBox1.Text;
            String b = comboBox2.Text;
            String c = fetch_typeno(a, b);
            int i = 0;
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "Select typeno, quantity, no_of_pieces, location_id, wsprice from tile natural join stock where cname='" + a + "' and design_no ='"+b+ "'";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "tile natural join stock");
            dt = ds.Tables["tile natural join stock"];
            String d,e1,f,g,h;
            for (i = 0; i < dt.Rows.Count; i++)
            {

                dr = dt.Rows[i];
                d = dr["quantity"].ToString();
                richTextBox1.Text = "stock:" + d + "\n";
                e1 = dr["no_of_pieces"].ToString();
                f = dr["location_id"].ToString();
                g = dr["wsprice"].ToString();
                richTextBox1.AppendText("no. of pieces:  " + e1 + "\n");
                richTextBox1.AppendText("location id:  " + f + "\n");
                richTextBox1.AppendText("price:  " + g + "\n");

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = listBox1.SelectedIndex;
            
            {
                listBox2.SelectedIndex = a;
                listBox3.SelectedIndex = a;
                listBox4.SelectedIndex = a;
                listBox5.SelectedIndex = a;
                listBox6.SelectedIndex = a;
            }
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = listBox6.SelectedIndex;
            
            {
                listBox2.SelectedIndex = a;
                listBox3.SelectedIndex = a;
                listBox4.SelectedIndex = a;
                listBox5.SelectedIndex = a;
                listBox1.SelectedIndex = a;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = listBox2.SelectedIndex;
            
            {
                listBox1.SelectedIndex = a;
                listBox3.SelectedIndex = a;
                listBox4.SelectedIndex = a;
                listBox5.SelectedIndex = a;
                listBox6.SelectedIndex = a;
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = listBox3.SelectedIndex;
            
            {
                listBox2.SelectedIndex = a;
                listBox1.SelectedIndex = a;
                listBox4.SelectedIndex = a;
                listBox5.SelectedIndex = a;
                listBox6.SelectedIndex = a;
            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = listBox4.SelectedIndex;
            
            {
                listBox2.SelectedIndex = a;
                listBox3.SelectedIndex = a;
                listBox1.SelectedIndex = a;
                listBox5.SelectedIndex = a;
                listBox6.SelectedIndex = a;
            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

            int a = listBox5.SelectedIndex;
            
            {
                listBox2.SelectedIndex = a;
                listBox3.SelectedIndex = a;
                listBox4.SelectedIndex = a;
                listBox1.SelectedIndex = a;
                listBox6.SelectedIndex = a;
            }
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            int a = listBox1.SelectedIndex;
            if (a != -1)
            {
                listBox1.Items.RemoveAt(a);
                listBox2.Items.RemoveAt(a);
                listBox3.Items.RemoveAt(a);
                listBox4.Items.RemoveAt(a);
                listBox5.Items.RemoveAt(a);
                listBox6.Items.RemoveAt(a);
                total_price();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "delete from tile_order where orderno="+ono;
            comm.CommandType = CommandType.Text;
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            int count=listBox1.Items.Count;
            String[] a = new String[30];
            String[] b = new String[30];
            String[] c = new String[30];
            

            int i = 0;
            for(;i<count;i++)
            {
                a[i] = listBox1.Items[i].ToString();
                b[i] = listBox4.Items[i].ToString();
                c[i] = listBox5.Items[i].ToString();
                
            }
            int flag = 0;
            for (i=0; i < count; i++)
            {
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "insert into tile_order values(" + ono + "," + a[i] + "," + b[i] + "," + c[i] + ")";
                comm.CommandType = CommandType.Text;
                try
                {
                    comm.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    flag = 1;   
                    MessageBox.Show(ex.Message);
                }
            }
            if(flag!=1)
                MessageBox.Show("Ordered Successfully");
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void load_prev_order()
        {
            
            int i = 0;
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "Select typeno,oquantity,total from tile_order where orderno=" + ono;
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "tile_order");
            dt = ds.Tables["tile_order"];

            for (i = 0; i < dt.Rows.Count; i++)
            {

                dr = dt.Rows[i];

                listBox1.Items.Add(dr["typeno"].ToString());
                listBox2.Items.Add(ret_price(dr["typeno"].ToString()));
                listBox3.Items.Add(ret_lid(dr["typeno"].ToString()));
                listBox4.Items.Add(dr["oquantity"].ToString());
                listBox5.Items.Add(dr["total"].ToString());
                listBox6.Items.Add(ret_cname(dr["typeno"].ToString()));
            }
            int count = listBox5.Items.Count;
            int sum = 0;
            String[] x = new String[30];
            for (i = 0; i < count; i++)
            {
                x[i] = listBox5.Items[i].ToString();
                sum = sum + Int32.Parse(x[i]);
            }
            textBox2.Text = sum.ToString();
           
        }
        private String ret_cname(String s)
        {
            int RETURN_VALUE_BUFFER_SIZE = 32767;
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "ret_cname";
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("abc", OracleDbType.Varchar2, RETURN_VALUE_BUFFER_SIZE);
            comm.Parameters["abc"].Direction = ParameterDirection.ReturnValue;

            comm.Parameters.Add("a", OracleDbType.Varchar2);
            comm.Parameters["a"].Value =s ;

            
            comm.ExecuteNonQuery();
            string bval = comm.Parameters["abc"].Value.ToString();
            return bval;
        }
        private String ret_price(String s)
        {
            int RETURN_VALUE_BUFFER_SIZE = 32767;
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "ret_price";
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("abc", OracleDbType.Varchar2, RETURN_VALUE_BUFFER_SIZE);
            comm.Parameters["abc"].Direction = ParameterDirection.ReturnValue;

            comm.Parameters.Add("a", OracleDbType.Varchar2);
            comm.Parameters["a"].Value = s;


            comm.ExecuteNonQuery();
            string bval = comm.Parameters["abc"].Value.ToString();
            return bval;
        }
        private String ret_lid(String s)
        {
            int RETURN_VALUE_BUFFER_SIZE = 32767;
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "ret_lid";
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add("abc", OracleDbType.Varchar2, RETURN_VALUE_BUFFER_SIZE);
            comm.Parameters["abc"].Direction = ParameterDirection.ReturnValue;

            comm.Parameters.Add("a", OracleDbType.Varchar2);
            comm.Parameters["a"].Value = s;


            comm.ExecuteNonQuery();
            string bval = comm.Parameters["abc"].Value.ToString();
            return bval;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
