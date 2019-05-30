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

namespace FaceCat {
    /// <summary>
    /// 界面相关的库
    /// </summary>
    public class NFunctionBase : CFunction {
        /// <summary>
        /// 创建方法
        /// </summary>
        /// <param name="indicator">指标</param>
        /// <param name="id">ID</param>
        /// <param name="name">名称</param>
        /// <param name="withParameters">是否有参数</param>
        public NFunctionBase(FCScript indicator, int id, String name, FCNative native) {
            m_indicator = indicator;
            m_ID = id;
            m_name = name;
            m_native = native;
        }

        /// <summary>
        /// 指标
        /// </summary>
        public FCScript m_indicator;

        /// <summary>
        /// XML对象
        /// </summary>
        public FCNative m_native;

        /// <summary>
        /// 方法
        /// </summary>
        private static string FUNCTIONS = "IN,OUT,SLEEP";

        /// <summary>
        /// 前缀
        /// </summary>
        private static string PREFIX = "";

        /// <summary>
        /// 开始索引
        /// </summary>
        private static int STARTINDEX = 1000;

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="var">变量</param>
        /// <returns>结果</returns>
        public override double onCalculate(CVariable var) {
            switch (var.m_functionID) {
                case 1000:
                    return IN(var);
                case 1001:
                    return OUT(var);
                case 1002:
                    return SLEEP(var);
                default: return 0;
            }
        }

        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="indicator">方法库</param>
        /// <param name="native">脚本</param>
        /// <param name="xml">XML</param>
        /// <returns>指标</returns>
        public static void addFunctions(FCScript indicator, FCNative native) {
            string[] functions = FUNCTIONS.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            int functionsSize = functions.Length;
            for (int i = 0; i < functionsSize; i++) {
                indicator.addFunction(new NFunctionBase(indicator, STARTINDEX + i, PREFIX + functions[i], native));
            }
        }

        /// <summary>
        /// 输入函数
        /// </summary>
        /// <param name="var">变量</param>
        /// <returns>状态</returns>
        private double IN(CVariable var) {
            CVariable newVar = new CVariable(m_indicator);
            newVar.m_expression = "'" + Console.ReadLine() + "'";
            m_indicator.setVariable(var.m_parameters[0], newVar);
            return 0;
        }

        /// <summary>
        /// 输出函数
        /// </summary>
        /// <param name="var">变量</param>
        /// <returns>状态</returns>
        private double OUT(CVariable var) {
            int len = var.m_parameters.Length;
            for (int i = 0; i < len; i++) {
                string text = m_indicator.getText(var.m_parameters[i]);
                Console.Write(text);
            }
            Console.WriteLine("");
            return 0;
        }

        /// <summary>
        /// 睡眠
        /// </summary>
        /// <param name="var">变量</param>
        /// <returns>状态</returns>
        private double SLEEP(CVariable var) {
            Thread.Sleep((int)m_indicator.getValue(var.m_parameters[0]));
            return 1;
        }
    }
}
