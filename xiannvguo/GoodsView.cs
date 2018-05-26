using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
namespace xiannvguo
{
    public struct Time  //设置时间
    {
       public string starTime;  //开始时间
       public string endTime;   //结束时间
    
    } 
    
    public partial class GoodsView : Form
    {
        public Time newTime = new Time();
        int KindView = 0;//货物列表窗口 0全部 1未提取 2备货中 3发货中
        string ShoppingId = null; //配货员账号
        string adminId;






        public GoodsView(string adminid)

        {   
             InitializeComponent();
             adminId = adminid;

            if (newTime.starTime !=null && newTime.endTime !=null)
            {
                Allshowinfo();

            }

            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.MouseMove += panel1_MouseMove;
            panel1.MouseDown += panel1_MouseDown;
        }
        private Point _mousePoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Top = MousePosition.Y - _mousePoint.Y;
                Left = MousePosition.X - _mousePoint.X;
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mousePoint.X = e.X;
                _mousePoint.Y = e.Y;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Behavior")
            {
                OrdersInfo newinfo = new OrdersInfo(dataGridView1.Rows[e.RowIndex].Cells["OrderNo"].Value.ToString());
                newinfo.ShowDialog();
            }
        }

        private void GoodsView_Load(object sender, EventArgs e)
        {
            
        }

        private void 时间ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            setTime newsetTime = new setTime();
            newsetTime.ShowDialog();
            if (newsetTime.DialogResult == DialogResult.OK)
            {
                newTime.starTime = newsetTime.starTime.ToString();
                newTime.endTime = newsetTime.endTime.ToString();
                Allshowinfo();
            }

            

        }
        /// <summary>
        /// 订单全部显示
        /// </summary>
        public void Allshowinfo()
        {
            if (newTime.starTime != null && newTime.endTime != null)
            {
                dataGridView1.Rows.Clear();
                dataBase read = new dataBase();
                List<info> readContent = new List<info>();
                String ResultStr = string.Empty;
                readContent = read.readString(newTime.starTime.ToString(), newTime.endTime.ToString());




                for (int i = 0; i < readContent.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["Id"].Value = i;
                    dataGridView1.Rows[i].Cells["OrderNo"].Value = readContent[i].OrderNo;
                    dataGridView1.Rows[i].Cells["PayTime"].Value = readContent[i].PayTime;
                    dataGridView1.Rows[i].Cells["RecevieName"].Value = readContent[i].RecevieName;
                    dataGridView1.Rows[i].Cells["ReceiveTel"].Value = readContent[i].ReceiveTel;
                    dataGridView1.Rows[i].Cells["OrderMoney"].Value = readContent[i].OrderMoney;
                    dataGridView1.Rows[i].Cells["OrderMoney"].Value = readContent[i].OrderMoney;
                    dataGridView1.Rows[i].Cells["Behavior"].Value = "详情";

                    

                    switch (readContent[i].OrderState)
                    {

                        case 0: ResultStr = "待确认"; break;
                        case 1: ResultStr = "已确认"; break;
                        case 2: ResultStr = "已取消"; break;
                        case 4: ResultStr = "无效"; break;
                        default: break;


                    }

                    switch (readContent[i].PayState)
                    {
                        case 0: ResultStr += "未支付"; break;
                        case 2: ResultStr += "已支付"; break;
                        default: break;

                    }
                    switch (readContent[i].ShoppingState)
                    {
                        case 0: ResultStr += "未发货"; break;
                        case 1: ResultStr += "备货中"; break;
                        case 2: ResultStr += "发货中"; break;
                        case 3: ResultStr += "已发货"; break;
                        case 4: ResultStr += "确认收货"; break;
                        default: break;

                    }

                    dataGridView1.Rows[i].Cells["OrderState"].Value = ResultStr;





                }
                KindView = 0; //修改货物窗口种类
            }
        
        
        }
        /// <summary>
        /// 显示未发货订单
        /// </summary>
        public void weifahuoShow()
        {
            if (newTime.starTime != null && newTime.endTime != null)
            {
                dataGridView1.Rows.Clear();
                dataBase read = new dataBase();
                List<info> readContent = new List<info>();
                String ResultStr = string.Empty;
                readContent = read.readString(newTime.starTime.ToString(), newTime.endTime.ToString());

                int count = 0;


                for (int i = 0; i < readContent.Count; i++)
                {
                    if (readContent[i].ShoppingState == 0)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[count].Cells["Id"].Value = count;
                        
                        dataGridView1.Rows[count].Cells["OrderNo"].Value = readContent[i].OrderNo;
                        dataGridView1.Rows[count].Cells["PayTime"].Value = readContent[i].PayTime;
                        dataGridView1.Rows[count].Cells["RecevieName"].Value = readContent[i].RecevieName;
                        dataGridView1.Rows[count].Cells["ReceiveTel"].Value = readContent[i].ReceiveTel;
                        dataGridView1.Rows[count].Cells["OrderMoney"].Value = readContent[i].OrderMoney;
                        dataGridView1.Rows[count].Cells["Behavior"].Value = "详情";
                        
                        
                        


                        dataGridView1.Rows[count].Cells["OrderState"].Value = "未发货";
                        count++;
                    }




                }

                KindView = 1;

            }
        
        
        
        
        }
        /// <summary>
        /// 显示备货中订单
        /// </summary>
        public void beihuozhongShow()
        {
            if (newTime.starTime != null && newTime.endTime != null)
            { 
            dataGridView1.Rows.Clear();
            dataBase read = new dataBase();
            List<info> readContent = new List<info>();
            String ResultStr = string.Empty;
            readContent = read.readString(newTime.starTime.ToString(), newTime.endTime.ToString());

            int count = 0;


            for (int i = 0; i < readContent.Count; i++)
            {
                if (readContent[i].ShoppingState == 1)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[count].Cells["Id"].Value = count;
                   
                    dataGridView1.Rows[count].Cells["OrderNo"].Value = readContent[i].OrderNo;
                    dataGridView1.Rows[count].Cells["PayTime"].Value = readContent[i].PayTime;
                    dataGridView1.Rows[count].Cells["RecevieName"].Value = readContent[i].RecevieName;
                    dataGridView1.Rows[count].Cells["ReceiveTel"].Value = readContent[i].ReceiveTel;
                    dataGridView1.Rows[count].Cells["OrderMoney"].Value = readContent[i].OrderMoney;
                    dataGridView1.Rows[count].Cells["Behavior"].Value = "详情";


                    dataGridView1.Rows[count].Cells["OrderState"].Value = "备货中";
                    count++;
                }



            }
            KindView = 2;


            }
        
        }
        /// <summary>
        /// 显示发货中订单
        /// </summary>
        public void fahuozhongShow()
        {
            if (newTime.starTime != null && newTime.endTime != null)
            {
                dataGridView1.Rows.Clear();
                dataBase read = new dataBase();
                List<info> readContent = new List<info>();
                String ResultStr = string.Empty;
                readContent = read.readString(newTime.starTime.ToString(), newTime.endTime.ToString());

                int count = 0;


                for (int i = 0; i < readContent.Count; i++)
                {
                    if (readContent[i].ShoppingState == 2)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[count].Cells["Id"].Value = count;
                        
                        dataGridView1.Rows[count].Cells["OrderNo"].Value = readContent[i].OrderNo;
                        dataGridView1.Rows[count].Cells["PayTime"].Value = readContent[i].PayTime;
                        dataGridView1.Rows[count].Cells["RecevieName"].Value = readContent[i].RecevieName;
                        dataGridView1.Rows[count].Cells["ReceiveTel"].Value = readContent[i].ReceiveTel;
                        dataGridView1.Rows[count].Cells["OrderMoney"].Value = readContent[i].OrderMoney;

                        dataGridView1.Rows[count].Cells["Behavior"].Value = "详情";

                        dataGridView1.Rows[count].Cells["OrderState"].Value = "发货中";
                        count++;

                    }




                }

                KindView = 3;


            }

        }


        /// <summary>
        /// 搜索订单
        /// </summary>
        /// <param name="OrderNo">订单号</param>
        private void searchOrder(string OrderNo)
        {
            if (newTime.starTime != null && newTime.endTime != null)
            {
                dataGridView1.Rows.Clear();
                dataBase read = new dataBase();

                //bool returnBool;
                //returnBool = read.checkOrder(stockOrOrder.Text.ToString());

               
                if (!read.existSearchOrder(stockOrOrder.Text.ToString()))
                {
                    MessageBox.Show("没有相应订单");
                    return;

                }




                info searchContent = read.searchOrder(stockOrOrder.Text.ToString());


                dataGridView1.Rows.Add();
                dataGridView1.Rows[0].Cells["Id"].Value = 0;

                dataGridView1.Rows[0].Cells["OrderNo"].Value = searchContent.OrderNo;
                dataGridView1.Rows[0].Cells["PayTime"].Value = searchContent.PayTime;
                dataGridView1.Rows[0].Cells["RecevieName"].Value = searchContent.RecevieName;
                dataGridView1.Rows[0].Cells["ReceiveTel"].Value = searchContent.ReceiveTel;
                dataGridView1.Rows[0].Cells["OrderMoney"].Value = searchContent.OrderMoney;

                dataGridView1.Rows[0].Cells["Behavior"].Value = "详情";


                string ResultStr = string.Empty;
                switch (searchContent.OrderState)
                {

                    case 0: ResultStr = "待确认"; break;
                    case 1: ResultStr = "已确认"; break;
                    case 2: ResultStr = "已取消"; break;
                    case 4: ResultStr = "无效"; break;
                    default: break;


                }

                switch (searchContent.PayState)
                {
                    case 0: ResultStr += "未支付"; break;
                    case 2: ResultStr += "已支付"; break;
                    default: break;

                }
                switch (searchContent.ShoppingState)
                {
                    case 0: ResultStr += "未发货"; break;
                    case 1: ResultStr += "备货中"; break;
                    case 2: ResultStr += "发货中"; break;
                    case 3: ResultStr += "已发货"; break;
                    case 4: ResultStr += "确认收货"; break;
                    default: break;

                }

                dataGridView1.Rows[0].Cells["OrderState"].Value = ResultStr;









            }

            KindView = 0;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            KindView = 0;
            Allshowinfo();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KindView = 1;
            weifahuoShow();
            
           
            
            
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            KindView = 2;
            beihuozhongShow();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KindView = 3;
            fahuozhongShow();
        }

        private void 备货检验ToolStripMenuItem_Click(object sender, EventArgs e)
        {   //修改未发货的订单-备货
            if (KindView == 1 && dataGridView1.Rows[0].Cells["OrderNo"].Value!=null)
            {
                altercheck newCheck = new altercheck(KindView, dataGridView1.Rows[0].Cells["OrderNo"].Value.ToString(),adminId);
                
                newCheck.ShowDialog();
                if (newCheck.DialogResult == DialogResult.OK)
                {
                    weifahuoShow();
                }



                
                    
            }
            if (KindView == 2 && dataGridView1.Rows[0].Cells["OrderNo"].Value != null)
            {
                altercheck newCheck = new altercheck(KindView, dataGridView1.Rows[0].Cells["OrderNo"].Value.ToString(), adminId);
                
                newCheck.ShowDialog();
                if (newCheck.DialogResult == DialogResult.OK)
                {
                    beihuozhongShow();
                }
            }
        }


    

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (KindView == 1)
            {
                if ( KindView == 1) //写入配货员编码
                {

                    dataBase sqlConn = new dataBase();

                   
                    
                        #region
                        if (sqlConn.checkId(stockOrOrder.Text.ToString())) //检查是否有配货员id
                        {

                            if (sqlConn.checkedStokUperCodeOrder(stockOrOrder.Text.ToString()))
                            {
                                
                                MessageBox.Show("此售货员正在备货");
                                return;
                            
                            
                            }
                            //变更状态
                            if (sqlConn.WriteOrderState(dataGridView1.Rows[0].Cells["OrderNo"].Value.ToString(), 1) && sqlConn.WriteShoppingId(dataGridView1.Rows[0].Cells["OrderNo"].Value.ToString(), stockOrOrder.Text.ToString()) == 1)
                            {
                                moban newmoban=new moban();
                                printShow(dataGridView1.Rows[0].Cells["OrderNo"].Value.ToString(), 0,newmoban);//打印
                                
                                //写入日志
                                Log_Order_info newLog = new Log_Order_info();
                                newLog = sqlConn.Log_Getinfo(dataGridView1.Rows[0].Cells["OrderNo"].Value.ToString());
                                newLog.Remark = "订单管理工具";
                                newLog.Creater = sqlConn.searchContent("ManageName", "ManageTel", stockOrOrder.Text.ToString(), "yl_ManageAccount");
                                newLog.UserCode = Convert.ToInt32(sqlConn.searchContent("UserCode", "ManageTel", stockOrOrder.Text.ToString(), "yl_ManageAccount"));
                                newLog.Pubtime = DateTime.Now.ToString();

                                sqlConn.Write_Log(newLog);


                                stockOrOrder.Text="订单"+dataGridView1.Rows[0].Cells["OrderNo"].Value.ToString()+"已由备货员"+stockOrOrder.Text.ToString()+"开始备货";

                                weifahuoShow();

                               
                                





                            }
                            else
                            {
                                stockOrOrder.Text="订单"+dataGridView1.Rows[0].Cells["OrderNo"].Value.ToString()+"备货失败";
                               
                            }
                            




                        }
                        else
                        {
                            stockOrOrder.Text="没有该配货员";

                        }


                        #endregion

                        return;

                 }

                  




             }
           

            


            if (KindView == 2)
            {
                if ( KindView == 2) //写入配货员编码
                {

                    dataBase sqlConn = new dataBase();

                   
                    
                        #region
                        if (sqlConn.checkOrder(stockOrOrder.Text.ToString())) //检查是否有此订单
                        {
                            //变更状态
                            if (sqlConn.WriteOrderState(stockOrOrder.Text.ToString(), 2) && sqlConn.WriteCheckerCodeId(stockOrOrder.Text.ToString(), adminId) == 1)
                            {

                                //printShow(stockOrOrder.Text.ToString());//打印
                                //写入日志
                                Log_Order_info newLog = new Log_Order_info();
                                newLog = sqlConn.Log_Getinfo(stockOrOrder.Text.ToString());
                                newLog.Remark = "订单管理工具";
                                newLog.Creater = sqlConn.searchContent("ManageName", "ManageTel", adminId, "yl_ManageAccount");
                                newLog.UserCode = Convert.ToInt32(sqlConn.searchContent("UserCode", "ManageTel", adminId, "yl_ManageAccount"));
                                newLog.Pubtime = DateTime.Now.ToString();

                                sqlConn.Write_Log(newLog);




                                stockOrOrder.Text = "订单" + stockOrOrder.Text.ToString() + "检验成功";
                                beihuozhongShow();


                             





                            }
                            else
                            {
                                stockOrOrder.Text = "检验失败";
                            }





                        }
                        else
                        {
                            stockOrOrder.Text = "没有该订单";

                        }
                        #endregion
                        return;
                    }


                    
            }

            if (KindView == 0)
            {


                searchOrder(stockOrOrder.Text.ToString());
                stockOrOrder.Focus();
                return;
                
                
                
                
                 
            
            
            }

            
           




            }

        private void printShow(string cache, int count, moban newmoban)
        {


            OrdersInfo newinfo = new OrdersInfo(cache);
            newmoban = new moban();
            
            //moban newmoban = new moban();

            //收货人姓名
            TextObject RecevieName = (TextObject)newmoban.ReportDefinition.ReportObjects["RecevieName"];
            RecevieName.Text = newinfo.RecevieName.Text.ToString();

            //收货人电话
            TextObject ReceiveTel = (TextObject)newmoban.ReportDefinition.ReportObjects["ReceiveTel"];
            ReceiveTel.Text = newinfo.ReceiveTel.Text.ToString();

            //提货点名称
            TextObject PickPointName = (TextObject)newmoban.ReportDefinition.ReportObjects["PickPointName"];
            PickPointName.Text = newinfo.PickPointName.Text.ToString();


            //订单号

            TextObject OrderNo = (TextObject)newmoban.ReportDefinition.ReportObjects["OrderNo"];
            OrderNo.Text = "*" + newinfo.OrderNo.Text.ToString() + "*";

            //订单详情
            TextObject commidityInfo = (TextObject)newmoban.ReportDefinition.ReportObjects["commidityInfo"];
            for (; count < newinfo.dataGridView1.RowCount - 1; count++)
            {
                if ((count + 1) % 10 == 0)
                {
                    //newmoban.Dispose();
                    printShow(cache, count + 1, newmoban);
                    commidityInfo.Text += (count + 1).ToString() + "," + newinfo.dataGridView1.Rows[count].Cells["GoodsName"].Value.ToString() + "\n"
                        + "数量：" + newinfo.dataGridView1.Rows[count].Cells["GoodsNum"].Value.ToString() + "份" + "       " + "￥：" + newinfo.dataGridView1.Rows[count].Cells["Subtotal"].Value.ToString() + "\n";
                    break;

                }
                else 

                {
                    commidityInfo.Text += (count + 1).ToString() + "," + newinfo.dataGridView1.Rows[count].Cells["GoodsName"].Value.ToString() + "\n"
                        + "数量：" + newinfo.dataGridView1.Rows[count].Cells["GoodsNum"].Value.ToString() + "份" + "       " + "￥：" + newinfo.dataGridView1.Rows[count].Cells["Subtotal"].Value.ToString() + "\n";
                }


            }

            //小计

            TextObject subtotal = (TextObject)newmoban.ReportDefinition.ReportObjects["subtotal"];
            subtotal.Text = "商品总价￥:" + newinfo.TotalMoney.Text.ToString() + "\n"
                            + "-优惠抵扣￥：" + newinfo.CouponsMoney.Text.ToString() + "\n"
                            + "-余额支付￥：" + newinfo.BanlanceMoney.Text.ToString() + "\n"
                            + "=实际支付￥：" + newinfo.PayMoney.Text.ToString() + "\n";


            //下单时间

            TextObject PayTime = (TextObject)newmoban.ReportDefinition.ReportObjects["PayTime"];
            PayTime.Text = newinfo.OrderTime.Text.ToString();

            //表尾
            //收货人姓名2
            TextObject RecevieName2 = (TextObject)newmoban.ReportDefinition.ReportObjects["RecevieName2"];
            RecevieName2.Text = newinfo.RecevieName.Text.ToString();

            //收货人电话2
            TextObject ReceiveTel2 = (TextObject)newmoban.ReportDefinition.ReportObjects["ReceiveTel2"];
            ReceiveTel2.Text = newinfo.ReceiveTel.Text.ToString();

            //提货点名称2
            TextObject PickPointName2 = (TextObject)newmoban.ReportDefinition.ReportObjects["PickPointName2"];
            PickPointName2.Text = newinfo.PickPointName.Text.ToString();

            TextObject OrderNo2 = (TextObject)newmoban.ReportDefinition.ReportObjects["OrderNo2"];
            OrderNo2.Text = "*" + newinfo.OrderNo.Text.ToString() + "*";

            //表尾数字订单号
            TextObject OrderNo3 = (TextObject)newmoban.ReportDefinition.ReportObjects["Text1"];
            //OrderNo3.Text = newinfo.OrderNo.Text.ToString();
            OrderNo3.Text = newinfo.OrderNo.Text.ToString();




            //crystalReportViewer1.ReportSource = newinfo;

            //crystalReportViewer1.Show();
            //newinfo.PrintOptions.PrinterName=

            //newmoban.PrintOptions.PrinterName = DefaultPrinter;   // 设置打印机名称



            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
            //List<string> Printer = new List<string>();



            //foreach (string fPrinterName in LocalPrinter.GetLocalPrinters())
            //{

            //    Printer.Add(fPrinterName);



            //}
            ////doc.PrinterSettings.PrinterName = DefaultPrinter;
            //doc.PrinterSettings.PrinterName = Printer[0].ToString();

            //LocalPrinter print=new LocalPrinter();
            //newmoban.PrintOptions.PrinterName=print.DefaultPrinter  ;
            int rawKind = 1;
            for (int i = 0; i <= doc.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                if (doc.PrinterSettings.PaperSizes[i].PaperName == "xiannvguo")
                {
                    rawKind = doc.PrinterSettings.PaperSizes[i].RawKind;
                }
            }


            newmoban.PrintOptions.PrinterName = doc.PrinterSettings.PrinterName;

            newmoban.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;    // 设置打印纸张样式
            newmoban.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation;//默认纸张方向
            newmoban.PrintToPrinter(1, false, 1, 1);
            return;




        }



     


        }
    }

