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
using System.Net;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FaceCat {
    /// <summary>
    /// ��Ʊ����
    /// </summary>
    public class SecurityService {
        /// <summary>
        /// ��ȡ֤ȯ�б�
        /// </summary>
        /// <returns>֤ȯ�б�</returns>
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
