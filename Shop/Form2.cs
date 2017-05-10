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
    public partial class Form2 : Form
    {
        static public String orderno;
        OracleConnection conn;
        OracleCommand comm;
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        Form5 fr5 = new Form5();
        int flag;

        public void connect1()
        {
            String oradb = "Data Source=sg140797;User ID=shop;Password=qwer1234";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        public Form2()
        {
            flag = 0;
            InitializeComponent();
            connect1();
            adddata.SelectedIndexChanged += new EventHandler(adddata_SelectedIndexChanged);
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                String a = comboBox5.Text.ToString();
                String b = comboBox4.Text.ToString();
                String c = richTextBox1.Text;
                String d = pnotext.Text;
                String e1 = salarytext.Text;
                String f = extratext.Text.ToString();

                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "insert into employee(emp_id,fname,lname,address,phone,salary,extra) values((select max(emp_id)+1 from employee),'" + a + "','" + b + "','" + c + "'," + d + "," + e1 + ",'" + f + "') ";
                comm.CommandType = CommandType.Text;
                try
                {
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else MessageBox.Show("You are not authorised for it.\nLogin to continue");
        }

        private void adddata_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (adddata.SelectedTab == adddata.TabPages["designtab"])//your specific tabname
            {
                comboBox1.Items.Clear();
                comboBox9.Items.Clear();
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
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "Select typeno from tile order by typeno";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "tile");
                dt = ds.Tables["tile"];
                comboBox9.Items.Add("New");
                for (i = 0; i < dt.Rows.Count; i++)
                {

                    dr = dt.Rows[i];
                    name = dr["typeno"].ToString().ToLower();
                    comboBox9.Items.Add(name);
                }
                
            }
            else if (adddata.SelectedTab == adddata.TabPages["dealertab"])
            {
                comboBox3.Items.Clear();
                comboBox10.Items.Clear();
                int i = 0;
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "Select dno,name from dealer order by dno";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "dealer");
                dt = ds.Tables["dealer"];
                String name;
                comboBox10.Items.Add("New");
                for (i = 0; i < dt.Rows.Count; i++)
                {

                    dr = dt.Rows[i];
                    name = dr["name"].ToString();
                    comboBox3.Items.Add(name);
                    name = dr["dno"].ToString();
                    comboBox10.Items.Add(name);

                }
                

            }
            else if (adddata.SelectedTab == adddata.TabPages["employeetab"])
            {
                comboBox11.Items.Clear();
                comboBox5.Items.Clear();
                int i = 0;
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "Select emp_id,fname from employee order by emp_id";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "employee");
                dt = ds.Tables["employee"];
                String name;
                comboBox11.Items.Add("New");
                for (i = 0; i < dt.Rows.Count; i++)
                {

                    dr = dt.Rows[i];
                    name = dr["fname"].ToString();
                    comboBox5.Items.Add(name);
                    name = dr["emp_id"].ToString();
                    comboBox11.Items.Add(name);
                }

            }
            else if (adddata.SelectedTab == adddata.TabPages["warehousetab"])
            {
                comboBox6.Items.Clear();
                int i = 0;
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "Select location_id from warehouse";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "warehouse");
                dt = ds.Tables["warehouse"];
                String name;
                for (i = 0; i < dt.Rows.Count; i++)
                {

                    dr = dt.Rows[i];
                    name = dr["location_id"].ToString();
                    comboBox6.Items.Add(name);
                }
                comboBox6.Items.Add("New");
            }
            else if (adddata.SelectedTab == adddata.TabPages["ordertab"])
            {
                comboBox7.Items.Clear();
                int i = 0;
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "Select orderno from orders";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "orders");
                dt = ds.Tables["orders"];
                String name;
                for (i = 0; i < dt.Rows.Count; i++)
                {

                    dr = dt.Rows[i];
                    name = dr["orderno"].ToString();
                    comboBox7.Items.Add(name);
                }
                comboBox7.Items.Add("New");
                comboBox8.Items.Clear();
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "Select emp_id from employee";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "employee");
                dt = ds.Tables["employee"];
                for (i = 0; i < dt.Rows.Count; i++)
                {

                    dr = dt.Rows[i];
                    name = dr["emp_id"].ToString();
                    comboBox8.Items.Add(name);
                }
            }


        }
        private void designtab_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            String a = comboBox6.Text;
            String b = textBox5.Text;
            String c = waddress.Text.ToString();
            comm = new OracleCommand();
            comm.Connection = conn;
            if (a == "New")
            {
                comm.CommandText = "insert into warehouse(location_id,capacity,address) values((select max(location_id)+1 from warehouse),'" + b + "','" + c + "')";
                comm.CommandType = CommandType.Text;
                try
                {
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Contact Database Administrator!");
                }
            }
            else
            {
                MessageBox.Show("To add new Warehouse select new in Warehouse ID!");
            }
            

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cname_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {

            String a = comboBox1.Text.ToString().ToLower();
            String b = comboBox2.Text.ToString();
            String c = textBox7.Text;
            String d = textBox6.Text;
            String e1 = textBox4.Text;
            String f = textBox3.Text;
            String g = textBox1.Text.ToString();
            String h = textBox8.Text.ToString();
            String i = textBox2.Text.ToString();
            try
            {
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "update tile set wsprice='" + f + "',dno='" + e1 + "' where cname='" + a + "' and design_no='" + b + "'";
            comm.CommandType = CommandType.Text;
            comm.ExecuteNonQuery();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "select typeno from tile where cname='" + a + "' and design_no='" + b + "'";
            comm.CommandType = CommandType.Text;
            comm.ExecuteNonQuery();
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "tile");
            dt = ds.Tables["tile"];
            dr = dt.Rows[0];
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "update stock set location_id='" + h + "',no_of_pieces='" + g + "', quantity='" + i + "' where typeno='" + dr["typeno"].ToString() + "'";
            comm.CommandType = CommandType.Text;
            
                comm.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Design does not exist.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            String b = comboBox3.Text;
            String c = address.Text;
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "update dealer set address='" + c + "' where name='" + b + "'";
            comm.CommandType = CommandType.Text;
            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dealer does not exist.");
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox9.Text == "New")
            {
                String a = comboBox1.Text.ToString().ToLower();
                String b = comboBox2.Text.ToString();
                String c = textBox7.Text;
                String d = textBox6.Text;
                String e1 = textBox4.Text;
                String f = textBox3.Text;
                String g = textBox1.Text;
                String h = textBox8.Text;
                String i = textBox2.Text;
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "insert into tile(typeno,cname,design_no,length,width,dno,wsprice) values((select max(typeno)+1 from tile),'" + a + "','" + b + "','" + c + "','" + d + "','" + e1 + "','" + f + "') ";
                comm.CommandType = CommandType.Text;

                try
                {
                    comm.ExecuteNonQuery();
                    comm = new OracleCommand();
                    comm.Connection = conn;
                    comm.CommandText = "insert into stock values((select max(typeno) from tile)," + h + "," + g + "," + i + ")";
                    comm.CommandType = CommandType.Text;
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Already exists in the database.");
                }

            }
            else MessageBox.Show("Select new in tile number.");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            String a = comboBox1.Text.ToString().ToLower();
            String b = comboBox2.Text.ToString();
            //tile table values
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "Select * from tile where cname='" + a + "'and design_no='" + b + "'";

            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "tile");
            dt = ds.Tables["tile"];
            dr = dt.Rows[0];
            textBox7.Text = dr["length"].ToString();
            textBox6.Text = dr["width"].ToString();
            textBox4.Text = dr["dno"].ToString();
            textBox3.Text = dr["wsprice"].ToString();
            //stock table values
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "Select * from stock where typeno='" + dr["typeno"].ToString() + "'";

            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "stock");
            dt = ds.Tables["stock"];
            dr = dt.Rows[0];
            textBox1.Text = dr["no_of_pieces"].ToString();
            textBox8.Text = dr["location_id"].ToString();
            textBox2.Text = dr["quantity"].ToString();
            comboBox9.Text = dr["typeno"].ToString();
        }

        private void dealertab_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            String check = comboBox3.Text;
            int i = 0;
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "Select * from dealer where name='" + check + "'";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "dealer");
            dt = ds.Tables["dealer"];
            for (i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[0];
                address.Text = dr["address"].ToString();
                comboBox10.Text = dr["dno"].ToString(); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String b = comboBox3.Text;
            String c = address.Text;
            if (comboBox10.Text == "New")
            {
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "insert into dealer(dno,name,address) values((select max(dno)+1 from dealer),'" + b + "','" + c + "')";
                comm.CommandType = CommandType.Text;
                try
                {
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Already exists in the database.");
                }

            }
            else
                MessageBox.Show("Select new in Dealer ID.");
        }


        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            String check = comboBox5.Text;
            int i = 0;
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "Select lname from employee where fname='" + check + "'";

            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "employee");
            dt = ds.Tables["employee"];
            String name;

            for (i = 0; i < dt.Rows.Count; i++)
            {

                dr = dt.Rows[i];
                name = dr["lname"].ToString();
                comboBox4.Items.Add(name);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            String a = comboBox5.Text;
            String b = comboBox4.Text;
            //tile table values
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "Select * from employee where fname='" + a + "'and lname='" + b + "'";

            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "employee");
            dt = ds.Tables["employee"];
            dr = dt.Rows[0];
            richTextBox1.Text = dr["address"].ToString();
            pnotext.Text = dr["phone"].ToString();
            salarytext.Text = dr["salary"].ToString();
            extratext.Text = dr["extra"].ToString();
            comboBox11.Text= dr["emp_id"].ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                String a = comboBox5.Text.ToString();
                String b = comboBox4.Text.ToString();
                String c = richTextBox1.Text;
                String d = pnotext.Text;
                String e1 = salarytext.Text;
                String f = extratext.Text.ToString();
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "Select salary from employee where fname='" + a + "' and lname='" + b + "'";

                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "warehouse");
                dt = ds.Tables["warehouse"];
                dr = dt.Rows[0];
                String xyz = dr["salary"].ToString();
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "update employee set address='" + c + "', phone=" + d + ",salary=" + e1 + ",extra='" + f + "',raise_date=(select sysdate from dual), raise_amount="+(Int32.Parse(e1) - Int32.Parse(xyz)).ToString()+" where fname='" + a + "' and lname='" + b + "'";

                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully!");
            }
            else MessageBox.Show("You are not authorised for it.\nLogin to continue");
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

            String a = comboBox6.Text;
            if (a != "New")
            {
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "Select * from warehouse where location_id='" + a + "'";

                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "warehouse");
                dt = ds.Tables["warehouse"];
                dr = dt.Rows[0];
                waddress.Text = dr["address"].ToString();
                textBox5.Text = dr["capacity"].ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            String a = comboBox6.Text;
            String b = textBox5.Text;
            String c = waddress.Text;
            if (a != "New")
            {
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "update warehouse set address='" + c + "', capacity=" + b + " where location_id=" + a;

                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();
                MessageBox.Show("Updated Successfully!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String a = comboBox1.Text.ToString().ToLower();
            String b = comboBox2.Text.ToString();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "select typeno from tile where cname='" + a + "' and design_no='" + b + "'";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "tile");
            dt = ds.Tables["tile"];
            dr = dt.Rows[0];
            String x = dr["typeno"].ToString();


            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "delete from stock where typeno=" + x + "";
            comm.CommandType = CommandType.Text;
            comm.ExecuteNonQuery();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "delete from tile where typeno=" + x + "";
            comm.CommandType = CommandType.Text;
            comm.ExecuteNonQuery();
            MessageBox.Show("Deleted Successfully!");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            String a = comboBox3.Text.ToString();
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "delete from dealer where name='" + a + "'";
            comm.CommandType = CommandType.Text;
            comm.ExecuteNonQuery();
            MessageBox.Show("Deleted Successfully!");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                String a = comboBox5.Text.ToString();
                String b = comboBox4.Text.ToString();
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "delete from employee where fname='" + a + "' and lname='" + b + "'";
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully!");
            }
            else
                MessageBox.Show("You are not authorised for it.\nLogin to continue");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            String a = comboBox6.Text;
            comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = "delete from warehouse where location_id=" + a + "";
            comm.CommandType = CommandType.Text;
            comm.ExecuteNonQuery();
            MessageBox.Show("Deleted Successfully!");


        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                String a = textBox9.Text.ToString();
                String b = textBox10.Text.ToString();
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from login";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "tile");
                dt = ds.Tables["tile"];
                int i;
                for (i = 0; i < dt.Rows.Count; i++)
                {

                    dr = dt.Rows[i];
                    if (dr["username"].ToString() == a && dr["pass"].ToString() == b)
                    {
                        flag = 1;
                        MessageBox.Show("Logged in successfully.");
                        Login.Text = "Logout";
                        textBox9.Text = "";
                        textBox10.Text = "";

                    }

                }
                if (flag == 0)
                {
                    MessageBox.Show("Wrong credentials.");

                }
            }
            else
            {
                Login.Text = "Login";
                flag = 0;
                MessageBox.Show("Logged out successfully.");
                textBox9.Text = "";
                textBox10.Text = "";
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            String a = comboBox7.Text;
            comm = new OracleCommand();
            comm.Connection = conn;
            if (a != "New")
            {
                comm.CommandText = "select * from orders where orderno=" + a;
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "orders");
                dt = ds.Tables["orders"];
                int i;
                for (i = 0; i < dt.Rows.Count; i++)
                {

                    dr = dt.Rows[i];
                    textBox11.Text = dr["cust_name"].ToString();
                    textBox12.Text = dr["cust_phone"].ToString();
                    comboBox8.Text = dr["emp_id"].ToString();
                }
            }
           
            
        }

        private void button12_Click(object sender, EventArgs e)
        {

            String chk = comboBox7.Text;
            if (chk == "New")
            {
                String a = textBox11.Text.ToString();
                String b = textBox12.Text;
                String c = comboBox8.Text;
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "insert into orders values((select max(orderno)+1 from orders),'" + a + "'," + b + "," + c + ")";
                comm.CommandType = CommandType.Text;
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Already exists in the database.");
                    return;
                }
            }
            
                orderno = comboBox7.Text;
           
                Form3 fr3 = new Shop.Form3();
                fr3.Show();

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            String a = comboBox9.Text;
            if (a == "New")
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
            else
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                comm = new OracleCommand();
                
                //tile table values
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "Select * from tile where typeno=" + a;

                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "tile");
                dt = ds.Tables["tile"];
                dr = dt.Rows[0];
                textBox7.Text = dr["length"].ToString();
                textBox6.Text = dr["width"].ToString();
                textBox4.Text = dr["dno"].ToString();
                textBox3.Text = dr["wsprice"].ToString();
                comboBox1.Text = dr["cname"].ToString();
                comboBox2.Text = dr["design_no"].ToString();
                //stock table values
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "Select * from stock where typeno=" + a;

                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "stock");
                dt = ds.Tables["stock"];
                dr = dt.Rows[0];
                textBox1.Text = dr["no_of_pieces"].ToString();
                textBox8.Text = dr["location_id"].ToString();
                textBox2.Text = dr["quantity"].ToString();
            }
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            String a = comboBox10.Text;
            if (a == "New")
            {
                comboBox3.Items.Clear();
                int i = 0;
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "Select name from dealer";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "dealer");
                dt = ds.Tables["dealer"];
                String name;
                for (i = 0; i < dt.Rows.Count; i++)
                {

                    dr = dt.Rows[i];
                    name = dr["name"].ToString();
                    comboBox3.Items.Add(name);
                }
            }
            else
            {
                int i = 0;
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "Select * from dealer where dno="+a;
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "dealer");
                dt = ds.Tables["dealer"];
                String name;
                for (i = 0; i < dt.Rows.Count; i++)
                {

                    dr = dt.Rows[i];
                    comboBox3.Text = dr["name"].ToString();
                    address.Text = dr["address"].ToString();
                    
                }
            }
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            String a = comboBox11.Text;
            if(a=="New")
            {
                comboBox5.Items.Clear();
                int i = 0;
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "Select fname from employee";
                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "employee");
                dt = ds.Tables["employee"];
                String name;
                for (i = 0; i < dt.Rows.Count; i++)
                {

                    dr = dt.Rows[i];
                    name = dr["fname"].ToString();
                    comboBox5.Items.Add(name);
                }
            }
            else
            {
                comm = new OracleCommand();
                comm.Connection = conn;
                comm.CommandText = "Select * from employee where emp_id=" + a;

                comm.CommandType = CommandType.Text;
                ds = new DataSet();
                da = new OracleDataAdapter(comm.CommandText, conn);
                da.Fill(ds, "employee");
                dt = ds.Tables["employee"];
                dr = dt.Rows[0];
                richTextBox1.Text = dr["address"].ToString();
                pnotext.Text = dr["phone"].ToString();
                salarytext.Text = dr["salary"].ToString();
                extratext.Text = dr["extra"].ToString();
                comboBox5.Text= dr["fname"].ToString();
                comboBox4.Text = dr["lname"].ToString();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
           
            fr5.Show();
            this.Close();
        }
        ~Form2()
        {
           
            fr5.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }
    }
}
