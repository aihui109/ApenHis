using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApenHis.EntityExtensions
{
    public partial class UserExt
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "拼音码不能为空")]
        [StringLength(16, ErrorMessage = "拼音码长度不能超过50个字符"), Column(TypeName = "nvarchar(16)")]
        public string InputCode { get; set; }

        [Display(Name = "部门")]
        public Guid? DepartmentId { get; set; }

        [Display(Name = "身份证号码")]
        [StringLength(18, ErrorMessage = "{0}不能超过18位"), Column(TypeName = "nvarchar(18)")]
        [RegularExpression(@"\d{17}[\d|X]|\d{15}", ErrorMessage = "身份证格式不正确,请输入15或18位身份证号")]
        public string IDCard { get; set; }

        [Display(Name = "性别")]
        [Column(TypeName = "nvarchar(20)")]
        public string Sex { get; set; }

        [Display(Name = "生日")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "民族")]
        [Column(TypeName = "nvarchar(20)")]
        public string Nation { get; set; }

        [Display(Name = "职称")]
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        public bool IsAdmin { get; set; }
    }
}