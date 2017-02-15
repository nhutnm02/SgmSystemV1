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
    public class UserEventCreateViewModel
    {
        public int UeID { get; set; }

        public int? EventID { get; set; }

        public int? UserID { get; set; }

        [DisplayName("Mã Tour / Mô Tả")]
        [StringLength(200)]
        [Required(ErrorMessage = "Hãy nhập thông tin!", AllowEmptyStrings = false)]
        public string UeNote { get; set; }

        public DateTime? UeCreateDate { get; set; }

        [DisplayName("Đến Ngày")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Hãy chọn ngày!")]
        
        public DateTime? UeWillExpires { get; set; }

        [DisplayName("Từ Ngày")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Hãy chọn ngày!")]
        public DateTime? UeDateExpires { get; set; }

        public int? UeType { get; set; }

        public bool? UeLeaderOk { get; set; }

        public bool? UeOk { get; set; }

        public string Message { get; set; }

    }

    public class UserEventListViewModel
    {
        public int UeID { get; set; }

        public int? UserID { get; set; }

        [DisplayName("Mã Tour / Mô Tả")]
        [StringLength(200)] 
        public string UeNote { get; set; }

        public DateTime? UeCreateDate { get; set; }

        [DisplayName("Đến Ngày")]
        [DataType(DataType.Date)]
        public DateTime? UeWillExpires { get; set; }

        [DisplayName("Từ Ngày")]
        [DataType(DataType.Date)]
        public DateTime? UeDateExpires { get; set; }

        [DisplayName("Tình Trạng")]
        public string UeOk { get; set; }

        public string Color { get; set; }

    }

    public class UserEventListHomeViewModel
    {
        public int? UserID { get; set; }

        public string UserFullName { get; set; }

        public string UserPhone { get; set; }

        [DisplayName("Mã Tour / Mô Tả")]
        [StringLength(200)]
        public string UeNote { get; set; }

        [DisplayName("Đến Ngày")]
        [DataType(DataType.Date)]
        public DateTime? UeWillExpires { get; set; }

        [DisplayName("Từ Ngày")]
        [DataType(DataType.Date)]
        public DateTime? UeDateExpires { get; set; }

        public string Loai { get; set; }
        public string Color { get; set; }
    }

    public class UserEventAdminListViewModel
    {
        public int? UserID { get; set; }

        public int UeID { get; set; }

        public string UserFullName { get; set; }

        public string UserPhone { get; set; }

        [DisplayName("Mã Tour / Mô Tả")]
        [StringLength(200)]
        public string UeNote { get; set; }

        [DisplayName("Đến Ngày")]
        [DataType(DataType.Date)]
        public DateTime? UeWillExpires { get; set; }

        [DisplayName("Từ Ngày")]
        [DataType(DataType.Date)]
        public DateTime? UeDateExpires { get; set; }

        public bool? UeOk { get; set; }
        public string Loai { get; set; }
        public string Color { get; set; }

        public int? UeCount { get; set; }
    }
}
