using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace xiannvguo
{
    public partial class OrdersInfo : Form
    {
        public string IndexOrderNo
        {
            get;
            set;
        }
 //        public struct OrderInfo    //订单详情
 //       {
 //            public string OrderNo;
 //            public string UserTel;
 //            public string PayType;
 //            public string PickPointName;
 //            public string StockUperCode;
 //            public string CheckerCode;
 //            public string OrderState;
 //            public string OrderTime;
 //            public string PayTime;
 //            public string ShoppingTime;
 //            public string ShoppingNo;
 //            public string ShopperCode;
 //            public string RecevieName;
 //            public string ReceiveTel;
 //            public string ShoppingMoney; //配送费用
 //            public string CouponsMoney;  //优惠券抵用费用
 //            public string BalanceMoney;//使用余额
 //}

        public OrdersInfo(string cache)
        {
            InitializeComponent();
            IndexOrderNo = cache;
            dataBase SqlConn = new dataBase();

            OrderInfo newinfo = SqlConn.OrderInfo(IndexOrderNo);


            
            newinfo.OrderNo = IndexOrderNo;
            
           

            //窗体赋值
            OrderNo.Text = newinfo.OrderNo;
            UserTel.Text = newinfo.UserTel;
            switch (newinfo.PayType)
            {
                case "1": PayType.Text = "余额"; break;
                case "2": PayType.Text = "支付宝"; break;
                default: PayType.Text = "错误"; break;
            
            }
            PickPointName.Text = newinfo.PickPointName;
            StockUperCode.Text = newinfo.StockUperCode;
            switch (newinfo.OrderState)
            {
                case "0": OrderState.Text = "待确认"; break;
                case "1": OrderState.Text = "已确认"; break;
                case "2": OrderState.Text = "已取消"; break;
                case "4": OrderState.Text = "无效"; break;
                default: break;
            
            
            }
             OrderTime.Text=newinfo.OrderTime;
             PayTime.Text=newinfo.PayTime;
             ShoppingTime.Text=newinfo.ShoppingTime;
             ShoppingNo.Text=newinfo.ShoppingNo;
              ShopperCode.Text=newinfo.ShopperCode;
              RecevieName.Text=newinfo.RecevieName;
              ReceiveTel.Text=newinfo.ReceiveTel;
              CheckerCode.Text = newinfo.CheckerCode;

              List<commodity> newCommodityInfo = new List<commodity>();
              newCommodityInfo = SqlConn.ReadCommodity(IndexOrderNo);

              decimal subtotal=0;

              for (int i = 0; i < newCommodityInfo.Count; i++)
              {
                  dataGridView1.Rows.Add();
                  dataGridView1.Rows[i].Cells["GoodsName"].Value = newCommodityInfo[i].GoodsName;
                  dataGridView1.Rows[i].Cells["GoodsCode"].Value = newCommodityInfo[i].GoodsCode;
                  dataGridView1.Rows[i].Cells["GoodsNum"].Value = newCommodityInfo[i].GoodsNum;
                  dataGridView1.Rows[i].Cells["SalePrice"].Value = newCommodityInfo[i].SalePrice;
                  subtotal += Convert.ToDecimal(newCommodityInfo[i].SalePrice) * Convert.ToDecimal(newCommodityInfo[i].SalePrice);
                  dataGridView1.Rows[i].Cells["Subtotal"].Value = Convert.ToDecimal(newCommodityInfo[i].SalePrice) * Convert.ToDecimal(newCommodityInfo[i].SalePrice);
              
              }
              total.Text = subtotal.ToString();
              SubMoney.Text = subtotal.ToString();
              ShoppingMoney.Text = newinfo.ShoppingMoney.ToString();
              TotalMoney.Text = (subtotal + Convert.ToDecimal(newinfo.ShoppingMoney)).ToString();
              BanlanceMoney.Text = newinfo.BalanceMoney.ToString();
              CouponsMoney.Text = newinfo.CouponsMoney.ToString();
              PayMoney.Text = (Convert.ToDecimal(TotalMoney.Text.ToString()) - Convert.ToDecimal(BanlanceMoney.Text.ToString()) - Convert.ToDecimal(CouponsMoney.Text.ToString())).ToString();









        }

        private void OrdersInfo_Load(object sender, EventArgs e)
        {

            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
