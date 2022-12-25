using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_KhuVuc
    {
        #region Atribute
        private string ma_kv;
        private string ma_kv_edit;
        private string ten_kv;
        private string ghi_chu;
        #endregion Atribute
        public DTO_KhuVuc()
        {
            ma_kv = "";
            ten_kv = "";
        }
        public string MaKhuVuc
        {
            get { return ma_kv; }
            set { ma_kv = value; }
        }
        public string MaKhuVuc_Sua
        {
            get { return ma_kv_edit; }
            set { ma_kv_edit = value; }
        }
        public string TenKhuVuc
        {
            get { return ten_kv; }
            set { ten_kv = value; }
        }
        public string GhiChu
        {
            get { return ghi_chu; }
            set { ghi_chu = value; }
        }
    }
}
