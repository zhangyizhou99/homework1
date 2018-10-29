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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 myForm = new Form2();
            myForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 myForm = new Form3();
            myForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 myForm = new Form4();
            myForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 myForm = new Form5();
            myForm.ShowDialog();
        }
    }
}
