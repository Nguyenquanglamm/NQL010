using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NQLBaiTapLon010.Models
{
    [Table("Dangkys")]
    public class Dangkytuyendung
    {
        [Key]
        public string ID { get; set; }

        [Display(Name = "Họ và tên")]
        public string Ten { get; set; }

        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }

        [Display(Name = "Giới tính")]
        public string Gioitinh { get; set; }

        [Display(Name = "Ngày sinh")]
        public string Ngaysinh { get; set; }

        [Display(Name = "Quê quán")]
        public string Quequan { get; set; }

        [Display(Name = "Trình độ học vấn")]
        public string Trinhdo { get; set; }

        [Display(Name = "Gmail cá nhân")]
        public string Gmail { get; set; }

        [Display(Name = "Vị trí ứng tuyển")]
        public string Vitriungtuyen { get; set; }

        [Display(Name = "Kinh nghiệm")]
        public string Kinhnghiem { get; set; }
    }
}