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
    /// 绘图类
    /// </summary>
    public class FCDraw {
        /// <summary>
        /// 用户自定义色
        /// </summary>
        public const long FCCOLORS_USERCOLOR = -200000000100;

        /// <summary>
        /// 背景色
        /// </summary>
        public const long FCCOLORS_BACKCOLOR = FCCOLORS_USERCOLOR - 1;

        /// <summary>
        /// 背景色2
        /// </summary>
        public const long FCCOLORS_BACKCOLOR2 = FCCOLORS_USERCOLOR - 2;

        /// <summary>
        /// 背景色3
        /// </summary>
        public const long FCCOLORS_BACKCOLOR3 = FCCOLORS_USERCOLOR - 3;

        /// <summary>
        /// 背景色4
        /// </summary>
        public const long FCCOLORS_BACKCOLOR4 = FCCOLORS_USERCOLOR - 4;

        /// <summary>
        /// 背景色5
        /// </summary>
        public const long FCCOLORS_BACKCOLOR5 = FCCOLORS_USERCOLOR - 5;

        /// <summary>
        /// 背景色6
        /// </summary>
        public const long FCCOLORS_BACKCOLOR6 = FCCOLORS_USERCOLOR - 6;

        /// <summary>
        /// 背景色7
        /// </summary>
        public const long FCCOLORS_BACKCOLOR7 = FCCOLORS_USERCOLOR - 7;

        /// <summary>
        /// 前景色
        /// </summary>
        public const long FCCOLORS_FORECOLOR = FCCOLORS_USERCOLOR - 100;

        /// <summary>
        /// 前景色2
        /// </summary>
        public const long FCCOLORS_FORECOLOR2 = FCCOLORS_USERCOLOR - 101;

        /// <summary>
        /// 前景色3
        /// </summary>
        public const long FCCOLORS_FORECOLOR3 = FCCOLORS_USERCOLOR - 102;

        /// <summary>
        /// 前景色4
        /// </summary>
        public const long FCCOLORS_FORECOLOR4 = FCCOLORS_USERCOLOR - 103;

        /// <summary>
        /// 前景色5
        /// </summary>
        public const long FCCOLORS_FORECOLOR5 = FCCOLORS_USERCOLOR - 104;

        /// <summary>
        /// 前景色6
        /// </summary>
        public const long FCCOLORS_FORECOLOR6 = FCCOLORS_USERCOLOR - 105;

        /// <summary>
        /// 前景色7
        /// </summary>
        public const long FCCOLORS_FORECOLOR7 = FCCOLORS_USERCOLOR - 106;

        /// <summary>
        /// 前景色8
        /// </summary>
        public const long FCCOLORS_FORECOLOR8 = FCCOLORS_USERCOLOR - 107;

        /// <summary>
        /// 前景色9
        /// </summary>
        public const long FCCOLORS_FORECOLOR9 = FCCOLORS_USERCOLOR - 108;

        /// <summary>
        /// 前景色10
        /// </summary>
        public const long FCCOLORS_FORECOLOR10 = FCCOLORS_USERCOLOR - 109;

        /// <summary>
        /// 前景色11
        /// </summary>
        public const long FCCOLORS_FORECOLOR11 = FCCOLORS_USERCOLOR - 110;

        /// <summary>
        /// 线的颜色
        /// </summary>
        public const long FCCOLORS_LINECOLOR = FCCOLORS_USERCOLOR - 200;

        /// <summary>
        /// 线的颜色2
        /// </summary>
        public const long FCCOLORS_LINECOLOR2 = FCCOLORS_USERCOLOR - 201;

        /// <summary>
        /// 线的颜色3
        /// </summary>
        public const long FCCOLORS_LINECOLOR3 = FCCOLORS_USERCOLOR - 202;

        /// <summary>
        /// 线的颜色4
        /// </summary>
        public const long FCCOLORS_LINECOLOR4 = FCCOLORS_USERCOLOR - 203;

        /// <summary>
        /// 线的颜色5
        /// </summary>
        public const long FCCOLORS_LINECOLOR5 = FCCOLORS_USERCOLOR - 204;

        /// <summary>
        /// 平盘色
        /// </summary>
        public const long FCCOLORS_MIDCOLOR = FCCOLORS_USERCOLOR - 300;

        /// <summary>
        /// 上涨色
        /// </summary>
        public const long FCCOLORS_UPCOLOR = FCCOLORS_USERCOLOR - 301;

        /// <summary>
        /// 下跌色
        /// </summary>
        public const long FCCOLORS_DOWNCOLOR = FCCOLORS_USERCOLOR - 302;

        /// <summary>
        /// 下跌色2
        /// </summary>
        public const long FCCOLORS_DOWNCOLOR2 = FCCOLORS_USERCOLOR - 303;

        /// <summary>
        /// 下跌色3
        /// </summary>
        public const long FCCOLORS_DOWNCOLOR3 = FCCOLORS_USERCOLOR - 304;

        /// <summary>
        /// 选中行颜色
        /// </summary>
        public const long FCCOLORS_SELECTEDROWCOLOR = FCCOLORS_USERCOLOR - 400;

        /// <summary>
        /// 悬停行颜色
        /// </summary>
        public const long FCCOLORS_HOVEREDROWCOLOR = FCCOLORS_USERCOLOR - 401;

        /// <summary>
        /// 窗体前景色
        /// </summary>
        public const long FCCOLORS_WINDOWFORECOLOR = FCCOLORS_USERCOLOR - 500;

        /// <summary>
        /// 窗体背景色
        /// </summary>
        public const long FCCOLORS_WINDOWBACKCOLOR = FCCOLORS_USERCOLOR - 501;

        /// <summary>
        /// 窗体背景色2
        /// </summary>
        public const long FCCOLORS_WINDOWBACKCOLOR2 = FCCOLORS_USERCOLOR - 502;

        /// <summary>
        /// 窗体内容背景色
        /// </summary>
        public const long FCCOLORS_WINDOWCONTENTBACKCOLOR = FCCOLORS_USERCOLOR - 503;

        /// <summary>
        /// 绘制文字
        /// </summary>
        /// <param name="paint">绘图对象</param>
        /// <param name="text">文字</param>
        /// <param name="dwPenColor">颜色</param>
        /// <param name="font">字体</param>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        public static FCSize drawText(FCPaint paint, String text, long dwPenColor, FCFont font, int x, int y) {
            FCSize tSize = paint.textSize(text, font);
            FCRect tRect = new FCRect(x, y, x + tSize.cx, y + tSize.cy);
            paint.drawText(text, dwPenColor, font, tRect);
            return tSize;
        }

        /// <summary>
        /// 绘制有下划线的数字
        /// </summary>
        /// <param name="paint">绘图对象</param>
        /// <param name="value">值</param>
        /// <param name="digit">保留小数位数</param>
        /// <param name="font">字体</param>
        /// <param name="fontColor">文字颜色</param>
        /// <param name="zeroAsEmpty">0是否为空</param>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        /// <returns>绘制的横坐标</returns>
        public static int drawUnderLineNum(FCPaint paint, double value, int digit, FCFont font, long fontColor, bool zeroAsEmpty, int x, int y) {
            if (zeroAsEmpty && value == 0) {
                String text = "-";
                FCSize size = paint.textSize(text, font);
                FCDraw.drawText(paint, text, fontColor, font, x, y);
                return size.cx;
            }
            else {
                String[] nbs = FCStr.getValueByDigit(value, digit).Split(new String[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                if (nbs.Length == 1) {
                    FCSize size = paint.textSize(nbs[0], font);
                    FCDraw.drawText(paint, nbs[0], fontColor, font, x, y);
                    return size.cx;
                }
                else {
                    FCSize decimalSize = paint.textSize(nbs[0], font);
                    FCSize size = paint.textSize(nbs[1], font);
                    FCDraw.drawText(paint, nbs[0], fontColor, font, x, y);
                    FCDraw.drawText(paint, nbs[1], fontColor, font, x
                        + decimalSize.cx + 1, y);
                    paint.drawLine(fontColor, 1, 0, x
                        + decimalSize.cx + 1, y + decimalSize.cy,
                        x + decimalSize.cx + size.cx, y + decimalSize.cy);
                    return decimalSize.cx + size.cx;
                }
            }
        }

        /// <summary>
        /// 获取黑色风格的颜色
        /// </summary>
        /// <param name="color">颜色</param>
        /// <returns>新的颜色</returns>
        public static long getBlackColor(long color) {
            if (color > FCDraw.FCCOLORS_USERCOLOR) {
                if (color == FCColor.Back) {
                    color = FCColor.argb(100, 0, 0, 0);
                }
                else if (color == FCColor.Border) {
                    color = 3289650;
                }
                else if (color == FCColor.Text) {
                    color = FCColor.argb(255, 255, 255);
                }
                else if (color == FCColor.DisabledBack) {
                    color = FCColor.argb(50, 255, 255, 255);
                }
                else if (color == FCColor.DisabledText) {
                    color = 3289650;
                }
                else if (color == FCColor.Hovered) {
                    color = FCColor.argb(50, 255, 255, 255);
                }
                else if (color == FCColor.Pushed) {
                    color = FCColor.argb(50, 255, 255, 255);
                }
            }
            else if (color == FCDraw.FCCOLORS_BACKCOLOR) {
                color = FCColor.argb(255, 50, 50, 50);
            }
            else if (color == FCDraw.FCCOLORS_BACKCOLOR2) {
                color = FCColor.argb(150, 0, 0, 0);
            }
            else if (color == FCDraw.FCCOLORS_BACKCOLOR3) {
                color = FCColor.argb(100, 0, 0, 0);
            }
            else if (color == FCDraw.FCCOLORS_BACKCOLOR4) {
                color = FCColor.argb(0, 0, 0);
            }
            else if (color == FCDraw.FCCOLORS_BACKCOLOR5) {
                color = FCColor.argb(10, 255, 255, 255);
            }
            else if (color == FCDraw.FCCOLORS_BACKCOLOR6) {
                color = FCColor.argb(25, 0, 0, 0);
            }
            else if (color == FCDraw.FCCOLORS_BACKCOLOR7) {
                color = FCColor.argb(200, 255, 255, 255);
            }
            else if (color == FCDraw.FCCOLORS_FORECOLOR) {
                color = FCColor.argb(255, 255, 255);
            }
            else if (color == FCDraw.FCCOLORS_FORECOLOR2) {
                color = FCColor.argb(217, 217, 68);
            }
            else if (color == FCDraw.FCCOLORS_FORECOLOR3) {
                color = FCColor.argb(80, 255, 255);
            }
            else if (color == FCDraw.FCCOLORS_FORECOLOR4) {
                color = FCColor.argb(112, 112, 112);
            }
            else if (color == FCDraw.FCCOLORS_FORECOLOR5) {
                color = FCColor.argb(192, 192, 192);
            }
            else if (color == FCDraw.FCCOLORS_FORECOLOR6) {
                color = FCColor.argb(0, 0, 0);
            }
            else if (color == FCDraw.FCCOLORS_FORECOLOR7) {
                color = FCColor.argb(0, 255, 255);
            }
            else if (color == FCDraw.FCCOLORS_FORECOLOR8) {
                color = FCColor.argb(50, 50, 50);
            }
            else if (color == FCDraw.FCCOLORS_FORECOLOR9) {
                color = FCColor.argb(255, 255, 0);
            }
            else if (color == FCDraw.FCCOLORS_FORECOLOR10) {
                color = FCColor.argb(255, 255, 80);
            }
            else if (color == FCDraw.FCCOLORS_FORECOLOR11) {
                color = FCColor.argb(135, 206, 235);
            }
            else if (color == FCDraw.FCCOLORS_LINECOLOR) {
                color = FCColor.argb(255, 255, 255);
            }
            else if (color == FCDraw.FCCOLORS_LINECOLOR2) {
                color = FCColor.argb(217, 217, 68);
            }
            else if (color == FCDraw.FCCOLORS_LINECOLOR3) {
                color = FCColor.argb(50, 255, 255, 255);
            }
            else if (color == FCDraw.FCCOLORS_LINECOLOR4) {
                color = FCColor.argb(150, 0, 0);
            }
            else if (color == FCDraw.FCCOLORS_LINECOLOR5) {
                color = FCColor.argb(100, 100, 100);
            }
            else if (color == FCDraw.FCCOLORS_MIDCOLOR) {
                color = FCColor.argb(255, 255, 255);
            }
            else if (color == FCDraw.FCCOLORS_UPCOLOR) {
                color = FCColor.argb(255, 82, 82);
            }
            else if (color == FCDraw.FCCOLORS_DOWNCOLOR) {
                color = FCColor.argb(80, 255, 80);
            }
            else if (color == FCDraw.FCCOLORS_DOWNCOLOR2) {
                color = FCColor.argb(80, 255, 255);
            }
            else if (color == FCDraw.FCCOLORS_DOWNCOLOR3) {
                color = FCColor.argb(100, 0, 255);
            }
            else if (color == FCDraw.FCCOLORS_SELECTEDROWCOLOR) {
                color = FCColor.argb(150, 100, 100, 100);
            }
            else if (color == FCDraw.FCCOLORS_HOVEREDROWCOLOR) {
                color = FCColor.argb(150, 150, 150, 150);
            }
            else if (color == FCDraw.FCCOLORS_WINDOWFORECOLOR) {
                color = FCColor.argb(255, 255, 255);
            }
            else if (color == FCDraw.FCCOLORS_WINDOWBACKCOLOR) {
                color = FCColor.argb(255, 50, 50, 50);
            }
            else if (color == FCDraw.FCCOLORS_WINDOWBACKCOLOR2) {
                color = FCColor.argb(200, 20, 20, 20);
            }
            else if (color == FCDraw.FCCOLORS_WINDOWCONTENTBACKCOLOR) {
                color = FCColor.argb(200, 0, 0, 0);
            }
            return color;
        }

        /// <summary>
        /// 根据价格获取颜色
        /// </summary>
        /// <param name="price">价格</param>
        /// <param name="comparePrice">比较价格</param>
        /// <returns>颜色</returns>
        public static long getPriceColor(double price, double comparePrice) {
            if (price != 0) {
                if (price > comparePrice) {
                    return FCDraw.FCCOLORS_UPCOLOR;
                }
                else if (price < comparePrice) {
                    return FCDraw.FCCOLORS_DOWNCOLOR;
                }
            }
            return FCDraw.FCCOLORS_MIDCOLOR;
        }
    }
}
