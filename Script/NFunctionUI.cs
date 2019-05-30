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
using System.Threading;
using System.Windows.Forms;

namespace FaceCat {
    /// <summary>
    /// 界面相关的库
    /// </summary>
    public class NFunctionUI : CFunction {
        /// <summary>
        /// 创建方法
        /// </summary>
        /// <param name="indicator">指标</param>
        /// <param name="id">ID</param>
        /// <param name="name">名称</param>
        /// <param name="withParameters">是否有参数</param>
        public NFunctionUI(FCScript indicator, int id, String name, FCUIXml xml) {
            m_indicator = indicator;
            m_ID = id;
            m_name = name;
            m_xml = xml;
        }

        /// <summary>
        /// 指标
        /// </summary>
        public FCScript m_indicator;

        /// <summary>
        /// XML对象
        /// </summary>
        public FCUIXml m_xml;

        /// <summary>
        /// 方法
        /// </summary>
        private static string FUNCTIONS = "GETPROPERTY,SETPROPERTY,GETSENDER,ALERT,INVALIDATE,SHOWWINDOW,CLOSEWINDOW,STARTTIMER,STOPTIMER";

        /// <summary>
        /// 前缀
        /// </summary>
        private static string PREFIX = "";

        /// <summary>
        /// 开始索引
        /// </summary>
        private static int STARTINDEX = 2000;

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="var">变量</param>
        /// <returns>结果</returns>
        public override double onCalculate(CVariable var) {
            switch (var.m_functionID) {
                case 2000:
                    return GETPROPERTY(var);
                case 2001:
                    return SETPROPERTY(var);
                case 2002:
                    return GETSENDER(var);
                case 2003:
                    return ALERT(var);
                case 2004:
                    return INVALIDATE(var);
                case 2005:
                    return SHOWWINDOW(var);
                case 2006:
                    return CLOSEWINDOW(var);
                case 2007:
                    return STARTTIMER(var);
                case 2008:
                    return STOPTIMER(var);
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="indicator">方法库</param>
        /// <param name="native">脚本</param>
        /// <param name="xml">XML</param>
        /// <returns>指标</returns>
        public static void addFunctions(FCScript indicator, FCUIXml xml) {
            string[] functions = FUNCTIONS.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            int functionsSize = functions.Length;
            for (int i = 0; i < functionsSize; i++) {
                indicator.addFunction(new NFunctionUI(indicator, STARTINDEX + i, PREFIX + functions[i], xml));
            }
        }


        /// <summary>
        /// 弹出提示
        /// </summary>
        /// <param name="var">变量</param>
        /// <returns>状态</returns>
        private double ALERT(CVariable var) {
            double result = 0;
            int len = var.m_parameters.Length;
            if (len == 1) {
                if (DialogResult.OK == MessageBox.Show(m_indicator.getText(var.m_parameters[0]))) {
                    result = 1;
                }
            }
            else {
                if (DialogResult.OK == MessageBox.Show(m_indicator.getText(var.m_parameters[0]),
                    m_indicator.getText(var.m_parameters[1]))) {
                    result = 1;
                }
            }
            return result;
        }

        /// <summary>
        /// 获取属性
        /// </summary>
        /// <param name="var">变量</param>
        /// <returns>状态</returns>
        public double GETPROPERTY(CVariable var) {
            FaceCatScript fScript = m_xml.Script as FaceCatScript;
            string name = m_indicator.getText(var.m_parameters[1]);
            string propertyName = m_indicator.getText(var.m_parameters[2]);
            string text = fScript.getProperty(name, propertyName);
            CVariable newVar = new CVariable(m_indicator);
            newVar.m_expression = "'" + text + "'";
            m_indicator.setVariable(var.m_parameters[0], newVar);
            return 0;
        }

        /// <summary>
        /// 获取调用者
        /// </summary>
        /// <param name="var">变量</param>
        /// <returns>状态</returns>
        public double GETSENDER(CVariable var) {
            FaceCatScript fScript = m_xml.Script as FaceCatScript;
            string text = fScript.getSender();
            CVariable newVar = new CVariable(m_indicator);
            newVar.m_expression = "'" + text + "'";
            m_indicator.setVariable(var.m_parameters[0], newVar);
            return 0;
        }

        /// <summary>
        /// 刷新界面
        /// </summary>
        /// <param name="var">变量</param>
        /// <returns>状态</returns>
        private double INVALIDATE(CVariable var) {
            if (m_xml != null) {
                m_xml.Native.invalidate();
            }
            return 0;
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="var">变量</param>
        /// <returns>状态</returns>
        private double SETPROPERTY(CVariable var) {
            FaceCatScript fScript = m_xml.Script as FaceCatScript;
            string name = m_indicator.getText(var.m_parameters[0]);
            string propertyName = m_indicator.getText(var.m_parameters[1]);
            string propertyValue = m_indicator.getText(var.m_parameters[2]);
            fScript.setProperty(name, propertyName, propertyValue);
            return 0;
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="var">变量</param>
        /// <returns>状态</returns>
        private double CLOSEWINDOW(CVariable var) {
            WindowXmlEx windowXmlEx = m_xml as WindowXmlEx;
            if (windowXmlEx != null) {
                windowXmlEx.close();
            }
            return 0;
        }

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="var">变量</param>
        /// <returns>状态</returns>
        private double SHOWWINDOW(CVariable var) {
            string xmlName = m_indicator.getText(var.m_parameters[0]);
            string windowName = m_indicator.getText(var.m_parameters[1]);
            WindowXmlEx window = new WindowXmlEx();
            window.load(m_xml.Native, xmlName, windowName);
            window.show();
            return 0;
        }

        /// <summary>
        /// 开始秒表
        /// </summary>
        /// <param name="var">变量</param>
        /// <returns>状态</returns>
        private double STARTTIMER(CVariable var) {
            FCView control = m_xml.findControl(m_indicator.getText(var.m_parameters[0]));
            control.startTimer((int)m_indicator.getValue(var.m_parameters[1]), (int)m_indicator.getValue(var.m_parameters[2]));
            return 0;
        }

        /// <summary>
        /// 结束秒表
        /// </summary>
        /// <param name="var">变量</param>
        /// <returns>状态</returns>
        private double STOPTIMER(CVariable var) {
            FCView control = m_xml.findControl(m_indicator.getText(var.m_parameters[0]));
            control.stopTimer((int)m_indicator.getValue(var.m_parameters[1]));
            return 0;
        }
    }
}