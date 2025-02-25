using NDEFReadWriteTool.bean;
using NDEFReadWriteTool.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDEFReadWriteTool
{
    internal class ReaderPersenter
    {
        private readonly IReaderService _readerService;
        private readonly IReaderView _readerView;

        public ReaderPersenter(IReaderService readerService, IReaderView readerView)
        {
            _readerService = readerService;
            this._readerView = readerView;
            this._readerView.ConnectSwitchValueChange += connectSwitchClick;
            _readerService.OnVersionReturn += readerVersionReturn;
            _readerService.OnInfoReturn += OnNdefRwReturn;
            _readerView.RefreshButtonClick += refreshBtnClick;
            _readerView.RadioButtonChange += tagTypeChange;
            _readerView.ReadURLButtonClick += readUrlBtnClick;
            _readerView.WriteURLButtonClick += writeUrlBtnClick;
            _readerView.WriteTXTButtonClick += writeTxtBtnClick;
            _readerView.ReadTXTButtonClick += readTxtBtnClick; 
            _readerView.WriteWifiButtonClick += writeWifidBtnClick;
            _readerView.ReadWifiButtonClick+=readWifiBtnClick;
            _readerView.WriteBleButtonClick += writeBleBtnClick;
            _readerView.ReadBleButtonClick += readbleBtnClick;
        }

        private  async void connectSwitchClick(object sender,bool value)
        {
            //view需要弹出进度dialog
            _readerView.controlProgressDialog(true);
            ConnectParam param = _readerView.GetConnectParam();
            if (value)
            {           
                bool result = await _readerService.ReaderInitAsync(param);
                if (result)
                {
                    _readerView.showTips(0, "设备连接成功");
                }
                else
                {
                    _readerView.showTips(2, "设备连接失败");
                }
            }
            else
            {
                _readerService.CloseReader(param.ConnectType);
                _readerView.showTips(0, "设备关闭成功");
            }
            //view关闭进度dialog
            _readerView.controlProgressDialog(false);
        }

        private async void refreshBtnClick(object e,EventArgs args)
        {
            bool result = await  _readerService.GetReaderVersionAsync();
            if (result)
            {
                _readerView.showTips(0, "版本获取成功");
            }
            else
            {
                _readerView.showTips(2, "通信超时");
            }
        }

        private void readerVersionReturn(ReaderVersion readerVersion)
        {
            _readerView.showReaderVersion(readerVersion);
        }

        private async void tagTypeChange(object obj,int index,string txt)
        {
            _readerView.controlProgressDialog(true);
            bool result = await _readerService.SetReaderConfigAsync(index);
            if (result)
            {
                _readerView.showTips(0, "协议选择成功");
            }
            else
            {
                _readerView.showTips(2, "通信超时");
            }
            _readerView.controlProgressDialog(false);
        }

        private async void readUrlBtnClick(object sender,EventArgs args)
        {
            bool bResult = await _readerService.ReadNdefDataAsync(0);
            if (bResult)
            {
                _readerView.showTips(0, "读取成功");
            }
            else
            {
                _readerView.showTips(2, "读取错误");
            }
        }

        private async void writeUrlBtnClick(object sender,EventArgs e)
        {
            NdefInfo info = _readerView.GetNdefInfo(0);
            bool bResult=await _readerService.WriteNdefDataAsync(0,info.Cc,info.NdefData,"");
            if (bResult)
            {
                _readerView.showTips(0, "写入成功");
            }
            else
            {
                _readerView.showTips(2, "写入错误");
            }
        }

        private async void readTxtBtnClick(object sender, EventArgs args)
        {
            bool bResult = await _readerService.ReadNdefDataAsync(1);
            if (bResult)
            {
                _readerView.showTips(0, "读取成功");
            }
            else
            {
                _readerView.showTips(2, "读取错误");
            }
        }

        private async void writeTxtBtnClick(object sender, EventArgs e)
        {
            NdefInfo info = _readerView.GetNdefInfo(1);
            bool bResult = await _readerService.WriteNdefDataAsync(1, info.Cc, info.NdefData, "");
            if (bResult)
            {
                _readerView.showTips(0, "写入成功");
            }
            else
            {
                _readerView.showTips(2, "写入错误");
            }
        }

        private async void readWifiBtnClick(object sender, EventArgs args)
        {
            bool bResult = await _readerService.ReadNdefDataAsync(2);
            if (bResult)
            {
                _readerView.showTips(0, "读取成功");
            }
            else
            {
                _readerView.showTips(2, "读取错误");
            }
        }

        private async void writeWifidBtnClick(object sender,EventArgs e)
        {
            NdefInfo info = _readerView.GetNdefInfo(2);
            bool bResult = await _readerService.WriteNdefDataAsync(2,info.Cc,info.NdefData,info.NdefData2);
            if (bResult)
            {
                _readerView.showTips(0, "写入成功");
            }
            else
            {
                _readerView.showTips(2, "写入错误");
            }
        }

        private async void readbleBtnClick(object sender, EventArgs args)
        {
            bool bResult = await _readerService.ReadNdefDataAsync(3);
            if (bResult)
            {
                _readerView.showTips(0, "读取成功");
            }
            else
            {
                _readerView.showTips(2, "读取错误");
            }
        }

        private async void writeBleBtnClick(object sender, EventArgs e)
        {
            NdefInfo info = _readerView.GetNdefInfo(3);
            bool bResult = await _readerService.WriteNdefDataAsync( 3, info.Cc, info.NdefData, "");
            if (bResult)
            {
                _readerView.showTips(0, "写入成功");
            }
            else
            {
                _readerView.showTips(2, "写入错误");
            }
        }

        private void OnNdefRwReturn(NdefInfo ndefInfo,int type)
        {
            _readerView.showNdefInfo(ndefInfo,type);            
        }
    }
}
