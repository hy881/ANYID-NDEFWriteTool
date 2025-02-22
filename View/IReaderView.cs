using NDEFReadWriteTool.bean;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NDEFReadWriteTool.View
{

    internal interface IReaderView
    {

      
        ConnectParam GetConnectParam();

        NdefInfo GetNdefInfo(int writeType);

        event EventHandler<bool> ConnectSwitchValueChange;

        event EventHandler RefreshButtonClick;

        event UIRadioButtonGroup.OnValueChanged RadioButtonChange;

        event EventHandler ReadURLButtonClick;

        event EventHandler WriteURLButtonClick;

        event EventHandler WriteWifiButtonClick;

        event EventHandler WriteBleButtonClick;

        void showReaderVersion(ReaderVersion readerVersion);
        void controlProgressDialog(bool bOpen);
        void showTips(int type, string message);
        void showUrlInfo(NdefInfo info);
    }
}
