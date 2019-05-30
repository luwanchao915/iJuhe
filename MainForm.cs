/*��������èFaceCat��� v1.0 https://github.com/FaceCat007/facecat.git
 1.��ʼ��-�󶴳���Ա-�Ϻ����׿Ƽ���ʼ��-����KOL-�յ� (΢�ź�:suade1984);
 2.���ϴ�ʼ��-�Ϻ����׿Ƽ���ʼ��-Ԭ����(΢�ź�:wx627378127);
 3.���ϴ�ʼ��-Ф����(΢�ź�:xiaotianlong_luu);
 4.���Ͽ�����-������(΢�ź�:chenxiaoyangzxy)������-���(΢�ź�:cnnic_zhu);
 5.�ó���ԴЭ��ΪBSD����ӭ�����ǵĴ�ҵ����и���֧�֣���ӭ���࿪���߼��롣
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FaceCat {
    /// <summary>
    /// ʾ���ؼ�
    /// </summary>
    public partial class MainForm : Form {
        /// <summary>
        ///  ����ͼ�οؼ�
        /// </summary>
        public MainForm() {
            InitializeComponent();
            m_juhe = new Juhe();
            m_juhe.createNative();
            m_juhe.Script = new FaceCatScript(m_juhe);
            m_native = m_juhe.Native;
            m_native.Paint = new GdiPlusPaintEx();
            m_host = new WinHostEx();
            m_host.Native = m_native;
            m_native.Host = m_host;
            m_host.HWnd = Handle;
            m_native.AllowScaleSize = true;
            m_native.DisplaySize = new FCSize(ClientSize.Width, ClientSize.Height);
            m_juhe.resetScaleSize(getClientSize());
            Invalidate();
            m_juhe.load(DataCenter.getAppPath() + "\\config\\MainFrame.html");
            m_native.update();
        }

        /// <summary>
        /// �ؼ�������
        /// </summary>
        private WinHost m_host;


        /// <summary>
        /// �ۺ�ϵͳ
        /// </summary>
        private Juhe m_juhe;

        /// <summary>
        /// �ؼ���
        /// </summary>
        private FCNative m_native;

        /// <summary>
        /// ��ȡ�ͻ��˳ߴ�
        /// </summary>
        /// <returns>�ͻ��˳ߴ�</returns>
        public FCSize getClientSize() {
            return new FCSize(ClientSize.Width, ClientSize.Height);
        }

        /// <summary>
        /// ����ر��¼�
        /// </summary>
        /// <param name="e">�¼�����</param>
        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
        }

        /// <summary>
        /// �ߴ�ı䷽��
        /// </summary>
        /// <param name="e">����</param>
        protected override void OnSizeChanged(EventArgs e) {
            base.OnSizeChanged(e);
            if (m_host != null) {
                m_juhe.resetScaleSize(getClientSize());
                Invalidate();
            }
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="e">����</param>
        protected override void OnMouseWheel(MouseEventArgs e) {
            base.OnMouseWheel(e);
            if (m_host.isKeyPress(0x11)) {
                double scaleFactor = m_juhe.ScaleFactor;
                if (e.Delta > 0) {
                    if (scaleFactor > 0.2) {
                        scaleFactor -= 0.1;
                    }
                } else if (e.Delta < 0) {
                    if (scaleFactor < 10) {
                        scaleFactor += 0.1;
                    }
                }
                m_juhe.ScaleFactor = scaleFactor;
                m_juhe.resetScaleSize(getClientSize());
                Invalidate();
            }
        }

        /// <summary>
        /// ��Ϣ����
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m) {
            if (m_host != null) {
                if (m_host.onMessage(ref m) > 0) {
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }
}