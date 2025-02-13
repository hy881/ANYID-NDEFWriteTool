using NDEFReadWriteTool.bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDEFReadWriteTool
{
    public delegate void VersionReturnDelegate(ReaderVersion readerVersion);

    internal interface IReaderService
    {
        event VersionReturnDelegate OnVersionReturn;
        Task<bool> ReaderInitAsync(ConnectParam param);
        Task<bool> GetReaderVersionAsync();
        Task<bool> SetReaderConfigAsync(int type);
        Task<bool> WriteUrlAsync(string ccData,string url);
        Task<bool> ReadUrlAsync();
        void CloseReader(int type);

       
    }
}
