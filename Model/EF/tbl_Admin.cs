namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.tbl_Admin")]
    public partial class tbl_Admin
    {
        [Key]
        public int AdminID { get; set; }

        [StringLength(50)]
        public string AdminName { get; set; }

        [StringLength(50)]
        public string AdminPass { get; set; }

        [StringLength(100)]
        public string AdminDes { get; set; }
    }
}
