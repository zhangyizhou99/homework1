using ordertest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderTest
{
    public partial class Form2 : Form
    {
        Form1 form1 = null;
        
       


        
        public Form2()
        {
            InitializeComponent();

            

        }
     
        
        OrderService myService = new OrderService();

        private void button1_Click(object sender, EventArgs e)
        {
            
            form1 = (Form1)this.Owner;
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter enough information!!!");
            }
            
            else
            {

                
                MessageBox.Show("Add order succeed!!!");
                this.Close();
            }
            

            }


        public Order GetOrder() {

            Order order = new Order(uint.Parse(textBox1.Text), new Customer(uint.Parse(textBox1.Text), textBox2.Text));
                
            return order;
            }
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
