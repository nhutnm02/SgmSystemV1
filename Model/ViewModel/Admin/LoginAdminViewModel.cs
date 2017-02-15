using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel.Admin
{
    public class LoginAdminViewModel
    {
        public int AdminID { get; set; }

        [StringLength(50)]
        [DisplayName("Tài Khoản")]
        [Required(ErrorMessage = "Hãy nhập tài khoản!")]
        public string AdminName { get; set; }

        [StringLength(50)]
        [DisplayName("Mật Khẩu")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Hãy nhập tài khoản!")]
        public string AdminPass { get; set; }

        [StringLength(100)]
        public string AdminDes { get; set; }
    }
}
