/*��������èFaceCat��� v1.0 https://github.com/FaceCat007/facecat.git
 1.��ʼ��-�󶴳���Ա-�Ϻ����׿Ƽ���ʼ��-����KOL-�յ� (΢�ź�:suade1984);
 2.���ϴ�ʼ��-�Ϻ����׿Ƽ���ʼ��-Ԭ����(΢�ź�:wx627378127);
 3.���ϴ�ʼ��-Ф����(΢�ź�:xiaotianlong_luu);
 4.���Ͽ�����-������(΢�ź�:chenxiaoyangzxy)������-���(΢�ź�:cnnic_zhu);
 5.�ó���ԴЭ��ΪBSD����ӭ�����ǵĴ�ҵ����и���֧�֣���ӭ���࿪���߼��롣
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace FaceCat {
    /// <summary>
    /// �������ݷ���
    /// </summary>
    public class SinaNewsService : BaseWork {
        /// <summary>
        /// ��������
        /// </summary>
        public SinaNewsService() {
            Threads = 20;
        }

        /// <summary>
        /// �б��ַ
        /// </summary>
        private String m_listUrl = "http://vip.stock.finance.sina.com.cn/corp/go.php/vCB_AllNewsStock/symbol/{0}.phtml";

        /// <summary>
        /// �����˳�
        /// </summary>
        /// <param name="dataInfo">��Ϣ</param>
        public override void onWorkQuit(WorkDataInfo dataInfo) {
        }

        /// <summary>
        /// ��ʼ����
        /// </summary>
        /// <param name="dataInfo">��Ϣ</param>
        public override void onWorkStart(WorkDataInfo dataInfo) {
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="dataInfo">��Ϣ</param>
        /// <returns>״̬</returns>
        public override int onWorking(WorkDataInfo dataInfo) {
            Console.WriteLine(dataInfo.m_id.ToString());
            SecurityDataInfo securityDataInfo = dataInfo as SecurityDataInfo;
            String url = String.Format(m_listUrl, FCStrEx.ConvertDBCodeToSinaCode(securityDataInfo.m_security.m_code));
            Log = String.Format("����:{0}", securityDataInfo.m_security.m_code);
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
                                    Log = String.Format("����:{0}", securityDataInfo.m_security.m_code);
                                    String contentHtml = DataCenter.getHttpWebRequest(newsInfo.m_url, "UTF-8");
                                    String sIdentifier = "<!-- ԭʼ����start -->", eIdentifier = "<!-- ԭʼ����end -->";
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
        /// ��ʼ����
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
