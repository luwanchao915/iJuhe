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
using FaceCat;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace FaceCat {
    /// <summary>
    /// 提示方法
    /// </summary>
    public class NFunctionEx : CFunction {
        /// <summary>
        /// 创建方法
        /// </summary>
        /// <param name="indicator">指标</param>
        /// <param name="id">ID</param>
        /// <param name="name">名称</param>
        /// <param name="withParameters">是否有参数</param>
        public NFunctionEx(FCScript indicator, int id, String name, FCUIXml xml) {
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
        /// 方法字段
        /// </summary>
        private const String FUNCTIONS = "JUHE.SERVICESTATE,JUHE.STARTSERVICE,JUHE.STOPSERVICE";

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="var">变量</param>
        /// <returns>结果</returns>
        public override double onCalculate(CVariable var) {
            switch (var.m_functionID) {
                case 1000000:
                    return JUHE_SERVICESTATE(var);
                case 1000001:
                    return JUHE_STARTSERVICE(var);
                case 1000002:
                    return JUHE_STOPSERVICE(var);
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 创建指标
        /// </summary>
        /// <param name="native">方法库</param>
        /// <param name="script">脚本</param>
        /// <param name="xml">XML</param>
        /// <returns>指标</returns>
        public static FCScript createIndicator(string script, FCUIXml xml) {
            FCScript indicator = new FCScript();
            FCDataTable table = new FCDataTable();
            indicator.DataSource = table;
            NFunctionBase.addFunctions(indicator, xml.Native);
            NFunctionUI.addFunctions(indicator, xml);
            int index = 1000000;
            string[] functions = FUNCTIONS.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            int functionsSize = functions.Length;
            for (int i = 0; i < functionsSize; i++) {
                indicator.addFunction(new NFunctionEx(indicator, index + i, functions[i], xml));
            }
            indicator.Script = script;
            table.addColumn(0);
            table.set(0, 0, 0);
            indicator.onCalculate(0);
            return indicator;
        }

        /// <summary>
        /// 服务状态
        /// </summary>
        /// <param name="var">变量</param>
        /// <returns>状态</returns>
        private double JUHE_SERVICESTATE(CVariable var) {
            string serviceName = m_indicator.getText(var.m_parameters[0]);
            if (serviceName == "all") {
                foreach (BaseWork work in DataCenter.Works.Values) {
                    if (work.IsRunning) {
                        return 1;
                    }
                }
                return 0;
            }
            else {
                return DataCenter.Works[serviceName.ToLower()].IsRunning ? 1 : 0;
            }
        }

        /// <summary>
        /// 开始服务
        /// </summary>
        /// <param name="var">变量</param>
        /// <returns>状态</returns>
        private double JUHE_STARTSERVICE(CVariable var) {
            string serviceName = m_indicator.getText(var.m_parameters[0]).ToLower();
            DataCenter.Works[serviceName].start();
            return 0;
        }

        /// <summary>
        /// 结束服务
        /// </summary>
        /// <param name="var">变量</param>
        /// <returns>状态</returns>
        private double JUHE_STOPSERVICE(CVariable var) {
            string serviceName = m_indicator.getText(var.m_parameters[0]).ToLower();
            DataCenter.Works[serviceName].stop();
            return 0;
        }
    }
}
