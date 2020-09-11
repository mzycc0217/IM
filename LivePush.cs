using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Coldairarrow.Util.LivePush
{
    
 

    public class LivePush
    {
       public string key { get; set; } = "2409666d261c239a829b20f39008349f";
   


        public List<LiveModel> GetLivePushUrl(string StringName)
        {
            //本地时间转为UTC时间
              DateTime dateTime = DateTime.Now.AddDays(1).ToUniversalTime(); ;
              //转为时间戳
              var p = GetTimeStamp(dateTime);
              //转为16进制大写
              string sk = tenToSixteen(p.ToString()).ToUpper();
              string inputkey = this.key + StringName + sk;
              //正确的Md5加密
              var spk = MD5Encrypt(inputkey);
             

              //推流地址
               var PushUrl = "rtmp://tl.dillonl.cn/live/"+StringName+"?txSecret=" +spk +"&txTime="+ sk;
           
            //播流地址
              var PlayUrl = "rtmp://ll.dillonl.cn/live/"+StringName ;
            List<LiveModel> liveModels = new List<LiveModel>();
            liveModels.Add(new LiveModel
              {
                  StringName=StringName,
                  PushUrl=PushUrl,
                  PlayUrl=PlayUrl
              });
            return liveModels;


        }






        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input">需要加密的字符串</param>
        /// <param name="encode">字符的编码</param>
        /// <returns></returns>
        private static string MD5Encrypt(string input)
        {
            MD5 md5 = MD5.Create();
            //需要将字符串转成字节数组
            byte[] buffer = Encoding.Default.GetBytes(input);
            //加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择
            byte[] md5buffer = md5.ComputeHash(buffer);
            string str = null;
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            foreach (byte b in md5buffer)
            {
                //得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                //但是在和对方测试过程中，发现我这边的MD5加密编码，经常出现少一位或几位的问题；
                //后来分析发现是 字符串格式符的问题， X 表示大写， x 表示小写， 
                //X2和x2表示不省略首位为0的十六进制数字；
                str += b.ToString("x2");
            }

            return str;
        }


        //格林北京时间
        private static DateTime DateTime1970 = new DateTime(1970, 1, 1, 08, 00, 00).ToLocalTime();

        /// <summary>
        /// 获取从 1970-01-01 到现在的毫秒数。
        /// </summary>
        /// <returns></returns>
        //public static long GetTimeStamp()
        //{
        //    return (long)(DateTime.Now.ToLocalTime() - DateTime1970).TotalSeconds;
        //}

        /// <summary>
        /// 计算 1970-01-01 到指定 <see cref="DateTime"/> 的毫秒数。
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private static long GetTimeStamp(DateTime dateTime)
        {
            return (long)(dateTime.ToLocalTime() - DateTime1970).TotalSeconds;
        }

        /// <summary>
        /// 将string格公式为十六进制数据
        /// </summary>
        /// <param name="msg">
        /// </param>
        /// <returns>
        /// </returns>
        private static string tenToSixteen(string msg)
        {
            long number = Convert.ToInt64(msg);
            return Convert.ToString(number, 16);
        }
    }
}
