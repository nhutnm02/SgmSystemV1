namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.tbl_UserRole")]
    public partial class tbl_UserRole
    {
        [Key]
        public int UrID { get; set; }

        public int? RoID { get; set; }

        public int? UserID { get; set; }
    }
}
