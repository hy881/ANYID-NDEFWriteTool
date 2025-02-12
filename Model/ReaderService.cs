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

        public ReaderVersion GetReaderVersion()
        {
            throw new NotImplementedException();
        }


        public async Task<bool> ReaderInitAsync(ConnectParam param)
        {
            try
            {
                return await Task.Run(() =>
                {
                    bool bStart = true;
                    int step = 0;                 
                    while (bStart)
                    {
                        switch (step)
                        {
                            case 0:
                                AnyIDReader.initReader(obj =>
                                {
                                    OnSucReturn(step,"系统初始化",null);
                                    step++;
                                }, msg =>
                                {
                                    OnFailReturn(step,msg,null);
                                    bStart = false;
                                });
                                break;
                            case 1:
                                AnyIDReader.openReader(obj =>
                                {
                                    OnSucReturn(step, "打开读写器", null);
                                    step++;
                                }, msg =>
                                {
                                    OnFailReturn(step, msg, null);
                                    bStart = false;
                                });
                                break;
                            case 2:
                                AnyIDReader.getReaderVersion(obj =>
                                {
                                    OnSucReturn(step,"获取版本成功",obj);

                                }, msg =>
                                {
                                    OnFailReturn(step, msg, null);
                                    
                                });
                                bStart = false;
                                break;
                        }
                    }
                    return bStart;
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
    }
}
