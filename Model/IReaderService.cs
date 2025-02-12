using NDEFReadWriteTool.bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDEFReadWriteTool
{
    internal interface IReaderService
    {
        Task<bool> ReaderInitAsync(ConnectParam param);
        ReaderVersion GetReaderVersion();
        void CloseReader(int type);

    }
}
