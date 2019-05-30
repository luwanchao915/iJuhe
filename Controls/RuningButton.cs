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
    /// 任务按钮
    /// </summary>
    public class RuningButton : FCButton {
        /// <summary>
        /// 创建透明按钮
        /// </summary>
        public RuningButton() {
            AllowDrag = true;
            BackColor = FCColor.argb(50, 50, 50);
            BorderColor = FCColor.argb(100, 100, 100);
            Font = new FCFont("SimSun", 30, true, false, false);
        }

        /// <summary>
        /// 重绘背景方法
        /// </summary>
        /// <param name="paint">绘图对象</param>
        /// <param name="clipRect">裁剪区域</param>
        public override void onPaintBackground(FCPaint paint, FCRect clipRect) {
            int width = Width, height = Height;
            FCRect drawRect = new FCRect(0, 0, width, height);
            paint.fillRoundRect(getPaintingBackColor(), clipRect, 20);
            //绘制选中效果
            if (paint.supportTransparent()) {
                FCNative native = Native;
                if (this == native.PushedControl) {
                    paint.fillRoundRect(FCDraw.FCCOLORS_BACKCOLOR6, drawRect, 20);
                }
                else if (this == native.HoveredControl) {
                    paint.fillRoundRect(FCDraw.FCCOLORS_BACKCOLOR5, drawRect, 20);
                }
            }
        }

        /// <summary>
        /// 重绘边线方法
        /// </summary>
        /// <param name="paint">绘图对象</param>
        /// <param name="clipRect">裁剪区域</param>
        public override void onPaintBorder(FCPaint paint, FCRect clipRect) {
            paint.drawRoundRect(getPaintingBorderColor(), 1, 0, clipRect, 20);
        }

        /// <summary>
        /// 重绘前景方法
        /// </summary>
        /// <param name="paint">绘图对象</param>
        /// <param name="clipRect">裁剪区域</param>
        public override void onPaintForeground(FCPaint paint, FCRect clipRect) {
            int width = Width, height = Height;
            if (width > 0 && height > 0) {
                String text = Text;
                if (text != null && text.Length > 0) {
                    FCFont font = Font;
                    FCRect rect = DisplayRect;
                    FCSize tSize = paint.textSize(text, font);
                    long foreColor = getPaintingTextColor();
                    string cmd = Name.Substring(3).ToLower();
                    BaseWork work = DataCenter.Works[cmd];
                    if (work != null) {
                        FCFont sFont = new FCFont("Arial", 30, true, false, false);
                        String state = "START!";
                        if (work.IsRunning) {
                            state = work.Log;
                            if (state.Length == 0) {
                                state = "START!";
                            }
                            else {
                                sFont.m_fontSize = 30;
                            }
                        }
                        FCDraw.drawText(paint, text, foreColor, font, (width - tSize.cx) / 2, (height - tSize.cy) / 2 - 30);
                        tSize = paint.textSize(state, sFont);
                        FCDraw.drawText(paint, state, foreColor, sFont, (width - tSize.cx) / 2, (height - tSize.cy) / 2 + 30);
                    }
                }
            }
        }
    }
}
