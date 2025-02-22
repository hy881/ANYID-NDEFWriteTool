using NDEFReadWriteTool.bean;
using NDEFReadWriteTool.View;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDEFReadWriteTool
{
    public partial class Form1 : UIForm, IReaderView
    {
        private string _ccData;
        private string _ndefData;
       
        public Form1()
        {
            InitializeComponent();
            initUrlDataGridView();
            comb_connect_type.SelectedIndex = 0;
            uiRadioButtonGroup1.SelectedIndex = 0;
            switch_connect.ValueChanged +=(s,e)=> ConnectSwitchValueChange?.Invoke(this,e);
            btn_refresh.Click += (s, e) => RefreshButtonClick?.Invoke(this,e);
            uiRadioButtonGroup1.ValueChanged+=(s,i,e)=>RadioButtonChange?.Invoke(this,i,e);
            btn_url_read.Click += (s, e) => ReadURLButtonClick?.Invoke(this, e);
            btn_url_write.Click += (s, e) => WriteURLButtonClick?.Invoke(this, e);
            btn_wifi_write.Click+=(s, e) => WriteWifiButtonClick?.Invoke(this, e);
            btn_ble_write.Click += (s, e) => WriteBleButtonClick?.Invoke(this, e);
        }

        public event EventHandler<bool> ConnectSwitchValueChange;
        public event EventHandler RefreshButtonClick;
        public event UIRadioButtonGroup.OnValueChanged RadioButtonChange;
        public event EventHandler ReadURLButtonClick;
        public event EventHandler WriteURLButtonClick;
        public event EventHandler SaveCsvButtonClick;
        public event EventHandler WriteWifiButtonClick;
        public event EventHandler WriteBleButtonClick;

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
                param.ComStr = comb_com.Text;
                param.Baudrate = combo_baudrate.Text;
                param.ConnectType = 1;
            }
            else
            {
                param.IpStr = txt_param1.Text;
                param.Port = txt_param2.Text.ToInt();
                param.ConnectType = 2;
            }
            return param;
        }
        public void showReaderVersion(ReaderVersion readerVersion)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                this.txt_model.Text = readerVersion.Model;
                this.txt_softwave.Text = readerVersion.SoftwareVersion;
                this.txt_hardwave.Text = readerVersion.HardwareVersion;
            }));

        }


        #endregion

        #region 读写URL
        public void showUrlInfo(NdefInfo info)
        {
            this.Invoke((MethodInvoker)(() => {
                this.txt_uid.Text = info.Uid;
                this.txt_cc.Text = info.Cc;
                this.txt_url.Text = info.NdefData;
                urlList.Add(info);
                url_table.Rows.Add(urlList.Count, info.Uid, info.NdefData);
                dgv_url.FirstDisplayedScrollingRowIndex = dgv_url.Rows.Count - 1;
            }));
        }
        List<NdefInfo> urlList = new List<NdefInfo>();
        DataTable url_table = new DataTable();
        private void initUrlDataGridView()
        {
            url_table.Columns.Add("序号", typeof(int));
            url_table.Columns.Add("UID", typeof(string));
            url_table.Columns.Add("URL", typeof(string));

            dgv_url.DataSource = url_table;
        }

        private void btn_url_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
                Title = "Save a CSV File",
                OverwritePrompt = false // 不自动提示覆盖
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                // 检查文件是否已存在
                if (File.Exists(filePath))
                {
                    MessageBox.Show("文件已存在，不能覆盖！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // 文件已存在，终止操作
                }

            }
        }
        #endregion

        #region 读写文本
        #endregion

        #region 读写WIFI
        #endregion

        #region 读写蓝牙
        #endregion

        public void controlProgressDialog(bool bOpen)
        {
            if (bOpen)
            {
                this.ShowProcessForm(100);
            }
            else
            {
                this.HideProcessForm();
            }
        }

        public void showTips(int type, string message)
        {
            if (type == 0)
            {
                this.ShowSuccessTip(message);
            }
            else if (type == 1)
            {
                this.ShowWarningTip(message);
            }
            else
            {
                this.ShowErrorTip(message);
            }
        }

        public NdefInfo GetNdefInfo(int writeType)
        {
            NdefInfo info = new NdefInfo();
            switch (writeType)
            {
                case 0:
                    info.Cc = this.txt_cc.Text;
                    info.NdefData = this.txt_url.Text;
                    break;
                case 1:

                    break;
                case 2:
                    info.Cc = this.txt_cc.Text;
                    info.NdefData=this.txt_wifiName.Text;
                    info.NdefData2=this.txt_wifiPassword.Text;
                    break;
                case 3:
                    info.Cc = this.txt_cc.Text;
                    info.NdefData=this.txt_mac.Text;
                    break;
            }
            return info;
        }

      
    }
}
