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

namespace FaceCat {
    /// <summary>
    /// ����������Ϣ
    /// </summary>
    public class WorkDataInfo : IDisposable {
        /// <summary>
        /// ��
        /// </summary>
        public int m_id;

        /// <summary>
        /// ִ�д���
        /// </summary>
        public int m_pos;

        /// <summary>
        /// �߳�ID
        /// </summary>
        public int m_threadID;

        /// <summary>
        /// ������Դ����
        /// </summary>
        public virtual void Dispose() {
        }
    }

    /// <summary>
    /// ��ʼ�¼�
    /// </summary>
    /// <param name="dataInfo">������Ϣ</param>
    /// <returns>������Ϣ</returns>
    public delegate void StartWorkEventHandler(WorkDataInfo dataInfo);

    /// <summary>
    /// �˳��¼�
    /// </summary>
    /// <param name="dataInfo">������Ϣ</param>
    public delegate void QuitWorkEventHandler(WorkDataInfo dataInfo);

    /// <summary>
    /// ִ���¼�
    /// </summary>
    /// <param name="dataInfo">������Ϣ</param>
    /// <returns>״̬</returns>
    public delegate int WorkingEventHandler(WorkDataInfo dataInfo);

    /// <summary>
    /// ���߳�
    /// </summary>
    public class MultiThreadWork {
        /// <summary>
        /// ���������̳߳�
        /// </summary>
        public MultiThreadWork() {
        }

        /// <summary>
        /// ��������
        /// </summary>
        ~MultiThreadWork() {
            m_dataInfos.Clear();
            lock (m_messages) {
                m_messages.Clear();
            }
            m_quitEvent = null;
            m_startEvent = null;
            lock (m_stopPushDatas) {
                m_stopPushDatas.Clear();
            }
            m_workEvent = null;
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        private Dictionary<int, List<WorkDataInfo>> m_dataInfos = new Dictionary<int, List<WorkDataInfo>>();

        /// <summary>
        /// ���������Ϣ
        /// </summary>
        private List<WorkDataInfo> m_messages = new List<WorkDataInfo>();

        /// <summary>
        /// �˳��¼�
        /// </summary>
        private QuitWorkEventHandler m_quitEvent;

        /// <summary>
        /// ��ʼ�¼�
        /// </summary>
        private StartWorkEventHandler m_startEvent;

        /// <summary>
        /// ֹͣ������Ϣ
        /// </summary>
        private List<WorkDataInfo> m_stopPushDatas = new List<WorkDataInfo>();

        /// <summary>
        /// �߳��б�
        /// </summary>
        private List<Thread> m_threads = new List<Thread>();

        /// <summary>
        /// �����¼�
        /// </summary>
        private WorkingEventHandler m_workEvent;

        private bool m_isRunning;

        /// <summary>
        /// ��ȡ�������Ƿ���������
        /// </summary>
        public bool IsRunning {
            get { return m_isRunning; }
            set { m_isRunning = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="id">�̱߳��</param>
        public void onWork(int id) {
            //������Ϣ
            lock (m_messages) {
                int messagesSize = m_messages.Count;
                if (messagesSize > 0) {
                    for (int i = 0; i < messagesSize; i++) {
                        if (m_startEvent != null) {
                            m_startEvent(m_messages[i]);
                            m_dataInfos[id].Add(m_messages[i]);
                            m_messages.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            //ִ�з���
            if (m_workEvent != null) {
                List<WorkDataInfo> dataInfos = m_dataInfos[id];
                int dataInfosSize = dataInfos.Count;
                //���ֹͣ����
                List<WorkDataInfo> stopPushDatas = new List<WorkDataInfo>();
                int stopPushDatasSize = m_stopPushDatas.Count;
                if (stopPushDatasSize > 0) {
                    lock (m_stopPushDatas) {
                        stopPushDatasSize = m_stopPushDatas.Count;
                        for (int i = 0; i < stopPushDatasSize; i++) {
                            stopPushDatas.Add(m_stopPushDatas[i]);
                        }
                    }
                }
                for (int i = 0; i < dataInfosSize; i++) {
                    WorkDataInfo pushDataInfo = dataInfos[i];
                    pushDataInfo.m_threadID = id;
                    int state = 0;
                    if (stopPushDatasSize > 0) {
                        for (int j = 0; j < stopPushDatasSize; j++) {
                            WorkDataInfo reqDataInfo = stopPushDatas[j];
                            if (reqDataInfo.m_id == pushDataInfo.m_id) {
                                lock (m_stopPushDatas) {
                                    int spdSize = m_stopPushDatas.Count;
                                    for (int s = 0; s < spdSize; s++) {
                                        if (m_stopPushDatas[s].m_id == reqDataInfo.m_id) {
                                            m_stopPushDatas.RemoveAt(s);
                                            break;
                                        }
                                    }
                                }
                                state = -1;
                            }
                        }
                    }
                    if (state == 0) {
                        state = m_workEvent(pushDataInfo);
                    }
                    if (state <= 0) {
                        if (m_quitEvent != null) {
                            m_quitEvent(pushDataInfo);
                        }
                        dataInfos.RemoveAt(i);
                        i--;
                        dataInfosSize--;
                    }
                }
            }
        }

        /// <summary>
        /// �˳�
        /// </summary>
        /// <param name="reqInfo">������Ϣ</param>
        /// <returns>״̬</returns>
        public int quitWork(WorkDataInfo reqInfo) {
            lock (m_stopPushDatas) {
                m_stopPushDatas.Add(reqInfo);
            }
            return 0;
        }

        /// <summary>
        /// ��ʼ
        /// </summary>
        /// <param name="dataInfo">��Ϣ</param>
        public void startWork(WorkDataInfo dataInfo) {
            lock (m_messages) {
                m_messages.Add(dataInfo);
            }
        }

        /// <summary>
        /// ��ʼ
        /// </summary>
        /// <param name="dataInfos">��Ϣ�б�</param>
        public void startWork(List<WorkDataInfo> dataInfos) {
            lock (m_messages) {
                m_messages.AddRange(dataInfos.ToArray());
            }
        }

        /// <summary>
        /// ע���˳��¼�
        /// </summary>
        /// <param name="quitEvent">�¼�</param>
        public void registerQuitEvent(QuitWorkEventHandler quitEvent) {
            m_quitEvent = quitEvent;
        }

        /// <summary>
        /// ע������¼�
        /// </summary>
        /// <param name="recvEvent">�¼�</param>
        public void registerRecvEvent(StartWorkEventHandler recvEvent) {
            m_startEvent = recvEvent;
        }

        /// <summary>
        /// ע�Ṥ���¼�
        /// </summary>
        /// <param name="workEvent">�¼�</param>
        public void RegisterWorkEvent(WorkingEventHandler workEvent) {
            m_workEvent = workEvent;
        }

        /// <summary>
        /// �����߳�
        /// </summary>
        /// <param name="size">�߳���</param>
        public void start(int size) {
            m_isRunning = true;
            for (int i = 0; i < size; i++) {
                m_dataInfos[i] = new List<WorkDataInfo>();
                Thread thread = new Thread(new ParameterizedThreadStart(onWork));
                thread.IsBackground = true;
                object[] parameters = new object[2];
                parameters[0] = this;
                parameters[1] = i;
                thread.Start(parameters);
                m_threads.Add(thread);
            }
        }

        /// <summary>
        /// ֹͣ����
        /// </summary>
        public void stop() {
            m_isRunning = false;
            int threadsSize = m_threads.Count;
            for (int i = 0; i < threadsSize; i++) {
                m_threads[i].Abort();
            }
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        private void onWork(object args) {
            object[] parameters = (object[])args;
            int id = (int)parameters[1];
            while (true) {
                onWork(id);
                Thread.Sleep(1);
            }
        }
    }
}
