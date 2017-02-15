using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class GroupViewModel
    {
        public int GroupID { get; set; }
        [StringLength(10)]
        public string GroupCode { get; set; }
        [StringLength(100)]
        public string GroupName { get; set; }
        [StringLength(200)]
        public string GroupDes { get; set; }

        public bool? GroupStatus { get; set; }
    }
}
