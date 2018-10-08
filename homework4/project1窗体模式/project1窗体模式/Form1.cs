using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1窗体模式
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "现在的时间是" + DateTime.Now.ToString();
            
            
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            int b;
            b = int.Parse(a);
            string c = textBox2.Text;
            int d;
            d = int.Parse(c);
            DateTime time = DateTime.Now;
            if (time.Hour == b && time.Minute == d )
            {
                MessageBox.Show("闹钟时间到了！");
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Interval = 10000;//秒
            timer1.Enabled = true;
        }
    }
}
