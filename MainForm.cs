/*基于捂脸猫FaceCat框架 v1.0 https://github.com/FaceCat007/facecat.git
 1.创始人-矿洞程序员-上海宁米科技创始人-脉脉KOL-陶德 (微信号:suade1984);
 2.联合创始人-上海宁米科技创始人-袁立涛(微信号:wx627378127);
 3.联合创始人-肖添龙(微信号:xiaotianlong_luu);
 4.联合开发者-陈晓阳(微信号:chenxiaoyangzxy)，助理-朱炜(微信号:cnnic_zhu);
 5.该程序开源协议为BSD，欢迎对我们的创业活动进行各种支持，欢迎更多开发者加入。
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
    /// 示例控件
    /// </summary>
    public partial class MainForm : Form {
        /// <summary>
        ///  创建图形控件
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
        /// 控件管理器
        /// </summary>
        private WinHost m_host;


        /// <summary>
        /// 聚合系统
        /// </summary>
        private Juhe m_juhe;

        /// <summary>
        /// 控件库
        /// </summary>
        private FCNative m_native;

        /// <summary>
        /// 获取客户端尺寸
        /// </summary>
        /// <returns>客户端尺寸</returns>
        public FCSize getClientSize() {
            return new FCSize(ClientSize.Width, ClientSize.Height);
        }

        /// <summary>
        /// 窗体关闭事件
        /// </summary>
        /// <param name="e">事件参数</param>
        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
        }

        /// <summary>
        /// 尺寸改变方法
        /// </summary>
        /// <param name="e">参数</param>
        protected override void OnSizeChanged(EventArgs e) {
            base.OnSizeChanged(e);
            if (m_host != null) {
                m_juhe.resetScaleSize(getClientSize());
                Invalidate();
            }
        }

        /// <summary>
        /// 鼠标滚动方法
        /// </summary>
        /// <param name="e">参数</param>
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
        /// 消息监听
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