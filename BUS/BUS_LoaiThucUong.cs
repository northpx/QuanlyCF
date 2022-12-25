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
    public class BUS_LoaiThucUong
    {
        public DataTable DanhSachLoaiThucUong()
        {
            DAL_LoaiThucUong TypeFood = new DAL_LoaiThucUong();
            DataTable dtList = TypeFood.DanhSachLoaiThucUong();
            return dtList;
        }

        public void ThemLoai(DTO_LoaiThucUong ma_loai)
        {
            DAL_LoaiThucUong TypeFood = new DAL_LoaiThucUong();
            TypeFood.ThemLoai(ma_loai);
        }
        public int KiemTraLoaiThucUongTonTai(string ma_loai)
        {
            DAL_LoaiThucUong TypeFood = new DAL_LoaiThucUong();
            int i = TypeFood.KiemTraLoaiThucUongTonTai(ma_loai);
            return i;
        }
        public void SuaLoai(DTO_LoaiThucUong ma_loai)
        {
            DAL_LoaiThucUong TypeFood = new DAL_LoaiThucUong();
            TypeFood.SuaLoai(ma_loai);
        }
        public void XoaLoai(DTO_LoaiThucUong ma_loai)
        {
            DAL_LoaiThucUong TypeFood = new DAL_LoaiThucUong();
            TypeFood.XoaLoai(ma_loai);
        }
        public DataTable LoadDanhSachTimKiem(string value, string text)
        {
            DAL_LoaiThucUong TypeFood = new DAL_LoaiThucUong();
            DataTable dtList = TypeFood.LoadDanhSachTimKiem(value, text);
            return dtList;
        }
    }
}
