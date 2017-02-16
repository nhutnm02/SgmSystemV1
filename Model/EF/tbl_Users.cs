namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Users
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        public string UserPass { get; set; }

        [StringLength(200)]
        public string UserFullName { get; set; }

        [StringLength(200)]
        public string UserAddress { get; set; }

        [StringLength(50)]
        public string UserPhone { get; set; }

        [StringLength(50)]
        public string UserExtention { get; set; }

        [StringLength(50)]
        public string UserEmail { get; set; }

        public DateTime? UserDOB { get; set; }

        public DateTime? UserCreateDate { get; set; }

        [StringLength(50)]
        public string UserComputer { get; set; }

        public bool? UserStatus { get; set; }

        public int GroupID { get; set; }

        public DateTime? UserJoinDate { get; set; }
    }
}
