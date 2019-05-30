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
    /// ����ť
    /// </summary>
    public class RuningButton : FCButton {
        /// <summary>
        /// ����͸����ť
        /// </summary>
        public RuningButton() {
            AllowDrag = true;
            BackColor = FCColor.argb(50, 50, 50);
            BorderColor = FCColor.argb(100, 100, 100);
            Font = new FCFont("SimSun", 30, true, false, false);
        }

        /// <summary>
        /// �ػ汳������
        /// </summary>
        /// <param name="paint">��ͼ����</param>
        /// <param name="clipRect">�ü�����</param>
        public override void onPaintBackground(FCPaint paint, FCRect clipRect) {
            int width = Width, height = Height;
            FCRect drawRect = new FCRect(0, 0, width, height);
            paint.fillRoundRect(getPaintingBackColor(), clipRect, 20);
            //����ѡ��Ч��
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
        /// �ػ���߷���
        /// </summary>
        /// <param name="paint">��ͼ����</param>
        /// <param name="clipRect">�ü�����</param>
        public override void onPaintBorder(FCPaint paint, FCRect clipRect) {
            paint.drawRoundRect(getPaintingBorderColor(), 1, 0, clipRect, 20);
        }

        /// <summary>
        /// �ػ�ǰ������
        /// </summary>
        /// <param name="paint">��ͼ����</param>
        /// <param name="clipRect">�ü�����</param>
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
