using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    public class TimeSender {
        public delegate void TimeHandler(int shi,int fen);

        public event TimeHandler SetClock;

        public void SendTimeMsg(int shi, int fen) {
            if (SetClock != null){
            SetClock(shi, fen);
            }
        }
    }

    public class TimeReceiver {
        public int shi;
        public int fen;

        public TimeReceiver()
        {
            

            string s = "";
            
            Console.Write("请设置闹钟时数");
            s = Console.ReadLine();
            shi = Int32.Parse(s);
            Console.Write("请设置闹钟分数");
            s = Console.ReadLine();
            fen = Int32.Parse(s);

        }

        public void ReceiveMsg( int shi,int fen ) {
            System.Timers.Timer t = new System.Timers.Timer(10000);   //实例化Timer类，设置间隔时间为10000毫秒；   
            t.Elapsed += new System.Timers.ElapsedEventHandler(theout); //到达时间的时候执行事件；   
            t.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；   
            t.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；   

            
            


        }


        public void theout(object source, System.Timers.ElapsedEventArgs e)
            {
            String a, b;
            a = DateTime.Now.Hour.ToString();
            b = DateTime.Now.Minute.ToString();
            int c, d;
            c = int.Parse(a);
            d = int.Parse(b);
            if (a == c & b == d)
                Console.WriteLine(this.shi + "时" + this.fen + "分已到");
            }


    }
    class Program
    {
        static void Main(string[] args)
        {
            TimeSender timeSender = new TimeSender();
            TimeReceiver time1 = new TimeReceiver();

            timeSender.SetClock += new TimeSender.TimeHandler(time1.ReceiveMsg);

            timeSender.SendTimeMsg(1,2);
            Console.ReadLine();
        }
    }
}
