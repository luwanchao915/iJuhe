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
    /// ͸����ť
    /// </summary>
    public class RibbonButton : FCButton {
        /// <summary>
        /// ����͸����ť
        /// </summary>
        public RibbonButton() {
            BackColor = FCColor.None;
            BorderColor = FCColor.None;
        }

        private int m_arrowType;

        /// <summary>
        /// ��ȡ�����ü�ͷ����
        /// </summary>
        public int ArrowType {
            get { return m_arrowType; }
            set { m_arrowType = value; }
        }

        private bool m_isClose;

        /// <summary>
        /// ��ȡ�������Ƿ��ǹرհ�ť
        /// </summary>
        public bool IsClose {
            get { return m_isClose; }
            set { m_isClose = value; }
        }

        /// <summary>
        /// ��ȡ�������Ƿ�ѡ��
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
        /// ��ȡҪ���Ƶ�ǰ��ɫ
        /// </summary>
        /// <returns>ǰ��ɫ</returns>
        protected override long getPaintingTextColor() {
            if (Enabled) {
                return FCDraw.FCCOLORS_FORECOLOR;
            }
            else {
                return FCDraw.FCCOLORS_FORECOLOR5;
            }
        }

        /// <summary>
        /// �ػ汳��
        /// </summary>
        /// <param name="paint">��ͼ����</param>
        /// <param name="clipRect">�ü�����</param>
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
                    //����
                    case 1:
                        points[0] = new FCPoint(mw - ts, mh);
                        points[1] = new FCPoint(mw + ts, mh - ts);
                        points[2] = new FCPoint(mw + ts, mh + ts);
                        break;
                    //����
                    case 2:
                        points[0] = new FCPoint(mw + ts, mh);
                        points[1] = new FCPoint(mw - ts, mh - ts);
                        points[2] = new FCPoint(mw - ts, mh + ts);
                        break;
                    //����
                    case 3:
                        points[0] = new FCPoint(mw, mh - ts);
                        points[1] = new FCPoint(mw - ts, mh + ts);
                        points[2] = new FCPoint(mw + ts, mh + ts);
                        break;
                    //����
                    case 4:
                        points[0] = new FCPoint(mw, mh + ts);
                        points[1] = new FCPoint(mw - ts, mh - ts);
                        points[2] = new FCPoint(mw + ts, mh - ts);
                        break;
                }
                paint.fillPolygon(FCDraw.FCCOLORS_FORECOLOR, points);
            }
            //����ѡ��Ч��
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
