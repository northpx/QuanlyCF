using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_LoaiThucUong
    {
        #region Atribute
        private string ma_loai;
        private string ma_loai_edit;
        private string ten_loai;
        private string ghi_chu;
        #endregion Atribute
        public DTO_LoaiThucUong()
        {
            ma_loai = "";
            ten_loai = "";
        }
        public string MaLoai
        {
            get { return ma_loai; }
            set { ma_loai = value; }
        }
        public string MaLoai_Sua
        {
            get { return ma_loai_edit; }
            set { ma_loai_edit = value; }
        }
        public string TenLoai
        {
            get { return ten_loai; }
            set { ten_loai = value; }
        }
        public string GhiChu
        {
            get { return ghi_chu; }
            set { ghi_chu = value; }
        }
    }
}
