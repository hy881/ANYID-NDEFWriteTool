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
            _readerView.RefreshButtonClick += refreshBtnClick;
            _readerView.RadioButtonChange += tagTypeChange;
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
    }
}
