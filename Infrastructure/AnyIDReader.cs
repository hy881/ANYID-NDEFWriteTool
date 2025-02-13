using NDEFReadWriteTool.bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDEFReadWriteTool
{
    static class AnyIDReader
    {
        public delegate void onSuccess(Object obj);
        public delegate void onFail(string msg);
        private static int hSerial = -1;
        private static byte[] uid = new byte[8];
        public const int TAGTYPE_ISO15693 = 0x00;
        public const int TAGTYPE_NTAG = 0x01;

        private static string[] NDEF_URI_PREFIXS = {
                                        "",
                                        "http://www.",
                                        "https://www.",
                                        "http://",
                                        "https://",
                                        "tel:",
                                        "mailto:",
                                        "ftp://anonymous:anonymous@",
                                        "ftp://ftp.",
                                        "ftps://",
                                        "sftp://",
                                        "smb://",
                                        "nfs://",
                                        "ftp://",
                                        "dav://",
                                        "news:",
                                        "telnet://",
                                        "imap:",
                                        "rtsp://",
                                        "urn:",
                                        "pop:",
                                        "sip:",
                                        "sips:",
                                        "tftp:",
                                        "btspp://",
                                        "btl2cap://",
                                        "btgoep://",
                                        "tcpobex://",
                                        "irdaobex://",
                                        "file://",
                                        "urn:epc:id:",
                                        "urn:epc:tag:",
                                        "urn:epc:pat:",
                                        "urn:epc:raw:",
                                        "urn:epc:",
                                        "urn:nfc:"
        };

        public static void initReader(onSuccess fun1, onFail fun2)
        {
            int hHFREADERDLLModule = 0;
            hHFREADERDLLModule = hfReaderDll.LoadLibrary("HFREADER.dll");
            if (hHFREADERDLLModule > 0)
            {
                fun1("初始化设备成功");
            }
            else
            {
                fun2("缺少文件HFREADER.dll");
            }
        }

        public static void openReader(onSuccess fun1, onFail fun2)
        {
            hSerial = hfReaderDll.hfReaderOpenUsb(0x0505, 0x5050);
            if (hSerial > 0)
            {
                fun1("设备连接成功");
            }
            else
            {
                fun2("设备连接失败");
            }
        }

        public static void getReaderVersion(onSuccess fun1, onFail fun2)
        {
            Byte[] buffer = new Byte[255];
            ushort[] addrArray = new ushort[2];
            HFREADER_VERSION pVersion = new HFREADER_VERSION();
            pVersion.type = new byte[hfReaderDll.HFREADER_VERSION_SIZE];
            pVersion.sv = new byte[hfReaderDll.HFREADER_VERSION_SIZE];
            pVersion.hv = new byte[hfReaderDll.HFREADER_VERSION_SIZE];
            int rlt = hfReaderDll.hfReaderGetVersion(hSerial, 0x0000, 0xFFFF, ref pVersion, null, null);
            if (rlt > 0)
            {
                if (pVersion.result.flag == 0)
                {
                    ReaderVersion readerVersion=new ReaderVersion();
                    readerVersion.Model = System.Text.Encoding.Default.GetString(pVersion.type).Replace("\0", "");
                    readerVersion.HardwareVersion = System.Text.Encoding.Default.GetString(pVersion.hv).Replace("\0", "");
                    readerVersion.SoftwareVersion = System.Text.Encoding.Default.GetString(pVersion.sv).Replace("\0", "");
                    fun1(readerVersion);
                }
            }
            else
            {
                fun2("获取版本失败");
            }

        }
        /// <summary>
        /// 配置读写器参数
        /// </summary>
        /// <param name="tagType"></param>
        /// <param name="fun1"></param>
        /// <param name="fun2"></param>
        public static void setReaderConfig(int tagType, onSuccess fun1, onFail fun2)
        {
            ushort[] addrArray = { 0x0000, 0x0001 };
            Byte WorkMode = 0;
            HFREADER_CONFIG pReaderConfig = new HFREADER_CONFIG();
            if (tagType == TAGTYPE_ISO15693)
            {
                WorkMode |= hfReaderDll.HFREADER_CFG_TYPE_ISO15693 | hfReaderDll.HFREADER_CFG_WM_INVENTORY;
            }
            else
            {
                WorkMode |= hfReaderDll.HFREADER_CFG_TYPE_ISO14443A | hfReaderDll.HFREADER_CFG_WM_INVENTORY;
            }
            pReaderConfig.workMode = WorkMode;
            pReaderConfig.cmdMode = hfReaderDll.HFREADER_CFG_INVENTORY_TRIGGER;
            pReaderConfig.uidSendMode = hfReaderDll.HFREADER_CFG_UID_POSITIVE;
            pReaderConfig.beepStatus = hfReaderDll.HFREADER_CFG_BUZZER_DISABLE;
            pReaderConfig.afiCtrl = hfReaderDll.HFREADER_CFG_AFI_DISABLE;
            pReaderConfig.tagStatus = hfReaderDll.HFREADER_CFG_TAG_NOQUIET;
            pReaderConfig.baudrate = hfReaderDll.HFREADER_CFG_BAUDRATE38400;
            pReaderConfig.afi = 0x00;
            pReaderConfig.readerAddr = (ushort)(addrArray[1]);
            int rlt = hfReaderDll.hfReaderSetConfig(hSerial, 0, 1, ref pReaderConfig, null, null);
            if (rlt > 0)
            {
                fun1("设置设备成功");
            }
            else
            {
                fun2("设置设备失败");
            }
        }

  
        /// <summary>
        /// 文本转txtNDEF
        /// </summary>
        /// <param name="txtMsg">输入文本</param>
        /// <returns>返回转换的byte数组</returns>
        public static byte[] formatTxtNdef(string txtMsg)
        {
            int index = 0;
            byte[] block = new byte[1024];
            block[index++] = 0x03;
            block[index++] = (byte)(1 + 4 + txtMsg.Length);
            block[index++] = 0xD1;
            block[index++] = 0x01;
            block[index++] = (byte)(block[1] - 4);
            block[index++] = 0x54;
            block[index++] = 0x02;
            block[index++] = 0x65;
            block[index++] = 0x6E;
            byte[] data= System.Text.Encoding.ASCII.GetBytes(txtMsg);
            Array.Copy(data, 0, block, index, data.Length);
            index+=data.Length;
            block[index++] = 0xFE;
            byte[] buffer = new byte[index];
            Array.Copy(block, 0, buffer, 0, index);
            return buffer;
        }

        /// <summary>
        /// URL转urlNDEF
        /// </summary>
        /// <param name="ndefStr">输入URL</param>
        /// <returns>返回转换的byte数组</returns>
        public static byte[] formatUrlNdef(string ndefStr)
        {
            int i = 0;
            int uriType = 0;
            for (i = 1; i < NDEF_URI_PREFIXS.Length; i++)       //第一个是空的
            {
                if (ndefStr.IndexOf(NDEF_URI_PREFIXS[i]) == 0)
                {
                    uriType = i;
                    ndefStr = ndefStr.Replace(NDEF_URI_PREFIXS[i], "");
                    break;
                }
            }
            int index = 0;
            byte[] block = new byte[1024];
            block[index++] = 0x03;
            block[index++] = 0xB9;
            block[index++] = 0xD1;
            block[index++] = 0x01;

            block[index++] = (byte)(block[1] - 4);
            block[index++] = 0x55;
            block[index++] = (byte)uriType;
            byte[] array = new byte[1024];                          //定义一组数组array
            int uriLen = 0;
            uriLen = ndefStr.Length;// -NDEF_URI_PREFIXS[uriType].Length;
            array = System.Text.Encoding.ASCII.GetBytes(ndefStr);   //string转换的字母.Substring(NDEF_URI_PREFIXS[uriType].Length)
            Array.Copy(array, 0, block, index, uriLen);
            index += uriLen;
            block[index++] = 0xFE;
            byte[] data = new byte[index];
            Array.Copy(block, 0, data, 0, index);
            return data;
        }


        #region 15693
        public static void getUidFor15693(onSuccess fun1, onFail fun2)
        {
            string uidStr = "";
            int rlt = 0;
            HFREADER_OPRESULT pResult = new HFREADER_OPRESULT();
            ISO15693_UIDPARAM iso15693Uid = new ISO15693_UIDPARAM();
            iso15693Uid.uid = new Byte[25 * 8];
            hfReaderDll.hfReaderCtrlRf(hSerial, 0, 1, hfReaderDll.HFREADER_RF_OPEN, ref pResult, null, null);       //RF复位                                                                                                                      //Thread.Sleep(10);
            rlt = hfReaderDll.iso15693GetUid(hSerial, 0, 1, 0, ref iso15693Uid, null, null);                  //获取UID
            if (rlt > 0 && iso15693Uid.result.flag == 0 && iso15693Uid.num > 0)
            {
                uidStr = TranfUtil.HexToString(iso15693Uid.uid, 0, hfReaderDll.HFREADER_ISO15693_SIZE_UID);
                Array.Copy(iso15693Uid.uid, 0, uid, 0, 8);
                fun1(uidStr);
            }
            else
            {
                fun2("没有读取到标签");
            }
        }

        public static void readBlockFor15693()
        {

        }


        public static void writeNDEFFor15693(string ndefMsg,onSuccess fun1,onFail fun2)
        {
            ISO15693_BLOCKPARAM iso15693BlockParams = new ISO15693_BLOCKPARAM();
            iso15693BlockParams.block = new Byte[32 * 4];
            byte[] ndefData = formatTxtNdef(ndefMsg);
            int blockNum=ndefData.Length/4;
            if (ndefData.Length % 4 > 0)
            {
                blockNum++;
            }
            iso15693BlockParams.addr = 1;
            iso15693BlockParams.num = (uint)blockNum;
            Array.Copy(ndefData, 0, iso15693BlockParams.block, 0, iso15693BlockParams.num * 4);
            int rlt = hfReaderDll.iso15693WriteBlock(hSerial, 0, 1, uid, ref iso15693BlockParams, null, null);
            if (rlt > 0 && iso15693BlockParams.result.flag == 0)
            {
                checkBlock(ndefData, obj =>
                {
                    //写成功

                }, msg =>
                {
                    //写失败

                });
            }
            else
            {
                //写失败

            }

        }


        public static void imWriteBlock(string dataStr, onSuccess fun1, onFail fun2)
        {
            int rlt = -1;
            byte[] data = TranfUtil.strToHexByte(dataStr);
            // getUid();
            int len = data.Length / 4;
            if (data.Length % 4 > 0)
            {
                len += 1;//不足一个块数目的数据补零
            }
            ISO15693_BLOCKPARAM iso15693BlockParams = new ISO15693_BLOCKPARAM();
            iso15693BlockParams.block = new Byte[4 * 32];
            iso15693BlockParams.addr = (uint)0;
            iso15693BlockParams.num = (uint)len;
            Array.Copy(data, 0, iso15693BlockParams.block, 0, data.Length);
            rlt = hfReaderDll.iso15693ImWriteBlock(hSerial, 0, 1, uid, ref iso15693BlockParams, null, null);
            if (rlt > 0 && iso15693BlockParams.result.flag == 0)
            {
                fun1("写块成功");
            }
            else
            {
                fun2("写块失败");
            }
        }

        public static void checkBlock(byte[] data, onSuccess fun1, onFail fun2)
        {
            int rlt = -1;
            int len = data.Length / 4;
            if (data.Length % 4 > 0)
            {
                len += 1;
            }
            byte[] blockBuffer = new byte[len * 4];
            for (int i = 0; i < len; i++)
            {
                ISO15693_BLOCKPARAM iso15693BlockParams = new ISO15693_BLOCKPARAM();
                iso15693BlockParams.block = new Byte[4 * 32];
                iso15693BlockParams.addr = (uint)i;
                iso15693BlockParams.num = 1;
                rlt = hfReaderDll.iso15693ReadBlock(hSerial, 0, 1, uid, ref iso15693BlockParams, null, null);
                if (rlt > 0 && iso15693BlockParams.result.flag == 0)
                {
                    Array.Copy(iso15693BlockParams.block, 0, blockBuffer, i * 4, 4);
                }
                else
                {
                    fun2("读块失败");
                    return;
                }
            }
            if (checkBytes(data, blockBuffer, data.Length))
            {
                fun1("校验成功");
            }
            else
            {
                fun2("校验失败");
            }


        }

        #endregion

        #region Ntag
        public static void getUidForNtag(onSuccess fun1, onFail fun2)
        {
            string uidStr = "";
            int rlt = 0;
            HFREADER_OPRESULT pResult = new HFREADER_OPRESULT();
            ISO14443A_UIDPARAM iso14443aUid = new ISO14443A_UIDPARAM();
            iso14443aUid.uid = new ISO14443A_UID[15];
            hfReaderDll.hfReaderCtrlRf(hSerial, 0, 1, hfReaderDll.HFREADER_RF_OPEN, ref pResult, null, null);       //RF复位                                                                                                                      //Thread.Sleep(10);
            rlt = hfReaderDll.iso14443AGetUID(hSerial, 0, 1, 0, ref iso14443aUid, null, null);                 //获取UID
            if (rlt > 0 && iso14443aUid.result.flag == 0 && iso14443aUid.num > 0)
            {
                uidStr = TranfUtil.HexToString(iso14443aUid.uid[0].uid, 0, iso14443aUid.uid[0].len);
                Array.Copy(iso14443aUid.uid[0].uid, 0, uid, 0, 8);
                fun1(uidStr);
            }
            else
            {
                fun2("没有读取到标签");
            }
        }

        public static void writePage(string dataStr, onSuccess fun1, onFail fun2)
        {
            int rlt = -1;
            byte[] data = TranfUtil.strToHexByte(dataStr);
            // getUid();
            int len = data.Length / 4;
            if (data.Length % 4 > 0)
            {
                len += 1;//不足一个块数目的数据补零
            }
            ISO14443A_BLOCKPARAM iso14443ABlock = new ISO14443A_BLOCKPARAM();
            iso14443ABlock.block = new Byte[13 * hfReaderDll.HFREADER_ISO14443A_LEN_M1BLOCK];
            iso14443ABlock.key = new Byte[hfReaderDll.HFREADER_ISO14443A_LEN_M1_KEY];
            iso14443ABlock.uid = new ISO14443A_UID();
            iso14443ABlock.uid.uid = new Byte[hfReaderDll.HFREADER_ISO14443A_LEN_MAX_UID];
            iso14443ABlock.keyType = 0;
            iso14443ABlock.uid.len = 0;
            iso14443ABlock.addr = 0x03;
            iso14443ABlock.num = (uint)len;
            Array.Copy(data, 0, iso14443ABlock.block, 0, data.Length);
            rlt = hfReaderDll.iso14443AWriteM0Block(hSerial, 0, 1, ref iso14443ABlock, null, null);
            if (rlt > 0 && iso14443ABlock.result.flag == 0)
            {
                fun1("写Page成功");
            }
            else
            {
                fun2("写Page失败");
            }
        }

        public static void checkPage(string dataStr, onSuccess fun1, onFail fun2)
        {
            int rlt = -1;
            byte[] data = TranfUtil.strToHexByte(dataStr);
            int len = data.Length / 4;
            if (data.Length % 4 > 0)
            {
                len += 1;
            }
            byte[] blockBuffer = new byte[len * 4];
            ISO14443A_BLOCKPARAM iso14443ABlock = new ISO14443A_BLOCKPARAM();
            iso14443ABlock.block = new Byte[13 * hfReaderDll.HFREADER_ISO14443A_LEN_M1BLOCK];
            iso14443ABlock.key = new Byte[hfReaderDll.HFREADER_ISO14443A_LEN_M1_KEY];
            iso14443ABlock.uid = new ISO14443A_UID();
            iso14443ABlock.uid.uid = new Byte[hfReaderDll.HFREADER_ISO14443A_LEN_MAX_UID];
            iso14443ABlock.keyType = 0;
            iso14443ABlock.uid.len = 0;
            iso14443ABlock.addr = 0x03;
            iso14443ABlock.num = (uint)len;
            rlt = hfReaderDll.iso14443AReadM0Block(hSerial, 0, 1, ref iso14443ABlock, null, null);
            if (rlt > 0 && iso14443ABlock.result.flag == 0)
            {
                Array.Copy(iso14443ABlock.block, 0, blockBuffer, 0, len * 4);
            }
            else
            {
                fun2("读Page失败");
                return;
            }
            if (checkBytes(data, blockBuffer, data.Length))
            {
                fun1("校验成功");
            }
            else
            {
                fun2("校验失败");
            }
        }


        #endregion

        private static bool checkBytes(byte[] scrArray, byte[] destArray, int len)
        {
            bool result = false;
            for (int i = 0; i < len; i++)
            {
                if (scrArray[i].Equals(destArray[i]) == false)
                {
                    return result;
                }
            }
            return true;
        }
        public static void closeReader(int connect_type)
        {
            if (connect_type==0)
            {
                hfReaderDll.hfReaderCloseUsb(hSerial);
            }
            else
            {
                hfReaderDll.hfReaderClosePort(hSerial);
            }
        }

    }
}
