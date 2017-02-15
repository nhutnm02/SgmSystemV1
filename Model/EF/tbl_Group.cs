namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Group
    {
        [Key]
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
