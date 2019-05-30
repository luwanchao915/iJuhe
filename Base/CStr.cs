/*基于捂脸猫FaceCat框架 v1.0 https://github.com/FaceCat007/facecat.git
 1.创始人-矿洞程序员-上海宁米科技创始人-脉脉KOL-陶德 (微信号:suade1984);
 2.联合创始人-上海宁米科技创始人-袁立涛(微信号:wx627378127);
 3.联合创始人-肖添龙(微信号:xiaotianlong_luu);
 4.联合开发者-陈晓阳(微信号:chenxiaoyangzxy)，助理-朱炜(微信号:cnnic_zhu);
 5.该程序开源协议为BSD，欢迎对我们的创业活动进行各种支持，欢迎更多开发者加入。
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FaceCat
{
    public class FCStrEx
    {
        /// <summary>
        /// 将股票代码转化为百度代码
        /// </summary>
        /// <param name="code">股票代码</param>
        /// <returns>百度代码</returns>
        public static String convertDBCodeToBaiduCode(String code)
        {
            String securityCode = code;
            int index = securityCode.IndexOf(".");
            if (index > 0)
            {
                securityCode = securityCode.Substring(0, index);
            }
            return securityCode;
        }

        /// <summary>
        /// 将股票代码转化为百度代码
        /// </summary>
        /// <param name="code">股票代码</param>
        /// <returns>百度代码</returns>
        public static String convertDBCodeToDzhCode(String code)
        {
            String securityCode = code;
            int index = securityCode.IndexOf(".SH");
            if (index > 0)
            {
                securityCode = "sh" + securityCode.Substring(0, securityCode.IndexOf("."));
            }
            else
            {
                securityCode = "sz" + securityCode.Substring(0, securityCode.IndexOf("."));
            }
            return securityCode;
        }


        /// <summary>
        /// 获取证券代码的文件名称
        /// </summary>
        /// <param name="code">代码</param>
        /// <returns>文件名称</returns>
        public static String convertDBCodeToFileName(String code)
        {
            String fileName = code;
            if (fileName.IndexOf(".") != -1)
            {
                fileName = fileName.Substring(fileName.IndexOf('.') + 1) + fileName.Substring(0, fileName.IndexOf('.'));
            }
            fileName += ".txt";
            return fileName;
        }

        /// <summary>
        /// 将股票代码转化为新浪代码
        /// </summary>
        /// <param name="code">股票代码</param>
        /// <returns>新浪代码</returns>
        public static String ConvertDBCodeToSinaCode(String code)
        {
            String securityCode = code;
            int index = securityCode.IndexOf(".SH");
            if (index > 0)
            {
                securityCode = "sh" + securityCode.Substring(0, securityCode.IndexOf("."));
            }
            else
            {
                securityCode = "sz" + securityCode.Substring(0, securityCode.IndexOf("."));
            }
            return securityCode;
        }


        /// <summary>
        /// 将股票代码转化为东财代码
        /// </summary>
        /// <param name="code">股票代码</param>
        /// <returns>东财代码</returns>
        public static String convertDBCodeToEastmoneyCode(String code)
        {
            String securityCode = code;
            int index = securityCode.IndexOf(".SH");
            if (index > 0)
            {
                securityCode = securityCode.Substring(0, securityCode.IndexOf("."));
            }
            else
            {
                securityCode = securityCode.Substring(0, securityCode.IndexOf("."));
            }
            return securityCode;
        }

        /// <summary>
        /// 将股票代码转化为腾讯代码
        /// </summary>
        /// <param name="code">股票代码</param>
        /// <returns>腾讯代码</returns>
        public static String convertDBCodeToTencentCode(String code)
        {
            String securityCode = code;
            int index = securityCode.IndexOf(".");
            if (index > 0)
            {
                index = securityCode.IndexOf(".SH");
                if (index > 0)
                {
                    securityCode = "sh" + securityCode.Substring(0, securityCode.IndexOf("."));
                }
                else
                {
                    securityCode = "sz" + securityCode.Substring(0, securityCode.IndexOf("."));
                }
            }
            return securityCode;
        }

        /// <summary>
        /// 将新浪代码转化为股票代码
        /// </summary>
        /// <param name="code">新浪代码</param>
        /// <returns>股票代码</returns>
        public static String convertSinaCodeToDBCode(String code)
        {
            int equalIndex = code.IndexOf('=');
            int startIndex = code.IndexOf("var hq_str_") + 11;
            String securityCode = equalIndex > 0 ? code.Substring(startIndex, equalIndex - startIndex) : code;
            securityCode = securityCode.Substring(2) + "." + securityCode.Substring(0, 2).ToUpper();
            return securityCode;
        }

        /// <summary>
        /// 将腾讯代码转化为股票代码
        /// </summary>
        /// <param name="code">腾讯代码</param>
        /// <returns>股票代码</returns>
        public static String convertTencentCodeToDBCode(String code)
        {
            int equalIndex = code.IndexOf('=');
            String securityCode = equalIndex > 0 ? code.Substring(0, equalIndex) : code;
            if (securityCode.StartsWith("v_sh"))
            {
                securityCode = securityCode.Substring(4) + ".SH";
            }
            else if (securityCode.StartsWith("v_sz"))
            {
                securityCode = securityCode.Substring(4) + ".SZ";
            }
            return securityCode;
        }

        /// <summary>
        /// 获取数据库转义字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>转义字符串</returns>
        public static String getDBString(String str)
        {
            return str.Replace("'", "''");
        }
    }
}
