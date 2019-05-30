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
    /// 重绘窗体
    /// </summary>
    public class WindowEx : FCWindow {
        /// <summary>
        /// 创建窗体
        /// </summary>
        public WindowEx() {
            BackColor = FCColor.None;
            BorderColor = FCDraw.FCCOLORS_LINECOLOR3;
            CaptionHeight = 23;
            Font = new FCFont("SimSun", 14, true, false, false);
            TextColor = FCColor.None;
            Opacity = 0;
            ShadowColor = FCDraw.FCCOLORS_BACKCOLOR5;
        }

        /// <summary>
        /// 移动方向
        /// </summary>
        private int m_animateDirection = -1;

        /// <summary>
        /// 动画类型
        /// </summary>
        private int m_animateType = 0;

        /// <summary>
        /// 随机种子
        /// </summary>
        private Random m_rd = new Random();

        /// <summary>
        /// 秒表ID
        /// </summary>
        private int m_timerID = FCView.getNewTimerID();

        private bool m_animateMoving;

        /// <summary>
        /// 获取是否正在动画移动
        /// </summary>
        public bool AnimateMoving {
            get { return m_animateMoving; }
        }

        private RibbonButton m_closeButton;

        /// <summary>
        /// 获取或设置关闭按钮
        /// </summary>
        public RibbonButton CloseButton {
            get { return m_closeButton; }
            set { m_closeButton = value; }
        }

        private bool m_isChildWindow;

        /// <summary>
        /// 获取或设置是否子窗体
        /// </summary>
        public bool IsChildWindow {
            get { return m_isChildWindow; }
            set { m_isChildWindow = value; }
        }

        /// <summary>
        /// 以动画形式隐藏
        /// </summary>
        public void animateHide() {
            m_animateType = 1;
            FCNative native = Native;
            FCHost host = native.Host;
            m_animateDirection = m_rd.Next(0, 4);
            startTimer(m_timerID, 10);
            m_animateMoving = true;
            host.AllowOperate = false;
        }

        /// <summary>
        /// 以动画形式显示
        /// </summary>
        /// <param name="showDialog">是否对话框打开</param>
        public void animateShow(bool showDialog) {
            m_animateType = 0;
            FCNative native = Native;
            FCHost host = native.Host;
            FCSize nativeSize = native.DisplaySize;
            int width = Width, height = Height, mx = (nativeSize.cx - width) / 2, my = (nativeSize.cy - height) / 2, x = mx, y = my;
            m_animateDirection = m_rd.Next(0, 4);
            switch (m_animateDirection) {
                case 0:
                    x = -width;
                    break;
                case 1:
                    x = nativeSize.cx;
                    break;
                case 2:
                    y = -height;
                    break;
                case 3:
                    y = nativeSize.cy;
                    break;
            }
            FCPoint location = new FCPoint(x, y);
            Location = location;
            if (showDialog) {
                this.showDialog();
            }
            else {
                show();
            }
            update();
            startTimer(m_timerID, 10);
            m_animateMoving = true;
            host.AllowOperate = false;
        }

        /// <summary>
        /// 销毁控件方法
        /// </summary>
        public override void delete() {
            if (!IsDeleted) {
                m_animateMoving = false;
                stopTimer(m_timerID);
            }
            base.delete();
        }

        /// <summary>
        /// 控件添加方法
        /// </summary>
        public override void onAdd() {
            base.onAdd();
            if (m_closeButton == null) {
                m_closeButton = new RibbonButton();
                m_closeButton.IsClose = true;
                m_closeButton.Name = "btnClose";
                FCSize buttonSize = new FCSize(22, 22);
                m_closeButton.Size = buttonSize;
                addControl(m_closeButton);
            }
        }

        /// <summary>
        /// 拖动开始方法
        /// </summary>
        /// <param name="startOffset">偏移启动量</param>
        public override void onDragReady(ref FCPoint startOffset) {
            startOffset.x = 0;
            startOffset.y = 0;
        }

        /// <summary>
        /// 重绘前景方法
        /// </summary>
        /// <param name="paint">绘图对象</param>
        /// <param name="clipRect">裁剪区域</param>
        public override void onPaintBackground(FCPaint paint, FCRect clipRect) {
            int width = Width;
            int height = Height;
            FCRect rect = new FCRect(0, 0, width, height);
            long backColor = FCDraw.FCCOLORS_WINDOWBACKCOLOR;
            long foreColor = FCDraw.FCCOLORS_WINDOWFORECOLOR;
            if (paint.supportTransparent()) {
                backColor = FCDraw.FCCOLORS_WINDOWBACKCOLOR2;
            }
            int captionHeight = CaptionHeight;
            FCRect hRect = new FCRect(0, 0, width, captionHeight);
            paint.fillRect(backColor, hRect);
            FCRect lRect = new FCRect(0, captionHeight, 5, height);
            paint.fillRect(backColor, lRect);
            FCRect rRect = new FCRect(width - 5, captionHeight, width, height);
            paint.fillRect(backColor, rRect);
            FCRect bRect = new FCRect(0, height - 5, width, height);
            paint.fillRect(backColor, bRect);
            FCRect contentRect = rect;
            contentRect.top += captionHeight;
            contentRect.bottom -= 5;
            contentRect.left += 5;
            contentRect.right -= 5;
            if (contentRect.right - contentRect.left > 0 && contentRect.bottom - contentRect.top > 0) {
                paint.fillRect(FCDraw.FCCOLORS_WINDOWCONTENTBACKCOLOR, contentRect);
            }
            FCDraw.drawText(paint, Text, foreColor, Font, 5, 5);
        }

        /// <summary>
        /// 秒表方法
        /// </summary>
        /// <param name="timerID">秒表ID</param>
        public override void onTimer(int timerID) {
            base.onTimer(timerID);
            if (m_timerID == timerID) {
                FCNative native = Native;
                FCHost host = native.Host;
                FCSize nativeSize = native.DisplaySize;
                int x = Left, y = Top, width = Width, height = Height;
                if (m_animateType == 0) {
                    int xSub = nativeSize.cx / 4;
                    int ySub = nativeSize.cy / 4;
                    int mx = (nativeSize.cx - width) / 2;
                    int my = (nativeSize.cy - height) / 2;
                    float opacity = Opacity;
                    opacity += 0.1F;
                    if (opacity > 1) {
                        opacity = 1;
                    }
                    Opacity = opacity;
                    bool stop = false;
                    switch (m_animateDirection) {
                        //从左向右
                        case 0:
                            if (x + xSub >= mx) {
                                x = mx;
                                stop = true;
                            }
                            else {
                                x += xSub;
                            }
                            break;
                        //从右向左
                        case 1:
                            if (x - xSub <= mx) {
                                x = mx;
                                stop = true;
                            }
                            else {
                                x -= xSub;
                            }
                            break;
                        //从上往下
                        case 2:
                            if (y + ySub >= my) {
                                y = my;
                                stop = true;
                            }
                            else {
                                y += ySub;
                            }
                            break;
                        //从下往上
                        case 3:
                            if (y - ySub <= my) {
                                y = my;
                                stop = true;
                            }
                            else {
                                y -= ySub;
                            }
                            break;
                    }
                    if (stop) {
                        Opacity = 1;
                        m_animateMoving = false;
                        stopTimer(m_timerID);
                        host.AllowOperate = true;
                    }
                }
                else {
                    int xSub = nativeSize.cx / 4;
                    int ySub = nativeSize.cy / 4;
                    float opacity = Opacity;
                    opacity -= 0.1F;
                    if (opacity < 0) {
                        opacity = 0;
                    }
                    Opacity = opacity;
                    bool stop = false;
                    switch (m_animateDirection) {
                        //从右向左
                        case 0:
                            if (x - xSub <= -width) {
                                x = 0;
                                stop = true;
                            }
                            else {
                                x -= xSub;
                            }
                            break;
                        //从左向右
                        case 1:
                            if (x + xSub >= nativeSize.cx) {
                                x = 0;
                                stop = true;
                            }
                            else {
                                x += xSub;
                            }
                            break;
                        //从下往上
                        case 2:
                            if (y - ySub <= -height) {
                                y = 0;
                                stop = true;
                            }
                            else {
                                y -= ySub;
                            }
                            break;
                        //从上往下
                        case 3:
                            if (y + ySub >= nativeSize.cy) {
                                y = 0;
                                stop = true;
                            }
                            else {
                                y += ySub;
                            }
                            break;
                    }
                    if (stop) {
                        Opacity = 0;
                        m_animateMoving = false;
                        stopTimer(m_timerID);
                        host.AllowOperate = true;
                        hide();
                    }
                }
                FCPoint location = new FCPoint(x, y);
                Location = location;
                native.invalidate();
            }
        }

        /// <summary>
        /// 布局改变方法
        /// </summary>
        public override void update() {
            base.update();
            if (m_closeButton != null) {
                FCPoint location = new FCPoint(Width - 26, 2);
                m_closeButton.Location = location;
            }
        }
    }
}
