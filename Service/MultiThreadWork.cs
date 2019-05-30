/*基于捂脸猫FaceCat框架 v1.0 https://github.com/FaceCat007/facecat.git
 1.创始人-矿洞程序员-上海宁米科技创始人-脉脉KOL-陶德 (微信号:suade1984);
 2.联合创始人-上海宁米科技创始人-袁立涛(微信号:wx627378127);
 3.联合创始人-肖添龙(微信号:xiaotianlong_luu);
 4.联合开发者-陈晓阳(微信号:chenxiaoyangzxy)，助理-朱炜(微信号:cnnic_zhu);
 5.该程序开源协议为BSD，欢迎对我们的创业活动进行各种支持，欢迎更多开发者加入。
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FaceCat {
    /// <summary>
    /// 工作数据信息
    /// </summary>
    public class WorkDataInfo : IDisposable {
        /// <summary>
        /// 键
        /// </summary>
        public int m_id;

        /// <summary>
        /// 执行次数
        /// </summary>
        public int m_pos;

        /// <summary>
        /// 线程ID
        /// </summary>
        public int m_threadID;

        /// <summary>
        /// 销毁资源方法
        /// </summary>
        public virtual void Dispose() {
        }
    }

    /// <summary>
    /// 开始事件
    /// </summary>
    /// <param name="dataInfo">数据信息</param>
    /// <returns>推送信息</returns>
    public delegate void StartWorkEventHandler(WorkDataInfo dataInfo);

    /// <summary>
    /// 退出事件
    /// </summary>
    /// <param name="dataInfo">数据信息</param>
    public delegate void QuitWorkEventHandler(WorkDataInfo dataInfo);

    /// <summary>
    /// 执行事件
    /// </summary>
    /// <param name="dataInfo">数据信息</param>
    /// <returns>状态</returns>
    public delegate int WorkingEventHandler(WorkDataInfo dataInfo);

    /// <summary>
    /// 多线程
    /// </summary>
    public class MultiThreadWork {
        /// <summary>
        /// 创建推送线程池
        /// </summary>
        public MultiThreadWork() {
        }

        /// <summary>
        /// 析构函数
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
        /// 数据信息
        /// </summary>
        private Dictionary<int, List<WorkDataInfo>> m_dataInfos = new Dictionary<int, List<WorkDataInfo>>();

        /// <summary>
        /// 待处理的消息
        /// </summary>
        private List<WorkDataInfo> m_messages = new List<WorkDataInfo>();

        /// <summary>
        /// 退出事件
        /// </summary>
        private QuitWorkEventHandler m_quitEvent;

        /// <summary>
        /// 开始事件
        /// </summary>
        private StartWorkEventHandler m_startEvent;

        /// <summary>
        /// 停止推送信息
        /// </summary>
        private List<WorkDataInfo> m_stopPushDatas = new List<WorkDataInfo>();

        /// <summary>
        /// 线程列表
        /// </summary>
        private List<Thread> m_threads = new List<Thread>();

        /// <summary>
        /// 工作事件
        /// </summary>
        private WorkingEventHandler m_workEvent;

        private bool m_isRunning;

        /// <summary>
        /// 获取或设置是否正在运行
        /// </summary>
        public bool IsRunning {
            get { return m_isRunning; }
            set { m_isRunning = value; }
        }

        /// <summary>
        /// 处理方法
        /// </summary>
        /// <param name="id">线程编号</param>
        public void onWork(int id) {
            //新增消息
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
            //执行方法
            if (m_workEvent != null) {
                List<WorkDataInfo> dataInfos = m_dataInfos[id];
                int dataInfosSize = dataInfos.Count;
                //检测停止推送
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
        /// 退出
        /// </summary>
        /// <param name="reqInfo">请求信息</param>
        /// <returns>状态</returns>
        public int quitWork(WorkDataInfo reqInfo) {
            lock (m_stopPushDatas) {
                m_stopPushDatas.Add(reqInfo);
            }
            return 0;
        }

        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="dataInfo">消息</param>
        public void startWork(WorkDataInfo dataInfo) {
            lock (m_messages) {
                m_messages.Add(dataInfo);
            }
        }

        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="dataInfos">消息列表</param>
        public void startWork(List<WorkDataInfo> dataInfos) {
            lock (m_messages) {
                m_messages.AddRange(dataInfos.ToArray());
            }
        }

        /// <summary>
        /// 注册退出事件
        /// </summary>
        /// <param name="quitEvent">事件</param>
        public void registerQuitEvent(QuitWorkEventHandler quitEvent) {
            m_quitEvent = quitEvent;
        }

        /// <summary>
        /// 注册接收事件
        /// </summary>
        /// <param name="recvEvent">事件</param>
        public void registerRecvEvent(StartWorkEventHandler recvEvent) {
            m_startEvent = recvEvent;
        }

        /// <summary>
        /// 注册工作事件
        /// </summary>
        /// <param name="workEvent">事件</param>
        public void RegisterWorkEvent(WorkingEventHandler workEvent) {
            m_workEvent = workEvent;
        }

        /// <summary>
        /// 启动线程
        /// </summary>
        /// <param name="size">线程数</param>
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
        /// 停止工作
        /// </summary>
        public void stop() {
            m_isRunning = false;
            int threadsSize = m_threads.Count;
            for (int i = 0; i < threadsSize; i++) {
                m_threads[i].Abort();
            }
        }

        /// <summary>
        /// 处理消息
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
