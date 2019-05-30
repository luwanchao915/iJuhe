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
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace FaceCat {
    /// <summary>
    /// ��������
    /// </summary>
    public class DataCenter {
        private static SecurityService m_securityService = new SecurityService();

        /// <summary>
        /// ��ȡ֤ȯ����
        /// </summary>
        public static SecurityService SecurityService {
            get { return DataCenter.m_securityService; }
        }

        private static SinaNewsService m_sinaNewsService = new SinaNewsService();

        /// <summary>
        /// ��ȡ�������ݷ���
        /// </summary>
        public static SinaNewsService SinaNewsService {
            get { return m_sinaNewsService; }
        }

        private static Dictionary<string, BaseWork> m_works = new Dictionary<string, BaseWork>();

        /// <summary>
        /// ��ȡ���еĹ���
        /// </summary>
        public static Dictionary<string, BaseWork> Works {
            get { return DataCenter.m_works; }
        }

        /// <summary>
        /// ��ȡ����·��
        /// </summary>
        /// <returns>����·��</returns>
        public static String getAppPath() {
            return Application.StartupPath;
        }

        /// <summary>
        /// ���ݻ�ȡ�洢·��
        /// </summary>
        /// <returns>����·��</returns>
        public static String getDataPath() {
            return Application.StartupPath;
        }

        /// <summary>
        /// ��ȡ�����Զ��HTTP��ַ
        /// </summary>
        /// <returns></returns>
        public static String getQuoteDataUrl() {
            return "http://114.55.4.91";
        }

        /// <summary>
        /// ��ȡ���鶯̬����Ŀ¼
        /// </summary>
        /// <returns>Ŀ¼</returns>
        public static String getQuoteDynamicDataDir() {
            return getAppPath() + "\\data";
        }

        /// <summary>
        /// ��ȡ���龲̬����Ŀ¼
        /// </summary>
        /// <returns>Ŀ¼</returns>
        public static String GetQuoteStaticDataDir() {
            return getAppPath() + "\\data";
        }

        /// <summary>
        /// ��ȡ��ҳ����
        /// </summary>
        /// <param name="url">��ַ</param>
        /// <param name="encoding">��ַ</param>
        /// <returns>ҳ��Դ��</returns>
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
        /// ��������
        /// </summary>
        public static void startService() {
            m_works["sinanews"] = DataCenter.SinaNewsService;
        }
    }
}
