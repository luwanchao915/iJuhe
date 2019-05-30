﻿/*基于捂脸猫FaceCat框架 v1.0 https://github.com/FaceCat007/facecat.git
 1.创始人-矿洞程序员-上海宁米科技创始人-脉脉KOL-陶德 (微信号:suade1984);
 2.联合创始人-上海宁米科技创始人-袁立涛(微信号:wx627378127);
 3.联合创始人-肖添龙(微信号:xiaotianlong_luu);
 4.联合开发者-陈晓阳(微信号:chenxiaoyangzxy)，助理-朱炜(微信号:cnnic_zhu);
 5.该程序开源协议为BSD，欢迎对我们的创业活动进行各种支持，欢迎更多开发者加入。
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FaceCat {
    public class FaceCatScript : FCUIScript {
        /// <summary>
        /// 创建脚本
        /// </summary>
        /// <param name="xml">XML对象</param>
        public FaceCatScript(FCUIXml xml) {
            m_xml = xml;
        }

        /// <summary>
        /// 脚本对象
        /// </summary>
        private FCScript m_script;

        /// <summary>
        /// 脚本文本
        /// </summary>
        private String m_text;

        private bool m_isDeleted = false;

        /// <summary>
        /// 获取是否被销毁
        /// </summary>
        public bool IsDeleted {
            get { return m_isDeleted; }
        }

        private FCUIXml m_xml;

        /// <summary>
        /// 获取或设置XML对象
        /// </summary>
        public FCUIXml Xml {
            get { return m_xml; }
            set { m_xml = value; }
        }

        /// <summary>
        /// 调用方法
        /// </summary>
        /// <param name="function">方法文本</param>
        /// <returns>返回值</returns>
        public String callFunction(String function) {
            return m_script.callFunction(function).ToString();
        }

        /// <summary>
        /// 销毁方法
        /// </summary>
        public virtual void delete() {
            if (!m_isDeleted) {
                if (m_script != null) {
                    m_script.delete();
                }
                m_isDeleted = true;
            }
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="name">控件名称</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns>属性值</returns>
        public String getProperty(String name, String propertyName) {
            if (m_xml != null) {
                FCView control = m_xml.findControl(name);
                if (control != null) {
                    String value = null, type = null;
                    control.getProperty(propertyName, ref value, ref type);
                    return value;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取调用者
        /// </summary>
        /// <returns>调用者名称</returns>
        public String getSender() {
            if (m_xml != null) {
                FCUIEvent uiEvent = m_xml.Event;
                if (uiEvent != null) {
                    return uiEvent.Sender;
                }
            }
            return null;
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="name">控件ID</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="propertyValue">属性值</param>
        public void setProperty(String name, String propertyName, String propertyValue) {
            if (m_xml != null) {
                FCView control = m_xml.findControl(name);
                if (control != null) {
                    control.setProperty(propertyName, propertyValue);
                }
            }
        }

        /// <summary>
        /// 设置脚本
        /// </summary>
        /// <param name="text">脚本</param>
        public void setText(String text) {
            m_text = text;
            m_script = NFunctionEx.createIndicator(text, m_xml);
        }
    }
}
