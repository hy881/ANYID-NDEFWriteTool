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
        }

        private void connectSwitchClick(object sender,bool value)
        {
            ConnectParam param = _readerView.GetConnectParam();
            if (value)
            {           
                _readerService.ReaderInitAsync(param);
            }
            else
            {
                _readerService.CloseReader(param.ConnectType);
            }
        }

    }
}
