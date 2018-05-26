using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace xiannvguo
{
    public partial class altercheck : Form
    {
        int KindView;//货物窗口类型
        string AlterOrderID;//要处理的订单号
        string adminId;//管理员id
        public altercheck(int Kindflag,string Orderflag,string adminid)
        {
            InitializeComponent();
            KindView = Kindflag;
            AlterOrderID = Orderflag;
            adminId = adminid;
            if(KindView==1)
            {
                stockOrOrder.Text = "请输入备货员账号";
            }
            if (KindView == 2)
            {
                stockOrOrder.Text = "请输入订单编号";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (KindView == 1)
            {
                if (stockOrOrder.Text != "" && KindView == 1) //写入配货员编码
                {

                    dataBase sqlConn = new dataBase();

                    if (selfMotion.Checked == true)   //自动？
                    {
                        #region
                        if (sqlConn.checkId(stockOrOrder.Text.ToString())) //检查是否有配货员id
                        {
                            //变更状态
                            if (sqlConn.WriteOrderState(AlterOrderID, 1) && sqlConn.WriteShoppingId(AlterOrderID, stockOrOrder.Text.ToString()) == 1)
                            {
                                //写入日志
                                Log_Order_info newLog = new Log_Order_info();
                                newLog = sqlConn.Log_Getinfo(AlterOrderID);
                                newLog.Remark = "订单管理工具";
                                newLog.Creater = sqlConn.searchContent("ManageName", "ManageTel", stockOrOrder.Text.ToString(), "yl_ManageAccount");
                                newLog.UserCode =Convert.ToInt32(sqlConn.searchContent("UserCode", "ManageTel", stockOrOrder.Text.ToString(), "yl_ManageAccount"));
                                newLog.Pubtime = DateTime.Now.ToString();

                                sqlConn.Write_Log(newLog);


                        

                                MessageBox.Show("变更成功");


                                this.DialogResult = DialogResult.OK;





                            }
                            else
                            {
                                MessageBox.Show("变更失败");
                            }





                        }
                        else
                        {
                            MessageBox.Show("没有该配货员");

                        }
                        #endregion
                    }

                    else if (selfMotion.Checked == false)
                    {
                        DialogResult dr = MessageBox.Show("确认您输入的配货员账号？", "提示", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.OK)
                        {
                            #region
                            if (sqlConn.checkId(stockOrOrder.Text.ToString())) //检查是否有配货员id
                            {
                                //变更状态
                                if (sqlConn.WriteOrderState(AlterOrderID, 1) && sqlConn.WriteShoppingId(AlterOrderID, stockOrOrder.Text.ToString()) == 1)
                                {
                                    //写入日志
                                    Log_Order_info newLog = new Log_Order_info();
                                    newLog = sqlConn.Log_Getinfo(AlterOrderID);
                                    newLog.Remark = "订单管理工具";
                                    newLog.Creater = sqlConn.searchContent("ManageName", "ManageTel", stockOrOrder.Text.ToString(), "yl_ManageAccount");
                                    newLog.UserCode = Convert.ToInt32(sqlConn.searchContent("UserCode", "ManageTel", stockOrOrder.Text.ToString(), "yl_ManageAccount"));
                                    newLog.Pubtime = DateTime.Now.ToString();

                                    sqlConn.Write_Log(newLog);




                                    MessageBox.Show("变更成功");


                                    this.DialogResult = DialogResult.OK;





                                }
                                else
                                {
                                    MessageBox.Show("变更失败");
                                }





                            }
                            else
                            {
                                MessageBox.Show("没有该配货员");

                            }
                            #endregion
                        }


                    }





                }
                else
                {
                    stockOrOrder.Text = "请输入配货员编码";
                }

            }


            if (KindView == 2)
            {
                if (stockOrOrder.Text != "" && KindView == 2) //写入配货员编码
                {

                    dataBase sqlConn = new dataBase();

                    if (selfMotion.Checked == true)   //自动？
                    {
                        #region
                        if (sqlConn.checkOrder(stockOrOrder.Text.ToString())) //检查是否有此订单
                        {
                            //变更状态
                            if (sqlConn.WriteOrderState(stockOrOrder.Text.ToString(), 2) && sqlConn.WriteCheckerCodeId(stockOrOrder.Text.ToString(), adminId)==1)
                            {

                                printShow(stockOrOrder.Text.ToString());//打印
                                //写入日志
                                Log_Order_info newLog = new Log_Order_info();
                                newLog = sqlConn.Log_Getinfo(stockOrOrder.Text.ToString());
                                newLog.Remark = "订单管理工具";
                                newLog.Creater = sqlConn.searchContent("ManageName", "ManageTel", adminId, "yl_ManageAccount");
                                newLog.UserCode = Convert.ToInt32(sqlConn.searchContent("UserCode", "ManageTel", adminId, "yl_ManageAccount"));
                                newLog.Pubtime = DateTime.Now.ToString();

                                sqlConn.Write_Log(newLog);




                                MessageBox.Show("检验成功");


                                this.DialogResult = DialogResult.OK;





                            }
                            else
                            {
                                MessageBox.Show("检验失败");
                            }





                        }
                        else
                        {
                            MessageBox.Show("没有该订单");

                        }
                        #endregion
                    }

                    else if (selfMotion.Checked == false)
                    {
                        DialogResult dr = MessageBox.Show("确认您输入的订单账号？", "提示", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.OK)
                        {
                            #region
                            if (sqlConn.checkOrder(stockOrOrder.Text.ToString())) //检查是否有此订单
                            {
                                //变更状态
                                if (sqlConn.WriteOrderState(stockOrOrder.Text.ToString(), 2)&&sqlConn.WriteCheckerCodeId(stockOrOrder.Text.ToString(), adminId)==1)
                                {


                                    printShow(stockOrOrder.Text.ToString());//打印
                                    //写入日志
                                    Log_Order_info newLog = new Log_Order_info();
                                    newLog = sqlConn.Log_Getinfo(stockOrOrder.Text.ToString());
                                    newLog.Remark = "订单管理工具";
                                    newLog.Creater = sqlConn.searchContent("ManageName", "ManageTel", adminId, "yl_ManageAccount");
                                    newLog.UserCode = Convert.ToInt32(sqlConn.searchContent("UserCode", "ManageTel", adminId, "yl_ManageAccount"));
                                    newLog.Pubtime = DateTime.Now.ToString();

                                    sqlConn.Write_Log(newLog);




                                    MessageBox.Show("检验成功");


                                    this.DialogResult = DialogResult.OK;





                                }
                                else
                                {
                                    MessageBox.Show("检验失败");
                                }





                            }
                            else
                            {
                                MessageBox.Show("没有该订单");

                            }
                            #endregion
                        }


                    }





                }
                else
                {
                    stockOrOrder.Text = "请输入订单编号";
                }

            
            
            
            }

        }

        private void altercheck_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="cache">订单号</param>
        private void printShow(string cache)
        {
            OrdersInfo newinfo = new OrdersInfo(cache);
            moban newmoban = new moban();

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
            OrderNo.Text ="*"+ newinfo.OrderNo.Text.ToString()+"*";

            //订单详情
            TextObject commidityInfo = (TextObject)newmoban.ReportDefinition.ReportObjects["commidityInfo"];
            for (int count = 0; count < newinfo.dataGridView1.RowCount-1; count++)
            {
                
                commidityInfo.Text += (count + 1).ToString() + "," + newinfo.dataGridView1.Rows[count].Cells["GoodsName"].Value.ToString() + "\n"
                    + "数量：" + newinfo.dataGridView1.Rows[count].Cells["GoodsNum"].Value.ToString() + "份" + "       " + "￥：" + newinfo.dataGridView1.Rows[count].Cells["Subtotal"].Value.ToString() + "\n";


            
            }

            //小计

            TextObject subtotal = (TextObject)newmoban.ReportDefinition.ReportObjects["subtotal"];
            subtotal.Text = "商品总价￥:"+newinfo.TotalMoney.Text.ToString()+"\n"
                            + "-优惠抵扣￥：" + newinfo.CouponsMoney.Text.ToString()+"\n"
                            + "-余额支付￥：" + newinfo.BanlanceMoney.Text.ToString()+"\n"
                            + "=实际支付￥：" + newinfo.PayMoney.Text.ToString()+"\n";


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
            OrderNo2.Text = "*"+newinfo.OrderNo.Text.ToString()+"*";


             

            //crystalReportViewer1.ReportSource = newinfo;

            //crystalReportViewer1.Show();
            //newinfo.PrintOptions.PrinterName=

            //newinfo.PrintOptions.PrinterName = printerName;   // 设置打印机名称
             
            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
            //List<string> Printer = new List<string>();
            //LocalPrinter.GetLocalPrinters();


            //foreach (string fPrinterName in  Printing.LocalPrinter.GetLocalPrinters())
            //{

            //    Printer.Add(fPrinterName);



            //}
            ////doc.PrinterSettings.PrinterName = "Foxit Reader PDF Printer";
            //doc.PrinterSettings.PrinterName = Printer[0].ToString();
            int rawKind = 1;
            for (int i = 0; i <= doc.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                if (doc.PrinterSettings.PaperSizes[i].PaperName == "xiannvguo")
                {
                    rawKind = doc.PrinterSettings.PaperSizes[i].RawKind;
                }
            }




            newmoban.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind; ;   // 设置打印纸张样式
            newmoban.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation;//默认纸张方向
            newmoban.PrintToPrinter(1, false, 1, 1);
           
        
        
        
        }
    }
}
