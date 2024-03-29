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
using System.Drawing;

namespace FaceCat {
    /// <summary>
    /// 行情系统
    /// </summary>
    public class Juhe : UIXmlEx {
        /// <summary>
        /// 创建行情系统
        /// </summary>
        public Juhe() {
        }

        /// <summary>
        /// 方法库
        /// </summary>
        private FCNative m_native;

        private double m_scaleFactor = 1;

        /// <summary>
        /// 获取或设置缩放因子
        /// </summary>
        public double ScaleFactor {
            get { return m_scaleFactor; }
            set { m_scaleFactor = value; }
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        private void initInterface() {
        }

        /// <summary>
        /// 加载XML
        /// </summary>
        /// <param name="xmlPath">XML路径</param>
        public void load(String xmlPath) {
            loadFile(xmlPath, null);
            m_native = Native;
            initInterface();
        }

        /// <summary>
        /// 重置缩放尺寸
        /// </summary>
        /// <param name="clientSize">客户端大小</param>
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
