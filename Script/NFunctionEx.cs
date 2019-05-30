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
using FaceCat;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace FaceCat {
    /// <summary>
    /// ��ʾ����
    /// </summary>
    public class NFunctionEx : CFunction {
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="indicator">ָ��</param>
        /// <param name="id">ID</param>
        /// <param name="name">����</param>
        /// <param name="withParameters">�Ƿ��в���</param>
        public NFunctionEx(FCScript indicator, int id, String name, FCUIXml xml) {
            m_indicator = indicator;
            m_ID = id;
            m_name = name;
            m_xml = xml;
        }

        /// <summary>
        /// ָ��
        /// </summary>
        public FCScript m_indicator;

        /// <summary>
        /// XML����
        /// </summary>
        public FCUIXml m_xml;

        /// <summary>
        /// �����ֶ�
        /// </summary>
        private const String FUNCTIONS = "JUHE.SERVICESTATE,JUHE.STARTSERVICE,JUHE.STOPSERVICE";

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="var">����</param>
        /// <returns>���</returns>
        public override double onCalculate(CVariable var) {
            switch (var.m_functionID) {
                case 1000000:
                    return JUHE_SERVICESTATE(var);
                case 1000001:
                    return JUHE_STARTSERVICE(var);
                case 1000002:
                    return JUHE_STOPSERVICE(var);
                default:
                    return 0;
            }
        }

        /// <summary>
        /// ����ָ��
        /// </summary>
        /// <param name="native">������</param>
        /// <param name="script">�ű�</param>
        /// <param name="xml">XML</param>
        /// <returns>ָ��</returns>
        public static FCScript createIndicator(string script, FCUIXml xml) {
            FCScript indicator = new FCScript();
            FCDataTable table = new FCDataTable();
            indicator.DataSource = table;
            NFunctionBase.addFunctions(indicator, xml.Native);
            NFunctionUI.addFunctions(indicator, xml);
            int index = 1000000;
            string[] functions = FUNCTIONS.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            int functionsSize = functions.Length;
            for (int i = 0; i < functionsSize; i++) {
                indicator.addFunction(new NFunctionEx(indicator, index + i, functions[i], xml));
            }
            indicator.Script = script;
            table.addColumn(0);
            table.set(0, 0, 0);
            indicator.onCalculate(0);
            return indicator;
        }

        /// <summary>
        /// ����״̬
        /// </summary>
        /// <param name="var">����</param>
        /// <returns>״̬</returns>
        private double JUHE_SERVICESTATE(CVariable var) {
            string serviceName = m_indicator.getText(var.m_parameters[0]);
            if (serviceName == "all") {
                foreach (BaseWork work in DataCenter.Works.Values) {
                    if (work.IsRunning) {
                        return 1;
                    }
                }
                return 0;
            }
            else {
                return DataCenter.Works[serviceName.ToLower()].IsRunning ? 1 : 0;
            }
        }

        /// <summary>
        /// ��ʼ����
        /// </summary>
        /// <param name="var">����</param>
        /// <returns>״̬</returns>
        private double JUHE_STARTSERVICE(CVariable var) {
            string serviceName = m_indicator.getText(var.m_parameters[0]).ToLower();
            DataCenter.Works[serviceName].start();
            return 0;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="var">����</param>
        /// <returns>״̬</returns>
        private double JUHE_STOPSERVICE(CVariable var) {
            string serviceName = m_indicator.getText(var.m_parameters[0]).ToLower();
            DataCenter.Works[serviceName].stop();
            return 0;
        }
    }
}
