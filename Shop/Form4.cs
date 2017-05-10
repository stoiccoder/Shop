using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop
{
    public partial class Form4 : Form
    {
        Form5 fr5 = new Form5();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet15.ORDERS' table. You can move, or remove it, as needed.
            this.oRDERSTableAdapter.Fill(this.dataSet15.ORDERS);
            // TODO: This line of code loads data into the 'dataSet13.STOCK' table. You can move, or remove it, as needed.
            this.sTOCKTableAdapter.Fill(this.dataSet13.STOCK);
            // TODO: This line of code loads data into the 'dataSet12.TILE' table. You can move, or remove it, as needed.
            this.tILETableAdapter.Fill(this.dataSet12.TILE);
            // TODO: This line of code loads data into the 'dataSet8.WAREHOUSE' table. You can move, or remove it, as needed.
            this.wAREHOUSETableAdapter.Fill(this.dataSet8.WAREHOUSE);
            // TODO: This line of code loads data into the 'dataSet7.EMPLOYEE' table. You can move, or remove it, as needed.
            this.eMPLOYEETableAdapter1.Fill(this.dataSet7.EMPLOYEE);
            // TODO: This line of code loads data into the 'dataSet6.EMPLOYEE' table. You can move, or remove it, as needed.
            this.eMPLOYEETableAdapter.Fill(this.dataSet6.EMPLOYEE);
            // TODO: This line of code loads data into the 'dataSet5.DEALER' table. You can move, or remove it, as needed.
            this.dEALERTableAdapter.Fill(this.dataSet5.DEALER);


        }
        

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            
                if (MessageBox.Show("Are you sure you want to exit?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else { Application.Exit(); }
            }
                                
       
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fr5.Show();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
    }
}
