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

namespace FaceCat {
    /// <summary>
    /// 基础工作线程
    /// </summary>
    public class BaseWork {
        /// <summary>
        /// 创建工作
        /// </summary>
        public BaseWork() {
            m_workThread.registerQuitEvent(new QuitWorkEventHandler(onWorkQuit));
            m_workThread.registerRecvEvent(new StartWorkEventHandler(onWorkStart));
            m_workThread.RegisterWorkEvent(new WorkingEventHandler(onWorking));
        }

        /// <summary>
        /// 历史数据线程池
        /// </summary>
        protected MultiThreadWork m_workThread = new MultiThreadWork();

        /// <summary>
        /// 获取是否正在运行
        /// </summary>
        public bool IsRunning {
            get { return m_workThread.IsRunning; }
        }

        private String m_log = "";

        /// <summary>
        /// 获取或设置日志
        /// </summary>
        public String Log {
            get { return m_log; }
            set { m_log = value; }
        }

        private int m_threads = 10;

        /// <summary>
        /// 获取或设置线程数
        /// </summary>
        public int Threads {
            get { return m_threads; }
            set { m_threads = value; }
        }

        /// <summary>
        /// 工作退出
        /// </summary>
        /// <param name="dataInfo">信息</param>
        public virtual void onWorkQuit(WorkDataInfo dataInfo) {
        }

        /// <summary>
        /// 开始工作
        /// </summary>
        /// <param name="dataInfo">信息</param>
        public virtual void onWorkStart(WorkDataInfo dataInfo) {
        }

        /// <summary>
        /// 工作中
        /// </summary>
        /// <param name="dataInfo">信息</param>
        /// <returns>状态</returns>
        public virtual int onWorking(WorkDataInfo dataInfo) {
            return 0;
        }

        /// <summary>
        /// 开始服务
        /// </summary>
        public virtual void start() {
            m_log = "开始工作";
            m_workThread.start(m_threads);
        }

        /// <summary>
        /// 结束服务
        /// </summary>
        public virtual void stop() {
            m_log = "结束工作";
            m_workThread.stop();
        }
    }
}
