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
using System.Xml;

namespace FaceCat {
    /// <summary>
    /// 股票图形控件Xml解析
    /// </summary>
    public class UIXmlEx : FCUIXml {
        /// <summary>
        /// 创建控件
        /// </summary>
        /// <param name="node">节点</param>
        /// <param name="type">类型</param>
        /// <returns>控件</returns>
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
    /// 窗体XML扩展
    /// </summary>
    public class WindowXmlEx : UIXmlEx {
        /// <summary>
        /// 调用控件方法事件
        /// </summary>
        private FCInvokeEvent m_invokeEvent;

        /// <summary>
        /// 方法库
        /// </summary>
        private FCNative m_native;

        private WindowEx m_window;

        /// <summary>
        /// 获取或设置窗体
        /// </summary>
        public WindowEx Window {
            get { return m_window; }
        }

        /// <summary>
        /// 按钮点击事件
        /// </summary>
        /// <param name="sender">调用者</param>
        /// <param name="mp">坐标</param>
        /// <param name="button">按钮</param>
        /// <param name="click">点击次数</param>
        /// <param name="delta">滚轮滚动值</param>
        private void clickButton(object sender, FCTouchInfo touchInfo) {
            if (touchInfo.m_firstTouch && touchInfo.m_clicks == 1) {
                FCView control = sender as FCView;
                if (m_window != null && control == m_window.CloseButton) {
                    close();
                }
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public virtual void close() {
            m_window.invoke("close");
        }

        /// <summary>
        /// 销毁方法
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
        /// 加载界面
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
            //注册点击事件
            registerEvents(m_window);
        }

        /// <summary>
        /// 调用控件线程方法
        /// </summary>
        /// <param name="sender">调用者</param>
        /// <param name="args">参数</param>
        private void invoke(object sender, object args) {
            onInvoke(args);
        }

        /// <summary>
        /// 调用控件线程方法
        /// </summary>
        /// <param name="args">参数</param>
        public void onInvoke(object args) {
            if (args != null && args.ToString() == "close") {
                delete();
                m_native.invalidate();
            }
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="control">控件</param>
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
        /// 显示
        /// </summary>
        public virtual void show() {
            m_window.Location = new FCPoint(-m_window.Width, -m_window.Height);
            m_window.animateShow(true);
            m_window.invalidate();
        }
    }
}
