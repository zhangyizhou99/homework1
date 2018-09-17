using System;

namespace project1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            int n = 0;

            Console.Write("please input an int :");
            s = Console.ReadLine();
            n = Int32.Parse(s);

            Console.Write("这个数的因数有");
            
            for (int i = 1; i <= n; i++) {
                int m;
                m = n % i;
                if (m == 0)
                    Console.WriteLine(i);
             };
            Console.WriteLine("按回车键关闭程序！");
            Console.Read();

        }
    }
}
