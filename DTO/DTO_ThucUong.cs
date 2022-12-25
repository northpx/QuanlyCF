using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ThucUong
    {
        #region Atribute
        private string ma_mon_an;
        private string ma_mon_an_Edit;
        private string ten_mon_an;
        private string loai_mon_an;
        private decimal don_gia;
        private decimal so_luong;
        private string ghi_chu;
        #endregion Atribute
        public DTO_ThucUong()
        {
            ma_mon_an = "";
            ten_mon_an = "";
        }
        public string MaMon_Sua
        {
            get { return ma_mon_an_Edit; }
            set { ma_mon_an_Edit = value; }
        }
        public string MaMon
        {
            get { return ma_mon_an; }
            set { ma_mon_an = value; }
        }
        public string TenMon
        {
            get { return ten_mon_an; }
            set { ten_mon_an = value; }
        }
        public string MaLoai
        {
            get { return loai_mon_an; }
            set { loai_mon_an = value; }
        }
        public decimal DonGia
        {
            get { return don_gia; }
            set { don_gia = value; }
        }
        public decimal SoLuong
        {
            get { return so_luong; }
            set { so_luong = value; }
        }
        public string GhiChu
        {
            get { return ghi_chu; }
            set { ghi_chu = value; }
        }
    }
}
