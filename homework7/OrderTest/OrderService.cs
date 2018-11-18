using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace ordertest
{
    /// <summary>
    /// OrderService:provide ordering service,
    /// like add order, remove order, query order and so on
    /// 实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
    /// </summary>
    public class OrderService
    {

        List<Order> orders;
        public List<Order> Orders { get => orders; set => orders = value; }
        private Dictionary<uint, Order> orderDict;
        /// <summary>
        /// OrderService constructor
        /// </summary>
        public OrderService()
        {
            orderDict = new Dictionary<uint, Order>();
        }

        /// <summary>
        /// add new order
        /// </summary>
        /// <param name="order">the order will be added</param>
        public void AddOrder(Order order)
        {
            if (orderDict.ContainsKey(order.Id))
                MessageBox.Show("This order is already exsist!!!");
            else
                orderDict[order.Id] = order;


        }

        /// <summary>
        /// cancel order
        /// </summary>
        /// <param name="orderId">id of the order which will be canceled</param> 
        public void RemoveOrder(uint orderId)
        {
            orderDict.Remove(orderId);
        }

        /// <summary>
        /// query all orders
        /// </summary>
        /// <returns>List<Order>:all the orders</returns> 
        public List<Order> QueryAllOrders()
        {
            return orderDict.Values.ToList();
        }

        /// <summary>
        /// query by orderId
        /// </summary>
        /// <param name="orderId">id of the order to find</param>
        /// <returns>List<Order></returns> 
        public List<Order> searchOrderByID(uint id)
        {
            var query = orders.Where(o => o.Id == id);
            return query.ToList();
        }

        /// <summary>
        /// query by goodsName
        /// </summary>
        /// <param name="goodsName">the name of goods in order's orderDetail</param>
        /// <returns></returns> 
        public List<Order> QueryByGoodsName(string goodsName)
        {
            var query = orderDict.Values.Where(order =>
                    order.Details.Where(d => d.Goods.Name == goodsName)
                    .Count() > 0
                );
            return query.ToList();

        }

        /// <summary>
        /// query by customerName
        /// </summary>
        /// <param name="customerName">customer name</param>
        /// <returns></returns> 
        public List<Order> QueryByCustomerName(string customerName)
        {
            var query = orderDict.Values
                .Where(order => order.Customer.Name == customerName);
            return query.ToList();
        }

        public List<Order> QueryByPrice(double price)
        {
            var query = orderDict.Values
                .Where(order => order.Amount > price);
            return query.ToList();
        }


        /// <summary>
        /// edit order's customer
        /// </summary>
        /// <param name="orderId"> id of the order whoes customer will be update</param>
        /// <param name="newCustomer">the new customer of the order which will be update</param> 
        public void UpdateCustomer(uint orderId, Customer newCustomer)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict[orderId].Customer = newCustomer;
            }
            else
            {
                throw new Exception($"order-{orderId} is not existed!");
            }
        }


        private string XslFilePath;
        //初始化,传入XSL文件路径
        public XmlToHtml(string XslFilePath)
        {
            this.XslFilePath = XslFilePath;
        }

        //将XmlFileDir目录所有的XML创建相应的HTML文件
        public void CreateHtmlFile(string XmlFileDir)
        {
            DealWithXmlFile(XmlFileDir);
        }

        //根据单个XML文件创建HTML文件
        public void CreateSigleHtmlFile(string XmlFilePath)
        {
            XmlTransToHtml(XmlFilePath);
        }

        //搜索XmlFilePath在的XML文件
        private void DealWithXmlFile(string XmlFileDir)
        {
            //创建数组保存源文件夹下的文件名
            string[] strFiles = Directory.GetFiles(XmlFileDir, "*.xml");
            for (int i = 0; i < strFiles.Length; i++)
            {
                XmlTransToHtml(strFiles[i]);
            }

            System.IO.DirectoryInfo dirInfo = new DirectoryInfo(XmlFileDir);
            //取得源文件夹下的所有子文件夹名称
            DirectoryInfo[] ZiPath = dirInfo.GetDirectories();
            for (int j = 0; j < ZiPath.Length; j++)
            {
                //获取所有子文件夹名
                string strZiPath = XmlFileDir + "//" + ZiPath[j].ToString();
                //把得到的子文件夹当成新的源文件夹，从头开始新一轮的搜索
                DealWithXmlFile(strZiPath);
            }
        }

        //将sXmlPath的XML文件转化为Html文件
        private void XmlTransToHtml(string sXmlPath)
        {
            try
            {
                //生成Html文件路径
                string HtmlFilePath = sXmlPath.Substring(0, sXmlPath.Length - 3) + "html";
                XPathDocument myXPathDoc = new XPathDocument(sXmlPath);
                XslCompiledTransform myXslTrans = new XslCompiledTransform();
                //加载XSL文件
                myXslTrans.Load(XslFilePath);

                XmlTextWriter myWriter = new XmlTextWriter(HtmlFilePath, System.Text.Encoding.Default);
                myXslTrans.Transform(myXPathDoc, null, myWriter);
                myWriter.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.ToString());
            }


            /*other edit function with write in the future.*/
        }
    }
}
