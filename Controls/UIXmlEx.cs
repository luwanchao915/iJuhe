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
using System.Xml;

namespace FaceCat {
    /// <summary>
    /// ��Ʊͼ�οؼ�Xml����
    /// </summary>
    public class UIXmlEx : FCUIXml {
        /// <summary>
        /// �����ؼ�
        /// </summary>
        /// <param name="node">�ڵ�</param>
        /// <param name="type">����</param>
        /// <returns>�ؼ�</returns>
        public override FCView createControl(XmlNode node, String type) {
            FCNative native = Native;
            if (type == "runningbutton") {
                return new RuningButton();
            }
            else if (type == "ribbonbutton") {
                return new RibbonButton();
            }
            else if (type == "windowex") {
                return new WindowEx();
            }
            else {
                return base.createControl(node, type);
            }
        }
    }

    /// <summary>
    /// ����XML��չ
    /// </summary>
    public class WindowXmlEx : UIXmlEx {
        /// <summary>
        /// ���ÿؼ������¼�
        /// </summary>
        private FCInvokeEvent m_invokeEvent;

        /// <summary>
        /// ������
        /// </summary>
        private FCNative m_native;

        private WindowEx m_window;

        /// <summary>
        /// ��ȡ�����ô���
        /// </summary>
        public WindowEx Window {
            get { return m_window; }
        }

        /// <summary>
        /// ��ť����¼�
        /// </summary>
        /// <param name="sender">������</param>
        /// <param name="mp">����</param>
        /// <param name="button">��ť</param>
        /// <param name="click">�������</param>
        /// <param name="delta">���ֹ���ֵ</param>
        private void clickButton(object sender, FCTouchInfo touchInfo) {
            if (touchInfo.m_firstTouch && touchInfo.m_clicks == 1) {
                FCView control = sender as FCView;
                if (m_window != null && control == m_window.CloseButton) {
                    close();
                }
            }
        }

        /// <summary>
        /// �ر�
        /// </summary>
        public virtual void close() {
            m_window.invoke("close");
        }

        /// <summary>
        /// ���ٷ���
        /// </summary>
        public override void delete() {
            if (!IsDeleted) {
                if (m_window != null) {
                    m_window.removeEvent(m_invokeEvent, FCEventID.INVOKE);
                    m_invokeEvent = null;
                    m_window.close();
                    m_window.delete();
                    m_window = null;
                }
                base.delete();
            }
        }


        /// <summary>
        /// ���ؽ���
        /// </summary>
        public virtual void load(FCNative native, string xmlName, string windowName) {
            Native = native;
            m_native = native;
            String xmlPath = DataCenter.getAppPath() + "\\config\\" + xmlName + ".xml";
            Script = new FaceCatScript(this);
            Native = m_native;
            loadFile(xmlPath, null);
            m_window = findControl(windowName) as WindowEx;
            m_invokeEvent = new FCInvokeEvent(invoke);
            m_window.addEvent(m_invokeEvent, FCEventID.INVOKE);
            //ע�����¼�
            registerEvents(m_window);
        }

        /// <summary>
        /// ���ÿؼ��̷߳���
        /// </summary>
        /// <param name="sender">������</param>
        /// <param name="args">����</param>
        private void invoke(object sender, object args) {
            onInvoke(args);
        }

        /// <summary>
        /// ���ÿؼ��̷߳���
        /// </summary>
        /// <param name="args">����</param>
        public void onInvoke(object args) {
            if (args != null && args.ToString() == "close") {
                delete();
                m_native.invalidate();
            }
        }

        /// <summary>
        /// ע���¼�
        /// </summary>
        /// <param name="control">�ؼ�</param>
        private void registerEvents(FCView control) {
            FCTouchEvent clickButtonEvent = new FCTouchEvent(clickButton);
            List<FCView> controls = control.getControls();
            int controlsSize = controls.Count;
            for (int i = 0; i < controlsSize; i++) {
                FCButton button = controls[i] as FCButton;
                if (button != null) {
                    button.addEvent(clickButtonEvent, FCEventID.CLICK);
                }
                registerEvents(controls[i]);
            }
        }

        /// <summary>
        /// ��ʾ
        /// </summary>
        public virtual void show() {
            m_window.Location = new FCPoint(-m_window.Width, -m_window.Height);
            m_window.animateShow(true);
            m_window.invalidate();
        }
    }
}
