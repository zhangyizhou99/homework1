using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2
{
    class OderDetail
    {

        public int Number;
        public string Name, Goods;

    }
    class OderService
    {
        public static List<OderDetail> OderDetails;
        public static int Count
        {
            get
            {
                return OderDetails.Count;
            }
        }


        static OderService()
        {
            OderDetails = new List<OderDetail>();

        }

        public static OderDetail Information()
        {
            OderDetail myOderdetails = new OderDetail();
            Console.WriteLine("请输入要添加的订单信息：");

            Console.WriteLine("\n请输入订单号：");
            myOderdetails.Number = int.Parse(Console.ReadLine());

            Console.WriteLine("\n请输入客户名：");
            myOderdetails.Name = Console.ReadLine();

            Console.WriteLine("\n请输入商品名称：");
            myOderdetails.Goods = Console.ReadLine();
            return myOderdetails;

        }


        public void ShowOderInfo(OderDetail myOderdetails) {
            if (myOderdetails == null) return;
            Console.WriteLine("订单的信息是: ");
            Console.Write("\n订单号:{0}", myOderdetails.Number);
            Console.Write("\n客户姓名: {0}", myOderdetails.Name);
            Console.Write("\n货物名: {0}", myOderdetails.Goods);

            Console.WriteLine();

        }

        public OderDetail Search(int Number) {
            for (int i = 0; i < OderDetails.Count; i++) {

                if (OderDetails[i].Number == Number) {

                    return OderDetails[i];
                }

            }
            return null;
        }
        public void Add(OderDetail myOderdetails) {

            if (myOderdetails != null)
            {
                OderDetails.Add(myOderdetails);
                Console.WriteLine("我们现在有{0}条商品信息", OderDetails.Count);
            }

            else
                Console.WriteLine("你所输入的信息有误，请核对后重新输入");

        }


        public void Delete(int Number) {

            OderDetail Ode = Search(Number);
            if (Ode != null) {
                OderDetails.Remove(Ode);
                Console.WriteLine("已经删除订单号为为{0}的订单", Number);
                Console.WriteLine("我们现在还有{0}条订单信息", OderDetails.Count);

            }
            else
                Console.WriteLine("未找到你要删除的订单，请核对后重新输入！");

        }

        public void Volume()
        {
            Console.WriteLine("查询到学生的总人数为{0}", OderDetails.Count);

        }


        public static OderDetail[] Search(string Name) {
            List<OderDetail> OdeList = new List<OderDetail>();
            for (int i = 0; i < OderDetails.Count; i ++) {

                if (OderDetails[i].Name == Name) {
                    OdeList.Add(OderDetails[i]);

                }


            }

            return OdeList.ToArray();

        }

    }


    class Operate {
        public void Check() {
            do
            {
                Console.WriteLine("请选择所要操作的种类：\n1、添加订单信息 \n2、删除订单信息 \n3、查询订单数 \n4、查询订单信息（按学号） \n5、查询订单信息（按姓名）");
                int number = int.Parse(Console.ReadLine());
                if (number > 5 || number < 1)
                    Console.WriteLine("你的输入有误，请核对后重新输入");
                OderService myOderDetails = new OderService();
                switch (number)
                {

                    case 1:
                        OderDetail ode = OderService.Information();
                        myOderDetails.Add(ode);
                        myOderDetails.ShowOderInfo(ode);
                        break;
                    case 2:
                        Console.WriteLine("请输入你要删除的订单信息：");
                        Console.WriteLine("请输入订单的订单号：");
                        int Number = int.Parse(Console.ReadLine());
                        myOderDetails.Search(Number);
                        myOderDetails.Delete(Number);
                        break;

                    case 3:
                        myOderDetails.Volume();
                        break;

                    case 4:
                        Console.WriteLine("请输入你要查询的订单信息：");
                        Console.WriteLine("请输入订单号：");
                        Number = int.Parse(Console.ReadLine());
                        myOderDetails.Search(Number);
                        ode = myOderDetails.Search(Number);
                        myOderDetails.ShowOderInfo(ode);
                        break;

                    case 5:
                        Console.WriteLine("请输入你要查询的订单信息：");
                        Console.WriteLine("请输入客户名：");
                        string Sname = Console.ReadLine();
                        OderDetail[] odeList = OderService.Search(Sname);
                        for (int i = 0; i < odeList.Length; i++)
                        {
                            myOderDetails.ShowOderInfo(odeList[i]);
                        }
                        break;

                }
                Console.Write("Do you want to continue?(y/n)");
                if (Console.ReadLine() != "y")
                    break;
            } while (true);

            }

        }

    class Test {
        public static void Main(string[] args) {
            Operate myOperate = new Operate();
            myOperate.Check();

        }


    }
    
    }


