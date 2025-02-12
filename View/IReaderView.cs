using NDEFReadWriteTool.bean;
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

        event EventHandler<bool> ConnectSwitchValueChange;
    }
}
