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
        public OrderService myService = new OrderService();
        
        public Form5()
        {
            InitializeComponent();
            bindingSource1.DataSource = myService.QueryAllOrders();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

         
            
        }

         public List<Order> Orders() {

            List<Order> orders = myService.QueryAllOrders();
            if (textBox1.Text != "")
            {

                orders = myService.QueryByGoodsName(textBox1.Text);
                
            }
            else
            {
                orders = myService.QueryByCustomerName(textBox2.Text);
                
            }

         
            
            return orders;
            
            }   
    }
}
