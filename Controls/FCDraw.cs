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

namespace FaceCat {
    /// <summary>
    /// ��ͼ��
    /// </summary>
    public class FCDraw {
        /// <summary>
        /// �û��Զ���ɫ
        /// </summary>
        public const long FCCOLORS_USERCOLOR = -200000000100;

        /// <summary>
        /// ����ɫ
        /// </summary>
        public const long FCCOLORS_BACKCOLOR = FCCOLORS_USERCOLOR - 1;

        /// <summary>
        /// ����ɫ2
        /// </summary>
        public const long FCCOLORS_BACKCOLOR2 = FCCOLORS_USERCOLOR - 2;

        /// <summary>
        /// ����ɫ3
        /// </summary>
        public const long FCCOLORS_BACKCOLOR3 = FCCOLORS_USERCOLOR - 3;

        /// <summary>
        /// ����ɫ4
        /// </summary>
        public const long FCCOLORS_BACKCOLOR4 = FCCOLORS_USERCOLOR - 4;

        /// <summary>
        /// ����ɫ5
        /// </summary>
        public const long FCCOLORS_BACKCOLOR5 = FCCOLORS_USERCOLOR - 5;

        /// <summary>
        /// ����ɫ6
        /// </summary>
        public const long FCCOLORS_BACKCOLOR6 = FCCOLORS_USERCOLOR - 6;

        /// <summary>
        /// ����ɫ7
        /// </summary>
        public const long FCCOLORS_BACKCOLOR7 = FCCOLORS_USERCOLOR - 7;

        /// <summary>
        /// ǰ��ɫ
        /// </summary>
        public const long FCCOLORS_FORECOLOR = FCCOLORS_USERCOLOR - 100;

        /// <summary>
        /// ǰ��ɫ2
        /// </summary>
        public const long FCCOLORS_FORECOLOR2 = FCCOLORS_USERCOLOR - 101;

        /// <summary>
        /// ǰ��ɫ3
        /// </summary>
        public const long FCCOLORS_FORECOLOR3 = FCCOLORS_USERCOLOR - 102;

        /// <summary>
        /// ǰ��ɫ4
        /// </summary>
        public const long FCCOLORS_FORECOLOR4 = FCCOLORS_USERCOLOR - 103;

        /// <summary>
        /// ǰ��ɫ5
        /// </summary>
        public const long FCCOLORS_FORECOLOR5 = FCCOLORS_USERCOLOR - 104;

        /// <summary>
        /// ǰ��ɫ6
        /// </summary>
        public const long FCCOLORS_FORECOLOR6 = FCCOLORS_USERCOLOR - 105;

        /// <summary>
        /// ǰ��ɫ7
        /// </summary>
        public const long FCCOLORS_FORECOLOR7 = FCCOLORS_USERCOLOR - 106;

        /// <summary>
        /// ǰ��ɫ8
        /// </summary>
        public const long FCCOLORS_FORECOLOR8 = FCCOLORS_USERCOLOR - 107;

        /// <summary>
        /// ǰ��ɫ9
        /// </summary>
        public const long FCCOLORS_FORECOLOR9 = FCCOLORS_USERCOLOR - 108;

        /// <summary>
        /// ǰ��ɫ10
        /// </summary>
        public const long FCCOLORS_FORECOLOR10 = FCCOLORS_USERCOLOR - 109;

        /// <summary>
        /// ǰ��ɫ11
        /// </summary>
        public const long FCCOLORS_FORECOLOR11 = FCCOLORS_USERCOLOR - 110;

        /// <summary>
        /// �ߵ���ɫ
        /// </summary>
        public const long FCCOLORS_LINECOLOR = FCCOLORS_USERCOLOR - 200;

        /// <summary>
        /// �ߵ���ɫ2
        /// </summary>
        public const long FCCOLORS_LINECOLOR2 = FCCOLORS_USERCOLOR - 201;

        /// <summary>
        /// �ߵ���ɫ3
        /// </summary>
        public const long FCCOLORS_LINECOLOR3 = FCCOLORS_USERCOLOR - 202;

        /// <summary>
        /// �ߵ���ɫ4
        /// </summary>
        public const long FCCOLORS_LINECOLOR4 = FCCOLORS_USERCOLOR - 203;

        /// <summary>
        /// �ߵ���ɫ5
        /// </summary>
        public const long FCCOLORS_LINECOLOR5 = FCCOLORS_USERCOLOR - 204;

        /// <summary>
        /// ƽ��ɫ
        /// </summary>
        public const long FCCOLORS_MIDCOLOR = FCCOLORS_USERCOLOR - 300;

        /// <summary>
        /// ����ɫ
        /// </summary>
        public const long FCCOLORS_UPCOLOR = FCCOLORS_USERCOLOR - 301;

        /// <summary>
        /// �µ�ɫ
        /// </summary>
        public const long FCCOLORS_DOWNCOLOR = FCCOLORS_USERCOLOR - 302;

        /// <summary>
        /// �µ�ɫ2
        /// </summary>
        public const long FCCOLORS_DOWNCOLOR2 = FCCOLORS_USERCOLOR - 303;

        /// <summary>
        /// �µ�ɫ3
        /// </summary>
        public const long FCCOLORS_DOWNCOLOR3 = FCCOLORS_USERCOLOR - 304;

        /// <summary>
        /// ѡ������ɫ
        /// </summary>
        public const long FCCOLORS_SELECTEDROWCOLOR = FCCOLORS_USERCOLOR - 400;

        /// <summary>
        /// ��ͣ����ɫ
        /// </summary>
        public const long FCCOLORS_HOVEREDROWCOLOR = FCCOLORS_USERCOLOR - 401;

        /// <summary>
        /// ����ǰ��ɫ
        /// </summary>
        public const long FCCOLORS_WINDOWFORECOLOR = FCCOLORS_USERCOLOR - 500;

        /// <summary>
        /// ���屳��ɫ
        /// </summary>
        public const long FCCOLORS_WINDOWBACKCOLOR = FCCOLORS_USERCOLOR - 501;

        /// <summary>
        /// ���屳��ɫ2
        /// </summary>
        public const long FCCOLORS_WINDOWBACKCOLOR2 = FCCOLORS_USERCOLOR - 502;

        /// <summary>
        /// �������ݱ���ɫ
        /// </summary>
        public const long FCCOLORS_WINDOWCONTENTBACKCOLOR = FCCOLORS_USERCOLOR - 503;

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="paint">��ͼ����</param>
        /// <param name="text">����</param>
        /// <param name="dwPenColor">��ɫ</param>
        /// <param name="font">����</param>
        /// <param name="x">������</param>
        /// <param name="y">������</param>
        public static FCSize drawText(FCPaint paint, String text, long dwPenColor, FCFont font, int x, int y) {
            FCSize tSize = paint.textSize(text, font);
            FCRect tRect = new FCRect(x, y, x + tSize.cx, y + tSize.cy);
            paint.drawText(text, dwPenColor, font, tRect);
            return tSize;
        }

        /// <summary>
        /// �������»��ߵ�����
        /// </summary>
        /// <param name="paint">��ͼ����</param>
        /// <param name="value">ֵ</param>
        /// <param name="digit">����С��λ��</param>
        /// <param name="font">����</param>
        /// <param name="fontColor">������ɫ</param>
        /// <param name="zeroAsEmpty">0�Ƿ�Ϊ��</param>
        /// <param name="x">������</param>
        /// <param name="y">������</param>
        /// <returns>���Ƶĺ�����</returns>
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
        /// ��ȡ��ɫ������ɫ
        /// </summary>
        /// <param name="color">��ɫ</param>
        /// <returns>�µ���ɫ</returns>
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
        /// ���ݼ۸��ȡ��ɫ
        /// </summary>
        /// <param name="price">�۸�</param>
        /// <param name="comparePrice">�Ƚϼ۸�</param>
        /// <returns>��ɫ</returns>
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
