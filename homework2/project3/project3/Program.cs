using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project3
{
    class Program
    {
        
            static void Main(string[] args)
            {
                int m, k, n = 0;
                for (m = 2; m < 100; m++)
                {
                    for (k = 2; k < m; k++)
                        if (m % k == 0)
                            break;                              //它从内循环语句中跳出，进入外循环的下一轮
                    if (k >= m)
                    {

                        Console.WriteLine("{0}", m);
                        if (++n % 10 == 0)
                            Console.WriteLine("\n");

                        
                    }

                }

                Console.ReadLine();//在这里加上这样的一句话，这是为了语句运行完后，还要读入一行，这样就可以看到你要的东西……
            }


        }
          





            
        }
    

