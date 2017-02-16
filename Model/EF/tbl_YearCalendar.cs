namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.tbl_YearCalendar")]
    public partial class tbl_YearCalendar
    {
        [Key]
        [Column(TypeName = "date")]
        public DateTime CalDate { get; set; }
    }
}
