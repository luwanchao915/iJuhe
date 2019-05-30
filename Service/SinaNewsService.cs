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

namespace FaceCat {
    /// <summary>
    /// 新浪数据服务
    /// </summary>
    public class SinaNewsService : BaseWork {
        /// <summary>
        /// 创建服务
        /// </summary>
        public SinaNewsService() {
            Threads = 20;
        }

        /// <summary>
        /// 列表地址
        /// </summary>
        private String m_listUrl = "http://vip.stock.finance.sina.com.cn/corp/go.php/vCB_AllNewsStock/symbol/{0}.phtml";

        /// <summary>
        /// 工作退出
        /// </summary>
        /// <param name="dataInfo">信息</param>
        public override void onWorkQuit(WorkDataInfo dataInfo) {
        }

        /// <summary>
        /// 开始工作
        /// </summary>
        /// <param name="dataInfo">信息</param>
        public override void onWorkStart(WorkDataInfo dataInfo) {
        }

        /// <summary>
        /// 工作中
        /// </summary>
        /// <param name="dataInfo">信息</param>
        /// <returns>状态</returns>
        public override int onWorking(WorkDataInfo dataInfo) {
            Console.WriteLine(dataInfo.m_id.ToString());
            SecurityDataInfo securityDataInfo = dataInfo as SecurityDataInfo;
            String url = String.Format(m_listUrl, FCStrEx.ConvertDBCodeToSinaCode(securityDataInfo.m_security.m_code));
            Log = String.Format("下载:{0}", securityDataInfo.m_security.m_code);
            String html = DataCenter.getHttpWebRequest(url, "GB2312");
            if (html != null && html.Length > 0) {
                NewsInfo newsInfo = new NewsInfo("sinanews");
                newsInfo.m_code = securityDataInfo.m_security.m_code;
                String dir = newsInfo.getDirectory();
                if (!FCFile.isDirectoryExist(dir)) {
                    FCFile.createDirectory(dir);
                }
                String identifier = "<div class=\"datelist\">";
                int pos = html.IndexOf(identifier);
                if (pos != -1) {
                    html = html.Substring(pos + identifier.Length);
                    html = html.Substring(0, html.IndexOf("</ul>"));
                    html = html.Replace("<ul>\r\n\t\t\t", "").Replace("&nbsp;", " ");
                    String[] strs = html.Split(new String[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries);
                    int strsSize = strs.Length;
                    for (int i = 0; i < strsSize; i++) {
                        try {
                            newsInfo.m_content = "";
                            String str = strs[i];
                            String[] subStrs = str.Split(new String[] { "<a target='_blank' href='" }, StringSplitOptions.RemoveEmptyEntries);
                            if (subStrs.Length >= 2) {
                                newsInfo.m_time = subStrs[0].Trim();
                                String[] sunStrs = subStrs[1].Split(new String[] { "'>" }, StringSplitOptions.RemoveEmptyEntries);
                                newsInfo.m_url = sunStrs[0];
                                newsInfo.m_title = sunStrs[1].Replace("</a>", "");
                                String fileName = newsInfo.getFileName();
                                if (!FCFile.isFileExist(fileName)) {
                                    Log = String.Format("下载:{0}", securityDataInfo.m_security.m_code);
                                    String contentHtml = DataCenter.getHttpWebRequest(newsInfo.m_url, "UTF-8");
                                    String sIdentifier = "<!-- 原始正文start -->", eIdentifier = "<!-- 原始正文end -->";
                                    int sPos = contentHtml.IndexOf(sIdentifier);
                                    if (sPos != -1) {
                                        String content = contentHtml.Substring(sPos + sIdentifier.Length);
                                        int ePos = content.IndexOf(eIdentifier);
                                        newsInfo.m_content = content.Substring(0, ePos);
                                        FCFile.write(fileName, newsInfo.ToString());
                                    }
                                }
                            }
                        }
                        catch (Exception ex) {
                        }
                    }
                }
            }
            return 1;
        }

        /// <summary>
        /// 开始服务
        /// </summary>
        public override void start() {
            base.start();
            String dir = DataCenter.getDataPath() + "\\sinanews";
            if (!FCFile.isDirectoryExist(dir)) {
                FCFile.createDirectory(dir);
            }
            List<Security> securities = DataCenter.SecurityService.getSecurities();
            int securitiesSize = securities.Count;
            List<WorkDataInfo> dataInfos = new List<WorkDataInfo>();
            for (int i = 0; i < securitiesSize; i++) {
                SecurityDataInfo dataInfo = new SecurityDataInfo();
                dataInfo.m_id = i;
                dataInfo.m_security = securities[i];
                dataInfos.Add(dataInfo);
            }
            m_workThread.startWork(dataInfos);
        }
    }
}
