using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array;
            Console.WriteLine("请输入数组的长度：");
            int length = Convert.ToInt32(Console.ReadLine());
            array = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.Write("请输入第{0}个数组的值：", i);
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            //求一个数组的最大值
            int a = 0;
            int max= 0;
            for (int  j = 0; j < array.Length ; j++) {

                if (max < array[j])
                {
                    a = j;
                    max = array[a];
                }
            }
           
            Console.WriteLine("本组数组的最大值是{0}",max);
            
            //求本组数组的最小值
            int b = 0;
            int min = array[0];
            for (int j = 0; j < array.Length; j++)
            {

                if (min > array[j])
                {
                    b = j;
                    min = array[b];
                }
            }

            Console.WriteLine("本组数组的最小值是{0}", min);
            Console.ReadKey();

            //求数组的和
            int sum = 0;
            for (int j = 0; j < array.Length; j++)
            {
                sum = sum + array[j];
            }
            Console.WriteLine("本组数组的和是{0}", sum);
            //求数组的平均值
            int average = 0;
            average = sum / array.Length;
            Console.WriteLine("本组数组的平均值是{0}", average );
            Console.ReadKey();
        }
    }
}
