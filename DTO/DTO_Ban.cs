using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Ban
    {
        #region Atribute
        private string ma_ban;
        private string ma_ban_Edit;
        private string ten_ban;
        private string khu_vuc;
        private decimal so_luong;
        private string ghi_chu;
        #endregion Atribute
        public DTO_Ban()
        {
            ma_ban = "";
            ten_ban = "";
        }
        public string MaBan_Sua
        {
            get { return ma_ban_Edit; }
            set { ma_ban_Edit = value; }
        }
        public string MaBan
        {
            get { return ma_ban; }
            set { ma_ban = value; }
        }
        public string TenBan
        {
            get { return ten_ban; }
            set { ten_ban = value; }
        }
        public string KhuVuc
        {
            get { return khu_vuc; }
            set { khu_vuc = value; }
        }
        public decimal SoLuong
        {
            get { return so_luong; }
            set { so_luong = value; }
        }
        public string GhIChu
        {
            get { return ghi_chu; }
            set { ghi_chu = value; }
        }
    }
}
