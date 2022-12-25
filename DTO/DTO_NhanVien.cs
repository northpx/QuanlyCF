using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_NhanVien
    {
        #region Atribute
        private string ma_nv;
        private string ma_nv_Edit;
        private string ten_nv;
        private string gioi_tinh;
        private string dien_thoai;
        private string dia_chi;
        private string ma_nv_search;
        private string ten_nv_search;
        #endregion Atribute
        public DTO_NhanVien()
        {
            ma_nv = "";
            ten_nv = "";
        }
        public string MaNhanVien_Sua
        {
            get { return ma_nv_Edit; }
            set { ma_nv_Edit = value; }
        }
        public string MaNhanVien
        {
            get { return ma_nv; }
            set { ma_nv = value; }
        }
        public string TeNhanVien
        {
            get { return ten_nv; }
            set { ten_nv = value; }
        }
        public string GioiTinh
        {
            get { return gioi_tinh; }
            set { gioi_tinh = value; }
        }
        public string DienThoai
        {
            get { return dien_thoai; }
            set { dien_thoai = value; }
        }
        public string DiaChi
        {
            get { return dia_chi; }
            set { dia_chi = value; }
        }
    }
}
