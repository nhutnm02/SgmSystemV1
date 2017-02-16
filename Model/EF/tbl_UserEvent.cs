namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_UserEvent
    {
        [Key]
        public int UeID { get; set; }

        public int? EventID { get; set; }

        public int? UserID { get; set; }

        [StringLength(200)]
        public string UeNote { get; set; }

        public DateTime? UeCreateDate { get; set; }

        public DateTime? UeWillExpires { get; set; }

        public DateTime? UeDateExpires { get; set; }

        public int? UeCount { get; set; }

        public bool? UeLeaderOk { get; set; }

        public bool? UeOk { get; set; }
    }
}
