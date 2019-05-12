using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _31161021170_OngVuongHoSanh.Models
{
    public class HoaDon
    {
        public HoaDon()
        {
            ChiTietHoaDons = new List<ChiTietHoaDon>();
        }
        [Key]
        public int MaHoaDon { get; set; }

        public IList<ChiTietHoaDon> ChiTietHoaDons
        {
            get;
            set;
        }
        public double TongTien { get; set; }
        public DateTime NgayLap { get; set; }
        public int? MaKhachHang { get; set; }
        public int TrangThai { get; set; }
        //0: chua thanh toan; 1:thanh toan, chua giao; 2:giao hang; 3: bi tra hang

    }
}