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
using System.Net;
using System.IO;

namespace FaceCat {
    /// <summary>
    /// 数据中心
    /// </summary>
    public class DataCenter {
        private static SecurityService m_securityService = new SecurityService();

        /// <summary>
        /// 获取证券服务
        /// </summary>
        public static SecurityService SecurityService {
            get { return DataCenter.m_securityService; }
        }

        private static SinaNewsService m_sinaNewsService = new SinaNewsService();

        /// <summary>
        /// 获取新浪数据服务
        /// </summary>
        public static SinaNewsService SinaNewsService {
            get { return m_sinaNewsService; }
        }

        private static Dictionary<string, BaseWork> m_works = new Dictionary<string, BaseWork>();

        /// <summary>
        /// 获取所有的工作
        /// </summary>
        public static Dictionary<string, BaseWork> Works {
            get { return DataCenter.m_works; }
        }

        /// <summary>
        /// 获取程序路径
        /// </summary>
        /// <returns>程序路径</returns>
        public static String getAppPath() {
            return Application.StartupPath;
        }

        /// <summary>
        /// 数据获取存储路径
        /// </summary>
        /// <returns>程序路径</returns>
        public static String getDataPath() {
            return Application.StartupPath;
        }

        /// <summary>
        /// 获取行情的远程HTTP地址
        /// </summary>
        /// <returns></returns>
        public static String getQuoteDataUrl() {
            return "http://114.55.4.91";
        }

        /// <summary>
        /// 获取行情动态数据目录
        /// </summary>
        /// <returns>目录</returns>
        public static String getQuoteDynamicDataDir() {
            return getAppPath() + "\\data";
        }

        /// <summary>
        /// 获取行情静态数据目录
        /// </summary>
        /// <returns>目录</returns>
        public static String GetQuoteStaticDataDir() {
            return getAppPath() + "\\data";
        }

        /// <summary>
        /// 获取网页数据
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="encoding">地址</param>
        /// <returns>页面源码</returns>
        public static String getHttpWebRequest(String url, String encoding) {
            for (int i = 0; i < 3; i++) {
                String content = "";
                HttpWebRequest request = null;
                HttpWebResponse response = null;
                StreamReader streamReader = null;
                Stream resStream = null;
                try {
                    request = (HttpWebRequest)WebRequest.Create(url);
                    request.KeepAlive = false;
                    request.Timeout = 30000;
                    response = (HttpWebResponse)request.GetResponse();
                    resStream = response.GetResponseStream();
                    streamReader = new StreamReader(resStream, System.Text.Encoding.GetEncoding(encoding));
                    content = streamReader.ReadToEnd();
                }
                catch (Exception ex) {
                }
                finally {
                    if (response != null) {
                        response.Close();
                    }
                    if (resStream != null) {
                        resStream.Close();
                    }
                    if (streamReader != null) {
                        streamReader.Close();
                    }
                }
                if (content.Length > 0) {
                    return content;
                }
            }
            return "";
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        public static void startService() {
            m_works["sinanews"] = DataCenter.SinaNewsService;
        }
    }
}
