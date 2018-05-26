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
    public partial class setTime : Form
    {   public string starTime;
        public string endTime;

        public setTime()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   
            //if (starYear.Text != "" && starMonth.Text != "" && starDay.Text != "" && endYear.Text != "" && endMonth.Text != "" && endDay.Text != "")
            //{



            //    starTime = starYear.Text.ToString() + "-" + starMonth.Text.ToString() + "-" + starDay.Text.ToString();
            //    endTime = endYear.Text.ToString() + "-" + endMonth.Text.ToString() + "-" + endDay.Text.ToString();

            //    this.DialogResult = DialogResult.OK;
                

            //}
            
            //else
            //{

            //    MessageBox.Show("不能为空！");
                

            //}
            starTime = dateTimeStart.Value.ToString();
            endTime = dateTimeEnd.Value.ToString();
            this.DialogResult = DialogResult.OK;


           
        }

        private void setTime_Load(object sender, EventArgs e)
        {

        }
    }
}
