using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _31161021170_OngVuongHoSanh.Models
{
    public class ChiTietHoaDon
    {
    [Key]
    public int MaChiTietHoaDon { get; set; }

    [ForeignKey("HoaDonObj")]
    public int MaHoaDon { get; set; }
    public virtual HoaDon HoaDonObj { get; set; }

    [ForeignKey("SanPhamObj")]
    public int MaSanPham { get; set; }
    public virtual SanPham SanPhamObj { get; set; }

    public int SoLuong { get; set; }
    }
}