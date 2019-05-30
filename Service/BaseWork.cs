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
    /// ���������߳�
    /// </summary>
    public class BaseWork {
        /// <summary>
        /// ��������
        /// </summary>
        public BaseWork() {
            m_workThread.registerQuitEvent(new QuitWorkEventHandler(onWorkQuit));
            m_workThread.registerRecvEvent(new StartWorkEventHandler(onWorkStart));
            m_workThread.RegisterWorkEvent(new WorkingEventHandler(onWorking));
        }

        /// <summary>
        /// ��ʷ�����̳߳�
        /// </summary>
        protected MultiThreadWork m_workThread = new MultiThreadWork();

        /// <summary>
        /// ��ȡ�Ƿ���������
        /// </summary>
        public bool IsRunning {
            get { return m_workThread.IsRunning; }
        }

        private String m_log = "";

        /// <summary>
        /// ��ȡ��������־
        /// </summary>
        public String Log {
            get { return m_log; }
            set { m_log = value; }
        }

        private int m_threads = 10;

        /// <summary>
        /// ��ȡ�������߳���
        /// </summary>
        public int Threads {
            get { return m_threads; }
            set { m_threads = value; }
        }

        /// <summary>
        /// �����˳�
        /// </summary>
        /// <param name="dataInfo">��Ϣ</param>
        public virtual void onWorkQuit(WorkDataInfo dataInfo) {
        }

        /// <summary>
        /// ��ʼ����
        /// </summary>
        /// <param name="dataInfo">��Ϣ</param>
        public virtual void onWorkStart(WorkDataInfo dataInfo) {
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="dataInfo">��Ϣ</param>
        /// <returns>״̬</returns>
        public virtual int onWorking(WorkDataInfo dataInfo) {
            return 0;
        }

        /// <summary>
        /// ��ʼ����
        /// </summary>
        public virtual void start() {
            m_log = "��ʼ����";
            m_workThread.start(m_threads);
        }

        /// <summary>
        /// ��������
        /// </summary>
        public virtual void stop() {
            m_log = "��������";
            m_workThread.stop();
        }
    }
}
