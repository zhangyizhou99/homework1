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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {

                OrderService os = new OrderService();
                List<Order> orders = os.QueryAllOrders();
                orders = os.QueryByGoodsName(textBox1.Text);
                foreach (Order od in orders)

                    MessageBox.Show(od.ToString());

            }
            else {

                OrderService os = new OrderService();
                List<Order> orders = os.QueryAllOrders();
                orders = os.QueryByCustomerName(textBox2.Text);
                foreach (Order od in orders)
                    
                MessageBox.Show(od.ToString());

            }

        }

       
    }
}
