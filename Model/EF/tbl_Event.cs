namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("db_owner.tbl_Event")]
    public partial class tbl_Event
    {
        [Key]
        public long EventID { get; set; }

        [StringLength(200)]
        public string EventName { get; set; }

        [StringLength(200)]
        public string EventNote { get; set; }
    }
}
