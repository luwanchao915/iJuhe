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
using System.Net;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FaceCat {
    /// <summary>
    /// 股票服务
    /// </summary>
    public class SecurityService {
        /// <summary>
        /// 获取证券列表
        /// </summary>
        /// <returns>证券列表</returns>
        public List<Security> getSecurities() {
            List<Security> securities = new List<Security>();
            String codesStr = "";
            FCFile.read(DataCenter.getAppPath() + "\\codes.txt", ref codesStr);
            String[] strs = codesStr.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int strsSize = strs.Length;
            for (int i = 0; i < strsSize; i++) {
                String[] subStrs = strs[i].Split(',');
                Security security = new Security();
                security.m_code = subStrs[0];
                security.m_name = subStrs[1];
                securities.Add(security);
            }
            return securities;
        }
    }
}
