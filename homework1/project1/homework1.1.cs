using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            int a,b,c = 0;
            Console.Write("please input an int :");
            s = Console.ReadLine();
            a = Int32.Parse(s);
            Console.Write("please input an int :");
            s = Console.ReadLine();
            b = Int32.Parse(s);
            c = a * b;
            Console.WriteLine("The product of these two numbers is " + c);
        }

    }
}
