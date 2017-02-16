namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.tbl_Role")]
    public partial class tbl_Role
    {
        [Key]
        public int RoID { get; set; }

        [StringLength(50)]
        public string RoName { get; set; }

        [StringLength(100)]
        public string RoDes { get; set; }
    }
}
