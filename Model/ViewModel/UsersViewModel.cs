using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Model.ViewModel
{
    public class UsersListViewModel
    {
        public int UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(200)]
        [DisplayName("Họ Và Tên")]
        public string UserFullName { get; set; }

        [StringLength(50)]
        [DisplayName("Di Động")]
        public string UserPhone { get; set; }

        [StringLength(50)]
        [DisplayName("Số Máy Nhánh")]
        public string UserExtention { get; set; }

        [StringLength(50)]
        public string UserEmail { get; set; }
        [DataType(DataType.Date)]
        public DateTime? UserDOB { get; set; }
        [DataType(DataType.Date)]
        public DateTime? UserCreateDate { get; set; }

        [StringLength(50)]
        public string UserComputer { get; set; }

        public bool? UserStatus { get; set; }

        public string GroupName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? UserJoinDate { get; set; }

        public string UserAddress { get; set; }
        public string Color { get; set; }
    }

    public class UserCreateViewModel
    {

        [StringLength(50)]
        [DisplayName("Tài Khoản")]
        [Required(ErrorMessage = "Hãy nhập {0}!",AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Mật Khẩu")]
        [Required(ErrorMessage = "Hãy nhập {0}", AllowEmptyStrings = false)]
        public string UserPass { get; set; }

        [StringLength(200)]
        [DisplayName("Họ Và Tên")]
        [Required(ErrorMessage = "Hãy nhập {0}", AllowEmptyStrings = false)]
        public string UserFullName { get; set; }

        [StringLength(200)]
        [DisplayName("Địa Chỉ")]
        [Required(ErrorMessage = "Hãy nhập {0}", AllowEmptyStrings = false)]
        public string UserAddress { get; set; }

        [StringLength(50)]
        [DisplayName("Di Động")]
        public string UserPhone { get; set; }

        [StringLength(50)]
        [DisplayName("Số Máy Nhánh")]
        public string UserExtention { get; set; }

        [StringLength(50)]
        [DisplayName("Email")]
        public string UserEmail { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [DisplayName("Ngày Sinh")]
        public DateTime? UserDOB { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Ngày Tạo")]
        public DateTime? UserCreateDate { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Hãy nhập {0}",AllowEmptyStrings = false)]
        public string UserComputer { get; set; }

        [DisplayName("Trạng Thái")]
        public bool? UserStatus { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [DisplayName("Ngày Vào Công Ty")]
        public DateTime? UserJoinDate { get; set; }

        [DisplayName("Nhóm")]
        [Required(ErrorMessage ="Hãy chọn {0}",AllowEmptyStrings = false)]
        public int GroupID { get; set; }

        public SelectList DdlGroupID { get; set; }

        public string Message { get; set; }
    }

    public class UserEditViewModel
    {
        public int UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string UserPass { get; set; }

        [StringLength(200)]
        [DisplayName("Họ Và Tên")]
        public string UserFullName { get; set; }

        [StringLength(200)]
        [DisplayName("Địa Chỉ")]
        public string UserAddress { get; set; }

        [StringLength(50)]
        [DisplayName("Di Động")]
        public string UserPhone { get; set; }

        [StringLength(50)]
        [DisplayName("Số Máy Nhánh")]
        public string UserExtention { get; set; }

        [StringLength(50)]
        public string UserEmail { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> UserDOB { get; set; }

        [StringLength(50)]
        public string UserComputer { get; set; }

        public bool? UserStatus { get; set; }

       
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? UserJoinDate { get; set; }

        public int GroupID { get; set; }

        public SelectList DdlGroupID { get; set; }

        public string Message { get; set; }
    }

    public class UserLoginViewModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string UserComName { get; set; }

        public bool UserStatus { get; set; }
        public string Message { get; set; }
    }
}
