using NDEFReadWriteTool.bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDEFReadWriteTool.Model
{
    internal class ReaderService : IReaderService
    {
        delegate void OnMessageReturnDelegate(int step, string msg, object value);
        event OnMessageReturnDelegate OnSucReturn;
        event OnMessageReturnDelegate OnFailReturn;
        public event VersionReturnDelegate OnVersionReturn;

        public async Task<bool> GetReaderVersionAsync()
        {
            return await Task.Run(() =>
            {
                bool bResult=false;
                AnyIDReader.getReaderVersion(obj =>
                {
                    bResult = true;
                    OnVersionReturn?.Invoke((ReaderVersion)obj);
                }, msg =>
                {
                    bResult=false;
                    OnFailReturn?.Invoke(0,msg,null);
                });
                return bResult;
            });
        }


       

        public async Task<bool> ReaderInitAsync(ConnectParam param)
        {
            try
            {
                return await Task.Run(() =>
                {
                    bool bStart = true;
                    bool bResult=false;
                    int step = 0;
                    while (bStart)
                    {
                        switch (step)
                        {
                            case 0:
                                AnyIDReader.initReader(obj =>
                                {
                                    OnSucReturn?.Invoke(step, "系统初始化", null);
                                    step++;
                                }, msg =>
                                {
                                    OnFailReturn?.Invoke(step, msg, null);
                                    bStart = false;
                                    bResult = false;
                                });
                                break;
                            case 1:
                                AnyIDReader.openReader(obj =>
                                {
                                    OnSucReturn?.Invoke(step, "打开读写器", null);
                                    step++;
                                }, msg =>
                                {
                                    OnFailReturn?.Invoke(step, msg, null);
                                    bStart = false;
                                    bResult = false;
                                });
                                break;
                            case 2:
                                AnyIDReader.getReaderVersion(obj =>
                                {
                                    bResult = true;
                                    OnSucReturn?.Invoke(step, "获取版本成功", obj);
                                    OnVersionReturn?.Invoke((ReaderVersion)obj);
                                }, msg =>
                                {
                                    OnFailReturn?.Invoke(step, msg, null);
                                    bResult = false;
                                });
                                bStart = false;
                                break;
                        }
                    }
                    return bResult;
                });

            }
            catch (Exception)
            {

                return false;
            }
        }

        public void CloseReader(int type)
        {
            AnyIDReader.closeReader(type);
        }

        public async Task<bool> SetReaderConfigAsync(int type)
        {
           return await Task.Run(() =>
            {
                bool bResult = false;
                AnyIDReader.setReaderConfig(type, obj =>
                {
                    bResult = true;
                }, msg =>
                {
                    bResult = false;
                });
                return bResult;
            });
           
        }
    }
}
