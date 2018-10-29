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
        public Form2()
        {
            InitializeComponent();

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint a = uint.Parse(textBox1.Text);
            string customerName = textBox2.Text;
            Customer customer1 = new Customer(a, customerName);

            string goodsName = textBox3.Text;
            double b = double.Parse(textBox4.Text);
            Goods goods = new Goods(a, goodsName, b);

            uint c = uint.Parse(textBox5.Text);

            OrderDetail orderDetails1 = new OrderDetail(1, goods, c);
            Order order1 = new Order(a, customer1);
            order1.AddDetails(orderDetails1);
        }
    }
}
