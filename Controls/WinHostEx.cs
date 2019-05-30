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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace FaceCat {
    /// <summary>
    /// ���������
    /// </summary>
    public class WinHostEx : WinHost {
        /// <summary>
        /// �����ڲ��ؼ�
        /// </summary>
        /// <param name="parent">���ؼ�</param>
        /// <param name="clsid">�ؼ���ʶ</param>
        /// <returns>�ڲ��ؼ�</returns>
        public override FCView createInternalControl(FCView parent, String clsid) {
            //�����ؼ�
            FCCalendar calendar = parent as FCCalendar;
            if (calendar != null) {
                if (clsid == "datetitle") {
                    return new DateTitle(calendar);
                }
                else if (clsid == "headdiv") {
                    HeadDiv headDiv = new HeadDiv(calendar);
                    headDiv.Width = parent.Width;
                    headDiv.Dock = FCDockStyle.Top;
                    return headDiv;
                }
                else if (clsid == "lastbutton") {
                    return new ArrowButton(calendar);
                }
                else if (clsid == "nextbutton") {
                    ArrowButton nextBtn = new ArrowButton(calendar);
                    nextBtn.ToLast = false;
                    return nextBtn;
                }
            }
            //�ָ��
            FCSplitLayoutDiv splitLayoutDiv = parent as FCSplitLayoutDiv;
            if (splitLayoutDiv != null) {
                if (clsid == "splitter") {
                    FCButton splitter = new FCButton();
                    splitter.BackColor = FCDraw.FCCOLORS_BACKCOLOR;
                    splitter.Size = new FCSize(5, 5);
                    return splitter;
                }
            }
            //������
            FCScrollBar scrollBar = parent as FCScrollBar;
            if (scrollBar != null) {
                scrollBar.BackColor = FCColor.None;
                if (clsid == "addbutton") {
                    RibbonButton addButton = new RibbonButton();
                    addButton.Size = new FCSize(15, 15);
                    if (scrollBar is FCHScrollBar) {
                        addButton.ArrowType = 2;
                    }
                    else if (scrollBar is FCVScrollBar) {
                        addButton.ArrowType = 4;
                    }
                    return addButton;
                }
                else if (clsid == "backbutton") {
                    FCButton backButton = new FCButton();
                    return backButton;
                }
                else if (clsid == "scrollbutton") {
                    FCButton scrollButton = new FCButton();
                    scrollButton.AllowDrag = true;
                    scrollButton.BackColor = FCDraw.FCCOLORS_BACKCOLOR;
                    scrollButton.BorderColor = FCDraw.FCCOLORS_LINECOLOR3;
                    return scrollButton;
                }
                else if (clsid == "reducebutton") {
                    RibbonButton reduceButton = new RibbonButton();
                    reduceButton.Size = new FCSize(15, 15);
                    if (scrollBar is FCHScrollBar) {
                        reduceButton.ArrowType = 1;
                    }
                    else if (scrollBar is FCVScrollBar) {
                        reduceButton.ArrowType = 3;
                    }
                    return reduceButton;
                }
            }
            //ҳ��
            FCTabPage tabPage = parent as FCTabPage;
            if (tabPage != null) {
                if (clsid == "headerbutton") {
                    RibbonButton button = new RibbonButton();
                    button.AllowDrag = true;
                    FCSize size = new FCSize(100, 20);
                    button.Size = size;
                    return button;
                }
            }
            //�����б�
            FCComboBox comboBox = parent as FCComboBox;
            if (comboBox != null) {
                if (clsid == "dropdownbutton") {
                    RibbonButton dropDownButton = new RibbonButton();
                    dropDownButton.ArrowType = 4;
                    dropDownButton.DisplayOffset = false;
                    int width = comboBox.Width;
                    int height = comboBox.Height;
                    FCPoint location = new FCPoint(width - 20, 0);
                    dropDownButton.Location = location;
                    FCSize size = new FCSize(20, height);
                    dropDownButton.Size = size;
                    return dropDownButton;
                }
                else if (clsid == "dropdownmenu") {
                    FCComboBoxMenu comboBoxMenu = new FCComboBoxMenu();
                    comboBoxMenu.ComboBox = comboBox;
                    comboBoxMenu.Popup = true;
                    FCSize size = new FCSize(100, 200);
                    comboBoxMenu.Size = size;
                    return comboBoxMenu;
                }
            }
            //����ѡ��
            FCDateTimePicker datePicker = parent as FCDateTimePicker;
            if (datePicker != null) {
                if (clsid == "dropdownbutton") {
                    RibbonButton dropDownButton = new RibbonButton();
                    dropDownButton.ArrowType = 4;
                    dropDownButton.DisplayOffset = false;
                    int width = datePicker.Width;
                    int height = datePicker.Height;
                    FCPoint location = new FCPoint(width - 16, 0);
                    dropDownButton.Location = location;
                    FCSize size = new FCSize(16, height);
                    dropDownButton.Size = size;
                    return dropDownButton;
                }
                else if (clsid == "dropdownmenu") {
                    FCMenu dropDownMenu = new FCMenu();
                    dropDownMenu.Padding = new FCPadding(1);
                    dropDownMenu.Popup = true;
                    FCSize size = new FCSize(200, 200);
                    dropDownMenu.Size = size;
                    return dropDownMenu;
                }
            }
            //����ѡ��
            FCSpin spin = parent as FCSpin;
            if (spin != null) {
                if (clsid == "downbutton") {
                    RibbonButton downButton = new RibbonButton();
                    downButton.ArrowType = 4;
                    downButton.DisplayOffset = false;
                    FCSize size = new FCSize(16, 16);
                    downButton.Size = size;
                    return downButton;
                }
                else if (clsid == "upbutton") {
                    RibbonButton upButton = new RibbonButton();
                    upButton.ArrowType = 3;
                    upButton.DisplayOffset = false;
                    FCSize size = new FCSize(16, 16);
                    upButton.Size = size;
                    return upButton;
                }
            }
            //������
            FCDiv div = parent as FCDiv;
            if (div != null) {
                if (clsid == "hscrollbar") {
                    FCHScrollBar hScrollBar = new FCHScrollBar();
                    hScrollBar.Visible = false;
                    hScrollBar.Size = new FCSize(15, 15);
                    return hScrollBar;
                }
                else if (clsid == "vscrollbar") {
                    FCVScrollBar vScrollBar = new FCVScrollBar();
                    vScrollBar.Visible = false;
                    vScrollBar.Size = new FCSize(15, 15);
                    return vScrollBar;
                }
            }
            //����
            FCGrid grid = parent as FCGrid;
            if (grid != null) {
                if (clsid == "edittextbox") {
                    FCTextBox textBox = new FCTextBox();
                    textBox.BackColor = FCDraw.FCCOLORS_BACKCOLOR;
                    return textBox;
                }
            }
            return base.createInternalControl(parent, clsid);
        }
    }
}