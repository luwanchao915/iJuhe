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
using System.Drawing;

namespace FaceCat {
    /// <summary>
    /// ����ϵͳ
    /// </summary>
    public class Juhe : UIXmlEx {
        /// <summary>
        /// ��������ϵͳ
        /// </summary>
        public Juhe() {
        }

        /// <summary>
        /// ������
        /// </summary>
        private FCNative m_native;

        private double m_scaleFactor = 1;

        /// <summary>
        /// ��ȡ��������������
        /// </summary>
        public double ScaleFactor {
            get { return m_scaleFactor; }
            set { m_scaleFactor = value; }
        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        private void initInterface() {
        }

        /// <summary>
        /// ����XML
        /// </summary>
        /// <param name="xmlPath">XML·��</param>
        public void load(String xmlPath) {
            loadFile(xmlPath, null);
            m_native = Native;
            initInterface();
        }

        /// <summary>
        /// �������ųߴ�
        /// </summary>
        /// <param name="clientSize">�ͻ��˴�С</param>
        public void resetScaleSize(FCSize clientSize) {
            if (Native != null) {
                m_native = Native;
            }
            if (m_native != null) {
                FCHost host = m_native.Host;
                FCSize nativeSize = m_native.DisplaySize;
                List<FCView> controls = m_native.getControls();
                int controlsSize = controls.Count;
                for (int i = 0; i < controlsSize; i++) {
                    FCWindowFrame frame = controls[i] as FCWindowFrame;
                    if (frame != null) {
                        WindowEx window = frame.getControls()[0] as WindowEx;
                        if (window != null && !window.AnimateMoving) {
                            FCPoint location = window.Location;
                            if (location.x < 10 || location.x > nativeSize.cx - 10) {
                                location.x = 0;
                            }
                            if (location.y < 30 || location.y > nativeSize.cy - 30) {
                                location.y = 0;
                            }
                            window.Location = location;
                        }
                    }
                }
                m_native.ScaleSize = new FCSize((int)(clientSize.cx * m_scaleFactor), (int)(clientSize.cy * m_scaleFactor));
                m_native.update();
            }
        }
    }
}
