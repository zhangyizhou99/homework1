using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project2
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string a = textBox2.Text;
            int b = int.Parse(a);
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(10, 200, 310, b, -Math.PI / 2);
        }
        
        private Graphics graphics;
        
       
        double per1 = 0.6;
        double per2 = 0.7;
        void drawCayleyTree(int n, double x0,double y0, double leng, double th)
        {
            if (n == 0) return;
            string c = textBox3.Text;
            int d = int.Parse(c);
            string e = textBox4.Text;
            int f = int.Parse(e);
            double th1 = d * Math.PI / 180;
            double th2 = f * Math.PI / 180;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + leng * Math.Cos(th)*1/2;
            double y2 = y0 + leng * Math.Sin(th) * 1 / 2;
            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2);


        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            string g = textBox5.Text;
            float  wid = float.Parse(g);
            
            Pen pen1 = new Pen(Color.Red, wid);
            Pen pen2 = new Pen(Color.Blue, wid);
            Pen pen3 = new Pen(Color.Green, wid);


            Random ra = new Random();
            string s = textBox1.Text;
            int a = int.Parse(s);
            if (a == 4)
                
                a = ra.Next(1, 4);
            switch (a ) {
                case 1:
                    graphics.DrawLine(
                pen1,
                (int )x0,(int)y0,(int)x1,(int)y1 );
                    break;
                case 2:
                    graphics.DrawLine(
                pen2,
                
                (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case 3:
                    graphics.DrawLine(
                pen3,
                (int)x0, (int)y0, (int)x1, (int)y1);
                    break;


            }




            
           
        }

      
    }
}
