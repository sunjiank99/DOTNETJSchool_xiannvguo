using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace xiannvguo
{   
    public partial class LoginWindows : Form
    {
        public LoginWindows()
        {
            InitializeComponent();
           
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase a = new dataBase();
            if (a.verifyPassWord(Id.Text.ToString(), Ps.Text.ToString()))
            {

                GoodsView mainView = new GoodsView(Id.Text.ToString());

                this.Hide();
                mainView.ShowDialog();
                this.Id.Text = string.Empty;
                this.Ps.Text = string.Empty;

                this.Show();

            }
            else
            {
                MessageBox.Show("账户或密码错误");
             
            }
        }

        private void LoginWindows_Load(object sender, EventArgs e)
        {

        }
    }
}
