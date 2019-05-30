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
    /// 透明按钮
    /// </summary>
    public class RibbonButton : FCButton {
        /// <summary>
        /// 创建透明按钮
        /// </summary>
        public RibbonButton() {
            BackColor = FCColor.None;
            BorderColor = FCColor.None;
        }

        private int m_arrowType;

        /// <summary>
        /// 获取或设置箭头类型
        /// </summary>
        public int ArrowType {
            get { return m_arrowType; }
            set { m_arrowType = value; }
        }

        private bool m_isClose;

        /// <summary>
        /// 获取或设置是否是关闭按钮
        /// </summary>
        public bool IsClose {
            get { return m_isClose; }
            set { m_isClose = value; }
        }

        /// <summary>
        /// 获取或设置是否选中
        /// </summary>
        public bool Selected {
            get {
                FCView parent = Parent;
                if (parent != null) {
                    FCTabControl tabControl = parent as FCTabControl;
                    if (tabControl != null) {
                        FCTabPage selectedTabPage = tabControl.SelectedTabPage;
                        if (selectedTabPage != null) {
                            if (this == selectedTabPage.HeaderButton) {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 获取要绘制的前景色
        /// </summary>
        /// <returns>前景色</returns>
        protected override long getPaintingTextColor() {
            if (Enabled) {
                return FCDraw.FCCOLORS_FORECOLOR;
            }
            else {
                return FCDraw.FCCOLORS_FORECOLOR5;
            }
        }

        /// <summary>
        /// 重绘背景
        /// </summary>
        /// <param name="paint">绘图对象</param>
        /// <param name="clipRect">裁剪区域</param>
        public override void onPaintBackground(FCPaint paint, FCRect clipRect) {
            int width = Width, height = Height;
            int mw = width / 2, mh = height / 2;
            FCRect drawRect = new FCRect(0, 0, width, height);
            if (m_isClose) {
                long lineColor = FCDraw.FCCOLORS_LINECOLOR;
                FCRect ellipseRect = new FCRect(1, 1, width - 2, height - 2);
                paint.fillEllipse(FCDraw.FCCOLORS_UPCOLOR, ellipseRect);
                paint.drawLine(lineColor, 2, 0, 4, 4, width - 7, height - 7);
                paint.drawLine(lineColor, 2, 0, 4, height - 7, width - 7, 3);
            }
            else {
                int cornerRadius = 4;
                if (m_arrowType > 0) {
                    cornerRadius = 0;
                }
                FCView parent = Parent;
                if (parent != null) {
                    FCTabControl tabControl = parent as FCTabControl;
                    if (tabControl != null) {
                        cornerRadius = 0;
                    }
                }
                paint.fillGradientRect(FCDraw.FCCOLORS_BACKCOLOR, FCDraw.FCCOLORS_BACKCOLOR2, drawRect, cornerRadius, 90);
                paint.drawRoundRect(FCDraw.FCCOLORS_LINECOLOR3, 1, 0, drawRect, cornerRadius);
            }
            if (m_arrowType > 0) {
                FCPoint[] points = new FCPoint[3];
                int ts = Math.Min(mw, mh) / 2;
                switch (m_arrowType) {
                    //向左
                    case 1:
                        points[0] = new FCPoint(mw - ts, mh);
                        points[1] = new FCPoint(mw + ts, mh - ts);
                        points[2] = new FCPoint(mw + ts, mh + ts);
                        break;
                    //向右
                    case 2:
                        points[0] = new FCPoint(mw + ts, mh);
                        points[1] = new FCPoint(mw - ts, mh - ts);
                        points[2] = new FCPoint(mw - ts, mh + ts);
                        break;
                    //向上
                    case 3:
                        points[0] = new FCPoint(mw, mh - ts);
                        points[1] = new FCPoint(mw - ts, mh + ts);
                        points[2] = new FCPoint(mw + ts, mh + ts);
                        break;
                    //向下
                    case 4:
                        points[0] = new FCPoint(mw, mh + ts);
                        points[1] = new FCPoint(mw - ts, mh - ts);
                        points[2] = new FCPoint(mw + ts, mh - ts);
                        break;
                }
                paint.fillPolygon(FCDraw.FCCOLORS_FORECOLOR, points);
            }
            //绘制选中效果
            if (paint.supportTransparent()) {
                FCNative native = Native;
                if (Selected) {
                    paint.fillRect(FCDraw.FCCOLORS_BACKCOLOR2, drawRect);
                }
                else if (this == native.PushedControl) {
                    paint.fillRect(FCDraw.FCCOLORS_BACKCOLOR6, drawRect);
                }
                else if (this == native.HoveredControl) {
                    paint.fillRect(FCDraw.FCCOLORS_BACKCOLOR5, drawRect);
                }
            }
        }
    }
}
