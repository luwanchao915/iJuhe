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
using System.Threading;
using System.Windows.Forms;

namespace FaceCat {
    /// <summary>
    /// ������صĿ�
    /// </summary>
    public class NFunctionUI : CFunction {
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="indicator">ָ��</param>
        /// <param name="id">ID</param>
        /// <param name="name">����</param>
        /// <param name="withParameters">�Ƿ��в���</param>
        public NFunctionUI(FCScript indicator, int id, String name, FCUIXml xml) {
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
        /// ����
        /// </summary>
        private static string FUNCTIONS = "GETPROPERTY,SETPROPERTY,GETSENDER,ALERT,INVALIDATE,SHOWWINDOW,CLOSEWINDOW,STARTTIMER,STOPTIMER";

        /// <summary>
        /// ǰ׺
        /// </summary>
        private static string PREFIX = "";

        /// <summary>
        /// ��ʼ����
        /// </summary>
        private static int STARTINDEX = 2000;

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="var">����</param>
        /// <returns>���</returns>
        public override double onCalculate(CVariable var) {
            switch (var.m_functionID) {
                case 2000:
                    return GETPROPERTY(var);
                case 2001:
                    return SETPROPERTY(var);
                case 2002:
                    return GETSENDER(var);
                case 2003:
                    return ALERT(var);
                case 2004:
                    return INVALIDATE(var);
                case 2005:
                    return SHOWWINDOW(var);
                case 2006:
                    return CLOSEWINDOW(var);
                case 2007:
                    return STARTTIMER(var);
                case 2008:
                    return STOPTIMER(var);
                default:
                    return 0;
            }
        }

        /// <summary>
        /// ��ӷ���
        /// </summary>
        /// <param name="indicator">������</param>
        /// <param name="native">�ű�</param>
        /// <param name="xml">XML</param>
        /// <returns>ָ��</returns>
        public static void addFunctions(FCScript indicator, FCUIXml xml) {
            string[] functions = FUNCTIONS.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            int functionsSize = functions.Length;
            for (int i = 0; i < functionsSize; i++) {
                indicator.addFunction(new NFunctionUI(indicator, STARTINDEX + i, PREFIX + functions[i], xml));
            }
        }


        /// <summary>
        /// ������ʾ
        /// </summary>
        /// <param name="var">����</param>
        /// <returns>״̬</returns>
        private double ALERT(CVariable var) {
            double result = 0;
            int len = var.m_parameters.Length;
            if (len == 1) {
                if (DialogResult.OK == MessageBox.Show(m_indicator.getText(var.m_parameters[0]))) {
                    result = 1;
                }
            }
            else {
                if (DialogResult.OK == MessageBox.Show(m_indicator.getText(var.m_parameters[0]),
                    m_indicator.getText(var.m_parameters[1]))) {
                    result = 1;
                }
            }
            return result;
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="var">����</param>
        /// <returns>״̬</returns>
        public double GETPROPERTY(CVariable var) {
            FaceCatScript fScript = m_xml.Script as FaceCatScript;
            string name = m_indicator.getText(var.m_parameters[1]);
            string propertyName = m_indicator.getText(var.m_parameters[2]);
            string text = fScript.getProperty(name, propertyName);
            CVariable newVar = new CVariable(m_indicator);
            newVar.m_expression = "'" + text + "'";
            m_indicator.setVariable(var.m_parameters[0], newVar);
            return 0;
        }

        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <param name="var">����</param>
        /// <returns>״̬</returns>
        public double GETSENDER(CVariable var) {
            FaceCatScript fScript = m_xml.Script as FaceCatScript;
            string text = fScript.getSender();
            CVariable newVar = new CVariable(m_indicator);
            newVar.m_expression = "'" + text + "'";
            m_indicator.setVariable(var.m_parameters[0], newVar);
            return 0;
        }

        /// <summary>
        /// ˢ�½���
        /// </summary>
        /// <param name="var">����</param>
        /// <returns>״̬</returns>
        private double INVALIDATE(CVariable var) {
            if (m_xml != null) {
                m_xml.Native.invalidate();
            }
            return 0;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="var">����</param>
        /// <returns>״̬</returns>
        private double SETPROPERTY(CVariable var) {
            FaceCatScript fScript = m_xml.Script as FaceCatScript;
            string name = m_indicator.getText(var.m_parameters[0]);
            string propertyName = m_indicator.getText(var.m_parameters[1]);
            string propertyValue = m_indicator.getText(var.m_parameters[2]);
            fScript.setProperty(name, propertyName, propertyValue);
            return 0;
        }

        /// <summary>
        /// �رմ���
        /// </summary>
        /// <param name="var">����</param>
        /// <returns>״̬</returns>
        private double CLOSEWINDOW(CVariable var) {
            WindowXmlEx windowXmlEx = m_xml as WindowXmlEx;
            if (windowXmlEx != null) {
                windowXmlEx.close();
            }
            return 0;
        }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        /// <param name="var">����</param>
        /// <returns>״̬</returns>
        private double SHOWWINDOW(CVariable var) {
            string xmlName = m_indicator.getText(var.m_parameters[0]);
            string windowName = m_indicator.getText(var.m_parameters[1]);
            WindowXmlEx window = new WindowXmlEx();
            window.load(m_xml.Native, xmlName, windowName);
            window.show();
            return 0;
        }

        /// <summary>
        /// ��ʼ���
        /// </summary>
        /// <param name="var">����</param>
        /// <returns>״̬</returns>
        private double STARTTIMER(CVariable var) {
            FCView control = m_xml.findControl(m_indicator.getText(var.m_parameters[0]));
            control.startTimer((int)m_indicator.getValue(var.m_parameters[1]), (int)m_indicator.getValue(var.m_parameters[2]));
            return 0;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="var">����</param>
        /// <returns>״̬</returns>
        private double STOPTIMER(CVariable var) {
            FCView control = m_xml.findControl(m_indicator.getText(var.m_parameters[0]));
            control.stopTimer((int)m_indicator.getValue(var.m_parameters[1]));
            return 0;
        }
    }
}