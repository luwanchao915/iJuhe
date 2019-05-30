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
    /// GDI+��ͼ��չ��
    /// </summary>
    public class GdiPlusPaintEx : GdiPlusPaint {
        /// <summary>
        /// ��ȡ��ɫ
        /// </summary>
        /// <param name="dwPenColor">������ɫ</param>
        /// <returns>�����ɫ</returns>
        public override long getColor(long dwPenColor) {
            if (dwPenColor < FCColor.None) {
                return FCDraw.getBlackColor(dwPenColor);
            }
            else {
                return base.getColor(dwPenColor);
            }
        }
    }
}
