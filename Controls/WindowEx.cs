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
using System.Drawing;

namespace FaceCat {
    /// <summary>
    /// �ػ洰��
    /// </summary>
    public class WindowEx : FCWindow {
        /// <summary>
        /// ��������
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
        /// �ƶ�����
        /// </summary>
        private int m_animateDirection = -1;

        /// <summary>
        /// ��������
        /// </summary>
        private int m_animateType = 0;

        /// <summary>
        /// �������
        /// </summary>
        private Random m_rd = new Random();

        /// <summary>
        /// ���ID
        /// </summary>
        private int m_timerID = FCView.getNewTimerID();

        private bool m_animateMoving;

        /// <summary>
        /// ��ȡ�Ƿ����ڶ����ƶ�
        /// </summary>
        public bool AnimateMoving {
            get { return m_animateMoving; }
        }

        private RibbonButton m_closeButton;

        /// <summary>
        /// ��ȡ�����ùرհ�ť
        /// </summary>
        public RibbonButton CloseButton {
            get { return m_closeButton; }
            set { m_closeButton = value; }
        }

        private bool m_isChildWindow;

        /// <summary>
        /// ��ȡ�������Ƿ��Ӵ���
        /// </summary>
        public bool IsChildWindow {
            get { return m_isChildWindow; }
            set { m_isChildWindow = value; }
        }

        /// <summary>
        /// �Զ�����ʽ����
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
        /// �Զ�����ʽ��ʾ
        /// </summary>
        /// <param name="showDialog">�Ƿ�Ի����</param>
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
        /// ���ٿؼ�����
        /// </summary>
        public override void delete() {
            if (!IsDeleted) {
                m_animateMoving = false;
                stopTimer(m_timerID);
            }
            base.delete();
        }

        /// <summary>
        /// �ؼ���ӷ���
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
        /// �϶���ʼ����
        /// </summary>
        /// <param name="startOffset">ƫ��������</param>
        public override void onDragReady(ref FCPoint startOffset) {
            startOffset.x = 0;
            startOffset.y = 0;
        }

        /// <summary>
        /// �ػ�ǰ������
        /// </summary>
        /// <param name="paint">��ͼ����</param>
        /// <param name="clipRect">�ü�����</param>
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
        /// �����
        /// </summary>
        /// <param name="timerID">���ID</param>
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
                        //��������
                        case 0:
                            if (x + xSub >= mx) {
                                x = mx;
                                stop = true;
                            }
                            else {
                                x += xSub;
                            }
                            break;
                        //��������
                        case 1:
                            if (x - xSub <= mx) {
                                x = mx;
                                stop = true;
                            }
                            else {
                                x -= xSub;
                            }
                            break;
                        //��������
                        case 2:
                            if (y + ySub >= my) {
                                y = my;
                                stop = true;
                            }
                            else {
                                y += ySub;
                            }
                            break;
                        //��������
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
                        //��������
                        case 0:
                            if (x - xSub <= -width) {
                                x = 0;
                                stop = true;
                            }
                            else {
                                x -= xSub;
                            }
                            break;
                        //��������
                        case 1:
                            if (x + xSub >= nativeSize.cx) {
                                x = 0;
                                stop = true;
                            }
                            else {
                                x += xSub;
                            }
                            break;
                        //��������
                        case 2:
                            if (y - ySub <= -height) {
                                y = 0;
                                stop = true;
                            }
                            else {
                                y -= ySub;
                            }
                            break;
                        //��������
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
        /// ���ָı䷽��
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
