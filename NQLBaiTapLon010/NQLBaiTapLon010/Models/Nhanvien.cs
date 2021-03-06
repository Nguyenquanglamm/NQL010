using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NQLBaiTapLon010.Models
{
    [Table("NhanViens")]
    public class Nhanvien
    {
        [Key]
        [Display(Name = "Mã nhân viên")]
        public string IDnhanvien { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ Và Tên Nhân Viên không được để trống !")]
        public string Tennhanvien { get; set; }

        

        [Display(Name = "Ngày Sinh")]
        [Required(ErrorMessage = "Ngày sinh nhân viên không được để trống !")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode =true)]
        public DateTime Ngaysinhnhanvien { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại nhân viên không được để trống !")]
        public string SDTnhanvien { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Giới tính nhân viên không được để trống !")]
        public string Gioitinhnhanvien { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ nhân viên không được để trống !")]
        public string Diachinhanvien { get; set; }

        [Display(Name = "Số căn cước công dân")]
        [Required(ErrorMessage = "Số căn cước công dân nhân viên không được để trống !")]
        public string CCCDnhanvien { get; set; }

        [Display(Name = "Chức vụ")]
        public string IDchucvu { get; set; }
        [ForeignKey("IDchucvu")]
        public virtual Chucvu Chucvus { get; set; }

        [Display(Name = "Phòng Ban")]
        public string IDphongban { get; set; }
        [ForeignKey("IDphongban")]
        public virtual Phongban Phongbans { get; set; }


        [Display(Name = "Ngày Vào")]
        [Required(ErrorMessage = "Ngày vào nhân viên không được để trống !")]
        public DateTime NgayVao { get; set; }

        public ICollection<Luong> Luongs { get; set; }

    }
}