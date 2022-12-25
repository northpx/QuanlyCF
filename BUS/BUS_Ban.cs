using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Ban
    {
        public DataTable DanhSachBan()
        {
            DAL_Ban Table = new DAL_Ban();
            DataTable dtList = Table.DanhSachBan();
            return dtList;
        }
        public DataTable DanhSachKhuVuc()
        {
            DAL_Ban Table = new DAL_Ban();
            return Table.DanhSachKhuVuc();
        }
        public void ThemBan(DTO_Ban ma_ban)
        {
            DAL_Ban Table = new DAL_Ban();
            Table.ThemBan(ma_ban);
        }
        public int KiemTraBanTonTai(string ma_ban)
        {
            DAL_Ban Table = new DAL_Ban();
            int i = Table.KiemTraBanTonTai(ma_ban);
            return i;
        }
        public void SuaBan(DTO_Ban ma_ban)
        {
            DAL_Ban Table = new DAL_Ban();
            Table.SuaBan(ma_ban);
        }
        public void XoaBan(DTO_Ban ma_ban)
        {
            DAL_Ban Table = new DAL_Ban();
            Table.XoaBan(ma_ban);
        }
        public DataTable LoadDanhSachTimKiem(string value, string text)
        {
            DAL_Ban Table = new DAL_Ban();
            DataTable dtList = Table.LoadDanhSachTimKiem(value, text);
            return dtList;
        }
    }
}
