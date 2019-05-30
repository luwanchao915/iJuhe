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
    /// ָ�����
    /// </summary>
    public class Indicator {
        /// <summary>
        /// ���
        /// </summary>
        public String m_category = "";

        /// <summary>
        /// Ԥ����ʾ����
        /// </summary>
        public String m_coordinate = "";

        /// <summary>
        /// ����
        /// </summary>
        public String m_description = "";

        /// <summary>
        /// ��ʾС����λ��
        /// </summary>
        public int m_digit;

        /// <summary>
        /// ָ��ID
        /// </summary>
        public String m_indicatorID = "";

        /// <summary>
        /// ����
        /// </summary>
        public String m_name = "";

        /// <summary>
        /// �б�˳��
        /// </summary>
        public int m_orderNum;

        /// <summary>
        /// ���߷���
        /// </summary>
        public int m_paintType;

        /// <summary>
        /// ����
        /// </summary>
        public String m_parameters = "";

        /// <summary>
        /// ����
        /// </summary>
        public String m_password = "";

        /// <summary>
        /// ����Y������
        /// </summary>
        public String m_specialCoordinate = "";

        /// <summary>
        /// �ı�
        /// </summary>
        public String m_text = "";

        /// <summary>
        /// ����
        /// </summary>
        public int m_type;

        /// <summary>
        /// �Ƿ�ʹ������
        /// </summary>
        public int m_usePassword;

        /// <summary>
        /// �û�ID
        /// </summary>
        public int m_userID;

        /// <summary>
        /// �汾
        /// </summary>
        public int m_version;
    }

    /// <summary>
    /// ��Ʊ��Ϣ
    /// </summary>
    public class Security {
        /// <summary>
        /// �������̾���
        /// </summary>
        public Security() {
        }

        /// <summary>
        /// ��Ʊ����
        /// </summary>
        public String m_code = "";

        /// <summary>
        /// ��Ʊ����
        /// </summary>
        public String m_name = "";

        /// <summary>
        /// ƴ��
        /// </summary>
        public String m_pingyin = "";

        /// <summary>
        /// ״̬
        /// </summary>
        public int m_status;

        /// <summary>
        /// �г�����
        /// </summary>
        public int m_type;
    }

    /// <summary>
    /// ֤ȯ����
    /// </summary>
    public class SecurityCategory {
        /// <summary>
        /// ��Ʊ
        /// </summary>
        public const int Stock = 0;

        /// <summary>
        /// ָ��
        /// </summary>
        public const int Index = 1;

        /// <summary>
        /// �ڻ�
        /// </summary>
        public const int Future = 2;

        /// <summary>
        /// ������ת��Ϊ���
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int convertTypeToCategory(int type) {
            switch (type) {
                case 11:
                case 12:
                case 50:
                case 51:
                case 52:
                case 68:
                case 80:
                case 81:
                    return Future;
                default:
                    return Stock;
            }
        }
    }

    /// <summary>
    /// ֤ȯ��ʷ����
    /// </summary>
    public class SecurityData {
        /// <summary>
        /// ƽ���۸�
        /// </summary>
        public float m_avgPrice;

        /// <summary>
        /// ���̼�
        /// </summary>
        public float m_close;

        /// <summary>
        /// ����
        /// </summary>
        public double m_date;

        /// <summary>
        /// ��߼�
        /// </summary>
        public float m_high;

        /// <summary>
        /// ��ͼ�
        /// </summary>
        public float m_low;

        /// <summary>
        /// ���̼�
        /// </summary>
        public float m_open;

        /// <summary>
        /// �ɽ���
        /// </summary>
        public double m_volume;

        /// <summary>
        /// �ɽ���
        /// </summary>
        public double m_amount;

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="data">����</param>
        public void copy(SecurityData data) {
            m_close = data.m_close;
            m_date = data.m_date;
            m_high = data.m_high;
            m_low = data.m_low;
            m_open = data.m_open;
            m_volume = data.m_volume;
            m_amount = data.m_amount;
        }
    }

    /// <summary>
    /// ����������Ϣ
    /// </summary>
    public class SecurityDataInfo : WorkDataInfo {
        /// <summary>
        /// ֤ȯ��Ϣ
        /// </summary>
        public Security m_security;
    }

    /// <summary>
    /// ����������Ϣ��չ
    /// </summary>
    public class SecurityDataInfoDateEx : SecurityDataInfo {
        /// <summary>
        /// ����
        /// </summary>
        public List<DateTime> m_dates;
    }

    /// <summary>
    /// ��Ʊʵʱ����
    /// </summary>
    public class SecurityLatestData {
        /// <summary>
        /// �ɽ���
        /// </summary>
        public double m_amount;

        /// <summary>
        /// ��һ��
        /// </summary>
        public int m_buyVolume1;

        /// <summary>
        /// �����
        /// </summary>
        public int m_buyVolume2;

        /// <summary>
        /// ������
        /// </summary>
        public int m_buyVolume3;

        /// <summary>
        /// ������
        /// </summary>
        public int m_buyVolume4;

        /// <summary>
        /// ������
        /// </summary>
        public int m_buyVolume5;

        /// <summary>
        /// ��һ��
        /// </summary>
        public float m_buyPrice1;

        /// <summary>
        /// �����
        /// </summary>
        public float m_buyPrice2;

        /// <summary>
        /// ������
        /// </summary>
        public float m_buyPrice3;

        /// <summary>
        /// ���ļ�
        /// </summary>
        public float m_buyPrice4;

        /// <summary>
        /// �����
        /// </summary>
        public float m_buyPrice5;

        /// <summary>
        /// ��ǰ�۸�
        /// </summary>
        public float m_close;

        /// <summary>
        /// ���ڼ�ʱ��
        /// </summary>
        public double m_date;

        /// <summary>
        /// ��߼�
        /// </summary>
        public float m_high;

        /// <summary>
        /// ���̳ɽ���
        /// </summary>
        public int m_innerVol;

        /// <summary>
        /// �������̼�
        /// </summary>
        public float m_lastClose;

        /// <summary>
        /// ��ͼ�
        /// </summary>
        public float m_low;

        /// <summary>
        /// ���̼�
        /// </summary>
        public float m_open;

        /// <summary>
        /// �ڻ��ֲ���
        /// </summary>
        public double m_openInterest;

        /// <summary>
        /// ���̳ɽ���
        /// </summary>
        public int m_outerVol;

        /// <summary>
        /// ��Ʊ����
        /// </summary>
        public String m_securityCode = "";

        /// <summary>
        /// ��һ��
        /// </summary>
        public int m_sellVolume1;

        /// <summary>
        /// ������
        /// </summary>
        public int m_sellVolume2;

        /// <summary>
        /// ������
        /// </summary>
        public int m_sellVolume3;

        /// <summary>
        /// ������
        /// </summary>
        public int m_sellVolume4;

        /// <summary>
        /// ������
        /// </summary>
        public int m_sellVolume5;

        /// <summary>
        /// ��һ��
        /// </summary>
        public float m_sellPrice1;

        /// <summary>
        /// ������
        /// </summary>
        public float m_sellPrice2;

        /// <summary>
        /// ������
        /// </summary>
        public float m_sellPrice3;

        /// <summary>
        /// ���ļ�
        /// </summary>
        public float m_sellPrice4;

        /// <summary>
        /// �����
        /// </summary>
        public float m_sellPrice5;

        /// <summary>
        /// �ڻ������
        /// </summary>
        public float m_settlePrice;

        /// <summary>
        /// ������
        /// </summary>
        public float m_turnoverRate;

        /// <summary>
        /// �ɽ���
        /// </summary>
        public double m_volume;

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="data">����</param>
        public void copy(SecurityLatestData data) {
            if (data == null) return;
            m_amount = data.m_amount;
            m_buyVolume1 = data.m_buyVolume1;
            m_buyVolume2 = data.m_buyVolume2;
            m_buyVolume3 = data.m_buyVolume3;
            m_buyVolume4 = data.m_buyVolume4;
            m_buyVolume5 = data.m_buyVolume5;
            m_buyPrice1 = data.m_buyPrice1;
            m_buyPrice2 = data.m_buyPrice2;
            m_buyPrice3 = data.m_buyPrice3;
            m_buyPrice4 = data.m_buyPrice4;
            m_buyPrice5 = data.m_buyPrice5;
            m_close = data.m_close;
            m_date = data.m_date;
            m_high = data.m_high;
            m_innerVol = data.m_innerVol;
            m_lastClose = data.m_lastClose;
            m_low = data.m_low;
            m_open = data.m_open;
            m_openInterest = data.m_openInterest;
            m_outerVol = data.m_outerVol;
            m_securityCode = data.m_securityCode;
            m_sellVolume1 = data.m_sellVolume1;
            m_sellVolume2 = data.m_sellVolume2;
            m_sellVolume3 = data.m_sellVolume3;
            m_sellVolume4 = data.m_sellVolume4;
            m_sellVolume5 = data.m_sellVolume5;
            m_sellPrice1 = data.m_sellPrice1;
            m_sellPrice2 = data.m_sellPrice2;
            m_sellPrice3 = data.m_sellPrice3;
            m_sellPrice4 = data.m_sellPrice4;
            m_sellPrice5 = data.m_sellPrice5;
            m_settlePrice = data.m_settlePrice;
            m_turnoverRate = data.m_turnoverRate;
            m_volume = data.m_volume;
        }

        /// <summary>
        /// �Ƚ��Ƿ���ͬ
        /// </summary>
        /// <param name="data">����</param>
        /// <returns>�Ƿ���ͬ</returns>
        public bool Equal(SecurityLatestData data) {
            if (data == null) return false;
            if (m_amount == data.m_amount
            && m_buyVolume1 == data.m_buyVolume1
            && m_buyVolume2 == data.m_buyVolume2
            && m_buyVolume3 == data.m_buyVolume3
            && m_buyVolume4 == data.m_buyVolume4
            && m_buyVolume5 == data.m_buyVolume5
            && m_buyPrice1 == data.m_buyPrice1
            && m_buyPrice2 == data.m_buyPrice2
            && m_buyPrice3 == data.m_buyPrice3
            && m_buyPrice4 == data.m_buyPrice4
            && m_buyPrice5 == data.m_buyPrice5
            && m_close == data.m_close
            && m_date == data.m_date
            && m_high == data.m_high
            && m_innerVol == data.m_innerVol
            && m_lastClose == data.m_lastClose
            && m_low == data.m_low
            && m_open == data.m_open
            && m_openInterest == data.m_openInterest
            && m_outerVol == data.m_outerVol
            && m_securityCode == data.m_securityCode
            && m_sellVolume1 == data.m_sellVolume1
            && m_sellVolume2 == data.m_sellVolume2
            && m_sellVolume3 == data.m_sellVolume3
            && m_sellVolume4 == data.m_sellVolume4
            && m_sellVolume5 == data.m_sellVolume5
            && m_sellPrice1 == data.m_sellPrice1
            && m_sellPrice2 == data.m_sellPrice2
            && m_sellPrice3 == data.m_sellPrice3
            && m_sellPrice4 == data.m_sellPrice4
            && m_sellPrice5 == data.m_sellPrice5
            && m_settlePrice == data.m_settlePrice
            && m_turnoverRate == data.m_turnoverRate
            && m_volume == data.m_volume) {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// ��Ʊʵʱ����LV2
    /// </summary>
    public class SecurityLatestDataLV2 {
        /// <summary>
        /// ί������
        /// </summary>
        public double m_allBuyVol;

        /// <summary>
        /// ί������
        /// </summary>
        public double m_allSellVol;

        /// <summary>
        /// ��Ȩƽ��ί���۸�
        /// </summary>
        public float m_avgBuyPrice;

        /// <summary>
        /// ��Ȩƽ��ί���۸�
        /// </summary>
        public float m_avgSellPrice;

        /// <summary>
        /// ������
        /// </summary>
        public int m_buyVolume6;

        /// <summary>
        /// ������
        /// </summary>
        public int m_buyVolume7;

        /// <summary>
        /// �����
        /// </summary>
        public int m_buyVolume8;

        /// <summary>
        /// �����
        /// </summary>
        public int m_buyVolume9;

        /// <summary>
        /// ��ʮ��
        /// </summary>
        public int m_buyVolume10;

        /// <summary>
        /// ������
        /// </summary>
        public float m_buyPrice6;

        /// <summary>
        /// ���߼�
        /// </summary>
        public float m_buyPrice7;

        /// <summary>
        /// ��˼�
        /// </summary>
        public float m_buyPrice8;

        /// <summary>
        /// ��ż�
        /// </summary>
        public float m_buyPrice9;

        /// <summary>
        /// ��ʮ��
        /// </summary>
        public float m_buyPrice10;

        /// <summary>
        /// ��Ʊ����
        /// </summary>
        public String m_securityCode = "";

        /// <summary>
        /// ������
        /// </summary>
        public int m_sellVolume6;

        /// <summary>
        /// ������
        /// </summary>
        public int m_sellVolume7;

        /// <summary>
        /// ������
        /// </summary>
        public int m_sellVolume8;

        /// <summary>
        /// ������
        /// </summary>
        public int m_sellVolume9;

        /// <summary>
        /// ��ʮ��
        /// </summary>
        public int m_sellVolume10;

        /// <summary>
        /// ������
        /// </summary>
        public float m_sellPrice6;

        /// <summary>
        /// ���߼�
        /// </summary>
        public float m_sellPrice7;

        /// <summary>
        /// ���˼�
        /// </summary>
        public float m_sellPrice8;

        /// <summary>
        /// ���ż�
        /// </summary>
        public float m_sellPrice9;

        /// <summary>
        /// ��ʮ��
        /// </summary>
        public float m_sellPrice10;

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="data">����</param>
        public void copy(SecurityLatestDataLV2 data) {
            if (data == null) return;
            m_allBuyVol = data.m_allBuyVol;
            m_allSellVol = data.m_allSellVol;
            m_avgBuyPrice = data.m_avgBuyPrice;
            m_avgSellPrice = data.m_avgSellPrice;
            m_buyVolume6 = data.m_buyVolume6;
            m_buyVolume7 = data.m_buyVolume7;
            m_buyVolume8 = data.m_buyVolume8;
            m_buyVolume9 = data.m_buyVolume9;
            m_buyVolume10 = data.m_buyVolume10;
            m_buyPrice6 = data.m_buyPrice6;
            m_buyPrice7 = data.m_buyPrice7;
            m_buyPrice8 = data.m_buyPrice8;
            m_buyPrice9 = data.m_buyPrice9;
            m_buyPrice10 = data.m_buyPrice10;
            m_securityCode = data.m_securityCode;
            m_sellVolume6 = data.m_sellVolume6;
            m_sellVolume7 = data.m_sellVolume7;
            m_sellVolume8 = data.m_sellVolume8;
            m_sellVolume9 = data.m_sellVolume9;
            m_sellVolume10 = data.m_sellVolume10;
            m_sellPrice6 = data.m_sellPrice6;
            m_sellPrice7 = data.m_sellPrice7;
            m_sellPrice8 = data.m_sellPrice8;
            m_sellPrice9 = data.m_sellPrice9;
            m_sellPrice10 = data.m_sellPrice10;
        }

        /// <summary>
        /// �Ƚ��Ƿ���ͬ
        /// </summary>
        /// <param name="data">����</param>
        /// <returns>�Ƿ���ͬ</returns>
        public bool Equal(SecurityLatestDataLV2 data) {
            if (data == null) return false;
            if (m_allBuyVol == data.m_allBuyVol
            && m_allSellVol == data.m_allSellVol
            && m_avgBuyPrice == data.m_avgBuyPrice
            && m_avgSellPrice == data.m_avgSellPrice
            && m_buyVolume6 == data.m_buyVolume6
            && m_buyVolume7 == data.m_buyVolume7
            && m_buyVolume8 == data.m_buyVolume8
            && m_buyVolume9 == data.m_buyVolume9
            && m_buyVolume10 == data.m_buyVolume10
            && m_buyPrice6 == data.m_buyPrice6
            && m_buyPrice7 == data.m_buyPrice7
            && m_buyPrice8 == data.m_buyPrice8
            && m_buyPrice9 == data.m_buyPrice9
            && m_buyPrice10 == data.m_buyPrice10
            && m_securityCode == data.m_securityCode
            && m_sellVolume6 == data.m_sellVolume6
            && m_sellVolume7 == data.m_sellVolume7
            && m_sellVolume8 == data.m_sellVolume8
            && m_sellVolume9 == data.m_sellVolume9
            && m_sellVolume10 == data.m_sellVolume10
            && m_sellPrice6 == data.m_sellPrice6
            && m_sellPrice7 == data.m_sellPrice7
            && m_sellPrice8 == data.m_sellPrice8
            && m_sellPrice9 == data.m_sellPrice9
            && m_sellPrice10 == data.m_sellPrice10) {
                return true;
            }
            else {
                return false;
            }
        }
    }

    /// <summary>
    /// �����ֶ�
    /// </summary>
    public class KeyFields {
        /// <summary>
        /// ���̼�
        /// </summary>
        public const String CLOSE = "CLOSE";
        /// <summary>
        /// ��߼�
        /// </summary>
        public const String HIGH = "HIGH";
        /// <summary>
        /// ��ͼ�
        /// </summary>
        public const String LOW = "LOW";
        /// <summary>
        /// ���̼�
        /// </summary>
        public const String OPEN = "OPEN";
        /// <summary>
        /// �ɽ���
        /// </summary>
        public const String VOL = "VOL";
        /// <summary>
        /// �ɽ���
        /// </summary>
        public const String AMOUNT = "AMOUNT";

        /// <summary>
        /// ƽ���۸�
        /// </summary>
        public const String AVGPRICE = "AVGPRICE";

        /// <summary>
        /// ���̼��ֶ�
        /// </summary>
        public const int CLOSE_INDEX = 0;
        /// <summary>
        /// ��߼��ֶ�
        /// </summary>
        public const int HIGH_INDEX = 1;
        /// <summary>
        /// ��ͼ��ֶ�
        /// </summary>
        public const int LOW_INDEX = 2;
        /// <summary>
        /// ���̼��ֶ�
        /// </summary>
        public const int OPEN_INDEX = 3;
        /// <summary>
        /// �ɽ����ֶ�
        /// </summary>
        public const int VOL_INDEX = 4;
        /// <summary>
        /// �ɽ����ֶ�
        /// </summary>
        public const int AMOUNT_INDEX = 5;

        /// <summary>
        /// ƽ���۸��ֶ�
        /// </summary>
        public const int AVGPRICE_INDEX = 6;
    }

    /// <summary>
    /// ��ѡ�����
    /// </summary>
    public class UserSecurityCategory {
        /// <summary>
        /// ���ID
        /// </summary>
        public String m_categoryID = "";

        /// <summary>
        /// ��Ʊ����
        /// </summary>
        public String m_codes = "";

        /// <summary>
        /// �������
        /// </summary>
        public String m_name = "";

        /// <summary>
        /// �б�˳��
        /// </summary>
        public int m_orderNum;

        /// <summary>
        /// ���
        /// </summary>
        public int m_type;

        /// <summary>
        /// �û�ID
        /// </summary>
        public int m_userID;
    }

    /// <summary>
    /// ����ѡ��ģ��
    /// </summary>
    public class SecurityFilterTemplate {
        /// <summary>
        /// ��ѡ�ɴ���
        /// </summary>
        public String m_codes = "";

        /// <summary>
        /// ��������
        /// </summary>
        public String m_filter = "";

        /// <summary>
        /// ָ��
        /// </summary>
        public String m_indicator = "";

        /// <summary>
        /// ģ��ID
        /// </summary>
        public String m_templateID = "";

        /// <summary>
        /// ����
        /// </summary>
        public int m_cycle;

        /// <summary>
        /// ��Ȩģʽ
        /// </summary>
        public int m_subscription;

        /// <summary>
        /// ģ������
        /// </summary>
        public String m_name = "";

        /// <summary>
        /// �б�˳��
        /// </summary>
        public int m_orderNum;

        /// <summary>
        /// ����
        /// </summary>
        public String m_parameters = "";

        /// <summary>
        /// �û�ID
        /// </summary>
        public int m_userID;
    }

    /// <summary>
    /// ��¼��Ϣ
    /// </summary>
    public class LoginInfo {
        /// <summary>
        /// ����û���
        /// </summary>
        public int m_maxUsers;

        /// <summary>
        /// �ǳ�
        /// </summary>
        public String m_nickName = "";

        /// <summary>
        /// ����
        /// </summary>
        public String m_passWord = "";

        /// <summary>
        /// �ỰID
        /// </summary>
        public int m_sessionID;

        /// <summary>
        /// ״̬
        /// </summary>
        public int m_state;

        /// <summary>
        /// ����
        /// </summary>
        public int m_type;

        /// <summary>
        /// �û�ID
        /// </summary>
        public int m_userID;

        /// <summary>
        /// �û�����
        /// </summary>
        public String m_userName = "";
    }

    /// <summary>
    /// ��ʷ������Ϣ
    /// </summary>
    public class HistoryDataInfo {
        /// <summary>
        /// ����
        /// </summary>
        public int m_cycle;

        /// <summary>
        /// ��������
        /// </summary>
        public double m_endDate;

        /// <summary>
        /// �Ƿ���Ҫ��������
        /// </summary>
        public bool m_pushData;

        /// <summary>
        /// ��Ʊ����
        /// </summary>
        public String m_securityCode;

        /// <summary>
        /// ��������
        /// </summary>
        public int m_size;

        /// <summary>
        /// ��ʼ����
        /// </summary>
        public double m_startDate;

        /// <summary>
        /// ��Ȩģʽ
        /// </summary>
        public int m_subscription;

        /// <summary>
        /// ����
        /// </summary>
        public int m_type;
    }

    /// <summary>
    /// ����������Ϣ
    /// </summary>
    public class LatestDataInfo {
        /// <summary>
        /// ����
        /// </summary>
        public String m_codes = "";

        /// <summary>
        /// ��ʽ
        /// </summary>
        public int m_formatType;

        /// <summary>
        /// �Ƿ����LV2
        /// </summary>
        public int m_lv2;

        /// <summary>
        /// ��������
        /// </summary>
        public int m_size;
    }

    /// <summary>
    /// ����LV2������Ϣ
    /// </summary>
    public class LatestDataInfoLV2 {
        /// <summary>
        /// ��������
        /// </summary>
        public int m_size;
    }

    /// <summary>
    /// �ɽ�����
    /// </summary>
    public class TransactionData {
        /// <summary>
        /// ����
        /// </summary>
        public double m_date;

        /// <summary>
        /// �۸�
        /// </summary>
        public float m_price;

        /// <summary>
        /// ����
        /// </summary>
        public int m_type;

        /// <summary>
        /// �ɽ���
        /// </summary>
        public double m_volume;
    }

    /// <summary>
    /// �ɽ���Ԥ������
    /// </summary>
    public class VolumeForecastData {
        /// <summary>
        /// ��Ʊ����
        /// </summary>
        public String m_securityCode = "";

        /// <summary>
        /// �ɽ���ռ��
        /// </summary>
        public double m_rate;
    }

    /// <summary>
    /// ָ�겼��
    /// </summary>
    public class IndicatorLayout {
        /// <summary>
        /// ����ID
        /// </summary>
        public String m_layoutID = "";

        /// <summary>
        /// ����
        /// </summary>
        public String m_name = "";

        /// <summary>
        /// �б�˳��
        /// </summary>
        public int m_orderNum;

        /// <summary>
        /// �ĵ�
        /// </summary>
        public String m_text = "";

        /// <summary>
        /// ����
        /// </summary>
        public int m_type;

        /// <summary>
        /// �û�ID
        /// </summary>
        public int m_userID;
    }

    /// <summary>
    /// ��������
    /// </summary>
    public class ChatData {
        /// <summary>
        /// ����
        /// </summary>
        public String m_text = "";

        /// <summary>
        /// ����
        /// </summary>
        public int m_type;

        /// <summary>
        /// �û�ID
        /// </summary>
        public int m_userID;
    }

    /// <summary>
    /// �û��Ự��Ϣ
    /// </summary>
    public class UserSession {
        /// <summary>
        /// �û�ID
        /// </summary>
        public int m_userID;
        /// <summary>
        /// �Ự��
        /// </summary>
        public String m_key = "";
        /// <summary>
        /// �Ựֵ
        /// </summary>
        public String m_value = "";
    }

    /// <summary>
    /// ��
    /// </summary>
    public class Macro {
        /// <summary>
        /// ��ȴʱ��
        /// </summary>
        public int m_cd;

        /// <summary>
        /// ����
        /// </summary>
        public String m_description = "";

        /// <summary>
        /// ͼ��
        /// </summary>
        public String m_icon = "";

        /// <summary>
        /// ���ݳ���
        /// </summary>
        public int m_interval = 1;

        /// <summary>
        /// ��ID
        /// </summary>
        public String m_macroID = "";

        /// <summary>
        /// ����
        /// </summary>
        public String m_name = "";

        /// <summary>
        /// �����ֶ�
        /// </summary>
        public int m_orderNum;

        /// <summary>
        /// �ű�
        /// </summary>
        public String m_script = "";

        /// <summary>
        /// ����
        /// </summary>
        public int m_type;

        /// <summary>
        /// �û�ID
        /// </summary>
        public int m_userID;
    }

    /// <summary>
    /// ���ʴ���
    /// </summary>
    public class UserSecurityVisitsCount {
        /// <summary>
        /// ���������
        /// </summary>
        public Dictionary<String, int> m_codes = new Dictionary<String, int>();

        /// <summary>
        /// �û�ID
        /// </summary>
        public int m_userID;

        /// <summary>
        /// ���ַ���ת��Ϊ����
        /// </summary>
        /// <param name="str">�ַ���</param>
        public void codesFromString(String str) {
            m_codes.Clear();
            String[] strs = str.Split(new String[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            int strsSize = strs.Length;
            for (int i = 0; i < strsSize; i++) {
                String[] subStrs = strs[i].Split(new String[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                m_codes[subStrs[0]] = FCStr.convertStrToInt(subStrs[1]);
            }
        }

        /// <summary>
        /// ת��Ϊ�ַ���
        /// </summary>
        /// <returns>�ַ���</returns>
        public String codesToString() {
            String str = "";
            foreach (String code in m_codes.Keys) {
                str += code + ":" + m_codes[code].ToString() + ";";
            }
            return str;
        }
    }

    /// <summary>
    /// ������Ϣ
    /// </summary>
    public class NewsInfo {
        /// <summary>
        /// ����������Ϣ
        /// </summary>
        /// <param name="identifier">����</param>
        public NewsInfo(String identifier) {
            m_identifier = identifier;
        }

        /// <summary>
        /// ����
        /// </summary>
        public String m_code;

        /// <summary>
        /// ����
        /// </summary>
        public String m_content;

        /// <summary>
        /// ��ʶ
        /// </summary>
        public String m_identifier;

        /// <summary>
        /// ����
        /// </summary>
        public String m_title;

        /// <summary>
        /// ʱ��
        /// </summary>
        public String m_time;

        /// <summary>
        /// ����
        /// </summary>
        public int m_type;

        /// <summary>
        /// ��ַ
        /// </summary>
        public String m_url;

        /// <summary>
        /// ��ȡĿ¼
        /// </summary>
        /// <returns>Ŀ¼</returns>
        public String getDirectory() {
            String fileName = FCStrEx.convertDBCodeToFileName(m_code);
            String dir = DataCenter.getDataPath() + "\\" + m_identifier;
            dir += "\\" + fileName.Replace(".txt", "");
            return dir;
        }

        /// <summary>
        /// ��ȡ�ļ�����
        /// </summary>
        /// <returns>�ļ�����</returns>
        public String getFileName() {
            DateTime date = DateTime.Parse(m_time);
            return getDirectory() + "\\" + date.ToString("yyyyMMddhhmm") + " " + CSpell.getChineseSpellCode(m_title);
        }

        /// <summary>
        /// ת��Ϊ�ַ���
        /// </summary>
        /// <returns>�ַ���</returns>
        public override String ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append(m_code + "\r\n");
            sb.Append(m_time + "\r\n");
            sb.Append(m_title + "\r\n");
            sb.Append(m_url + "\r\n");
            sb.Append(m_type + "\r\n");
            sb.Append(m_content);
            return sb.ToString();
        }
    }
}
