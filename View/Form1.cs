using NDEFReadWriteTool.bean;
using NDEFReadWriteTool.View;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDEFReadWriteTool
{
    public partial class Form1 : UIForm, IReaderView
    {
        public Form1()
        {
            InitializeComponent();   
            comb_connect_type.SelectedIndex = 0;
            switch_connect.Click +=(s,e)=> ConnectButtonClick?.Invoke(this,e);
        }

        public event EventHandler ConnectButtonClick;
        public event EventHandler<bool> ConnectSwitchValueChange;

        private void uiTabControlMenu1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region 读写器配置
        private void comb_connect_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comb_connect_type.SelectedIndex == 0)//USB
            {
                txt_param1.Visible = true;
                txt_param2.Visible = true;
                comb_com.Visible = false;
                combo_baudrate.Visible = false;
                lab_title1.Text = "PID:";
                lab_title2.Text = "VID";
                txt_param1.Text = "0x0505";
                txt_param2.Text = "0x0505";
                txt_param1.Enabled = false;
                txt_param2.Enabled = false;
            }
            else if (comb_connect_type.SelectedIndex == 1)//COM
            {
                txt_param1.Visible = false;
                txt_param2.Visible = false;
                comb_com.Visible = true;
                combo_baudrate.Visible = true;
                lab_title1.Text = "串口号:";
                lab_title2.Text = "波特率:";
                //增加com口刷新
            }
            else//TCP
            {
                txt_param1.Enabled = true;
                txt_param2.Enabled = true;
                txt_param1.Visible = true;
                txt_param2.Visible = true;
                comb_com.Visible = false;
                combo_baudrate.Visible = false;
                lab_title1.Text = "IP:";
                lab_title2.Text = "PORT:";
            }
        }

        #endregion

        private void switch_connect_ValueChanged(object sender, bool value)
        {
            if (value)
            {
                this.ShowProcessForm(100);
            }
            else
            {

            }
        }

        public ConnectParam GetConnectParam()
        {
            ConnectParam param = new ConnectParam();
            if (comb_connect_type.SelectedIndex == 0)
            {
                param.VID = 0x0505;
                param.PID = 0x5050;
                param.ConnectType = 0;
            }
            else if (comb_connect_type.SelectedIndex == 1)
            {
                param.ComStr=comb_com.Text;
                param.Baudrate=combo_baudrate.Text;
                param.ConnectType = 1;
            }
            else
            {
                param.IpStr = txt_param1.Text;
                param.Port=txt_param2.Text.ToInt();
                param.ConnectType = 2;
            }
            return param;
        }
    }
}
