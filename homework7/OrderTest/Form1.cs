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
    public partial class Form1 : Form
    {
        public OrderService myService = null;
        DataTable ds = new DataTable("Orderrr");
        
        
        public Form1()
        {
            InitializeComponent();
            init();
            
        }
        private void init() {
            myService = new OrderService();
            Customer customer1 = new Customer(1, "zhang");
            Goods good1 = new Goods(1, "milk", 5);
            OrderDetail oder1 = new OrderDetail(1, good1, 100);
            Order ode1 = new Order(1, customer1);
            ode1.AddDetails(oder1);
            myService.AddOrder(ode1);
            
            orderBindingSource.DataSource = myService.QueryAllOrders();
            dataGridView1.DataSource = orderBindingSource;

            
            


        }
        private void setDataGridView2()
        {
            
            List<Order> orderlist = myService.searchOrderByID(1);
            if (orderlist.Count == 0)
            {
                this.dataGridView2.DataSource = null;
            }
            else
            {
                detailsBindingSource.DataSource = orderlist[0].Details;
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = detailsBindingSource;
            }
        }


        public void reloadForm()
        {
            orderBindingSource.DataSource = myService.Orders;
            //重新指向新的orderBindingSource
            dataGridView1.DataSource = new List<Order>();
            dataGridView1.DataSource = orderBindingSource;
            setDataGridView2();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 myForm = new Form2();
            myForm.Owner = this;
            myForm.ShowDialog();
            Order order = myForm.GetOrder();
            myService.AddOrder(order);

            orderBindingSource.DataSource = myService.QueryAllOrders();
            dataGridView1.DataSource = orderBindingSource;
        }
        //验证输入的电话号码是否正确
        /*string pattern = "^1[0-9]{10}$";
        Regex rx = new Regex(pattern);

        form1 = (Form1) this.Owner;
            if (textBox1.Text == "" || textBox2.Text == "")
            {
            MessageBox.Show("Please enter enough information!!!");
        }
            else if(textBox1.Text != "" && !rx.IsMatch(textBox2.Text))
            {
                MessageBox.Show("Telephone number's data format is wrong!!!");
            }
            else
            {
                form1.myService.addOrder(new Order(new Customer(textBox1.Text, textBox2.Text)));
                MessageBox.Show("Add order succeed!!!");
            }*/

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 myForm = new Form3();
            myForm.Owner = this;
            myForm.ShowDialog();

            myService.RemoveOrder(myForm.deleteOrder());

            orderBindingSource.DataSource = myService.QueryAllOrders();
            dataGridView1.DataSource = orderBindingSource;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 myForm = new Form4();
            myForm.ShowDialog();
            Customer newcustomer = myForm.newcustomer();
            myService.UpdateCustomer(newcustomer.Id, newcustomer);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 myForm = new Form5();
            myForm.ShowDialog();
            List<Order> orders = myForm.Orders();
            orderBindingSource.DataSource = orders;
            
        }
    }
}
