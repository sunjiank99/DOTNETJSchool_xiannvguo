using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Web;

namespace xiannvguo
{   struct info    
    {
          public int id;
          public string OrderNo;   //订单号
          public string RecevieName;//收货人
          public string ReceiveTel;//收货电话
          public decimal OrderMoney;//总金额
          public string PayTime;//时间
          public byte ShoppingState;//配送状态
          public byte PayState;//支付状态
          public byte OrderState;//订单状态
          

    }
    //日志
    struct Log_Order_info
    {
        public string OrderNo;
        public byte OrderState;
        public byte PayState;
        public byte ShoppingState;
        public string Remark;
        public int UserCode;
        public string Creater;
        public string Pubtime;

    }
    /// <summary>
    /// 商品信息
    /// </summary>
    struct commodity
    {
        public string GoodsName;
        public string GoodsCode;
        public string SalePrice;
        public int GoodsNum;
        
    
    }
    /// <summary>
    /// 订单详情
    /// </summary>
     public struct OrderInfo    //订单详情
        {
             public string OrderNo;
             public string UserTel;
             public string PayType;
             public string PickPointName;
             public string StockUperCode;
             public string CheckerCode;
             public string OrderState;
             public string OrderTime;
             public string PayTime;
             public string ShoppingTime;
             public string ShoppingNo;
             public string ShopperCode;
             public string RecevieName;
             public string ReceiveTel;
             public string ShoppingMoney; //配送费用
             public string CouponsMoney;  //优惠券抵用费用
             public string BalanceMoney;//使用余额
 }


    class dataBase
    {
        string ConnString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=dingdan;Data Source=(local)";
        //string ConnString = "server=211.149.174.106;database=Fruit4.5;uid=fruit;pwd=fruit!@#123;";
        //string ConnString = "Data Source= 211.149.174.106;Initial Catalog= Fruit4.5;User ID=fruit;Password=fruit!@#123";
        /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="id">用户输入的账号</param>
        /// <param name="ps">用户输入的密码</param>
        /// <returns></returns>
        public bool verifyPassWord(string id, string ps)
        {
            string inputPs,readPS;
            bool returnVal;
            string ConnQuery = "select " + "ManagePwd" + " from " + "yl_ManageAccount" + " where " + "ManageTel" + "='" + id + "'";
            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();
            SqlCommand lo_cmd = new SqlCommand(ConnQuery, connection);
            SqlDataReader reader = lo_cmd.ExecuteReader();
            reader.Read();
            if (!reader.HasRows) //读取的行数
            {
               returnVal=false;
            }
            else
            {
                readPS = reader[0].ToString();
                inputPs = GetMD5(ps);
                //string strMd5 = HashPasswordForStoringInConfigFile("123", "md5"); 
               

                if (readPS == inputPs)
                {
                    returnVal = true;

                }
                else 
                {
                    returnVal = false;
                }
                


            }

            reader.Close();
            connection.Close();
            connection.Dispose();
            return returnVal;
        
        
        
        }


        /// <summary>
        /// Md5
        /// </summary>
        /// <param name="input">输入字符</param>
        /// <returns></returns>
        public static string GetMD5(String input)
        {
            string cl = input;
            string pwd = "";
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.Unicode.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 

                pwd = pwd + s[i].ToString("x");

            }
            return pwd;
        }
        /// <summary>
        /// 读取订单信息
        /// </summary>
        /// <param name="StarTime">开始时间</param>
        /// <param name="EndTime">结束时间</param>
        /// <returns></returns>
        public List<info> readString(string StarTime,string EndTime)
        {

            
            List<info> cacheRead=new List<info>();
            info cacheItem=new info();
            //string ConnQuery = "declare @startime as datetime "+
            //                   "declare @endtime as datetime  set @startime='" + StarTime + "'set @endtime='" + EndTime + "'"+
            //                   "select OrderNo,PayTime,OrderMoney,RecevieName,ReceiveTel,OrderState,ShoppingState,PayState from yl_GoodsOrder where PayTime between @startime and @endtime and OrderState=1 and PayState=2 and (ShoppingState=0 or ShoppingState=1 or ShoppingState=2) or Convert(varchar(10),PayTime,120) = CONVERT(varchar(10),@startime,120) or Convert(varchar(10),PayTime,120) = CONVERT(varchar(10),@endtime,120)";
            string ConnQuery = "select OrderNo,PayTime,OrderMoney,RecevieName,ReceiveTel,OrderState,ShoppingState,PayState from yl_GoodsOrder where PayTime between'" +StarTime+"' and'" +EndTime +"'and OrderState=1 and PayState=2 and (ShoppingState=0 or ShoppingState=1 or ShoppingState=2)";
            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();
            SqlCommand lo_cmd = new SqlCommand(ConnQuery, connection);
            SqlDataReader reader = lo_cmd.ExecuteReader();
            
            if (!reader.HasRows) //读取的行数
            {
                cacheRead = null;
            }
            else
            {   int i=0;
                while (reader.Read())
                {
                    cacheItem.id = i;
                    cacheItem.OrderNo = reader["OrderNo"].ToString();
                    cacheItem.RecevieName = reader["RecevieName"].ToString();
                    cacheItem.ReceiveTel = reader["ReceiveTel"].ToString();
                    cacheItem.OrderMoney = Convert.ToDecimal(reader["OrderMoney"]);
                    cacheItem.PayTime = reader["PayTime"].ToString();
                    cacheItem.ShoppingState = Convert.ToByte(reader["ShoppingState"]);
                    cacheItem.PayState = Convert.ToByte(reader["PayState"]);
                    cacheItem.OrderState = Convert.ToByte(reader["OrderState"]);

                    cacheRead.Add(cacheItem);
                    i++;
                
                }

                



            }

            reader.Close();
            connection.Close();
            connection.Dispose();
            return cacheRead;
        
        }


        /// <summary>
        /// 检查是否有次配货员 有返回true 没有返回false
        /// </summary>
        /// <param name="id">配货员账号</param>
        /// <returns></returns>
        public bool checkId(string id)
        {
            
            bool returnVal;
            string ConnQuery = "select " + "*" + " from " + "yl_ManageAccount" + " where " + "ManageTel" + "='" + id + "'";
            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();
            SqlCommand lo_cmd = new SqlCommand(ConnQuery, connection);
            SqlDataReader reader = lo_cmd.ExecuteReader();
            reader.Read();
            if (!reader.HasRows) //读取的行数
            {
                returnVal = false;
            }
            else
            {
                returnVal = true;



            }

            reader.Close();
            connection.Close();
            connection.Dispose();
            return returnVal;
        
        
        }

        /// <summary>
        /// 写入备货员编码
        /// </summary>
        /// <param name="OrderId"> 订单编号</param>
        /// <param name="ShoppingTel">售货员编号</param>


        public int WriteShoppingId(string OrderId,string ShoppingTel)
        {
            int rows;
            string ConnQuery = "update yl_GoodsOrder set StockUperCode='" + ShoppingTel + "' where OrderNo='" + OrderId + "'";
            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();
            SqlCommand lo_cmd = new SqlCommand(ConnQuery, connection);
            rows= lo_cmd.ExecuteNonQuery();
           
            
            
            connection.Close();
            connection.Dispose();
            return rows;
        
        
        
        }
        /// <summary>
        /// 写入检验员编码
        /// </summary>
        /// <param name="OrderId">订单账号</param>
        /// <param name="ShoppingTel">检验员账号</param>
        /// <returns></returns>
        public int WriteCheckerCodeId(string OrderId, string ShoppingTel)
        {
            int rows;
            string ConnQuery = "update yl_GoodsOrder set CheckerCode='" + ShoppingTel + "' where OrderNo='" + OrderId + "'";
            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();
            SqlCommand lo_cmd = new SqlCommand(ConnQuery, connection);
            rows = lo_cmd.ExecuteNonQuery();



            connection.Close();
            connection.Dispose();
            return rows;



        }
        
        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="OrderId">订单号</param>
        /// <param name="ShoppingState"></param>
        /// <returns></returns>
        public bool WriteOrderState(string OrderId, byte ShoppingState)
        {
            bool returnVal;
            int rows;
            string ConnQuery = "update yl_GoodsOrder set ShoppingState='" + ShoppingState + "' where OrderNo='" + OrderId + "'";
            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();
            SqlCommand lo_cmd = new SqlCommand(ConnQuery, connection);
            rows = lo_cmd.ExecuteNonQuery();
            if (rows == 1)
            {
                returnVal = true;
            }
            else
            {
               returnVal=false;
            }



            connection.Close();
            connection.Dispose();
            return returnVal;
        
        
        }
        /// <summary>
        /// 查询日志信息
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <returns></returns>
        public Log_Order_info Log_Getinfo(string OrderNo)
        {
            Log_Order_info cache = new Log_Order_info();
            string ConnQuery = "select " + "OrderState,PayState,ShoppingState" + " from " + "yl_GoodsOrder" + " where " + "OrderNo" + "='" + OrderNo + "'";
            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();
            SqlCommand lo_cmd = new SqlCommand(ConnQuery, connection);
            SqlDataReader reader = lo_cmd.ExecuteReader();
            reader.Read();
            cache.OrderNo = OrderNo;
            cache.OrderState = Convert.ToByte(reader["OrderState"]);
            cache.PayState = Convert.ToByte(reader["PayState"]);
            cache.ShoppingState = Convert.ToByte(reader["ShoppingState"]);

            reader.Close();
            connection.Close();
            connection.Dispose();

            return cache;
           
        
        }

        /// <summary>
        /// 读取数据库数据
        /// </summary>
        /// <param name="classname">要读取得类名</param>
        /// <param name="indexclass">索引类名</param>
        /// <param name="indexcontent">索引内容</param>
        /// <param name="tablename">要读取得表名</param>
        /// <returns></returns>
        public string searchContent(string classname, string indexclass, string indexcontent, string tablename)
        {
            string consequence;
            string ConnQuery = "select " + classname + " from " + tablename + " where " + indexclass + "='" + indexcontent + "'";
            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();
            SqlCommand lo_cmd = new SqlCommand(ConnQuery, connection);
            SqlDataReader reader = lo_cmd.ExecuteReader();
            reader.Read();
            
            consequence = reader[0].ToString();
            if (consequence == null)
            {
                consequence = "-1";
            }
            reader.Close();
            connection.Close();
            connection.Dispose();

            return consequence;

           
          

        }
        /// <summary>
        /// 写入日日志
        /// </summary>
        /// <param name="cache"> 写入的日子表</param>
        public void Write_Log(Log_Order_info cache)
        {
            
            
            string ConnQuery = " insert into yl_GoodsOrderLog values('"+ cache.OrderNo+"',"+cache.OrderState+","+cache.PayState+","+cache.ShoppingState+",'"+cache.Remark+"',"+cache.UserCode+",'"+cache.Creater+"','"+cache.Pubtime+"')";
            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();
            SqlCommand lo_cmd = new SqlCommand(ConnQuery, connection);
            lo_cmd.ExecuteNonQuery();
            



            connection.Close();
            connection.Dispose();
            
           
        
        
        }
        /// <summary>
        /// 检查订单是否存在
        /// </summary>
        /// <param name="Orderno">订单号</param>
        /// <returns></returns>
        public bool checkOrder(string Orderno)
        {
            bool returnVal;
            
            string ConnQuery = "select * from yl_GoodsOrder where OrderNo ='"+Orderno+"' and ShoppingState =1";
            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();
            SqlCommand lo_cmd = new SqlCommand(ConnQuery, connection);
            SqlDataReader reader = lo_cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows != false)
            {
                returnVal = true;
            }
            else
            {
                returnVal = false;
            }



            connection.Close();
            connection.Dispose();
            return returnVal;


        }

        /// <summary>
        /// 读取订单对应商品信息
        /// </summary>
        /// <param name="Orderno"></param>
        /// <returns></returns>
        public List<commodity> ReadCommodity(string Orderno)
        {
            commodity cache = new commodity();
            List<commodity> cacheList = new List<commodity>();

            string ConnQuery = "select " + "*" + " from " + "yl_GoodsOrderInfo" + " where " + "OrderNo" + "='" + Orderno + "'";
            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();
            SqlCommand lo_cmd = new SqlCommand(ConnQuery, connection);
            SqlDataReader reader = lo_cmd.ExecuteReader();
            while (reader.Read())
            {
                cache.GoodsCode = reader["GoodsCode"].ToString();
                cache.GoodsName = reader["GoodsName"].ToString();
                cache.GoodsNum = Convert.ToInt32(reader["GoodsNum"].ToString());
                cache.SalePrice = reader["SalePrice"].ToString();
                cacheList.Add(cache);
                
            
            
            
            }
            
            

            reader.Close();
            connection.Close();
            connection.Dispose();

            return cacheList;

        
        
        
        
        
        }
        /// <summary>
        /// 检查是否有该订单
        /// </summary>
        /// <param name="OrderNo">订单号</param>
        /// <returns></returns>
        public bool existSearchOrder(string OrderNo)
        {

            bool returnVal;

            string ConnQuery = "select * from yl_GoodsOrder where OrderNo ='" + OrderNo+"'";
            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();
            SqlCommand lo_cmd = new SqlCommand(ConnQuery, connection);
            SqlDataReader reader = lo_cmd.ExecuteReader();
            reader.Read();
            if (!reader.HasRows)
            {
                returnVal = false;
            }
            else
            {
                returnVal = true;
            }



            connection.Close();
            connection.Dispose();
            return returnVal;
        
        
        
        }
        /// <summary>
        /// 返回订单信息
        /// </summary>
        /// <param name="OrderNo">订单号</param>
        /// <returns></returns>
        public info searchOrder(string OrderNo)
        {
            info returnVal;
            returnVal.id = 0;
            returnVal.OrderMoney = -1;
            returnVal.OrderNo = null;
            returnVal.OrderState = 1;
            returnVal.PayState = 1;
            returnVal.PayTime = null;
            returnVal.ReceiveTel = null;
            returnVal.RecevieName = null;
            returnVal.ShoppingState =1;

            string ConnQuery = "select * from yl_GoodsOrder where OrderNo ='" + OrderNo+"'";
            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();
            SqlCommand lo_cmd = new SqlCommand(ConnQuery, connection);
            SqlDataReader reader = lo_cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                returnVal.id = 0;
                returnVal.OrderMoney = Convert.ToDecimal(reader["OrderMoney"].ToString());
                returnVal.OrderNo = reader["OrderNo"].ToString();
                returnVal.OrderState = Convert.ToByte(reader["OrderState"].ToString());
                returnVal.PayState = Convert.ToByte(reader["PayState"].ToString());
                returnVal.PayTime = reader["PayTime"].ToString();
                returnVal.ReceiveTel = reader["ReceiveTel"].ToString();
                returnVal.RecevieName = reader["RecevieName"].ToString();
                returnVal.ShoppingState = Convert.ToByte(reader["ShoppingState"].ToString());
                
            }



            connection.Close();
            connection.Dispose();
            return returnVal;
        
        
        
        
        }


        /// <summary>
        /// 返回订单详情
        /// </summary>
        /// <param name="OrderNo">订单号</param>
        /// <returns></returns>
        public OrderInfo OrderInfo(string OrderNo)
        {
            OrderInfo returnVal;

            returnVal.OrderNo = null;
            returnVal.UserTel = null;
            returnVal.PayType = null;
            returnVal.PickPointName = null;
            returnVal.StockUperCode = null;
            returnVal.CheckerCode = null;
            returnVal.OrderState = null;
            returnVal.OrderTime = null;
            returnVal.PayTime = null;
            returnVal.ShoppingTime = null;
            returnVal.ShoppingNo = null;
            returnVal.ShopperCode = null;
            returnVal.RecevieName = null;
            returnVal.ReceiveTel = null;
            returnVal.ShoppingMoney = null; //配送费用
            returnVal.CouponsMoney = null;  //优惠券抵用费用
            returnVal.BalanceMoney = null;//使用余额

            string ConnQuery = "select * from yl_GoodsOrder where OrderNo ='" + OrderNo + "'";
            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();
            SqlCommand lo_cmd = new SqlCommand(ConnQuery, connection);
            SqlDataReader reader = lo_cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                returnVal.OrderNo = reader["OrderNo"].ToString();
                returnVal.UserTel = reader["UserTel"].ToString();
                returnVal.PayType = reader["PayType"].ToString();
                returnVal.PickPointName = reader["PickPointName"].ToString();
                returnVal.StockUperCode = reader["StockUperCode"].ToString();
                returnVal.CheckerCode = reader["CheckerCode"].ToString();
                returnVal.OrderState = reader["OrderState"].ToString();
                returnVal.OrderTime = reader["OrderTime"].ToString();
                returnVal.PayTime = reader["PayTime"].ToString();
                returnVal.ShoppingTime = reader["ShoppingTime"].ToString();
                returnVal.ShoppingNo = reader["ShoppingNo"].ToString();
                returnVal.ShopperCode = reader["ShopperCode"].ToString();
                returnVal.RecevieName = reader["RecevieName"].ToString();
                returnVal.ReceiveTel = reader["ReceiveTel"].ToString();
                returnVal.ShoppingMoney = reader["ShoppingMoney"].ToString(); //配送费用
                returnVal.CouponsMoney = reader["CouponsMoney"].ToString();  //优惠券抵用费用
                returnVal.BalanceMoney = reader["BalanceMoney"].ToString();//使用余额

            }



            connection.Close();
            connection.Dispose();
            return returnVal;
        
        
        
        
        
        
        }

        /// <summary>
        /// 检查配货员是否有订单配货中 有返回true 没有返回false 
        /// </summary>
        /// <param name="StokUperCode">配货员账号</param>
        /// <returns></returns>
        public bool checkedStokUperCodeOrder(string StokUperCode)
        {
                
        
            bool returnVal;
            
            string ConnQuery = "select * from yl_GoodsOrder where StockUperCode ='"+StokUperCode+"' and ShoppingState =1";
            SqlConnection connection = new SqlConnection(ConnString);
            connection.Open();
            SqlCommand lo_cmd = new SqlCommand(ConnQuery, connection);
            SqlDataReader reader = lo_cmd.ExecuteReader();
            reader.Read();
            if (!reader.HasRows)
            {
                returnVal = false;
            }
            else
            {
                returnVal = true;
            }



            connection.Close();
            connection.Dispose();
            return returnVal;
        
        }

    }
}
