namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Attandance
    {
        [Key]
        public int AtID { get; set; }

        public int? UserID { get; set; }

        public int? AtInOrOut { get; set; }

        public DateTime? AtDateCheckIn { get; set; }

        public int? AtMonth { get; set; }

        public int? AtDay { get; set; }

        public int? AtYear { get; set; }

        public DateTime? AtTime { get; set; }

        [StringLength(200)]
        public string AtNote { get; set; }

        public int? UeID { get; set; }
    }
}
