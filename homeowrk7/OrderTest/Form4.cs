using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ordertest;
namespace OrderTest
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint orderId = uint.Parse(textBox1.Text);
            string newName = textBox2.Text;
            Customer newCustomer = new Customer(orderId ,newName) ;
            OrderService os = new OrderService();
            os.GetById(orderId);
            
            
            os.UpdateCustomer(orderId, newCustomer);
        }
    }
}

